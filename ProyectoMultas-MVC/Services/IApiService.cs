using ProyectoMultas.Models;

namespace ProyectoMultas.Services;

public interface IApiService
{
    Task<Profesor?> IniciarSesion(ProfesorLoginDto profesor);

    Task<Profesor?> Registrar(Profesor profesor);
    
    Task<List<Ayudante>?> ObtenerAyudantes();
    Task<Ayudante?> ObtenerAyudante(string idBanner);
    
    Task<List<Multa>?> ObtenerMultasPorId(string idBanner);
    
    Task<Profesor?> ActualizarProfesor(string idBanner, Profesor? profesor);
    Task ActualizarAyudante(string idBanner, Ayudante? ayudante);
    Task EliminarProfesor(string idBanner);
    Task EliminarAyudante(string idBanner);
    
    Task CrearAyudante(Ayudante? ayudante);
    Task CrearMulta(Multa? multa);
}