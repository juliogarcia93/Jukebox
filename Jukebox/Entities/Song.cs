//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        public Song()
        {
            this.Accounts = new HashSet<Account>();
            this.Artists = new HashSet<Artist>();
            this.Genres = new HashSet<Genre>();
            this.Albums = new HashSet<Album>();
        }
    
        public int Id { get; set; }
        public string sTitle { get; set; }
        public string sLength { get; set; }
        public string sFilePath { get; set; }
    
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
