using CandidatosApi.Models;

namespace CandidatosApi.Repository
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private static readonly List<Candidato> ListaCandidato = new List<Candidato>();
        private static readonly List<Voto> ListaVotos = new List<Voto>();

        public void Cadastrar(Candidato candidato)
        {
            ListaCandidato.Add(candidato);
        }

        public Candidato ObterPorNumero(int numero)
        {
            return ListaCandidato.Where(a => a.NumeroCandidato == numero).FirstOrDefault();
        }

        public List<Candidato> ObterTodos()
        {
            return ListaCandidato;
        }

        public void RegistrarVoto(Voto voto)
        {
            ListaVotos.Add(voto);
        }

        public bool ObterVotoPorRa(string ra)
        {
            return ListaVotos.Any(v => v.RaAluno == ra);
        }

        public int ObterQuantidadeVotosPorNumero(int numero)
        {
            return ListaVotos.Count(v => v.NumeroCandidato == numero);
        }
    }
}