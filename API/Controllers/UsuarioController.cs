namespace API.Controllers;
using API.data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/usuario")]
[ApiController]
public class CategoriaController: ControllerBase {
    private readonly AppDataContext _context;

    public CategoriaController(AppDataContext context) =>
    _context = context;

//POST: api/usuario/cadastrar
[HttpPost]
[Route("cadastrar")]
public IActionResult Cadastrar([FromBody] Usuario usuario) {
    try {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Created("", usuario);
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
        List<Usuario> usuarios = _context.
        Usuarios.
        ToList();
        return Ok(usuarios);
    } 
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}
}
