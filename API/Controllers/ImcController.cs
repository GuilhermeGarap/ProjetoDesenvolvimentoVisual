namespace API.Controllers;
using API.data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/imc")]
[ApiController]
public class ImcController: ControllerBase {
    private readonly AppDataContext _context;

    public ImcController(AppDataContext context) =>
    _context = context;

//POST: api/imc/cadastrar
[HttpPost]
[Route("cadastrar")]
public IActionResult Cadastrar([FromBody] Imc imc) {
    try {
        Usuario? usuario = _context.Usuarios.Find(imc.UsuarioId);
        if(usuario == null) {
            return NotFound();
        }
        imc.Usuario = usuario;
        _context.Imcs.Add(imc);
        _context.SaveChanges();
        return Created("", imc);
    } 
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
    }

[HttpGet]
[Route("listar")]
public IActionResult Listar() {
    try 
    {
        List<Imc> imcs = _context.
        Imcs.
        Include(x=>x.Usuario).
        ToList();
        return Ok(imcs);
    } 
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}

[HttpPut]
[Route("alterar/{id}")]
public IActionResult Alterar([FromRoute] int id, [FromBody] Imc imc){
    try 
    {
        Imc? imcCadastrado = _context.Imcs.FirstOrDefault(x => x.ImcId == id);
        if(imcCadastrado != null){
            return NotFound();
        }
        Usuario? usuario = _context.Usuarios.Find(imcCadastrado.UsuarioId);
        if(usuario == null) {
            return NotFound();
        }
        imcCadastrado.Altura = imc.Altura;
        imcCadastrado.Peso = imc.Peso;
        imcCadastrado.UsuarioId = imc.UsuarioId;
        imcCadastrado.ImcCalculado = imc.ImcCalculado;

        _context.Imcs.Update(imcCadastrado);
        _context.SaveChanges();
        return Ok();   
    }
        catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}
    
}

