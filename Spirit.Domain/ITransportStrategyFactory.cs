using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public interface ITransportStrategyFactory
    {
        ITransportStrategy Create(TransportType type);
    }
}
