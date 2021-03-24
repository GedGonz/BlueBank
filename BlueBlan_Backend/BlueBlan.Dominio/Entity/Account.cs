using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Dominio.Entity
{
    public enum ACOUNT_TYPE {
        SAVING,
        ORDINARY,
        OTHER
    }
    public enum STATE
    {
        ACTIVE,
        DESACTIVE
    }
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Number { get; set; }
        public decimal ValueInit { get; set; }
        public decimal Valuecurrent { get; set; }
        public ACOUNT_TYPE Type { get; set; }
        public STATE State { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<AccountMove> AccountMoves { get; set; }
    }
}
