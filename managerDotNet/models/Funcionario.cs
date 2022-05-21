namespace TestWebAPI.models
{
  public class Funcionario 
  {
  public Funcionario() {  }

  public Funcionario(int id, string nome, string foto, string rg, int idDepartamento)
  {
    this.Id = id;
    this.Nome = nome;
    this.Foto = foto;
    this.Rg = rg;

    this.IdDepartamento = idDepartamento;
  }
      public int Id { get; set; } 
      public string Nome { get; set; } 
      public string Foto { get; set; } 
      public string Rg { get; set; } 

      public int IdDepartamento { get; set; } 
      public Departamento Departamento { get; set; } 
  }

}