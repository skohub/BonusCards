using BonusCards.Infrastructure.Commands.Withdraws;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonusCards.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Withdraws")]
    public class WithdrawsController : Controller
    {
        private readonly CqrsBus _bus;

        public WithdrawsController(CqrsBus bus)
        {
            _bus = bus;
        }

        // POST: api/Withdraws
        [HttpPost]
        public void Post([FromBody]Create command)
        {
            _bus.ExecuteCommand(command);
            _bus.SaveChanges();
        }
    }
}
