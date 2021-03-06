﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Ccf.Ck.Models.Settings
{
    public class GeneralSettings
    {
        private Dictionary<string, string> _ModuleKey2Path;

        public GeneralSettings()
        {
            AuthorizationSection = new AuthorizationSection();
            SignalRSettings = new SignalRSettings();
            RazorAreaAssembly = new RazorAreaAssemblySettings();
            SupportedLanguages = new List<string>();
            RequestRecorder = new RequestRecorderSetting();
            Theme = "Module";
        }
        public bool EnableOptimization { get; set; }
        public List<string> ModulesRootFolders { get; set; }
        public string DefaultStartModule { get; set; }
        public string PassThroughJsConfig { get; set; }
        public string BindKraftConfiguration
        {
            get;
            private set;
        }
        public string Theme { get; set; }
        public string KraftUrlSegment { get; set; }
        public string KraftUrlCssJsSegment { get; set; }
        public string KraftUrlResourceSegment { get; set; }
        public string KraftUrlModuleImages { get; set; }
        public string KraftUrlModulePublic { get; set; }
        public string KraftRequestFlagsKey { get; set; }
        public AuthorizationSection AuthorizationSection { get; set; }
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool RedirectToHttps { get; set; }
        public bool RedirectToWww { get; set; }
        public SignalRSettings SignalRSettings { get; set; }
        public SignalSettings SignalSettings { get; set; }
        public List<HostingServiceSetting> HostingServiceSettings { get; set; }
        public RequestRecorderSetting RequestRecorder { get; set; }
        public ProgressiveWebAppSettings ProgressiveWebApp { get; set; }
        public RazorAreaAssemblySettings RazorAreaAssembly { get; set; }
        public List<string> SupportedLanguages { get; set; }

        public void ReplaceMacrosWithPaths(string contentRootPath, string wwwRootPath)
        {
            string path;
            for (int i = 0; i < ModulesRootFolders.Count; i++)
            {
                path = ModulesRootFolders[i].Replace("@wwwroot@", wwwRootPath).Replace("@contentroot@", contentRootPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    throw new Exception($"Configured path: {path} is not valid and doesn't exist!");
                }
                ModulesRootFolders[i] = directoryInfo.FullName;
            }
        }

        public IChangeToken BindKraftConfigurationGetReloadToken(IWebHostEnvironment webHostEnvironment)
        {
            if (PassThroughJsConfig != null)
            {
                FileInfo configFile = new FileInfo(Path.Combine(webHostEnvironment.ContentRootPath, PassThroughJsConfig));
                if (configFile.Exists)
                {
                    var blockComments = @"/\*(.*?)\*/";
                    var lineComments = @"//(.*?)\r?\n";
                    var strings = @"""((\\[^\n]|[^""\n])*)""";
                    var verbatimStrings = @"@(""[^""]*"")+";
                    BindKraftConfiguration = Regex.Replace(File.ReadAllText(configFile.FullName, Encoding.UTF8),
                    blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
                    me =>
                    {
                        if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                            return me.Value.StartsWith("//") ? Environment.NewLine : "";
                        // Keep the literal strings
                        return me.Value;
                    },
                    RegexOptions.Singleline);
                    //Restart application if file changes
                    return webHostEnvironment.ContentRootFileProvider.Watch(configFile.Name);
                }
            }
            else
            {
                BindKraftConfiguration = "{}";
            }
            return null;
        }

        public string ModulesRootFolder(string moduleKey)
        {
            return _ModuleKey2Path[moduleKey.ToLower()];
        }

        public Dictionary<string, string> ModuleKey2Path
        {
            set
            {
                _ModuleKey2Path = value;
            }
        }

        public bool EnableThemeChange { get; set; }
    }
}
