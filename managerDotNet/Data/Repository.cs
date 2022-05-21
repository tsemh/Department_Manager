using System.Threading.Tasks;
using System.Linq;
using TestWebAPI.models;
using Microsoft.EntityFrameworkCore;



namespace TestWebAPI.Data
{
  public class Repository : IRepository
  {
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
      _context = context;
    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }
    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }
    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }
    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario = true)
    {
      IQueryable<Departamento> query = _context.Departamentos;

      query = query.Include(funcionario => funcionario.Funcionarios)
                   .AsNoTracking()
                   .OrderBy(departamento => departamento.Id);


      return await query.ToArrayAsync();
    }
        public async Task<Departamento> GetDepartamentoAsyncById(int IdDepartamento, bool includeFuncionario = true)
    {
      IQueryable<Departamento> query = _context.Departamentos;

      query = query.AsNoTracking()
                   .OrderBy(departamento => departamento.Id)
                   .Where(departamento => departamento.Id == IdDepartamento);
      return await query.FirstOrDefaultAsync();
    }


    public async Task<Funcionario[]> GetFuncionariosAsyncByIdDepartamento(int IdDepartamento, bool includeFuncionario = true)
    {
      IQueryable<Funcionario> query = _context.Funcionarios;

      query = query.Include(departamento => departamento.Departamento)
                   .AsNoTracking()
                   .Where(departamento => departamento.IdDepartamento == IdDepartamento);

      return await query.ToArrayAsync();
    }
    public async Task<Funcionario> GetFuncionarioAsyncById(int IdFuncionario)
    {
      IQueryable<Funcionario> query = _context.Funcionarios;

      query = query.AsNoTracking()
                   .OrderBy(funcionario => funcionario.Id)
                   .Where(funcionario => funcionario.Id == IdFuncionario);
      return await query.FirstOrDefaultAsync();
    }
  }
}
