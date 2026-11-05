using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class SeaTransportStrategy : ITransportStrategy
    {
        private readonly RateCard _rates;
        public TransportType Type => TransportType.Sea;

        public SeaTransportStrategy(RateCard rates)
        {
            _rates = rates;
        }

        public decimal CalculateFee(ShipmentDraft shipmentDraft)
        {
            return _rates.BaseFee + (shipmentDraft.WeightKg * _rates.FeePerKg) + (shipmentDraft.VolumeCbm * _rates.FeePerCbm) + _rates.ExtraFee;
        }

        public IReadOnlyList<string> Validate(ShipmentDraft shipmentDraft)
        {
            var errors = new List<string>();
            if(shipmentDraft.VolumeCbm <= 0)
                errors.Add($"Volume must be positive.");
            if(shipmentDraft.WeightKg <= 0)
                errors.Add($"Weight must be positive.");
            return errors;
        }
    }
}
