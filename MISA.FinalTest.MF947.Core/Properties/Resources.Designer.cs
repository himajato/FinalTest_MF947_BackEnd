﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.FinalTest.MF947.Core.Properties {
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
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.FinalTest.MF947.Core.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Mã thực thể không được để trống, vui lòng nhập lại.
        /// </summary>
        public static string MISABadrequest_400_Code_Empty {
            get {
                return ResourceManager.GetString("MISABadrequest_400_Code_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã thực thể đã tồn tại, vui lòng nhập lại.
        /// </summary>
        public static string MISABadrequest_400_CodeDuplicate {
            get {
                return ResourceManager.GetString("MISABadrequest_400_CodeDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email không đúng định dạng, vui lòng nhập lại.
        /// </summary>
        public static string MISABadrequest_400_Email {
            get {
                return ResourceManager.GetString("MISABadrequest_400_Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MISAError-001.
        /// </summary>
        public static string MISAErroCode {
            get {
                return ResourceManager.GetString("MISAErroCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Google.com.
        /// </summary>
        public static string MISAErroMoreInfor {
            get {
                return ResourceManager.GetString("MISAErroMoreInfor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có  lỗi xảy ra từ server, vui lòng liên hệ MISA !.
        /// </summary>
        public static string MISAException_Error {
            get {
                return ResourceManager.GetString("MISAException_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không có dữ liệu nào tồn tại !.
        /// </summary>
        public static string MISANoContent_204 {
            get {
                return ResourceManager.GetString("MISANoContent_204", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu này không được phép để trống.
        /// </summary>
        public static string MISARequireFieldEmpty {
            get {
                return ResourceManager.GetString("MISARequireFieldEmpty", resourceCulture);
            }
        }
    }
}
