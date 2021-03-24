using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueBan.Aplication.Entitydto
{
    public class Clientdto
    {
        public Guid ClientId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        public List<Accountdto> Accounts { get; set; }
    }
}
