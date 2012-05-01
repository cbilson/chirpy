using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.VisualStudio.CommandBars;
using Zippy.Chirp.Engines;
using Zippy.Chirp.Manager;

namespace Zippy.Chirp {
    /// <summary>
    /// The object for implementing an Add-in.
    /// </summary>
    /// <seealso cref="IDTExtensibility2"/>
    public class Chirp : IDTExtensibility2, IDTCommandTarget {
        internal DTE2 App;
        private const string POPUP_MENU_NAME_MINIFIER = "ChirpyPopupAddIn";
        private const string POPUP_MENU_CAPTION_MINIFIER = "Chirpy minifier file";
        private const string POPUP_MENU_NAME_JSHINT = "ChirpyPopupJsHintAddIn";
        private const string POPUP_MENU_CAPTION_JSHINT = "Chirpy JsHint";
        private const string POPUP_MENU_NAME_CSSLINT = "ChirpyPopupCssLintAddIn";
        private const string POPUP_MENU_CAPTION_CSSLINT = "Chirpy CssLint";
        private const string RegularCssFile = ".css";
        private const string RegularJsFile = ".js";
        private const string RegularCoffeeScriptFile = ".coffee";
        private const string RegularSassFile = ".sass";
        private const string RegularScssFile = ".scss";
        private const string RegularLessFile = ".less";
        private static string[] buildCommands = new[] { "Build.BuildSelection", "Build.BuildSolution", "ClassViewContextMenus.ClassViewProject.Build" };
        private Events2 events;
        private DocumentEvents eventsOnDocs;
        private ProjectItemsEvents eventsOnProjectItems;
        private SolutionEvents eventsOnSolution;
        private BuildEvents eventsOnBuild;
        private CommandEvents eventsOnCommand;
        private AddIn instance;
        private TaskList tasks;
        private OutputWindowPane lazyOutputWindowPane;
        private EngineManager engineManager;
        public const string COMMANDNAMESPACE = "Zippy.Chirp.Chirp";
        private bool dependenciesIndexed = false;

        internal EngineManager EngineManager {
            get {
                if (this.engineManager == null || this.engineManager.IsDisposed) {
                    this.LoadActions();
                }

                return this.engineManager;
            }
        }

        internal YuiJsEngine YuiJsEngine { get; set; }

        internal YuiCssEngine YuiCssEngine { get; set; }

        internal DeanEdwardsPackerEngine DeanEdwardsPackerEngine { get; set; } 

        internal ClosureCompilerEngine ClosureCompilerEngine { get; set; }

        internal MsCssEngine MsCssEngine { get; set; }

        internal MsJsEngine MsJsEngine { get; set; }

        internal LessEngine LessEngine { get; set; }

        internal ConfigEngine ConfigEngine { get; set; }

        internal T4Engine T4Engine { get; set; }

        internal ViewEngine ViewEngine { get; set; }

        internal CoffeeScriptEngine CoffeeScriptEngine { get; set; }

        internal UglifyEngine UglifyEngine { get; set; }

        internal JSHintEngine JSHintEngine { get; set; }

        internal CSSLintEngine CSSLintEngine { get; set; }

