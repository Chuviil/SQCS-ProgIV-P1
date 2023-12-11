using ProyectoMultas.Models;

namespace ProyectoMultas.Services;

public interface IApiService
{
    Task<Profesor?> IniciarSesion(ProfesorLoginDto profesor);

    Task<Profesor?> Registrar(Profesor profesor);
    
    Task<List<Ayudante>?> ObtenerAyudantes();
    Task<Ayudante?> ObtenerAyudante(string idBanner);
    Task<Multa?> ObtenerMulta(int idMulta);
    
    Task<List<Multa>?> ObtenerMultasPorId(string idBanner);
    
    Task<Profesor?> ActualizarProfesor(string idBanner, Profesor? profesor, string token);
    Task ActualizarAyudante(string idBanner, Ayudante? ayudante, string token);
    Task ActualizarMulta(int multaId, Multa? multa, string token);
    Task EliminarProfesor(string idBanner, string token);
    Task EliminarAyudante(string idBanner, string token);
    Task EliminarMulta(int multaId, string token);
    
    Task CrearAyudante(Ayudante? ayudante, string token);
    Task CrearMulta(Multa? multa, string token);
}