using MediatR;
using Spirit.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Application
{
    public sealed class RegisterShipmentHandler : IRequestHandler<RegisterShipmentCommand, RegisterShipmentResult>
    {
        private readonly ITransportStrategyFactory factory;
        private readonly IShipmentUOW uow;

        public RegisterShipmentHandler(ITransportStrategyFactory factory, IShipmentUOW uow)
        {
            this.factory = factory;
            this.uow = uow;
        }

        public async Task<RegisterShipmentResult> Handle(RegisterShipmentCommand command, CancellationToken cancellationToken)
        {
            var draft = new ShipmentDraft
            {
                CustomerID = command.CustomerID,
                Reference = command.Reference,
                TransportType = command.TransportType,
                Origin = command.Origin,
                Destination = command.Destination,
                WeightKg = command.WeightKg,
                VolumeCbm = command.VolumeCbm,
                DistanceKm = command.DistanceKm
            };

            var strategy = factory.Create(draft.TransportType);
            var errors = strategy.Validate(draft);
            if (errors.Count > 0)
            {
                return new RegisterShipmentResult
                {
                    Outcome = RegisterCommandOutcome.Invalid,
                    ErrorMessages = errors
                };
            }

            var customerExists = await uow.CustomerExistsAsync(draft.CustomerID, cancellationToken);
            if (!customerExists)
            {
                return new RegisterShipmentResult
                {
                    Outcome = RegisterCommandOutcome.CustomerNotFound,
                    ErrorMessages = new List<string> { "Customer not found" }
                };
            }

            var fee = strategy.CalculateFee(draft);
            var shipment = new Shipment
            {
                ID = Guid.NewGuid(),
                Draft = draft,
                Fee = fee,
                RegisteredAt = DateTimeOffset.UtcNow
            };
            var invoice = new Invoice
            {
                ID = Guid.NewGuid(),
                ShipmentID = shipment.ID,
                Amount = fee
            };
            var registrationNotice = new RegistrationNotice
            {
                ShipmentID = shipment.ID,
                CustomerID = draft.CustomerID,
                Reference = draft.Reference,
                Fee = fee
            };

            await uow.CommitRegistrationAsync(shipment, invoice, registrationNotice, cancellationToken);
            
            return new RegisterShipmentResult
            {
                Outcome = RegisterCommandOutcome.Registered,
                ShipmentID = shipment.ID,
                Fee = fee,
                ErrorMessages = new List<string>()
            };
        }
    }
}