        internal SassEngine SassEngine { get; set; }

        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom) {
            try {
                Settings.Saved += this.SettingsSaved;
            }catch(Exception ex)
            {
                this.OutputWindowWriteText("Error in commandBars: " + ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            this.instance = addInInst as AddIn;
            this.App = application as DTE2;
            this.events = this.App.Events as Events2;

            try {
                // http://code.google.com/p/explorer-popup-add-in/source/browse/#svn%2Ftrunk%2FExPopupAddIn
                Command cmdMinifier = CommandHelper.AddCommand(this.App, this.instance, POPUP_MENU_NAME_MINIFIER, 1, POPUP_MENU_CAPTION_MINIFIER, "Mashes, minifies, and validates your javascript, stylesheet, and dotless files.", string.Empty);
                Command cmdJsHint = CommandHelper.AddCommand(this.App, this.instance, POPUP_MENU_NAME_JSHINT, 1, POPUP_MENU_CAPTION_JSHINT, "Validates your javascript", string.Empty);
                Command cmdCssLint = CommandHelper.AddCommand(this.App, this.instance, POPUP_MENU_NAME_CSSLINT, 1, POPUP_MENU_CAPTION_CSSLINT, "Validates your stylesheet", string.Empty);
                CommandBars cmdBars = (CommandBars)this.App.CommandBars;
                var barsNames = new List<string>();
                // http://msdn.microsoft.com/en-us/library/ff697228.aspx
                barsNames.AddRange(new[] { "Item", "Web Item" });


                if (cmdJsHint != null) {
                    foreach (string item in barsNames) {
                        if (cmdBars[item] != null) {
                            cmdJsHint.AddControl(cmdBars[item], 1);
                        }
                    }
                }
                if (cmdCssLint != null) {
                    foreach (string item in barsNames) {
                        if (cmdBars[item] != null) {
                            cmdCssLint.AddControl(cmdBars[item], 1);
                        }
                    }
                }

                if (cmdMinifier != null) {
                    foreach (string item in barsNames) {
                        if (cmdBars[item] != null) {
                            cmdMinifier.AddControl(cmdBars[item], 1);
                        }
                    }
                }
            } catch (Exception ex) {
                this.OutputWindowWriteText("Error in commandBars: " + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void SettingsSaved()
        {
            LoadActions();
        }

        public void LoadActions() {
            if (this.engineManager == null || this.engineManager.IsDisposed) {
                this.engineManager = new EngineManager(this);
            }

            this.engineManager.Clear();
            this.engineManager.Add(YuiCssEngine = new YuiCssEngine());
            this.engineManager.Add(YuiJsEngine = new YuiJsEngine());
            this.engineManager.Add(DeanEdwardsPackerEngine = new DeanEdwardsPackerEngine());
            this.engineManager.Add(ClosureCompilerEngine = new ClosureCompilerEngine());
            this.engineManager.Add(LessEngine = new LessEngine());
            this.engineManager.Add(MsJsEngine = new MsJsEngine());
            this.engineManager.Add(MsCssEngine = new MsCssEngine());
            this.engineManager.Add(ConfigEngine = new ConfigEngine());
            this.engineManager.Add(ViewEngine = new ViewEngine());
            this.engineManager.Add(T4Engine = new T4Engine());
            this.engineManager.Add(CoffeeScriptEngine = new CoffeeScriptEngine());
            this.engineManager.Add(UglifyEngine = new UglifyEngine());
            this.engineManager.Add(JSHintEngine = new JSHintEngine());
            this.engineManager.Add(CSSLintEngine = new CSSLintEngine());
            this.engineManager.Add(SassEngine = new SassEngine());
        }

        /// <summary>
        /// Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.
        /// </summary>
        /// <param name="disconnectMode">Describes how the Add-in is being unloaded.</param>
        /// <param name="custom">Array of parameters that are host application specific.</param>
        /// <seealso cref="IDTExtensibility2"/>
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom) {
            EngineManager.Dispose();

            if (disconnectMode == ext_DisconnectMode.ext_dm_UserClosed) {
                // Delete the Commands
                CommandHelper.RemoveCommand(this.App, COMMANDNAMESPACE + "." + POPUP_MENU_NAME_MINIFIER);
                CommandHelper.RemoveCommand(this.App, COMMANDNAMESPACE + "." + POPUP_MENU_NAME_JSHINT);
                CommandHelper.RemoveCommand(this.App, COMMANDNAMESPACE + "." + POPUP_MENU_NAME_CSSLINT);

                // Remove the controls from the CommandBars
                CommandHelper.RemoveCommandControl(this.App, "Item", POPUP_MENU_NAME_MINIFIER);
                CommandHelper.RemoveCommandControl(this.App, "Item", POPUP_MENU_NAME_JSHINT);
                CommandHelper.RemoveCommandControl(this.App, "Item", POPUP_MENU_NAME_CSSLINT);
            }
        }

        /// <summary>
        /// Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.
        /// </summary>
        /// <param name="custom">Array of parameters that are host application specific.</param>
        /// <seealso cref="IDTExtensibility2"/>
        public void OnStartupComplete(ref Array custom) {
            this.eventsOnDocs = this.events.get_DocumentEvents();
            this.eventsOnProjectItems = this.events.ProjectItemsEvents;
            this.eventsOnSolution = this.events.SolutionEvents;
            this.eventsOnBuild = this.events.BuildEvents;
            this.eventsOnCommand = this.events.CommandEvents;

            this.eventsOnCommand.BeforeExecute += new _dispCommandEvents_BeforeExecuteEventHandler(this.CommandEvents_BeforeExecute);
            this.eventsOnSolution.Opened += new _dispSolutionEvents_OpenedEventHandler(eventsOnSolution_Opened);
            this.eventsOnSolution.ProjectRemoved += new _dispSolutionEvents_ProjectRemovedEventHandler(this.SolutionEvents_ProjectRemoved);
            this.eventsOnSolution.AfterClosing += new _dispSolutionEvents_AfterClosingEventHandler(this.EventsOnSolution_AfterClosing);
            this.eventsOnProjectItems.ItemRenamed += new _dispProjectItemsEvents_ItemRenamedEventHandler(this.ProjectItemsEvents_ItemRenamed);
            this.eventsOnProjectItems.ItemAdded += new _dispProjectItemsEvents_ItemAddedEventHandler(this.ProjectItemsEvents_ItemAdded);
            this.eventsOnProjectItems.ItemRemoved += new _dispProjectItemsEvents_ItemRemovedEventHandler(this.ProjectItemsEvents_ItemRemoved);
            this.eventsOnDocs.DocumentSaved += new _dispDocumentEvents_DocumentSavedEventHandler(this.DocumentEvents_DocumentSaved);

            this.tasks = new TaskList(this.App);

             try {
                this.LoadActions();
             }
             catch (Exception ex)
             {
                 this.OutputWindowWriteText("Error in load action: " + ex.ToString());
             }

            try {
                if (Settings.Instance().LessSyntaxHighlighting)
                {
                    this.TreatLessAsCss(true);
                }
            } catch (Exception ex) {
                this.OutputWindowWriteText("Error in TreatLessAsCss: " + ex.ToString());
            }

            // ensures the output window is lazy loaded so the multiple threads don't compete for and end up creating several
            if (Settings.Instance().ShowDetailLog)
            {
                this.OutputWindowWriteText("Ready");
            }
        }

        void eventsOnSolution_Opened() {
          dependenciesIndexed = false;
        }

        #region Unused IDTExtensibility2 methods

        /// <summary>
        /// Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.
        /// </summary>
        /// <param name="custom">Array of parameters that are host application specific.</param>
        /// <seealso cref="IDTExtensibility2"/>
        public void OnAddInsUpdate(ref Array custom) {
        }

        /// <summary>
        /// Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.
        /// </summary>
        /// <param name="custom">Array of parameters that are host application specific.</param>
        /// <seealso cref="IDTExtensibility2"/>
        public void OnBeginShutdown(ref Array custom) {
        }
        #endregion

        public IEnumerable<string> FindCommandBarName(DTE2 app, string menuItemName) {
            foreach (CommandBar commandBar in (CommandBars)app.CommandBars) {
                foreach (CommandBarControl control in commandBar.Controls) {
                    if (control.Caption.Contains(menuItemName)) {
                        yield return commandBar.Name;
                    }
                }
            }
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param name='commandName'>The name of the command to determine state for.</param>
        /// <param name='neededText'>Text that is needed for the command.</param>
        /// <param name='status'>The state of the command in the user interface.</param>
        /// <param name='commandText'>Text requested by the neededText parameter.</param>
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText) {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone) {
                if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_MINIFIER) {
                    status = vsCommandStatus.vsCommandStatusInvisible;
                    ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                    if (EngineManager.IsHandledWithoutHint(projectItem.FileName())) {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    } else {

                        string path = projectItem.FileName();
                        if (this.IsLessFile(path) || this.IsCoffeeScriptFile(path) || this.IsCssFile(path) || this.IsJsFile(path)) {
                            status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                        }
                    }
                }
            }
            if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_JSHINT) {
                status = vsCommandStatus.vsCommandStatusInvisible;
                ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                string path = projectItem.FileName();
                if (this.IsJsFile(path)) {
                    status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                }
            }
            if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_CSSLINT) {
                status = vsCommandStatus.vsCommandStatusInvisible;
                ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                string path = projectItem.FileName();
                if (this.IsCssFile(path)) {
                    status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                }
            }
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param name='commandName'>The name of the command to execute.</param>
        /// <param name='executeOption'>Describes how the command should be run.</param>
        /// <param name='varIn'>Parameters passed from the caller to the command handler.</param>
        /// <param name='varOut'>Parameters passed from the command handler to the caller.</param>
        /// <param name='handled'>Informs the caller if the command was handled or not.</param>
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled) {
            handled = false;

            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault) {
                if (this.App != null) {
                    string fileToTry = string.Empty;

                    try {
                        if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_MINIFIER) {
                            try {
                                ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                                if (EngineManager.IsHandledWithoutHint(projectItem.FileName()))
                                {
                                    this.ProjectItemsEvents_ItemAdded(projectItem);
                                }
                                else
                                {
                                    string path = projectItem.FileName();
                                    string code = System.IO.File.ReadAllText(path);
                                    var settings = Settings.Instance(path);
                                    string outputExtension = settings.OutputExtensionJS;
                                    if (this.IsLessFile(path))
                                    {
                                        code = LessEngine.TransformToCss(path, code, projectItem);
                                        outputExtension = settings.OutputExtensionCSS;
                                    }
                                    else if (this.IsCoffeeScriptFile(path))
                                    {
                                        code = CoffeeScriptEngine.TransformToJs(path, code, projectItem);
                                        outputExtension = settings.OutputExtensionJS;
                                    }
                                    else if (this.IsSassFile(path))
                                    {
                                        code = SassEngine.TransformToCss(path, code, projectItem);
                                        outputExtension = settings.OutputExtensionCSS;
                                    }
                                    else if (this.IsCssFile(path))
                                    {
                                        code = CssEngine.Minify(path, code, projectItem, Xml.MinifyType.Unspecified);
                                        outputExtension = settings.OutputExtensionCSS;
                                    }
                                    else if (this.IsJsFile(path))
                                    {
                                        code = JsEngine.Minify(path, code, projectItem, Xml.MinifyType.Unspecified, string.Empty);
                                        outputExtension = settings.OutputExtensionJS;
                                    }
                                    using (var manager = new Manager.VSProjectItemManager(this.App, projectItem))
                                    {
                                        manager.AddFileByFileName(Utilities.GetBaseFileName(path) + outputExtension, code);
                                    }
                                }
                            } catch (Exception e) {
                                this.OutputWindowWriteText(e.ToString());
                            }
                        } else if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_JSHINT) {
                            try {
                                ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                                string path = projectItem.FileName();
                                JSHintEngine.Run(path, projectItem);
                            } catch (Exception e) {
                                this.OutputWindowWriteText(e.ToString());
                            }
                        } else if (commandName == COMMANDNAMESPACE + "." + POPUP_MENU_NAME_CSSLINT) {
                            try {
                                ProjectItem projectItem = this.App.SelectedItems.Item(1).ProjectItem;
                                string path = projectItem.FileName();
                                CSSLintEngine.Run(path, projectItem);
                            } catch (Exception e) {
                                this.OutputWindowWriteText(e.ToString());
                            }
                        }
                    } catch (Exception ex) {
                        this.OutputWindowWriteText(string.Format("Error occured.\r\nFileName:\r\n{0}\r\nException details:\r\n{1}", fileToTry, ex));
                    } // try

