﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActiveDirectoryTools {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class DefaultSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static DefaultSettings defaultInstance = ((DefaultSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DefaultSettings())));
        
        public static DefaultSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("APEX.Local")]
        public string domain {
            get {
                return ((string)(this["domain"]));
            }
            set {
                this["domain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Apex")]
        public string primaryOu {
            get {
                return ((string)(this["primaryOu"]));
            }
            set {
                this["primaryOu"] = value;
            }
        }
    }
}
