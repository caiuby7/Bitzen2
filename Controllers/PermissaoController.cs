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
  [Route("v1/permissao")]
  [ApiExplorerSettings(GroupName = "v1")]
  public class PermissaoController : ControllerBase
  {
    private readonly IPermissaoService _service;

    public PermissaoController(IPermissaoService service)
    {
      _service = service;
    }
        /// <summary>
        /// Lista os perfils de acesso.
        /// </summary>
        /// <returns>Os itens de perfil list</returns>
        /// <response code="200">Returna os itens cadastrados</response>
        [HttpGet]
    public async Task<ActionResult<List<Permissao>>> Get()
    {
      return Ok(await _service.BuscarTodos());
    }

        // POST api/Bitzen
        /// <summary>
        /// Cria um Perfil.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///        "id": 1 (campo autoincremento),
        ///        "descrição": "Adminstrador",
        ///        "ativo": true
        ///     }
        ///
        /// </remarks>
        /// <param name="descricao"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo item criado</response>
        [HttpPost]
    [Route("{descricao:alpha}")]
    public async Task<ActionResult<DefaultViewModel>> Post(string descricao)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

            Permissao model = new Permissao(descricao);

      var newPermissao = await _service.Criar(model);

      return new DefaultViewModel(true, "Permissão criada com sucesso!", newPermissao);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<DefaultViewModel>> Put([FromServices] DataContext context, int id, [FromBody] Permissao model)
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