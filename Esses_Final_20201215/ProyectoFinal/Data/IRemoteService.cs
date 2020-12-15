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

        [Delete("/Usuario/{id}")]
        Task<Usuario> BorrarUsuario(int id);

        /****** RECURSO *****/

        [Get("/Recurso")]
        Task<List<Recurso>> GetAllRecursos();

        [Get("/Recurso/{id}")]
        Task<Recurso> GetRecurso(int id);

        [Post("/Recurso")]
        Task<Recurso> GuardarRecurso(Recurso valor);

        [Delete("/Recurso/{id}")]
        Task<Recurso> BorrarRecurso(int id);

        /****** TAREA *****/

        [Get("/Tarea")]
        Task<List<Tarea>> GetAllTareas();

        [Get("/Tarea/{id}")]
        Task<Tarea> GetTarea(int id);

        [Post("/Tarea")]
        Task<Tarea> GuardarTarea(Tarea valor);

        [Delete("/Tarea/{id}")]
        Task<Tarea> BorrarTarea(int id);

        /****** DETALLE *****/

        [Get("/Detalle")]
        Task<List<Detalle>> GetAllDetalles();

        [Get("/Detalle/{id}")]
        Task<Detalle> GetDetalle(int id);

        [Get("/Detalle/Filtro/{id}")]
        Task<List<Detalle>> GetDetalleTarea(int id);

        [Post("/Detalle")]
        Task<Detalle> GuardarDetalle(Detalle valor);

        [Delete("/Detalle/{id}")]
        Task<Detalle> BorrarDetalle(int id);
    }
}
