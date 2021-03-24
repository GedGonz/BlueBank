using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Dominio.Entity
{
    public enum ACOUNTMOVE_TYPE
    {
        WITHDRAW,
        CONSIGN,
    }
    public class AccountMove
    {
        public Guid AccountMoveId { get; set; }
        public decimal Value { get; set; }
        public ACOUNTMOVE_TYPE TypeMove { get; set; }

        public DateTime DateMove { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
