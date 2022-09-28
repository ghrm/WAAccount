using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WAAccount.Models1
{
    public partial class AccountT
    {
        [Key]
        public string Account { get; set; }
        public string AcctType { get; set; }
        public string Description { get; set; }
        public string Deparment { get; set; }
        public string TypicalBal { get; set; }
        public string DebitOffset { get; set; }
        public string CreditOffset { get; set; }
        public bool? Sts { get; set; }
    }
}
