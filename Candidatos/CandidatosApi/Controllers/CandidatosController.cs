using CandidatosApi.Models;
using CandidatosApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CandidatosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatosController(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Candidato candidato)
        {
            var resultado = _candidatoRepository.ObterPorNumero(candidato.NumeroCandidato);

            if (resultado == null)
            {
                _candidatoRepository.Cadastrar(candidato);
                return Ok("Cadastrado com sucesso");
            }

            return BadRequest("Número de candidato já existe");
        }

        [HttpPost]
        [Route("RegistrarVoto")]
        public IActionResult RegistrarVoto([FromBody] Voto voto)
        {
            var candidato = _candidatoRepository.ObterPorNumero(voto.NumeroCandidato);
            if (candidato == null)
            {
                return BadRequest("Candidato não encontrado.");
            }

            if (_candidatoRepository.ObterVotoPorRa(voto.RaAluno))
            {
                return BadRequest("Aluno com este RA já registrou um voto.");
            }

            voto.DataVoto = DateTime.Now;
            _candidatoRepository.RegistrarVoto(voto);

            return Ok("Voto registrado com sucesso!");
        }

        [HttpGet]
        [Route("ConsultarVotos/{numero}")]
        public IActionResult ConsultarVotos(int numero)
        {
            var candidato = _candidatoRepository.ObterPorNumero(numero);
            if (candidato == null)
            {
                return NotFound("Candidato não encontrado.");
            }

            var totalVotos = _candidatoRepository.ObterQuantidadeVotosPorNumero(numero);

            return Ok(new
            {
                NomeCandidato = candidato.Nome,
                NumeroCandidato = candidato.NumeroCandidato,
                TotalVotos = totalVotos
            });
        }
    }
}