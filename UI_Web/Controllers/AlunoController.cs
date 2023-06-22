using CadastrarAluno.Servicos;
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

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                List<Aluno> alunos = _aluno.ObterTodos();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Criar(Aluno novoAluno)
        {
            try
            {
                ValidarForm.Valida(novoAluno);
                _aluno.Criar(novoAluno);    
                return Created($"{novoAluno.Id}", novoAluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {
             Aluno aluno = _aluno.ObterPorId(id);
             return Ok(aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute]int id)
        {
            try
            {
                var aluno = _aluno.ObterPorId(id);
                _aluno.Remover(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] Aluno aluno)
        {
            try
            {
                ValidarForm.Valida(aluno);
                _aluno.Atualizar(id, aluno);
                return Ok(aluno.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}