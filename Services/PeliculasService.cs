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
        Task<Peliculas> GetDetail(int id);
        Task<bool> Save(Peliculas pelicula);
        Task<bool> Delete(int id);
    }
    #endregion interfaz
    /// <summary>
    /// Implementacion IPeliculasService
    /// </summary>
    public class PeliculasService : IPeliculasService
    {
        private IPeliculasRepository _PeliculasRepository;
        public PeliculasService(IPeliculasRepository peliculasRepository)
        {
            _PeliculasRepository = peliculasRepository;
        }
        public async Task<IEnumerable<Peliculas>> GetAll()
        {
            return await _PeliculasRepository.GetAll();
        }

        public async Task<Peliculas> GetDetail(int id)
        {
            return await _PeliculasRepository.GetDetail(id);
        }

        public async Task<bool> Save(Peliculas pelicula)
        {
            if (pelicula.PeliculasId == 0)
            {
                return await _PeliculasRepository.Insert(pelicula);
            }
            else return await _PeliculasRepository.Update(pelicula);
        }

        public async Task<bool> Delete(int id)
        {
            return await _PeliculasRepository.Delete(id);
        }
    }
}
