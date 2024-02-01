using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_MarceAbr.Models;
using tl2_tp09_2023_MarceAbr.Repositorios;

namespace tl2_tp09_2023_MarceAbr.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private ITareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost("Crear_Tarea")]
    public ActionResult<Tarea> CrearTarea(int idTablero, Tarea tarea) 
    {
        tareaRepository.CrearTarea(idTablero, tarea);
        return Ok(tarea);
    }

    [HttpPut("Modificar_Tarea")]
    public ActionResult<Tarea> ModificarTarea(int idTarea, Tarea tarea) 
    {
        tareaRepository.ModificarTarea(idTarea, tarea);
        return Ok(tarea);
    }

    [HttpPut("Modificar_Estado_Tarea")]
    public ActionResult<Tarea> ModificarEstadoTarea(int idTarea, Estado estado) 
    {
        Tarea tarea = tareaRepository.MostrarTareaPorId(idTarea);
        tarea.EstadoTarea = estado;
        tareaRepository.ModificarTarea(idTarea, tarea);
        return Ok();
    }

    [HttpDelete("Eliminar_tarea")]
    public ActionResult<Tarea> EliminarTarea(int idTarea) 
    {
        tareaRepository.EliminarTarea(idTarea);
        return Ok();
    }

    [HttpGet("Cantidad_Tarea_Por_Estado")]
    public ActionResult<Tarea> CantidadTareaPorEstado(Estado estado)
    {
        List<Tarea> tareas = tareaRepository.ListarTareas().FindAll(t => t.EstadoTarea == estado);
        if (tareas != null)
        {
            return Ok(tareas);
        } else {
            return NotFound();
        }
    }

    [HttpGet("Listar_Tarea_Por_Usuario")]
    public ActionResult<Tarea> ListarTareaPorUsuario(int idUsu)
    {
        List<Tarea> tareas = tareaRepository.ListarTareaPorUsuario(idUsu);
        if (tareas != null)
        {
            return Ok(tareas);
        } else {
            return NotFound();
        }
    }

    [HttpGet("Listar_Tarea_Por_Tablero")]
    public ActionResult<Tarea> ListarTareaPorTablero(int idTab)
    {
        List<Tarea> tareas = tareaRepository.ListarTareasPorTablero(idTab);
        if (tareas != null)
        {
            return Ok(tareas);
        } else {
            return NotFound();
        }
    }

    [HttpGet("Listar_Todas_las_tareas")]
    public ActionResult<Tarea> ListarTodasLasTarea()
    {
        List<Tarea> tareas = tareaRepository.ListarTareas();
        if (tareas != null)
        {
            return Ok(tareas);
        } else {
            return NotFound();
        }
    }
}
