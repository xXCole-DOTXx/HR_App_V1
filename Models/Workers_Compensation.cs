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
    
    public partial class Workers_Compensation
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Org_Number { get; set; }
        public string Division_District { get; set; }
        public int WC_TypeID { get; set; }
        public System.DateTime Injury_Date { get; set; }
        public Nullable<int> Claim_Number { get; set; }
        public string Injury_Type { get; set; }
        public string Body_Parts { get; set; }
        public string Job_Class { get; set; }
        public Nullable<System.DateTime> Tx_Date { get; set; }
        public Nullable<System.DateTime> EROI_Date { get; set; }
        public Nullable<int> Tx_EROI_LAG { get; set; }
        public int Claim_Ruling_TypeID { get; set; }
        public Nullable<System.DateTime> Claim_Ruling_Date { get; set; }
        public string TTD_ONSET_Date { get; set; }
        public Nullable<System.DateTime> Restricted_RTW { get; set; }
        public Nullable<System.DateTime> Full_Duty_RTW { get; set; }
        public string TTD_Award_Notice { get; set; }
        public string RTW_Notice { get; set; }
        public string Lost_Time { get; set; }
        public Nullable<int> Lost_Time_Year { get; set; }
        public Nullable<bool> MVA { get; set; }
        public Nullable<bool> H_EQ { get; set; }
        public Nullable<bool> Tree_Brush { get; set; }
        public Nullable<bool> CTS { get; set; }
        public Nullable<bool> HL { get; set; }
        public Nullable<bool> OP { get; set; }
        public Nullable<bool> OD_NOC { get; set; }
        public string Comments { get; set; }
    
        public virtual Claim_Ruling_Type Claim_Ruling_Type { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual WC_Type WC_Type { get; set; }
    }
}
