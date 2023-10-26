using ProyectoMultas.Models;

namespace ProyectoMultas.Services;

public interface IApiService
{
    Task<Profesor?> IniciarSesion(Profesor? profesor);

    Task<Profesor?> Registrar(Profesor profesor);
}