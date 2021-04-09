using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }        
        public int? CardId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
