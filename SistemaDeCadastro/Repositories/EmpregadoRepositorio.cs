using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Repositories.Interfaces;

namespace SistemaDeCadastro.Repositories
{
    public class EmpregadoRepositorio : IEmpregado
    {
        private readonly SistemaCadastroDBContext _dbContext;
        public EmpregadoRepositorio(SistemaCadastroDBContext sistemaCadastroDBContext)
        {
            _dbContext = sistemaCadastroDBContext;
        }
        public  async Task<List<Empregado>> ListaEmpregados()
        {
            var empregados = await _dbContext.Empregados.ToListAsync();

            return empregados;
        }
        public async Task<Empregado> AdicionarEmpregado(Empregado empregado)
        {
            await _dbContext.Empregados.AddAsync(empregado);
            await _dbContext.SaveChangesAsync();
            return empregado;
        }

        public async Task<Empregado> EditarEmpregado(Empregado empregado, int matricula)
        {
            var empregadoBuscado = await _dbContext.Empregados.FirstOrDefaultAsync(e => e.Matricula == matricula);
            if (empregadoBuscado is null)
                throw new Exception($"Empregado Não Encontado para matrícula: {matricula}");
            empregadoBuscado.Nome = empregado.Nome;
            empregadoBuscado.DataDenascimento = empregado.DataDenascimento;
            empregadoBuscado.EstadoCivil = empregado.EstadoCivil;

            _dbContext.Empregados.Update(empregadoBuscado);
            await _dbContext.SaveChangesAsync();

            return empregadoBuscado;
        }

        public async Task<bool> DeletarEmpregado(int matricula)
        {
            var empregadoBuscado = await _dbContext.Empregados.FirstOrDefaultAsync(e => e.Matricula == matricula);
            if (empregadoBuscado is null)
                throw new Exception($"Empregado Não Encontado para matrícula: {matricula}");

            _dbContext.Empregados.Remove(empregadoBuscado);
            await _dbContext.SaveChangesAsync();

            return true;
        }



    }
}
