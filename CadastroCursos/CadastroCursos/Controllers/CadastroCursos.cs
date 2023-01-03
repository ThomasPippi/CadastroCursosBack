using Microsoft.AspNetCore.Mvc;
using CadastroCursos.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace CadastroCursos.Controllers
{
   
    public class CadastroCursos : ControllerBase

    {

        [AllowAnonymous]
        [HttpGet]
        [Route("cursos")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var cursos = await contexto.Cursos.ToListAsync();
            return cursos  == null ? NotFound() : Ok(cursos);
        }
        

        [HttpPost]
        [Route("cursos")]
        public async Task<IActionResult> PostAsync([FromServices] Contexto contexto, [FromBody] Curso cursos)
        {
            try
            {
                await contexto.Cursos.AddAsync(cursos);
                await contexto.SaveChangesAsync();
                return Created($"cursos/{cursos.CursoId}", cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cursos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] Contexto contexto,
            [FromBody] Curso curso,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var p = await contexto.Cursos.FirstOrDefaultAsync(x => x.CursoId == id);
          

            if (p == null){ 
                return NotFound();
            }
            else { 
                try
                {
                    p.Nome_curso = curso.Nome_curso;
                    p.Turno_curso = curso.Turno_curso;
                    p.Versao_curso = curso.Versao_curso;
                    p.Conceito_mec = curso.Conceito_mec;
                    p.Nome_unidade = curso.Nome_unidade;
                    contexto.Cursos.Update(p);
                    await contexto.SaveChangesAsync();
                    return Ok(p);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }

            }
        }
        [HttpDelete]
        [Route("cursos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var p = await contexto.Cursos.FirstOrDefaultAsync(x => x.CursoId == id);
            if (p == null)
                return BadRequest("Pessoa não encontrada");

            try
            {
                contexto.Cursos.Remove(p);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }    
}
