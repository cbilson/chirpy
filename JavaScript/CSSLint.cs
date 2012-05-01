using System;
using System.Linq;
using Jurassic.Library;
using System.ComponentModel;
using System.Text;

namespace Zippy.Chirp.JavaScript {
    public class CSSLint : Environment {
        public class options
        {
            /// <summary>
            /// Don't use adjoining classes
            /// </summary>
            [Description("Don't use adjoining classes"), Category("Options")]
            public bool AdjoiningClasses { get; set; }

            /// <summary>
            /// Don't use @import
            /// </summary>
            [Description("Don't use @import"), Category("Options")]
            public bool Import { get; set; }

            /// <summary>
            /// Don't use IDs in selectors
            /// </summary>
            [Description("Don't use IDs in selectors"), Category("Options")]
            public bool Ids { get; set; }

            /// <summary>
            /// Remove empty rules
            /// </summary>
            [Description("Remove empty rules"), Category("Options")]
            public bool EmptyRules { get; set; }

            /// <summary>
            /// Use correct properties for a display
            /// </summary>
            [Description("Use correct properties for a display"), Category("Options")]
            public bool DisplayPropertyGrouping { get; set; }

            /// <summary>
            /// Don't use too many floats
            /// </summary>
            [Description("Don't use too many floats"), Category("Options")]
            public bool Floats { get; set; }

            /// <summary>
            /// Don't use too many web fonts
            /// </summary>
            [Description("Don't use too many web fonts"), Category("Options")]
            public bool FontFaces { get; set; }

            /// <summary>
            /// Don't use too may font-size declarations
            /// </summary>
            [Description("Don't use too may font-size declarations"), Category("Options")]
            public bool FontSizes { get; set; }

            /// <summary>
            /// Don't qualify headings
            /// </summary>
            [Description("Don't qualify headings"), Category("Options")]
            public bool QualifiedHeadings { get; set; }

            /// <summary>
            /// Heading styles should only be defined once
            /// </summary>
            [Description("Heading styles should only be defined once"), Category("Options")]
            public bool UniqueHeadings { get; set; }

            /// <summary>
            /// Zero values don't need units
            /// </summary>
            [Description("Zero values don't need units"), Category("Options")]
            public bool ZeroUnits { get; set; }

            /// <summary>
            /// Vendor prefixed properties should also have the standard
            /// </summary>
            [Description("Vendor prefixed properties should also have the standard"), Category("Options")]
            public bool VendorPrefix { get; set; }

            /// <summary>
            /// CSS gradients require all browser prefixes
            /// </summary>
            [Description("CSS gradients require all browser prefixes"), Category("Options")]
            public bool Gradients { get; set; }

            /// <summary>
            /// Avoid selectors that look like regular expressions
            /// </summary>
            [Description("Avoid selectors that look like regular expressions"), Category("Options")]
            public bool RegexSelectors { get; set; }

            /// <summary>
            /// Beware of broken box models
            /// </summary>
            [Description("Beware of broken box models"), Category("Options")]
            public bool BoxModel { get; set; }

            /// <summary>
            /// Don't use !important
            /// </summary>
            [Description("Don't use !important"), Category("Options")]
            public bool Important { get; set; }

            /// <summary>
            /// Include all compatible vendor prefixes
            /// </summary>
            [Description("Include all compatible vendor prefixes"), Category("Options")]
            public bool CompatibleVendorPrefixes { get; set; }

            /// <summary>
            /// Avoid duplicate properties
            /// </summary>
            [Description("Avoid duplicate properties"), Category("Options")]
            public bool DuplicateProperties { get; set; }
        }

        public class Message {
            public int col { get; set; }
            public string evidence { get; set; }
            public int line { get; set; }
            public string message { get; set; }
            public types type { get; set; }
            //public rule rule { get; set; }

            public enum types {
                error, info, warning
            }
        }

        public class result {
            public Message[] messages { get; set; }
        }

        private static T get<T>(Jurassic.Library.ObjectInstance dic, string name, T defaultValue) {
            var value = dic.GetPropertyValue(name);
            T ret = defaultValue;
            try {
                if (defaultValue is string) ret = (T)(object)Convert.ToString(value);
                else ret = (T)Convert.ChangeType(value, typeof(T));
            } catch { }
            return ret;
        }

        protected override void OnInit() {
            RunFile("csslint");
        }

        public result CSSLINT(string source, options options = null)
        {
            this["text"] = source;

            StringBuilder stringBuilder = new StringBuilder();
            if (options != null)
            {
                string OptionsVarName = "options";

                // https://github.com/stubbornella/csslint/issues/150
                stringBuilder.AppendLine("var " + OptionsVarName + " = {};");
                if (options != null)
                {
                    if (options.AdjoiningClasses)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['adjoining-classes']=true;");
                    }
                    if (options.EmptyRules)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['empty-rules']=true;");
                    }
                    if (options.DisplayPropertyGrouping)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['display-property-grouping']=true;");
                    }
                    if (options.Floats)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['floats']=true;");
                    }
                    if (options.FontFaces)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['font-faces']=true;");
                    }
                    if (options.FontSizes)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['font-sizes']=true;");
                    }
                    if (options.FontSizes)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['font-sizes']=true;");
                    }
                    if (options.Ids)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['ids']=true;");
                    }
                    if (options.QualifiedHeadings)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['qualified-headings']=true;");
                    }
                    if (options.UniqueHeadings)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['unique-headings']=true;");
                    }
                    if (options.ZeroUnits)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['zero-units']=true;");
                    }
                    if (options.VendorPrefix)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['vendor-prefix']=true;");
                    }
                    if (options.Gradients)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['gradients']=true;");
                    }
                    if (options.RegexSelectors)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['regex-selectors']=true;");
                    }
                    if (options.BoxModel)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['box-model']=true;");
                    }

                    if (options.Import)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['import']=true;");
                    }
                    if (options.Important)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['important']=true;");
                    }
                    if (options.CompatibleVendorPrefixes)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['compatible-vendor-prefixes']=true;");
                    }
                    if (options.DuplicateProperties)
                    {
                        stringBuilder.AppendLine(OptionsVarName + "['duplicate-properties']=true;");
                    }

                }

                this[OptionsVarName] = stringBuilder.ToString();
                stringBuilder.AppendLine("var result ; if (typeof CSSLint != \"undefined\") {result = CSSLint.verify(text, " + OptionsVarName + ");}");
            }
            else
            {
                stringBuilder.AppendLine("var result ;  if (typeof CSSLint  !=  \"undefined\") {result = CSSLint.verify(text);}");
            }
            Run(stringBuilder.ToString());

            try
            {
                var result = (ObjectInstance)this["result"];

                return new result
                {
                    messages = ((ArrayInstance)result.GetPropertyValue("messages"))
                       .ElementValues.OfType<ObjectInstance>().Select(x => new Message
                       {
                           col = get(x, "col", 0),
                           line = get(x, "line", 0),
                           evidence = get(x, "evidence", string.Empty),
                           message = get(x, "message", string.Empty),
                           type = (Message.types)System.Enum.Parse(typeof(Message.types), get(x, "type", string.Empty))
                       }).ToArray()
                };
            }
            catch (InvalidCastException eErrorCast)
            {

                //don't throw error (undefined result)
                return new result();
            }

        }
    }
}
