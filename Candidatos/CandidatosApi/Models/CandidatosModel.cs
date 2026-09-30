using System.ComponentModel.DataAnnotations;

namespace CandidatosApi.Models
{
    public class Candidato
    {
        [Required(ErrorMessage = "Nome deve ser informado")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email deve ser informado")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }

        [Range(1, 8, ErrorMessage = "A turma deve ser um número entre 1 e 8.")]
        public int Turma { get; set; }

        [StringLength(500, ErrorMessage = "A proposta deve ter no máximo 500 caracteres.")]
        public string DescricaoProposta { get; set; }

        [Range(10, 99, ErrorMessage = "O número do candidato deve estar entre 10 e 99.")]
        public int NumeroCandidato { get; set; }
    }

    public class Voto
    {
        [Required(ErrorMessage = "RA do aluno é obrigatório")]
        public string RaAluno { get; set; }

        public DateTime DataVoto { get; set; }

        [Range(10, 99, ErrorMessage = "O número do candidato deve estar entre 10 e 99.")]
        public int NumeroCandidato { get; set; }
    }
}