using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class Invoice
    {
        public Guid ID { get; init; }
        public Guid ShipmentID { get; init; }
        public decimal Amount { get; init; }
    }
}
