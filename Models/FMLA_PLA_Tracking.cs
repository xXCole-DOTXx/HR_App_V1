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
    
    public partial class FMLA_PLA_Tracking
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Org_Number { get; set; }
        public string Division_District { get; set; }
        public string Address { get; set; }
        public int FMLA_Absence_Tracking_TypeID { get; set; }
        public int Beginning_Balance { get; set; }
        public System.DateTime Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Hours_Used { get; set; }
        public Nullable<int> Ending_Balance { get; set; }
        public Nullable<int> Exhausted { get; set; }
        public Nullable<int> FMLA_Leave_TypeID { get; set; }
        public string Comment { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual FMLA_Absence_Tracking_Type FMLA_Absence_Tracking_Type { get; set; }
        public virtual FMLA_Leave_Type FMLA_Leave_Type { get; set; }
    }
}
