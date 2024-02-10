using Microsoft.AspNetCore.Mvc;
using rinha_de_backend_2024_q1.Models;
using System.Net.Mime;

namespace rinha_de_backend_2024_q1.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class AccountOperationsController : ControllerBase
    {
        private static readonly List<Clients> accounts = new List<Clients>
        {
            new Clients { Id = 1, Limit = 100000, OpeningBalance = 0},
            new Clients { Id = 2, Limit = 80000, OpeningBalance = 0},
            new Clients { Id = 3, Limit = 1000000, OpeningBalance = 0},
            new Clients { Id = 4, Limit = 10000000, OpeningBalance = 0},
            new Clients { Id = 5, Limit = 500000, OpeningBalance = 0}
        };

        private readonly ILogger<AccountOperationsController> _logger;

        public AccountOperationsController(ILogger<AccountOperationsController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("{id}/transacoes")]
        [ProducesResponseType(200, Type = typeof(Clients))]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<Clients>> Transaction(int id)
        {
            //return  Enumerable.Range(1, 5).Select(index => new Clients
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();3

            //var clients = new List<Clients>();

            return accounts.FirstOrDefault(x => x.Id == id) != null ? Ok(accounts.FirstOrDefault(x => x.Id == id)) : NotFound();
        }

        [HttpPost("{id}/extrato")]
        [ProducesResponseType(200, Type = typeof(Clients))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Clients>> Statement(int id)
        {
            //return  Enumerable.Range(1, 5).Select(index => new Clients
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();3

            //var clients = new List<Clients>();

            return accounts.FirstOrDefault(x => x.Id == id) != null ? Ok(accounts.FirstOrDefault(x => x.Id == id)) : NotFound();
        }
    }
}
