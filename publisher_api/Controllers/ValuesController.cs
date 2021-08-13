

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using publisher_api.Services;
using System;
using System.Collections.Generic;

namespace publisher_api.Controllers
{


    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public ValuesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {


            for (int i = 0; i < 60000; i++)
            {

                var weatherForecast = new WeatherForecast
                {
                    Date = DateTime.Parse("2019-08-01"),
                    TemperatureCelsius = 25,
                    Summary = "Hot:" + i
                };

               var resultado=  JsonConvert.SerializeObject(weatherForecast);




                Console.WriteLine("received a Post: ");
                _messageService.Enqueue(resultado);
            }

           


            return new string[] { "Fila ativa e já inseriu 60.000: Manda mais ---->" };


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string payload)
        {
            Console.WriteLine("received a Post: " + payload);
            _messageService.Enqueue(payload);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
