using System.Data.SQLite;
using Newtonsoft.Json;
class Program{
    static string pathdb = @"C:\Users\Pozzame\Documents\Corso_2024\Biblioteca\database.db";
    static string pathlibri = @"C:\Users\Pozzame\Documents\Corso_2024\Biblioteca\Libri";
    static string pathutenti = @"C:\Users\Pozzame\Documents\Corso_2024\Biblioteca\Utenti";

static void Main(string[] args)
    {
        if (!File.Exists(pathdb))
        {
            SQLiteConnection.CreateFile(pathdb);
            SQLiteConnection connection = new SQLiteConnection($"Data Source={pathdb};Versione=3;");
            connection.Open();
            string sql = @"CREATE TABLE prodotti 
            (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                nome TEXT UNIQUE, 
                prezzo real not null, 
                quantita integer check (quantita >=0), 
                stato bolean, 
                scadenza date, 
                id_categoria integer, 
                foreign key (id_categoria) 
                    references categorie (id)
            );
            CREATE TABLE categorie 
            (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                nome TEXT UNIQUE,
                descrizione text
            );
            INSERT INTO categorie (nome, descrizione) 
                VALUES ('Carne', 'La carne');
            INSERT INTO categorie (nome, descrizione) 
                VALUES ('Pesce', 'Il pesce');
            INSERT INTO categorie (nome, descrizione) 
                VALUES ('Formaggi', 'Il pesce');
            INSERT INTO prodotti (nome, prezzo, quantita, stato, scadenza, id_categoria) 
                VALUES ('Simmental', 10, 100, true, '2026-12-12', 1);
            INSERT INTO prodotti (nome, prezzo, quantita, stato, scadenza, id_categoria) 
                VALUES ('Riomare', 20, 200, true, '2025-12-12', 2);
            INSERT INTO prodotti (nome, prezzo, quantita, stato, scadenza, id_categoria) 
                VALUES ('Manzotin', 10, 100, true, '2026-12-12', 1);
            INSERT INTO prodotti (nome, prezzo, quantita, stato, scadenza, id_categoria) 
                VALUES ('Babybel', 5, 500, true, '2025-12-12', 3);
            ";

            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}