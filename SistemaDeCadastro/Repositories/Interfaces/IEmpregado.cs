using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Repositories.Interfaces
{
    public interface IEmpregado
    {
        Task<List<Empregado>> ListaEmpregados();
        Task<Empregado> AdicionarEmpregado(Empregado empregado);
        Task<Empregado> EditarEmpregado(Empregado empregado, int matricula);
        Task<bool> DeletarEmpregado(int matricula);

    }
}
