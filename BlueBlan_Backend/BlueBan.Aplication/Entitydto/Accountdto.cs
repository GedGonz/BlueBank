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
    public enum STATE
    {
        ACTIVE,
        DESACTIVE
    }
    public class Accountdto
    {
        public Guid accountid { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public string number { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public decimal valueinit { get; set; }
        public decimal valuecurrent { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public ACOUNT_TYPE type { get; set; }
        public STATE state { get; set; }
        public Guid clientid { get; set; }
        public virtual List<AccountMovedto> accountmoves { get; set; }
    }
}

