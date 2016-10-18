//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asp_responsive.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostD
    {
        public long Id { get; set; }
        public int SourceId { get; set; }
        public int SearchTypeId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public bool IsSelected { get; set; }
    
        public virtual SearchType SearchType { get; set; }
        public virtual Source Source { get; set; }
    }
}
