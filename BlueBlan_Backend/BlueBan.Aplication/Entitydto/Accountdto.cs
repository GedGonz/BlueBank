using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueBan.Aplication.Entitydto
{
    public enum ACOUNT_TYPE
    {
        SAVING,
        ORDINARY,
        OTHER
    }
    public class Accountdto
    {
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public ACOUNT_TYPE Type { get; set; }
        public int ClientId { get; set; }
        public Clientdto Client { get; set; }
    }
}

