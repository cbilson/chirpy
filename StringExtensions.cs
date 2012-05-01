using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Zippy.Chirp
{
    public static class StringExtensions
    {
        private static Dictionary<Type, Dictionary<string, IConvertible>> enums = new Dictionary<Type, Dictionary<string, IConvertible>>();

        public static Uri ToUri(this string input, Uri @base = null) {
            Uri result;
            if (@base != null) {
                if (Uri.TryCreate(@base, input, out result)) {
                    return result;
                }
            } else if (Uri.TryCreate(input, UriKind.Absolute, out result)) {
                return result;
            }
            return null;
        }

        public static bool Is(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase);
        }

        public static int ToInt(this string input, int defaultValue)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        public static bool ToBool(this string input, bool defaultValue)
        {
            return input.TryToBool() ?? defaultValue;
        }

        public static bool? TryToBool(this string input)
        {
            bool result;
            return bool.TryParse(input, out result) ? result : (bool?)null;
        }

        public static bool Contains(this string input, string other, StringComparison comparison)
        {
            return (input ?? string.Empty).IndexOf(other, comparison) > -1;
        }

        public static T ToEnum<T>(this string input) where T : struct, IConvertible
        {
            return ToEnum<T>(input, default(T));
        }

        public static T ToEnum<T>(this string input, T defaultValue) where T : struct, IConvertible
        {
            input = input ?? string.Empty;

            Dictionary<string, IConvertible> enums = null;
            if (!StringExtensions.enums.TryGetValue(typeof(T), out enums))
            {
                lock (StringExtensions.enums)
                {
                    var temp = ((T[])System.Enum.GetValues(typeof(T))).ToDictionary(x => Convert.ToString(x), x => (IConvertible)x, StringComparer.OrdinalIgnoreCase);
                    string desc;
                    foreach (var e in temp.Values.ToArray())
                    {
                        desc = Utilities.Description((Enum)e);
                        if (!desc.Is(Convert.ToString(e)))
                        {
                            temp.Add(desc, e);
                        }
                    }

                    enums = temp;

                    if (!StringExtensions.enums.ContainsKey(typeof(T)))
                    {
                        StringExtensions.enums.Add(typeof(T), temp);
                    }
                }
            }

            IConvertible value = null;
            if (!enums.TryGetValue(input, out value))
            {
                return defaultValue;
            }
            else
            {
                return (T)value;
            }
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return String.IsNullOrEmpty(s);
        }

        public static string F(this string format, object source)
        {
            return F(format, null, source);
        }

        public static string F(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            Regex r = new Regex(@"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            List<object> values = new List<object>();
            string rewrittenFormat = r.Replace(format, delegate(Match m)
            {
                Group startGroup = m.Groups["start"];
                Group propertyGroup = m.Groups["property"];
                Group formatGroup = m.Groups["format"];
                Group endGroup = m.Groups["end"];

                values.Add((propertyGroup.Value == "0")
                  ? source
                  : DataBinder.Eval(source, propertyGroup.Value));

                return new string('{', startGroup.Captures.Count) + (values.Count - 1) + formatGroup.Value
                  + new string('}', endGroup.Captures.Count);
            });

            return string.Format(provider, rewrittenFormat, values.ToArray());
        }
    }
}
