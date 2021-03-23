using System;
using System.Collections.Generic;
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
        public string Number { get; set; }
        public decimal Value { get; set; }
        public ACOUNT_TYPE Type { get; set; }
        public int ClientId { get; set; }
        public Clientdto Client { get; set; }
    }
}