                    handled = true;

                    return;
                }
            }
        } // Exec

        private void EventsOnSolution_AfterClosing() {
            if (this.tasks != null) {
                this.tasks.RemoveAll();
            }
        }

        private void SolutionEvents_ProjectRemoved(Project project) {
            this.tasks.Remove(project);
        }

        #region Event Handlers
        private void CommandEvents_BeforeExecute(string guid, int id, object customIn, object customOut, ref bool cancelDefault) {
            EnvDTE.Command objCommand = default(EnvDTE.Command);
            string commandName = null;

            try {
                objCommand = this.App.Commands.Item(guid, id);
            } catch (System.ArgumentException) {
            }

            if (objCommand != null) {
                commandName = objCommand.Name;

                var settings = new Settings();
                if (settings.T4RunAsBuild) {
                    if (buildCommands.Contains(commandName)) {
                        if (this.tasks != null) {
                            this.tasks.RemoveAll();
                        }

                        Engines.T4Engine.RunT4Template(this.App, settings.T4RunAsBuildTemplate);
                    }
                }
            }
        }

        private void IndexDependencies() {
            try {
                foreach (Project project in this.App.Solution.Projects) {
                    var projectItems = project.ProjectItems.ProcessFolderProjectItemsRecursively();
                    if (projectItems != null) {
                        var configs = projectItems
                            .Where(x => ConfigEngine.Handles(x.Name) > 0 || LessEngine.Handles(x.Name) > 0);

                        foreach (ProjectItem config in configs) {
                            ConfigEngine.ReloadFileDependencies(config);
                        }
                    }
                }
            } catch (Exception e) {
                this.OutputWindowWriteText(e.ToString());
            }
        }

        private void ProjectItemsEvents_ItemAdded(ProjectItem projectItem) {
            if (!dependenciesIndexed) {
                IndexDependencies();
                dependenciesIndexed = true;
            }

            try {
                EngineManager.Enqueue(projectItem);
            } catch (Exception e) {
                this.OutputWindowWriteText(e.ToString());
            }
        }

        private void ProjectItemsEvents_ItemRenamed(ProjectItem projectItem, string oldFileName) {
            if (EngineManager.IsTransformed(projectItem.FileName()))
            {
                // Now a chirp file
                this.ProjectItemsEvents_ItemAdded(projectItem);
            } else if (EngineManager.IsTransformed(oldFileName)) {
                try {
                    VSProjectItemManager.DeleteAllItems(projectItem.ProjectItems);
                    this.tasks.Remove(oldFileName);
                } catch (Exception e) {
                    this.OutputWindowWriteText("Exception was thrown when trying to rename file.\n" + e.ToString());
                }
            }
        }

        private void ProjectItemsEvents_ItemRemoved(ProjectItem projectItem) {
            string fileName = projectItem.FileName();
            this.tasks.Remove(fileName);

            if (T4Engine.Handles(fileName) > 0) {
                this.T4Engine.Run(fileName, projectItem);
            }
        }

        private void DocumentEvents_DocumentSaved(Document document) {
            try {
                ProjectItem item = document.ProjectItem;
                this.ProjectItemsEvents_ItemAdded(item);
            } catch (Exception e) {
                this.OutputWindowWriteText(e.ToString());
            }
        }

        #endregion

        private bool IsLessFile(string fileName) {
            return fileName.EndsWith(RegularLessFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsCoffeeScriptFile(string fileName) {
            return fileName.EndsWith(RegularCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsCssFile(string fileName) {
            return fileName.EndsWith(RegularCssFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsJsFile(string fileName) {
            return fileName.EndsWith(RegularJsFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsSassFile(string fileName)
        {
            return (fileName.EndsWith(RegularSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(RegularScssFile, StringComparison.OrdinalIgnoreCase));
        }
        

        #region Less

        public void TreatLessAsCss(bool force) {
            try {
                string extGuid = "{A764E898-518D-11d2-9A89-00C04F79EFC3}";
                string extPath = @"Software\Microsoft\VisualStudio\10.0_Config\Languages\File Extensions\.less";
                string editorGuid = "{A764E89A-518D-11d2-9A89-00C04F79EFC3}";
                string editorPath = string.Format(@"Software\Microsoft\VisualStudio\10.0_Config\Editors\{0}\Extensions", editorGuid);
                var user = Microsoft.Win32.Registry.CurrentUser;

                using (var extKey = user.OpenSubKey(extPath, true) ?? user.CreateSubKey(extPath))
                using (var editorKey = user.OpenSubKey(editorPath, true) ?? user.CreateSubKey(editorPath)) {
                    if (force || string.IsNullOrEmpty(extKey.GetValue(string.Empty) as string) || (editorKey.GetValue("less", 0) as int? ?? 0) == 0) {
                        extKey.SetValue(string.Empty, extGuid);
                        editorKey.SetValue("less", 0x28, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                }
            } catch (Exception e) {
                this.OutputWindowWriteText(e.ToString());
            }
        }
        #endregion

        #region "output login"
        public OutputWindowPane OutputWindowPane {
            get {
                if (this.lazyOutputWindowPane == null) {
                    this.lazyOutputWindowPane = this.GetOutputWindowPane("Chirpy");
                }

                return this.lazyOutputWindowPane;
            }
        }

        private OutputWindowPane GetOutputWindowPane(string name) {
            OutputWindow ow = this.App.ToolWindows.OutputWindow;
            OutputWindowPane owP;

            owP = ow.OutputWindowPanes.Cast<OutputWindowPane>().FirstOrDefault(x => x.Name == name);
            if (owP == null) {
                owP = ow.OutputWindowPanes.Add(name);
            }

            owP.Activate();
            return owP;
        }

        private void OutputWindowWriteText(string messageText) {
            try {
                this.OutputWindowPane.OutputString(messageText + System.Environment.NewLine);
            } catch (Exception errorThrow) {
                MessageBox.Show(errorThrow.ToString());
            }
        }
        #endregion
    }
}