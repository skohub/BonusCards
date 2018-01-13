using System.Collections.Generic;
using BonusCards.Infrastructure.Commands.Cards;
using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Dtos;
using BonusCards.Infrastructure.Queries.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonusCards.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Cards")]
    public class CardsController : Controller
    {
        private readonly CqrsBus _bus;

        public CardsController(CqrsBus bus)
        {
            _bus = bus;
        }

        // GET: api/Cards
        [HttpGet]
        public IActionResult Get()
        {
            var query = new FindAll();
            return Ok(_bus.Query<FindAll, IEnumerable<CardDto>>(query));
        }

        // GET: api/Cards/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var query = new Find{Id = id};
            var card = _bus.Query<Find, CardDto>(query);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        // POST: api/Cards
        [HttpPost]
        public void Post([FromBody]CreateWithCustomer command)
        {
            _bus.ExecuteCommand(command);
            _bus.SaveChanges();
        }
    }
}
