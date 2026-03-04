using ApiCrudFuncionario.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiCrudFuncionario.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public required string Sobrenome { get; set; }

        public DepartamentoEnum Departamento { get; set; }

        public bool Ativo { get; set; }

        public TurnoEnum Turno { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAtualizacao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
