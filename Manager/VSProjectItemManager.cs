using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using EnvDTE80;

namespace Zippy.Chirp.Manager
{
    public class VSProjectItemManager : IDisposable
    {
        #region Members
        private DTE2 dte;
        private ProjectItem projectItem;
        private Dictionary<string, object> filesAdded;	// FullFileName / Content
        private List<string> filesCreated;
        private string fullFileNamePrefix;
        #endregion

        #region Constructors
        internal VSProjectItemManager(DTE2 dte, ProjectItem projectItem)
            : this(dte, projectItem, null)
        {
        }

        internal VSProjectItemManager(DTE2 dte, ProjectItem projectItem, string fileNamePrefix)
        {
            this.dte = dte;
            this.projectItem = projectItem;

            this.filesAdded = new Dictionary<string, object>();
            this.filesCreated = new List<string>();

            if (this.projectItem != null)
            {
                if (string.IsNullOrEmpty(fileNamePrefix))
                {
                    fileNamePrefix = this.GetFileNamePrefix(projectItem.Name);
                }

                if (projectItem.FileCount > 0)
                {
                    try
                    {
                        this.fullFileNamePrefix = Path.GetDirectoryName(projectItem.get_FileNames(0)) + @"\" + fileNamePrefix;
                    }
                    catch (System.ArgumentException)
                    {
                        //vs.Php raise exception
                    }

                }
            }
        }
        #endregion

        public void AddFile(string fileExtension, string content)
        {
            this.AddFileByFileName(this.fullFileNamePrefix + fileExtension, content);
        }

        public void AddFileByFileName(string fileName, string content)
        {
            this.Add(fileName, content);
        }

        public void AddFile(string fileExtension, byte[] content)
        {
            this.AddFileByFileName(this.fullFileNamePrefix + fileExtension, content);
        }

        public void AddFileByFileName(string fileName, byte[] content)
        {
            this.Add(fileName, content);
        }

        public void SaveFile(string filename, object content)
        {
            var exists = System.IO.File.Exists(filename);
            if (exists)
            {
                Utilities.MakeWritable(filename);
            }
            if (content is string || content == null)
            {
                System.IO.File.WriteAllText(filename, (string)content, System.Text.Encoding.UTF8);
            }
            else if (content is byte[])
            {
                System.IO.File.WriteAllBytes(filename, (byte[])content);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Process()
        {
            if (this.filesAdded.Count < 1)
            {
                return;
            }

            // Remove unused items
            if (this.projectItem != null && this.projectItem.ProjectItems != null)
            {
                foreach (ProjectItem item in this.projectItem.ProjectItems)
                {
                    try
                    {
                        if (!this.filesAdded.ContainsKey(item.get_FileNames(0)))
                        {
                            item.Delete();
                        }
                    }
                    catch (System.ArgumentException)
                    {
                       //vs.Php throw exception
                    }

                   
                }
            }

            // Create Files
            foreach (var file in this.filesAdded)
            {
                string fullFileName = file.Key;

                if (!File.Exists(fullFileName) || this.projectItem == null)
                {
                    // File doesnt exists
                    this.filesCreated.Add(fullFileName);
                    this.CheckoutFileIfRequired(fullFileName);
                    this.SaveFile(fullFileName, file.Value);
                }
                else
                {
                    // File exists - find out if it is added to the projectItem
                    if (this.projectItem.ProjectItems != null)
                    {
                        if (ContainsItem(this.projectItem.ProjectItems, fullFileName))
                        {
                            if (!this.CompareFile(fullFileName, file.Value))
                            {
                                // Content was different
                                this.CheckoutFileIfRequired(fullFileName);
                                this.SaveFile(fullFileName, file.Value);
                            }
                            else
                            {
                                // File is already added to the projectItem
                                this.filesCreated.Add(fullFileName);
                            }
                        }
                        else
                        {
                            // File exists but is not added to the projectItem
                            // For a security reason dont overwrite - instead let the user know
                            // MessageBox.Show("Was not able to create file: " + fullFileName + "\nA file with the same name already exists.");
                            TaskList.Instance.Add(this.projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Warning, fullFileName, 1, 1, "Was not able to create file: " + fullFileName + "\nA file with the same name already exists.");
                        }
                    }
                    else
                    {
                        // visual studio 2010 (web site projet)
                        for (short i = 0; i <= this.projectItem.FileCount; i++)
                        {
                            try
                            {
                                fullFileName = this.projectItem.FileNames[i];

                                // File is already added to the projectItem
                                this.filesCreated.Add(fullFileName);

                                if (!this.CompareFile(fullFileName, file.Value))
                                {
                                    // Content was different
                                    this.CheckoutFileIfRequired(fullFileName);
                                    this.SaveFile(file.Key, file.Value);
                                }
                                else
                                {
                                    /* File exists but is not added to the projectItem
                                     For a security reason dont overwrite - instead let the user know
                                     MessageBox.Show("Was not able to create file: " + fullFileName + "\nA file with the same name already exists.");*/
                                    TaskList.Instance.Add(this.projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Warning, fullFileName, 1, 1, "Was not able to create file: " + fullFileName + "\nA file with the same name already exists.");
                                }
                            }
                            catch (System.ArgumentException)
                            {
                               //Vs.Php throw error
                            }
                           
                        }
                    }
                }
            }

            // Add files created
            if (this.projectItem != null) 
            {
                AddItems(this.projectItem, this.filesCreated); 
            }

            // Clear
            this.Clear();
        }

        public void Clear()
        {
            this.filesAdded.Clear();
            this.filesCreated.Clear();
        }

        #region IDisposable Members
        public void Dispose()
        {
            this.Process();
            
            this.dte = null;
            this.projectItem = null;
            this.filesAdded = null;
            this.filesCreated = null;
            this.fullFileNamePrefix = null;
        }
        #endregion

        internal static bool ContainsItem(ProjectItems items, string fullFileNameOfItemContained)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (string.IsNullOrEmpty(fullFileNameOfItemContained))
            {
                throw new Exception("fullFileNameOfItemContained needs to contain a valid filename.");
            }

            foreach (ProjectItem item in items)
            {
                if (item.get_FileNames(0).Equals(fullFileNameOfItemContained))
                {
                    return true;
                }
            }

            // valid is same folder
            string curringItemDir = new FileInfo(((ProjectItem)items.Parent).get_FileNames(0)).DirectoryName;
            if (curringItemDir != new FileInfo(fullFileNameOfItemContained).DirectoryName)
            {
                return true;
            }

            return false;
        }

        internal static ProjectItem GetItemByFullFileName(ProjectItems items, string fullFileNameOfItemToGet)
        {
            return GetItemByFullFileName(items, fullFileNameOfItemToGet, false);
        }

        internal static ProjectItem GetItemByFullFileName(ProjectItems items, string fullFileNameOfItemToGet, bool ignoreCase)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (string.IsNullOrEmpty(fullFileNameOfItemToGet))
            {
                throw new Exception("fullFileNameOfItemToGet needs to contain a valid filename.");
            }

            StringComparison strComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            foreach (ProjectItem item in items)
            {
                if (item.get_FileNames(0).Equals(fullFileNameOfItemToGet, strComparison))
                {
                    return item;
                }
            }

            return null;
        }

