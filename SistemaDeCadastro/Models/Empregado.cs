using SistemaDeCadastro.Enums;

namespace SistemaDeCadastro.Models
{
    public class Empregado
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public EstadoCivilEnum EstadoCivil { get; set; }
        public DateTime DataDenascimento { get; set; }
    }
}
