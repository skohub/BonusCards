using BonusCards.Infrastructure.Commands.Purchases;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace BonusCards.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Purchases")]
    public class PurchasesController : Controller
    {
        private readonly CqrsBus _bus;

        public PurchasesController(CqrsBus bus)
        {
            _bus = bus;
        }

        // POST: api/Purchases
        [HttpPost]
        public void Post([FromBody]Create command)
        {
            _bus.ExecuteCommand(command);
            _bus.SaveChanges();
        }
    }
}
