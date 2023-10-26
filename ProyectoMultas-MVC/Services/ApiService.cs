using ProyectoMultas.Models;

namespace ProyectoMultas.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _client;

    public ApiService(IConfiguration configuration)
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri(configuration["Api:Url"])
        };
    }

    public async Task<Profesor?> IniciarSesion(Profesor? profesor)
    {
        var response = await _client.PostAsJsonAsync("/api/Profesor/inicio", profesor);
        
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        profesor = await response.Content.ReadFromJsonAsync<Profesor>();

        return profesor;
    }

    public async Task<Profesor?> Registrar(Profesor? profesor)
    {
        var response = await _client.PostAsJsonAsync("/api/Profesor/registro", profesor);
        
        profesor = await response.Content.ReadFromJsonAsync<Profesor>();

        return profesor;
    }
}