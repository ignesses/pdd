using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ProyectoFinal.Data
{
    public interface IRemoteService
    {
        /****** USUARIO *****/

        [Get("/Usuario")]
        Task<List<Usuario>> GetAllUsuarios();

        [Get("/Usuario/{id}")]
        Task<Usuario> GetUsuario(int id);

        [Post("/Usuario")]
        Task<Usuario> GuardarUsuario(Usuario valor);

        /****** RECURSO *****/

        [Get("/Recurso")]
        Task<List<Recurso>> GetAllRecursos();

        [Get("/Recurso/{id}")]
        Task<Recurso> GetRecurso(int id);

        [Post("/Recurso")]
        Task<Recurso> GuardarRecurso(Recurso valor);

        /****** TAREA *****/

        [Get("/Tarea")]
        Task<List<Tarea>> GetAllTareas();

        [Get("/Tarea/{id}")]
        Task<Tarea> GetTarea(int id);

        [Post("/Tareas")]
        Task<Tarea> GuardarTarea(Tarea valor);

        /****** DETALLE *****/

        [Get("/Detalle")]
        Task<List<Detalle>> GetAllDetalles();

        [Get("/Detalle/{id}")]
        Task<Detalle> GetDetalle(int id);

        [Post("/Detalle")]
        Task<Detalle> GuardarDetalle(Detalle valor);
    }
}
