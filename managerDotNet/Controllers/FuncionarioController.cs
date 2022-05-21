using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data;
using TestWebAPI.models;

namespace TestWebAPI.controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class FuncionarioController : ControllerBase
  {
    private readonly IRepository _repo;
    public FuncionarioController(IRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("ByDepartamento/{IdDepartamento}")]

    public async Task<IActionResult> GetByIdDepartamento(int IdDepartamento)
    {
      try
      {
        var result = await _repo.GetFuncionariosAsyncByIdDepartamento(IdDepartamento, true);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
    }

    [HttpPost("ByDepartamento/{IdDepartamento}")]
    public async Task<IActionResult> postFuncionariosAsyncByIdDepartamento(int idDepartamento, Funcionario model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }

    [HttpPut("{IdFuncionario}")]
    public async Task<IActionResult> put(int IdFuncionario, Funcionario model)
    {
      try
      {
        var funcionario = await _repo.GetFuncionarioAsyncById(IdFuncionario);
        if (funcionario == null) return NotFound("Funcionario não encontrado");

        _repo.Update(model);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }

    [HttpDelete("{IdFuncionario}")]
    public async Task<IActionResult> delete(int IdFuncionario)
    {
      try
      {
        var funcionario = await _repo.GetFuncionarioAsyncById(IdFuncionario);
        if (funcionario == null) return NotFound();

        _repo.Delete(funcionario);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(new { message = "Departamento Deletado" });
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }
  }
}