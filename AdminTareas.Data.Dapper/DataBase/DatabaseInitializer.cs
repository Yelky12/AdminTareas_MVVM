using Microsoft.Data.Sqlite;

namespace AdminTareas.Data.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string connectionString)
        {
            using var cn = new SqliteConnection(connectionString);
            cn.Open();

           
            using (var pragma = cn.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            var sql = @"

            CREATE TABLE IF NOT EXISTS Prioridades (
                Id INTEGER PRIMARY KEY,
                Nombre TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Estados (
                Id INTEGER PRIMARY KEY,
                Nombre TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Tarea (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Descripcion TEXT NOT NULL,
                Usuario TEXT NOT NULL,
                EstadoId INTEGER NOT NULL,
                PrioridadId INTEGER NOT NULL,
                FechaCompromiso TEXT NOT NULL,
                Notas TEXT,

                FOREIGN KEY (EstadoId) REFERENCES Estados(Id),
                FOREIGN KEY (PrioridadId) REFERENCES Prioridades(Id)
            );
            ";

            using var cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            InsertarDatosIniciales(cn);
        }

        private static void InsertarDatosIniciales(SqliteConnection cn)
        {
            var sql = @"

            INSERT OR IGNORE INTO Estados (Id, Nombre) VALUES (1, 'Pendiente');
            INSERT OR IGNORE INTO Estados (Id, Nombre) VALUES (2, 'En Proceso');
            INSERT OR IGNORE INTO Estados (Id, Nombre) VALUES (3, 'Terminada');

            INSERT OR IGNORE INTO Prioridades (Id, Nombre) VALUES (1, 'Baja');
            INSERT OR IGNORE INTO Prioridades (Id, Nombre) VALUES (2, 'Media');
            INSERT OR IGNORE INTO Prioridades (Id, Nombre) VALUES (3, 'Alta');
            ";

            using var cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}