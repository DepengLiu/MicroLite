﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MicroLite.Logging {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LogMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MicroLite.Logging.LogMessages", typeof(LogMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type {0} has no property named &apos;Id&apos;, &apos;{0}Id&apos; or a property with an IdentifierAttribute specified..
        /// </summary>
        internal static string NoIdentifierFoundForType {
            get {
                return ResourceManager.GetString("NoIdentifierFoundForType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating a new instance of {0}.
        /// </summary>
        internal static string ObjectBuilder_CreatingInstance {
            get {
                return ResourceManager.GetString("ObjectBuilder_CreatingInstance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting the property value for {0}.{1}.
        /// </summary>
        internal static string ObjectBuilder_SettingPropertyValue {
            get {
                return ResourceManager.GetString("ObjectBuilder_SettingPropertyValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type {0} does not have a mapped property with the name {1}.
        /// </summary>
        internal static string ObjectBuilder_UnknownProperty {
            get {
                return ResourceManager.GetString("ObjectBuilder_UnknownProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating ObjectInfo for {0}.
        /// </summary>
        internal static string ObjectInfo_CreatingObjectInfo {
            get {
                return ResourceManager.GetString("ObjectInfo_CreatingObjectInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Retrieving ObjectInfo for {0}.
        /// </summary>
        internal static string ObjectInfo_RetrievingObjectInfo {
            get {
                return ResourceManager.GetString("ObjectInfo_RetrievingObjectInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session {0} closing database connection.
        /// </summary>
        internal static string Session_ClosingConnection {
            get {
                return ResourceManager.GetString("Session_ClosingConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session {0} created.
        /// </summary>
        internal static string Session_Created {
            get {
                return ResourceManager.GetString("Session_Created", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session {0} disposed.
        /// </summary>
        internal static string Session_Disposed {
            get {
                return ResourceManager.GetString("Session_Disposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session {0} opening database connection.
        /// </summary>
        internal static string Session_OpeningConnection {
            get {
                return ResourceManager.GetString("Session_OpeningConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} committing changes.
        /// </summary>
        internal static string Transaction_Committing {
            get {
                return ResourceManager.GetString("Transaction_Committing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} created.
        /// </summary>
        internal static string Transaction_Created {
            get {
                return ResourceManager.GetString("Transaction_Created", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} disposed.
        /// </summary>
        internal static string Transaction_Disposed {
            get {
                return ResourceManager.GetString("Transaction_Disposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} is being disposed with uncommitted changes.
        /// </summary>
        internal static string Transaction_DisposedUncommitted {
            get {
                return ResourceManager.GetString("Transaction_DisposedUncommitted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command enlisted in transaction {0}.
        /// </summary>
        internal static string Transaction_EnlistingCommand {
            get {
                return ResourceManager.GetString("Transaction_EnlistingCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} rolling back changes.
        /// </summary>
        internal static string Transaction_RollingBack {
            get {
                return ResourceManager.GetString("Transaction_RollingBack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type {0} is not a class and therefore cannot be used by the MicroLite ORM Framework.
        /// </summary>
        internal static string TypeMustBeClass {
            get {
                return ResourceManager.GetString("TypeMustBeClass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type {0} has no default (zero parameter) constructor and therefore cannot be used by the MicroLite ORM Framework.
        /// </summary>
        internal static string TypeMustHaveDefaultConstructor {
            get {
                return ResourceManager.GetString("TypeMustHaveDefaultConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type {0} is abstract and therefore cannot be used by the MicroLite ORM Framework.
        /// </summary>
        internal static string TypeMustNotBeAbstract {
            get {
                return ResourceManager.GetString("TypeMustNotBeAbstract", resourceCulture);
            }
        }
    }
}
