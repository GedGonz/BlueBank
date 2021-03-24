using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Dominio.Entity
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
