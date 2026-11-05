using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class TransportStrategyFactory : ITransportStrategyFactory
    {
        private readonly IRateCardLookup _rateCardLookup;
        public TransportStrategyFactory(IRateCardLookup rateCardLookup)
        {
            _rateCardLookup = rateCardLookup;
        }

        public ITransportStrategy Create(TransportType type)
        {
            var rateCard = _rateCardLookup.Get(type);
            return type switch
            {
                TransportType.Air => new AirTransportStrategy(rateCard),
                TransportType.Sea => new SeaTransportStrategy(rateCard),
                TransportType.Land => new LandTransportStrategy(rateCard),
                _ => throw new NotImplementedException($"Transport type {type} is not supported.")
            };
        }
    }
}
