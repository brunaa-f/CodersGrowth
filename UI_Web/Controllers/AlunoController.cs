using Dominio;
using Infra;
using Microsoft.AspNetCore.Mvc;

namespace UI_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlunoController : ControllerBase    
    {
        private IRepositorio _aluno;

        public AlunoController(IRepositorio aluno)
        {
            _aluno = aluno;
        }

        [HttpPost]
        public IActionResult ObterTodos()
        {
           try
            {
                List<Aluno> aluno = _aluno.ObterTodos();
                return Ok(aluno);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

    }
}