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
    
    public partial class FMLA_Leave_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FMLA_Leave_Type()
        {
            this.FMLA_PLA_Tracking = new HashSet<FMLA_PLA_Tracking>();
        }
    
        public int ID { get; set; }
        public string FMLA_Leave_Type1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FMLA_PLA_Tracking> FMLA_PLA_Tracking { get; set; }
    }
}
