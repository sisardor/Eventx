//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eventz.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Storage
    {
        public int Id { get; set; }
        public StorageType StorageType { get; set; }
        public System.DateTime LastUpdatedWeek { get; set; }
        public System.DateTime LastUpdatedClosest { get; set; }
        public System.DateTime LastUpdatedToday { get; set; }
    }
}