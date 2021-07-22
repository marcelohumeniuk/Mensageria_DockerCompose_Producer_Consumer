﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using publisher_api.Services;

namespace publisher_api.Controllers
{
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
               
                Console.WriteLine("received a Post: ");
                _messageService.Enqueue("Manda texto:" + i);
            }

           


            return new string[] { "Fila ativa e já inseriu 10.000: Manda mais ---->" };


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
