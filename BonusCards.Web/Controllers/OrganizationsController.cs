using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Commands.Organizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonusCards.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Organizations")]
    public class OrganizationsController : Controller
    {
        private readonly CqrsBus _bus;

        public OrganizationsController(CqrsBus bus)
        {
            _bus = bus;
        }

        // POST: api/Organizations
        [HttpPost]
        public void Post([FromBody]Create command)
        {
            _bus.ExecuteCommand(command);
            _bus.SaveChanges();
        }
    }
}
