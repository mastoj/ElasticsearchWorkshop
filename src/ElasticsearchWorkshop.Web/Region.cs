//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElasticsearchWorkshop.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territories>();
        }
    
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    
        public virtual ICollection<Territories> Territories { get; set; }
    }
}
