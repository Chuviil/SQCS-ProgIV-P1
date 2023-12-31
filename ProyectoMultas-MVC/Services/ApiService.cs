﻿using ProyectoMultas.Models;

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

    public async Task<Profesor?> IniciarSesion(ProfesorLoginDto? profesor)
    {
        var response = await _client.PostAsJsonAsync("/api/Profesor/login", profesor);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Profesor>();
        }

        return null;
    }

    public async Task<Profesor?> Registrar(Profesor? profesor)
    {
        var response = await _client.PostAsJsonAsync("/api/Profesor/registro", profesor);

        if (response.IsSuccessStatusCode)
        {
            profesor = await response.Content.ReadFromJsonAsync<Profesor>();

            return profesor;
        }

        return null;
    }

    public async Task<List<Ayudante>?> ObtenerAyudantes()
    {
        var response = await _client.GetFromJsonAsync<List<Ayudante>>("api/Ayudante");

        if (response != null)
        {
            return response;
        }

        return null;
    }

    public async Task<Ayudante?> ObtenerAyudante(string idBanner)
    {
        var ayudante = await _client.GetFromJsonAsync<Ayudante>($"api/Ayudante/{idBanner}");

        if (ayudante != null) return ayudante;

        return null;
    }

    public async Task<Multa?> ObtenerMulta(int multaId)
    {
        var multa = await _client.GetFromJsonAsync<Multa>($"api/Multa/{multaId}");

        if (multa != null) return multa;

        return null;
    }

    public async Task<List<Multa>?> ObtenerMultasPorId(string idBanner)
    {
        var response = await _client.GetFromJsonAsync<List<Multa>>($"api/Ayudante/{idBanner}/multas");

        if (response != null)
        {
            return response;
        }

        return null;
    }

    public async Task<Profesor?> ActualizarProfesor(string idBanner, Profesor? profesor, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        
        var response = await _client.PutAsJsonAsync($"api/Profesor/{idBanner}", profesor);

        profesor = await response.Content.ReadFromJsonAsync<Profesor>();

        if (profesor != null) return profesor;

        return null;
    }

    public async Task ActualizarAyudante(string idBanner, Ayudante? ayudante, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        
        await _client.PutAsJsonAsync($"api/Ayudante/{idBanner}", ayudante);
    }

    public async Task ActualizarMulta(int multaId, Multa? multa, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        await _client.PutAsJsonAsync($"api/Multa/{multaId}", multa);
    }

    public async Task EliminarProfesor(string idBanner, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        await _client.DeleteAsync($"api/Profesor/{idBanner}");
    }

    public async Task EliminarAyudante(string idBanner, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        await _client.DeleteAsync($"api/Ayudante/{idBanner}");
    }

    public async Task EliminarMulta(int multaId, string token)
    {    
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        await _client.DeleteAsync($"api/Multa/{multaId}");
    }

    public async Task CrearAyudante(Ayudante? ayudante, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}" );
        await _client.PostAsJsonAsync("/api/Ayudante", ayudante);
    }

    public async Task CrearMulta(Multa? multa, string token)
    {
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        await _client.PostAsJsonAsync("/api/Multa", multa);
    }
}