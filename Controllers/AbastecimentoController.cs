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
  [Route("v1/abastecimento")]
  [ApiExplorerSettings(GroupName = "v1")]
  public class AbastecimentoController : ControllerBase
  {
    private readonly IAbastecimentoService _service;

    public AbastecimentoController(IAbastecimentoService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Abastecimento>>> Get()
    {
      return Ok(await _service.BuscarTodos());
    }
        [HttpGet]
        [Route("{idUsuario:int}")]
        public async Task<ActionResult<List<Abastecimento>>> GetforUser(int idUsuario)
        {
            return Ok(await _service.BuscarPorUsuario(idUsuario));
        }

        [HttpGet]
        [Route("{ano:int}")]
        public async Task<ActionResult<List<Abastecimento>>> Getforano(int ano)
        {
            return Ok(await _service.BuscarPorPeriodo(ano));
        }

        [HttpPost]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Post(int id, [FromBody] Abastecimento model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

    

      var newAbastecimento = await _service.Criar(model);

      return new DefaultViewModel(true, "Permissão criada com sucesso!", newAbastecimento);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Put([FromServices] DataContext context, int id, [FromBody] Abastecimento model)
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