        internal static void AddItem(ProjectItem projectItem, string fullFileNameToAdd)
        {
            if (projectItem == null)
            {
                throw new ArgumentNullException("projectItem");
            }

            if (string.IsNullOrEmpty(fullFileNameToAdd))
            {
                throw new Exception("fullFileNameToAdd needs to contain a valid filename.");
            }

            if (projectItem.ProjectItems != null)
            {
                string curringItemDir = projectItem.get_FileNames(0);
                curringItemDir = new FileInfo(curringItemDir).DirectoryName;
                if (curringItemDir == new FileInfo(fullFileNameToAdd).DirectoryName)
                {
                    projectItem.ProjectItems.AddFromFile(fullFileNameToAdd);
                }
            }
        }

        internal static void AddItems(ProjectItem projectItem, IEnumerable<string> filesToAdd)
        {
            if (projectItem == null)
            {
                throw new ArgumentNullException("projectItem");
            }

            if (filesToAdd == null)
            {
                throw new ArgumentNullException("filesToAdd");
            }

            foreach (string fullFileNameToAdd in filesToAdd)
            {
                AddItem(projectItem, fullFileNameToAdd);
            }
        }

        internal static void DeleteAllItems(ProjectItems projectItems)
        {
            if (projectItems == null)
            {
                throw new ArgumentNullException("projectItems");
            }

            foreach (ProjectItem item in projectItems)
            {
                item.Delete();
            }
        }

        internal static void DeleteItems(ProjectItems projectItems, IEnumerable<string> itemsToKeep)
        {
            if (projectItems == null)
            {
                throw new ArgumentNullException("projectItem");
            }

            if (itemsToKeep == null)
            {
                throw new ArgumentNullException("itemsToKeep");
            }

            foreach (ProjectItem item in projectItems)
            {
                if (!itemsToKeep.Contains(item.get_FileNames(0)))
                {
                    item.Delete();
                }
            }
        }

        protected virtual string GetFileNamePrefix(string fileName)
        {
            string prefix = Path.GetFileNameWithoutExtension(fileName);

            if (prefix==null || prefix.Length < 1)
            {
                throw new Exception("Cannot get filename prefix");
            }

            return prefix;
        }

        private void Add(string fileName, object content)
        {
            if (this.filesAdded.ContainsKey(fileName))
            {
                this.filesAdded.Remove(fileName);
            }

            this.filesAdded.Add(fileName, content);
        }

        private bool CompareFile(string fileName, object contents)
        {
            if (contents == null)
            {
                return false;
            }
            else if (contents is string)
            {
                return System.IO.File.ReadAllText(fileName) == (string)contents;
            }
            else if (contents is byte[])
            {
                return this.Equals(System.IO.File.ReadAllBytes(fileName), (byte[])contents);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private bool Equals(byte[] a, byte[] b)
        {
            if (a.LongLength != b.LongLength)
            {
                return false;
            }

            for (long i = 0, j = a.LongLength; i < j; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void CheckoutFileIfRequired(string fullFileName)
        {
            if (this.dte == null)
            {
                return;
            }

            var sc = this.dte.SourceControl;
            if (sc != null && sc.IsItemUnderSCC(fullFileName) && !sc.IsItemCheckedOut(fullFileName))
            {
                this.dte.SourceControl.CheckOutItem(fullFileName);
            }
        }
    }
}