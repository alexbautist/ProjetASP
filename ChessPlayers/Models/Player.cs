using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace ChessPlayers.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Country { get; set; }
        public decimal Rating { get; set; }

        public static explicit operator Player(ViewDataDictionary v)
        {
            throw new NotImplementedException();
        }
    }

    public class PlayerDBContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
    }
}