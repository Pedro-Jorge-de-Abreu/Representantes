using CandidatosApi.Models;

namespace CandidatosApi.Repository
{
    public interface ICandidatoRepository
    {
        public void Cadastrar(Candidato candidato);
        public List<Candidato> ObterTodos();
        public Candidato ObterPorNumero(int numero);
        public void RegistrarVoto(Voto voto);
        public bool ObterVotoPorRa(string ra);
        public int ObterQuantidadeVotosPorNumero(int numero);
    }
}