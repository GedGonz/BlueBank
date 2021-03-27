using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueBan.Aplication.Entitydto
{
    public class Clientdto
    {
        public Guid clientid { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string lastname { get; set; }
        public List<Accountdto> accounts { get; set; }

        public override string ToString()
        {
            return string.Format("name: {0}, lastname: {1}", name, lastname);
        }
    }
}
