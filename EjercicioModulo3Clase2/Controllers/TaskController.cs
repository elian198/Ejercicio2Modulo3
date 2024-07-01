using EjercicioModulo3Clase2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EjercicioModulo3Clase2.Services.Interfaces;

namespace EjercicioModulo3Clase2.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Pasos previos
        /*
         * 1 - Instalar EF Core y EF Core SQL Server
         * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
         * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
         * 4 - Las rutas de los endpoints queda a criterio de cada uno.
         * 5 - En este controlador, realizar los siguientes ejercicios:
         */
        #endregion
        private ITasksService _clienteService;

        public TaskController(ITasksService clienteService)
        {
            _clienteService = clienteService;
        }

        #region Ejercicio 1
        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET
        [HttpGet]
        public ActionResult getTask()
        {
            return Ok(_clienteService.getTasks());
        }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        [HttpGet("/{id}")]
        public ActionResult getTaskById([FromRoute] int id)
        {
            return Ok(_clienteService.getTaskById(id));
        }
        #endregion

        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST
        [HttpPost]
        public ActionResult saveTask([FromBody] Tasks task)
        {
            _clienteService.saveTask(task);
            return Ok();
        }
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("/completar/{id}")]
        public ActionResult putCompleteTask([FromRoute] int id)
        { 
            return Ok(_clienteService.putCompleteTask(id));                                                         
        }
        #endregion

        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        [HttpPut ( "/baja/{id}" )]
        public ActionResult putDarBaja([FromRoute] int id)

        {
            return Ok(_clienteService.putDarBaja(id));
        }       
    }
    #endregion
}
