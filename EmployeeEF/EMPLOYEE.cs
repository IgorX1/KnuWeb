//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        public int ID { get; set; }
        public Nullable<byte> RATING { get; set; }
        public string NAME_E { get; set; }
        public Nullable<int> EMAIL { get; set; }
        public Nullable<int> DEPARTMENT { get; set; }
        public Nullable<int> CATHEDRA { get; set; }
        public Nullable<int> DEGREE { get; set; }
        public Nullable<int> PHOTO { get; set; }
    
        public virtual CATHEDRA CATHEDRA1 { get; set; }
        public virtual DEGREE DEGREE1 { get; set; }
        public virtual DEPARTMENT DEPARTMENT1 { get; set; }
        public virtual EMAIL EMAIL1 { get; set; }
        public virtual PHOTO PHOTO1 { get; set; }
    }
}
