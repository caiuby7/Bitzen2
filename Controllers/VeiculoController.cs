using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bitzen.Data;
using Bitzen.Interface.Services;
using Bitzen.Models;

namespace Bitzen.Controllers
{
  [ApiController]
  [Route("v1/veiculo")]
  [ApiExplorerSettings(GroupName = "v1")]
  public class VeiculoController : ControllerBase
  {
    private readonly IVeiculoService _service;

    public VeiculoController(IVeiculoService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Veiculo>>> Get()
    {
      return Ok(await _service.BuscarTodos());
    }

    [HttpPost]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Post(int id, [FromBody] Veiculo model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

    

      var newVeiculo = await _service.Criar(model);

      return new DefaultViewModel(true, "Permissão criada com sucesso!", newVeiculo);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Put([FromServices] DataContext context, int id, [FromBody] Veiculo model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return null;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Delete(int id)
    {
      return Ok(await _service.Excluir(id));
    }
  }
}