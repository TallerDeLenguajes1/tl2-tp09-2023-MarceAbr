using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_MarceAbr.Models;
using tl2_tp09_2023_MarceAbr.Repositorios;

namespace tl2_tp09_2023_MarceAbr.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("Crear_Usuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usu)
    {
        usuarioRepository.CrearUsuario(usu);
        return Ok(usu);
    }

    [HttpGet("Mostrar_Usuarios")]
    public ActionResult<List<Usuario>> GetUsuarios()
    {
        List<Usuario> usuarios = usuarioRepository.ListarUsuarios();
        if (usuarios != null)
        {
            return Ok(usuarios);
        } else {
            return NotFound();
        }
    }

    [HttpGet("Mostrar_usuario_por_ID")]
    public ActionResult<List<Usuario>> GetUsuariosPorID(int id)
    {
        Usuario usuario = usuarioRepository.MostrarUsuario(id);
        if(usuario != null)
        {
            return Ok(usuario);
        } else {
            return NotFound();
        }
    }

    [HttpPut("Cambiar_nombre_usuario")]
    public ActionResult<Usuario> ModificarNombreUsuario(int id, string nombre)
    {
        Usuario usuario = usuarioRepository.MostrarUsuario(id);
        usuario.NombreDeUsuario = nombre;

        usuarioRepository.ModificarUsuario(id, usuario);
        return Ok(usuario);
    }
}
