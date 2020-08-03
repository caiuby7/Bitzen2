using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bitzen.Data;
using Bitzen.Helpers;
using Bitzen.Models;

namespace Bitzen.Controllers
{
  [ApiController]
  [Route("v1/usuario")]
  [ApiExplorerSettings(GroupName = "v1")]
  public class UsuarioController : ControllerBase
  {
    [HttpGet]
    [Authorize(Roles = PermissaoHelper.Admin)]
    public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
    {
      return await context.Usuarios.ToListAsync();
    }

    [HttpPost]
    [Authorize(Roles = PermissaoHelper.Admin)]
    public async Task<ActionResult<DefaultViewModel>> Post([FromServices] DataContext context, [FromBody] Usuario model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      

      context.Usuarios.Add(model);
      await context.SaveChangesAsync();
      return new DefaultViewModel(true, "Usurio criado com sucesso!", model);
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = PermissaoHelper.Admin)]
    public async Task<ActionResult<DefaultViewModel>> Put([FromServices] DataContext context, int id, [FromBody] Usuario model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return null;
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize(Roles = PermissaoHelper.Admin)]
    public async Task<ActionResult<DefaultViewModel>> Delete([FromServices] DataContext context, int id)
    {
      return BadRequest(ModelState);
    }
  }
}