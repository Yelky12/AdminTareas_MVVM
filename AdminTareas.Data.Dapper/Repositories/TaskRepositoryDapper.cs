using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using AdminTareas.Data.Abstractions.Interfaces;
using AdminTareas.Models.Models;


namespace AdminTareas.Data.Dapper.Repositories
{
    public class TaskRepositoryDapper : ITareaRepository
    {
        private readonly string _connectionString;

        public TaskRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqliteConnection GetConnection()
            => new(_connectionString);

        // 🔹 Obtener todas ordenadas por FechaCompromiso
        public IEnumerable<Tarea> GetAll()
        {
            using var cn = GetConnection();

            //    var sql = @"
            //    SELECT 
            //        Id,
            //        Descripcion,
            //        Usuario,
            //        EstadoId,
            //        PrioridadId,
            //        FechaCompromiso,
            //        Notas
            //    FROM Tarea
            //    ORDER BY FechaCompromiso
            //";


            var sql = @"
            SELECT 
                t.Id,
                t.Descripcion,
                t.Usuario,
                t.EstadoId,
                e.Nombre AS EstadoNombre,
                t.PrioridadId,
                p.Nombre AS PrioridadNombre,
                t.FechaCompromiso,
                t.Notas
            FROM Tarea t
            INNER JOIN Prioridades p ON t.PrioridadId = p.Id
            INNER JOIN Estados e ON t.EstadoId = e.Id
            ORDER BY t.FechaCompromiso

        ";


            return cn.Query<Tarea>(sql);
        }

        public Tarea? GetById(int id)
        {
            using var cn = GetConnection();

            return cn.QueryFirstOrDefault<Tarea>(
                "SELECT * FROM Tarea WHERE Id = @Id",
                new { Id = id });
        }

        public void Add(Tarea task)
        {
            using var cn = GetConnection();

            var sql = @"
            INSERT INTO Tarea
            (Descripcion, Usuario, EstadoId, PrioridadId, FechaCompromiso, Notas)
            VALUES
            (@Descripcion, @Usuario, @EstadoId, @PrioridadId, @FechaCompromiso, @Notas);
        ";

            cn.Execute(sql, task);
        }

        public void Update(Tarea task)
        {
            using var cn = GetConnection();

            var sql = @"
            UPDATE Tarea SET
                Descripcion = @Descripcion,
                Usuario = @Usuario,
                EstadoId = @EstadoId,
                PrioridadId = @PrioridadId,
                FechaCompromiso = @FechaCompromiso,
                Notas = @Notas
            WHERE Id = @Id
        ";

            cn.Execute(sql, task);
        }

        public void Delete(int id)
        {
            using var cn = GetConnection();

            cn.Execute("DELETE FROM Tarea WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<Tarea> GetFiltered(TareaEstado? estado,TareaPrioridad? prioridad,string? usuario)
        {
            using var cn = GetConnection();

            var sql = @"SELECT 
                    t.Id,
                    t.Descripcion,
                    t.Usuario,
                    t.EstadoId,
                    e.Nombre AS EstadoNombre,
                    t.PrioridadId,
                    p.Nombre AS PrioridadNombre,
                    t.FechaCompromiso,
                    t.Notas
                FROM Tarea t
                INNER JOIN Prioridades p ON t.PrioridadId = p.Id
                INNER JOIN Estados e ON t.EstadoId = e.Id
                WHERE 1=1";

            if (estado.HasValue)
                sql += " AND t.EstadoId = @EstadoId";

            if (prioridad.HasValue)
                sql += " AND t.PrioridadId = @PrioridadId";

            if (!string.IsNullOrWhiteSpace(usuario))
                sql += " AND t.Usuario = @Usuario";

            sql += " ORDER BY t.FechaCompromiso";

            return cn.Query<Tarea>(sql, new
            {
                EstadoId = estado.HasValue ? (int?)estado.Value : null,
                PrioridadId = prioridad.HasValue ? (int?)prioridad.Value : null,
                Usuario = !string.IsNullOrWhiteSpace(usuario) ? $"{usuario}" : null
            });
        }
    }
}
