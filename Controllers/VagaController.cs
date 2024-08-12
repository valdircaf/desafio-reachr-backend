using api.Model;
using api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {

        private readonly VagaInterface repository;

        public VagaController(VagaInterface repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vagas = await this.repository.GetVagas();
            return vagas.Any() ? Ok(vagas) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaga(int id)
        {
            var vaga = await this.repository.GetVaga(id);
            return vaga != null ? Ok(vaga) : NotFound("Vaga não encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vagas vaga)
        {
            this.repository.NewVaga(vaga);
            return await this.repository.SaveChangesAsync() ? Ok(vaga) : Ok("Não adicionado");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Vagas vaga)
        {
            var vagaToCheck = await this.repository.GetVaga(id);
            if (vagaToCheck == null) return NotFound("Vaga não encontrada");

            vagaToCheck.Nome = vaga.Nome != "" ? vaga.Nome : vagaToCheck.Nome;
            vagaToCheck.Sallary = vaga.Sallary != 0 ? vaga.Sallary : vagaToCheck.Sallary;
            vagaToCheck.Descricao = vaga.Descricao != "" ? vaga.Descricao : vagaToCheck.Descricao;
            vagaToCheck.Cidade = vaga.Cidade != "" ? vaga.Cidade : vagaToCheck.Cidade;
            vagaToCheck.Uf = vaga.Uf != "" ? vaga.Uf : vagaToCheck.Uf;


            this.repository.UpdateVaga(vagaToCheck);

            return await this.repository.SaveChangesAsync() ? Ok(new { message = "Atualizado com sucesso" }) : BadRequest("Não adicionado");
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await this.repository.GetVaga(id);
            if (vaga == null) return NotFound("Vaga não existe");

            this.repository.DeleteVaga(vaga);

            return await this.repository.SaveChangesAsync() ? Ok(new { message = "Atualizado com sucesso" }) : BadRequest("Erro ao deletar vaga");


        }
    }
}