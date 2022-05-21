using System.Threading.Tasks;
using TestWebAPI.models;


namespace TestWebAPI.Data
{
   public interface IRepository 
   {
       
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

      
        Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario = true);
        Task<Departamento> GetDepartamentoAsyncById(int IdDepartamento,  bool includeFuncionario = true);

        Task<Funcionario[]> GetFuncionariosAsyncByIdDepartamento(int IdDepartamento, bool includeFuncionario = true);
        Task<Funcionario> GetFuncionarioAsyncById(int IdFuncionario);
   }
}