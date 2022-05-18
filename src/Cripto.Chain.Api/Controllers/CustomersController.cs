using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Cripto.Chain.Api.Infrastructure.MessageBus;
using Cripto.Chain.Api.Models;
using Cripto.Chain.Events.Events.Customers;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cripto.Chain.Api.Controllers
{
    [Route("api/v1/customers")]
    public class CustomersController : Controller
    {
        private readonly IBus _bus;
        public CustomersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create()
        {
            var customerEvent = new CustomerEvent()
            {
                Id = 1,
                Name = "Paulo Roberto de Souza",
                CreatedAt = DateTimeOffset.UtcNow
            };

            var message = new Message<CustomerEvent>(customerEvent);

            await _bus.WithExchangeName(CustomerEventType.ExchangeName)
                .WithQueueName(CustomerEventType.QueueName)
                .Bind()
                .Publish(message);

            return Created("", null);
        }
    }
}
