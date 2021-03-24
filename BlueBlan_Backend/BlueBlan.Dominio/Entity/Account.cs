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
    public class Account
    {
        public int AccountId { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public ACOUNT_TYPE Type { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
