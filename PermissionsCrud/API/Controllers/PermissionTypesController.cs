using Application.Features.PermissionTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PermissionTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPermissionTypes()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionType(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }


    }
}
