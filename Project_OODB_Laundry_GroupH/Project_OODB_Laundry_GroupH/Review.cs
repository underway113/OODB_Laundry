//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_OODB_Laundry_GroupH
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public string ReviewID { get; set; }
        public string Review1 { get; set; }
        public string ProductID { get; set; }
        public string UserID { get; set; }
    
        public virtual PriceList PriceList { get; set; }
        public virtual Users Users { get; set; }
    }
}
