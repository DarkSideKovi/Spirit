using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spirit.Domain
{
    public interface ITransportStrategy
    {
        TransportType Type { get; }
        decimal CalculateFee(ShipmentDraft shipmentDraft);
        IReadOnlyList<string> Validate(ShipmentDraft shipmentDraft);
    }
}
