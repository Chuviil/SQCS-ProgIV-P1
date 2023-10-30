using ProyectoMultas.Models;

namespace ProyectoMultas.Services;

public interface IApiService
{
    Task<Profesor?> IniciarSesion(ProfesorLoginDto profesor);

    Task<Profesor?> Registrar(Profesor profesor);
    
    Task<List<Ayudante>?> ObtenerAyudantes();
    
    Task<List<Multa>?> ObtenerMultasPorId(string idBanner);
    
    Task<Profesor?> ActualizarProfesor(string idBanner, Profesor? profesor);
    Task EliminarProfesor(string idBanner);
    
    Task CrearAyudante(Ayudante? ayudante);
}