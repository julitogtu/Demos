using System;
using DemoRabbitMQ.Support;
using Microsoft.AspNetCore.Mvc;

namespace DemoRabbitMQ.Controllers
{
    [Route("api/rabbitmqtest")]
    public class TestRabbitMqController : Controller
    {
        private readonly AmqpService amqpService;

        public TestRabbitMqController(AmqpService amqpService)
        {
            this.amqpService = amqpService ?? throw new ArgumentNullException(nameof(amqpService));
        }

        [HttpPost("")]
        public IActionResult PublishMessage([FromBody] object message)
        {
            amqpService.PublishMessage(message);
            return Ok();
        }
    }
}