using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class LandTransportStrategy : ITransportStrategy
    {
        public TransportType Type => TransportType.Land;
        private readonly RateCard _rates;

        public LandTransportStrategy(RateCard rates)
        {
            _rates = rates;
        }

        public decimal CalculateFee(ShipmentDraft shipmentDraft)
        {
            return _rates.BaseFee + (shipmentDraft.WeightKg * _rates.FeePerKg) + (shipmentDraft.DistanceKm * _rates.FeePerKm) + _rates.ExtraFee;
        }

        public IReadOnlyList<string> Validate(ShipmentDraft shipmentDraft)
        {
            var errors = new List<string>();
            if (shipmentDraft.DistanceKm <= 0)
                errors.Add($"Distance must be positive.");
            if (shipmentDraft.WeightKg <= 0)
                errors.Add($"Weight must be positive.");
            return errors;
        }
    }
}
