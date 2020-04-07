using BlazorApp1.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlazorApp1.Context.Repositories
{
    #region Interfaz
    /// <summary>
    /// Interfaz con los metodos
    /// </summary>
    public interface IPeliculasRepository
    {
        Task<IEnumerable<Peliculas>> GetAll();
        Task<IEnumerable<Peliculas>> GetDetail(int id);
        Task<bool> Insert(Peliculas pelicula);
        Task<bool> Update(Peliculas pelicula);
        Task<bool> Delete(Peliculas pelicula);

    }
    #endregion Interfaz



    /// <summary>
    /// Clase con la implementacion
    /// </summary>
    public class PeliculasRepository : IPeliculasRepository
    {
        private readonly IConfiguration _configuration;

        public PeliculasRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected SqlConnection ConexionDB()
        {
            return new SqlConnection(_configuration.GetConnectionString("Contexto"));

        }
        public Task<bool> Delete(Peliculas pelicula)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Peliculas>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Peliculas>> GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(Peliculas pelicula)
        {
            var Db = ConexionDB();
            var sql = @" INSERT INTO Peliculas (Titulo ,Director ,Fecha) VALUES (@Titulo, @Director ,@Fecha)";
            var result = await Db.ExecuteAsync(sql.ToString(), new
            {
                pelicula.Titulo,
                pelicula.Director,
                pelicula.Fecha
            });
            return (result > 0);
        }

        public Task<bool> Update(Peliculas pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
