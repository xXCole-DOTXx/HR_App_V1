//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_App_V1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Injury_Leave
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Org_Number { get; set; }
        public string Division_District { get; set; }
        public int TTD_TypeID { get; set; }
        public System.DateTime Medical_Excuse_To { get; set; }
        public string Doctor { get; set; }
        public Nullable<System.DateTime> DR_Fax_1 { get; set; }
        public Nullable<System.DateTime> DR_Fax_2 { get; set; }
        public Nullable<System.DateTime> PT_Fax { get; set; }
        public int Claim_Number { get; set; }
        public System.DateTime Injury_Date { get; set; }
        public Nullable<System.DateTime> RTW_Date { get; set; }
        public string Comments { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TTD_Type TTD_Type { get; set; }
    }
}
