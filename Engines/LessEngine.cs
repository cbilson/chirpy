using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Zippy.Chirp.Xml;

namespace Zippy.Chirp.Engines {
  public class LessEngine : TransformEngine {
    private static Regex regexLineNum = new Regex(@"line\s+([0-9]+)", RegexOptions.Compiled);
    private static Regex regexColNum = new Regex(@"\s+(\-*)\^", RegexOptions.Compiled);
    private static dotless.Core.Parser.Parser lazyLessParser;

    #region "constructor"
    public LessEngine() {
      Extensions = new[] { this.Settings.ChirpLessFile, this.Settings.ChirpMichaelAshLessFile, this.Settings.ChirpHybridLessFile, this.Settings.ChirpMSAjaxLessFile };
      OutputExtension = ".css";
    }
    #endregion

    public static dotless.Core.Parser.Parser LessParser {
      get {
        if (lazyLessParser == null) {
          lazyLessParser = new dotless.Core.Parser.Parser();
        }

        return lazyLessParser;
      }
    }

    private static Regex rxImports = new Regex(@"(?<=^|;)\s*\@import\s+(?:
                (?:url\s*\(\s*'(?<ref>[^']+)'\s*\))
              | (?:url\s*\(\s*""(?<ref>[^""]+)""\s*\))
              | (?:url\s*\(\s*(?<ref>[^)]+)\s*\))
              | (?:'(?<ref>[^']+)')
              | (?:""(?<ref>[^""]+)"")
            )", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

    public static Uri[] FindDependencies(string url, string code, string root = null) {
      var matches = rxImports.Matches(code);
      var uri = url.ToUri();
      var result = new List<Uri>();
      if (!root.IsNullOrEmpty() && !root.EndsWith("\\")) {
        root += "\\";
      }

      foreach (Match match in matches) {
        var value = match.Groups["ref"].Value;
        if (!value.Contains("://")) {
          if (value.StartsWith("/") && !root.IsNullOrEmpty()) {
            value = value.Replace("/", "\\").TrimStart('\\');
            value = System.IO.Path.Combine(root, value);
          }
          value = value.Replace("/", "\\").TrimStart('\\');
          value = value.Replace("/", "\\");

          if (!value.EndsWith(".less", StringComparison.InvariantCultureIgnoreCase) && !value.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase)) {
            value += ".less";
          }
        }

        var import = value.ToUri(uri);

        if (import != null) {
          result.Add(import);
        }
      }
      return result.ToArray();
    }

    public static string TransformToCss(string fullFileName, string text, EnvDTE.ProjectItem projectItem) {
      string css = null;
      Settings settings = Settings.Instance(fullFileName);

      lock (LessParser)
        using (new EnvironmentDirectory(fullFileName)) {
          try {
            // The built in static method doesn't throw error messages
              dotless.Core.Parser.Infrastructure.Env env=new dotless.Core.Parser.Infrastructure.Env();
              env.Compress = settings.DotLessCompress;
              css = LessParser.Parse(text, fullFileName).ToCSS(env);
          } catch (Exception e) {
            int line = 1, column = 1;
            var description = e.Message.Trim();
            Match match;
            if ((match = regexLineNum.Match(description)).Success) {
              line = match.Groups[1].Value.ToInt(1);
            }

            if ((match = regexColNum.Match(description)).Success) {
              column = match.Groups[1].Length + 1;
            }

            if (TaskList.Instance == null) {
              Console.WriteLine(string.Format("{0}({1},{2}){3}", fullFileName, line.ToString(), column.ToString(), description));
            } else {
              TaskList.Instance.Add(projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Error, fullFileName, line, column, description);
            }
          }
        }

      return css;
    }

    public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem) {
      string css = TransformToCss(fullFileName, text, projectItem);

      if (projectItem != null && this.Chirp != null) {
        this.Chirp.ConfigEngine.ReloadFileDependencies(projectItem);
      }
      return css;
    }

    public override int Handles(string fullFileName) {
      this.Settings = Settings.Instance(fullFileName);
      var match = Extensions.Where(x => fullFileName.EndsWith(x, StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault() ?? string.Empty;
      return match.Length;
    }

    public override void Process(Manager.VSProjectItemManager manager, string fullFileName, EnvDTE.ProjectItem projectItem, string baseFileName, string outputText) {
      base.Process(manager, fullFileName, projectItem, baseFileName, outputText);

      var mode = this.GetMinifyType(fullFileName);
      string mini = CssEngine.Minify(fullFileName, outputText, projectItem, mode);
      manager.AddFileByFileName(baseFileName + this.Settings.OutputExtensionCSS, mini);
    }

    public MinifyType GetMinifyType(string fullFileName) {
      this.Settings = Settings.Instance(fullFileName);
      MinifyType mode = MinifyType.yui;
      if (this.IsChirpMichaelAshLessFile(fullFileName) || this.IsChirpHybridLessFile(fullFileName) || this.IsChirpLessFile(fullFileName)) {
        mode = this.IsChirpMichaelAshLessFile(fullFileName) ? MinifyType.yuiMARE
       : this.IsChirpHybridLessFile(fullFileName) ? MinifyType.yuiHybrid
       : MinifyType.yui;
      }

      if (this.IsChirpMSAjaxLessFile(fullFileName)) {
        mode = MinifyType.msAjax;
      }

      return mode;
    }

    private bool IsChirpLessFile(string fileName) {
      return fileName.EndsWith(this.Settings.ChirpLessFile, StringComparison.OrdinalIgnoreCase);
    }

    private bool IsChirpHybridLessFile(string fileName) {
      return fileName.EndsWith(this.Settings.ChirpHybridLessFile, StringComparison.OrdinalIgnoreCase);
    }

    private bool IsChirpMichaelAshLessFile(string fileName) {
      return fileName.EndsWith(this.Settings.ChirpMichaelAshLessFile, StringComparison.OrdinalIgnoreCase);
    }

    private bool IsChirpMSAjaxLessFile(string fileName) {
      return fileName.EndsWith(this.Settings.ChirpMSAjaxLessFile, StringComparison.OrdinalIgnoreCase);
    }
  }
}
