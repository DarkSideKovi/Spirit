using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public interface IRateCardLookup
    {
        RateCard Get(TransportType transportType);
    }
}
