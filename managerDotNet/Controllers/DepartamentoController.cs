using System;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data;
using System.Threading.Tasks;
using TestWebAPI.models;

namespace TestWebAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]

  public class DepartamentoController : ControllerBase
  {

    private readonly IRepository _repo;
    public DepartamentoController(IRepository repo)
    {
      _repo = repo;
    }

    [HttpGet()]
    public async Task<IActionResult> Get() 
    {
      try
      {
        var result = await _repo.GetAllDepartamentosAsync(true);
        return Ok(result);
      }
      catch(Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
    }

        [HttpPost]
    public async Task<IActionResult> post(Departamento model)
    {
      try
      {
        _repo.Add(model);
        if(await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }
        [HttpPut("{IdDepartamento}")]
    public async Task<IActionResult> put(int IdDepartamento, Departamento model)
    {
      try
      {
        var departamento = await _repo.GetDepartamentoAsyncById(IdDepartamento, false);
        if(departamento == null) return NotFound("Departamento não encontrado");

        _repo.Update(model);
        
        if(await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }

        [HttpDelete("{IdDepartamento}")]
    public async Task<IActionResult> delete(int IdDepartamento)
    {
      try
      {
        var departamento = await _repo.GetDepartamentoAsyncById(IdDepartamento);
        if(departamento == null) return NotFound();

        _repo.Delete(departamento);

        if(await _repo.SaveChangesAsync())
        {
          return Ok(new { message = "Departamento Deletado" });
        }
      }catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }

  }
}