using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateGraphQL.Database.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOverdue { get; set; }
        public bool Paid { get; set; }
    }
}
