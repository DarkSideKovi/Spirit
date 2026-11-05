using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Application
{
    public sealed class RegisterShipmentResult
    {
        public RegisterCommandOutcome Outcome { get; init; }
        public Guid? ShipmentID { get; init; }
        public decimal? Fee { get; init; }
        public required IReadOnlyList<string> ErrorMessages { get; init; }
    }
}
