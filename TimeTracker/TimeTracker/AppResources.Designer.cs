﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracker {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TimeTracker.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you really want to clear all Data?.
        /// </summary>
        public static string AlertClearDB {
            get {
                return ResourceManager.GetString("AlertClearDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alert!.
        /// </summary>
        public static string AlertHeader {
            get {
                return ResourceManager.GetString("AlertHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time Tracker.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nope!.
        /// </summary>
        public static string Cancel {
            get {
                return ResourceManager.GetString("Cancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Database Cleaned!.
        /// </summary>
        public static string ClearDB {
            get {
                return ResourceManager.GetString("ClearDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops Somthing went wrong!.
        /// </summary>
        public static string GenericError {
            get {
                return ResourceManager.GetString("GenericError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Home Page.
        /// </summary>
        public static string HomeTitle {
            get {
                return ResourceManager.GetString("HomeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Okay.
        /// </summary>
        public static string Ok {
            get {
                return ResourceManager.GetString("Ok", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save Failed!.
        /// </summary>
        public static string SaveFail {
            get {
                return ResourceManager.GetString("SaveFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save Complete!.
        /// </summary>
        public static string SaveSuccess {
            get {
                return ResourceManager.GetString("SaveSuccess", resourceCulture);
            }
        }
    }
}
