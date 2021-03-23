using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Dominio.Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
