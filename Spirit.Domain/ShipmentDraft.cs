using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class ShipmentDraft
    {
        public int CustomerId { get; set; }
        public required string Reference { get; set; }
        public TransportType TransportType { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public int WeightKg { get; set; }
        public int VolumeCbm { get; set; }
        public int DistanceKm { get; set; }
    }
}
