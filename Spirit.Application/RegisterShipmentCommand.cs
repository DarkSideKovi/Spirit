using MediatR;
using Spirit.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Application
{
    public sealed class RegisterShipmentCommand : IRequest<RegisterShipmentResult>
    {
        public Guid CustomerID { get; init; }
        public required string Reference { get; init; }
        public TransportType TransportType { get; init; }
        public required string Origin { get; init; }
        public required string Destination { get; init; }
        public int WeightKg { get; init; }
        public int VolumeCbm { get; init; }
        public int DistanceKm { get; init; }
    }
}
