using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace expensit.MVVM.Models
{
    public enum ExpenseType
    {
        Electricity,
        Water,
        Internet,
        TV,
        Fuels
    }

    public class ExpenseRecord
    {
        public string Id { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(19,2)")]
        public decimal Amount { get; set; }
        
        public ExpenseType Type { get; set; }

        public DateTime PayDate { get; set; }
        
        public List<Group> Groups { get; } = new List<Group>();
    }
}
