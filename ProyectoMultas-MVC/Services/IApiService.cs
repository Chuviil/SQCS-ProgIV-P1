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
    
    Task<Profesor?> ActualizarProfesor(string idBanner, Profesor? profesor);
    Task ActualizarAyudante(string idBanner, Ayudante? ayudante);
    Task ActualizarMulta(int multaId, Multa? multa);
    Task EliminarProfesor(string idBanner);
    Task EliminarAyudante(string idBanner);
    Task EliminarMulta(int multaId);
    
    Task CrearAyudante(Ayudante? ayudante);
    Task CrearMulta(Multa? multa);
}