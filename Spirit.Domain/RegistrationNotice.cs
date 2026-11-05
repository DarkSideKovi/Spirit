using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class RegistrationNotice
    {
        public Guid ShipmentID { get; init; }
        public Guid CustomerID { get; init; }
        public required string Reference { get; init; }
        public decimal Fee { get; init; }
    }
}
