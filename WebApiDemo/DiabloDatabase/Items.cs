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
    
    public partial class Items
    {
        public Items()
        {
            this.GameTypes = new HashSet<GameTypes>();
            this.UsersGames = new HashSet<UsersGames>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }
        public int StatisticId { get; set; }
        public decimal Price { get; set; }
        public int MinLevel { get; set; }
    
        public virtual ItemTypes ItemTypes { get; set; }
        public virtual Statistics Statistics { get; set; }
        public virtual ICollection<GameTypes> GameTypes { get; set; }
        public virtual ICollection<UsersGames> UsersGames { get; set; }
    }
}