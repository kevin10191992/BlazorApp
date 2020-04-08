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
        Task<Peliculas> GetDetail(int id);
        Task<bool> Insert(Peliculas pelicula);
        Task<bool> Update(Peliculas pelicula);
        Task<bool> Delete(int id);

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
        public async Task<bool> Delete(int id)
        {
            var Db = ConexionDB();
            var sql = @" delete FROM Peliculas where PeliculasId=@PeliculasId";
            var result = await Db.ExecuteAsync(sql.ToString(), new { PeliculasId = id });
            return (result > 0);
        }

        public async Task<IEnumerable<Peliculas>> GetAll()
        {
            var Db = ConexionDB();
            var sql = @" SELECT * FROM Peliculas";

            return await Db.QueryAsync<Peliculas>(sql.ToString());
        }

        public async Task<Peliculas> GetDetail(int id)
        {
            var Db = ConexionDB();
            var sql = @" SELECT * FROM Peliculas where PeliculasId=@PeliculasId";

            return await Db.QueryFirstOrDefaultAsync<Peliculas>(sql.ToString(), new { PeliculasId = id });
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

        public async Task<bool> Update(Peliculas pelicula)
        {
            var Db = ConexionDB();
            var sql = @" update Peliculas 
                                set Titulo=@Titulo ,Director=@Director ,Fecha=@Fecha 
                                    where PeliculasId=@PeliculasId";

            var result = await Db.ExecuteAsync(sql.ToString(), new
            {
                pelicula.Titulo,
                pelicula.Director,
                pelicula.Fecha,
                pelicula.PeliculasId
            });
            return (result > 0);
        }
    }
}
