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
    
    public partial class Employees
    {
        public int ID { get; set; }
        public string Employment { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Priority Priority1 { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
