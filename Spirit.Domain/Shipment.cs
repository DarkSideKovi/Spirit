using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class Shipment
    {
        public Guid ID { get; init; }
        public required ShipmentDraft Draft { get; init; }
        public decimal Fee { get; init; }
        public DateTimeOffset RegisteredAt { get; init; }
    }
}
