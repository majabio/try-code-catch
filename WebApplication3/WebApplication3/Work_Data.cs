//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Work_Data
    {
        public int ID { get; set; }
        public System.DateTime Shift_Date_End { get; set; }
        public System.DateTime Shift_Time_End { get; set; }
    
        public virtual Worker Worker { get; set; }
    }
}
