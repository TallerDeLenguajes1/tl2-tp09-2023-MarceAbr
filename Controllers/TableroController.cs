using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_MarceAbr.Models;
using tl2_tp09_2023_MarceAbr.Repositorios;

namespace tl2_tp09_2023_MarceAbr.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private ITableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost("Crear_Tablero")]
    public ActionResult<Tablero> CrearTablero(Tablero tablero)
    {
        tableroRepository.CrearTablero(tablero);
        return Ok(tablero);
    }

    [HttpPost("Listar_tableros")]
    public ActionResult<List<Tablero>> ListarTableros()
    {
        List<Tablero> tableros = tableroRepository.ListarTableros();
        if(tableros != null)
        {
            return Ok(tableros);
        } else {
            return NotFound();
        }
    }
}
