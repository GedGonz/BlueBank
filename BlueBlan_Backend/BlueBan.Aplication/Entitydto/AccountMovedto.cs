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
        public Guid AccountMoveId { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "TypeMove is required")]
        public ACOUNTMOVE_TYPE TypeMove { get; set; }
        public DateTime DateMove { get; set; }
        public Guid AccountId { get; set; }
    }
}
