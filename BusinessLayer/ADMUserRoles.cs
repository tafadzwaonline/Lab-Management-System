//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADMUserRoles
    {
        public int UserRoleID { get; set; }
        public int FKUserID { get; set; }
        public int FKRoleID { get; set; }
    
        public virtual ADMRoles ADMRoles { get; set; }
        public virtual ADMUsers ADMUsers { get; set; }
    }
}
