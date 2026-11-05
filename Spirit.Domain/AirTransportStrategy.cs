using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class AirTransportStrategy : ITransportStrategy
    {
        public const int WeightLimitKg = 1000;
        public const int MinimumFee = 100;
        private readonly RateCard _rates;
        public TransportType Type => TransportType.Air;

        public AirTransportStrategy(RateCard rates)
        {
            _rates = rates;
        }


        public decimal CalculateFee(ShipmentDraft shipmentDraft)
        {
            return Math.Max(MinimumFee, _rates.BaseFee + (shipmentDraft.WeightKg * _rates.FeePerKg) + _rates.ExtraFee);
        }

        public IReadOnlyList<string> Validate(ShipmentDraft shipmentDraft)
        {
            var errors = new List<string>();
            if (shipmentDraft.WeightKg > WeightLimitKg)
                errors.Add($"Weight exceeds limit of {WeightLimitKg} kg.");
            else if (shipmentDraft.WeightKg <= 0)
                errors.Add($"Weight must be positive.");
            return errors;
        }
    }
}
