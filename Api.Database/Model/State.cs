using System;
using System.Collections.Generic;

namespace Api.Database.Model
{
    public partial class State
    {
        public State()
        {
            Lga = new HashSet<Lga>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lga> Lga { get; set; }
    }
}
