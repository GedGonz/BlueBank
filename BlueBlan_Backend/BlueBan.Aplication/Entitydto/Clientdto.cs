using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBan.Aplication.Entitydto
{
    public class Clientdto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Accountdto> Accounts { get; set; }
    }
}
