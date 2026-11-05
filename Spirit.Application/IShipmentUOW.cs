using Spirit.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Application
{
    public interface IShipmentUOW
    {
        Task<bool> CustomerExistsAsync(Guid customerId, CancellationToken cancellationToken);

        Task CommitRegistrationAsync(
            Shipment shipment,
            Invoice invoice,
            RegistrationNotice notice,
            CancellationToken cancellationToken
        );
    }
}
