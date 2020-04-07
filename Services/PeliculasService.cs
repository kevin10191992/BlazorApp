using BlazorApp1.Context.Repositories;
using BlazorApp1.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    #region interfaz
    public interface IPeliculasService
    {
        Task<IEnumerable<Peliculas>> GetAll();
        Task<IEnumerable<Peliculas>> GetDetail(int id);
        Task<bool> Save(Peliculas pelicula);
    }
    #endregion interfaz
    /// <summary>
    /// Implementacion IPeliculasService
    /// </summary>
    public class PeliculasService : IPeliculasService
    {
        private IPeliculasRepository _PeliculasRepository;
        private readonly IConfiguration _configuration;
        public PeliculasService(IConfiguration configuration, IPeliculasRepository peliculasRepository)
        {
            _configuration = configuration;
            _PeliculasRepository = peliculasRepository;
        }
        public Task<IEnumerable<Peliculas>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Peliculas>> GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save(Peliculas pelicula)
        {
            if (pelicula.PeliculasId == 0)
            {
                return await _PeliculasRepository.Insert(pelicula);
            }
            else return false;
        }
    }
}
