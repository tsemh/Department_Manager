using System.Collections.Generic;

namespace TestWebAPI.models
{
  public class Departamento
  {
    public Departamento() {  }

    public Departamento(int id, string nome, string sigla)
    {
      this.Id = id;
      this.Nome = nome;
      this.Sigla = sigla;

    }

      public int Id { get; set; } 
      public string Nome { get; set; }
      public string Sigla { get; set; }

      public IEnumerable<Funcionario> Funcionarios { get; set; }
  }
}