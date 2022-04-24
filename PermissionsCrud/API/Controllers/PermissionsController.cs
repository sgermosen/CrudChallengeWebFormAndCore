using Application.Features.Permissions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PermissionsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(Permission permission)//we can use frombody to tell the api where is exacly than it will find, but is not required
        {
            return HandleResult(await Mediator.Send(new Create.Command { Permission = permission }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Permission permission)
        {
            permission.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Permission = permission }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
