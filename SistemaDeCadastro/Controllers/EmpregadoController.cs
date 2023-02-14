using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Repositories.Interfaces;

namespace SistemaDeCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadoController : ControllerBase
    {
        private readonly IEmpregado _empregado;
        public EmpregadoController(IEmpregado empregado)
        {
            _empregado = empregado;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empregado>>> ListaEmpregados()
        {
            var empregados = await _empregado.ListaEmpregados();
            return Ok(empregados);
        }

        [HttpPost]
        public async Task<ActionResult<Empregado>> AdicionarEmpregado(Empregado empregado)
        {
            var empregadoAdicionado = await _empregado.AdicionarEmpregado(empregado);
            return Ok(empregadoAdicionado);
        }

        [HttpPut]
        public async Task<ActionResult<Empregado>> EditarEmpregado(Empregado empregado, int matricula)
        {
            var empregadoEditado = await _empregado.EditarEmpregado(empregado, matricula);
            return Ok(empregadoEditado);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletarEmpregado(int matricula)
        {
            await _empregado.DeletarEmpregado(matricula);
            return true;
        }
    }
}
