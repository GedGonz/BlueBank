using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueBan.Aplication.Entitydto
{
    public enum ACOUNTMOVE_TYPE
    {
        WITHDRAW,
        CONSIGN,
    }
    public class AccountMovedto
    {
        public Guid accountmoveid { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public decimal value { get; set; }
        [Required(ErrorMessage = "TypeMove is required")]
        public ACOUNTMOVE_TYPE typemove { get; set; }
        public DateTime datemove { get; set; }
        public Guid accountId { get; set; }
    }
}
