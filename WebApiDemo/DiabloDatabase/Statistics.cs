//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabloDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statistics
    {
        public Statistics()
        {
            this.Characters = new HashSet<Characters>();
            this.GameTypes = new HashSet<GameTypes>();
            this.Items = new HashSet<Items>();
        }
    
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int Mind { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }
    
        public virtual ICollection<Characters> Characters { get; set; }
        public virtual ICollection<GameTypes> GameTypes { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
