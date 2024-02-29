using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Scarpe_Co.Models
{
    public class Scarpa
    {
        public int id_scarpa { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string imgCopertina { get; set; }

        public bool Disponibile { get; set; }
        public List<string> imgAggiuntive { get; set; }

        // Costruttore vuoto
        public Scarpa() { }

        // Costruttore con tutti parametri
        public Scarpa(int id_scarpa, string nome, decimal prezzo, string descrizione, string imgCopertina, bool disponibile)
        {
            this.id_scarpa = id_scarpa;
            Nome = nome;
            Prezzo = prezzo;
            Descrizione = descrizione;
            this.imgCopertina = imgCopertina;
            Disponibile = disponibile;
        }

        // Costruttore senza id_scarpa
        //public Scarpa(string nome, decimal prezzo, string descrizione, string imgCopertina, List<string> imgAggiuntive)
        //{
        //    Nome = nome;
        //    Prezzo = prezzo;
        //    Descrizione = descrizione;
        //    this.imgCopertina = imgCopertina;
        //    this.imgAggiuntive = imgAggiuntive;
        //}

        // Costruttore senza immagini aggiuntive
        public Scarpa(string nome, decimal prezzo, string descrizione, string imgCopertina)
        {
            Nome = nome;
            Prezzo = prezzo;
            Descrizione = descrizione;
            this.imgCopertina = imgCopertina;
        }

        // Metodo per ottenere una scarpa dal database tramite id
        // Riceve in input l'id della scarpa
        // Restituisce un oggetto Scarpa
        public static Scarpa GetScarpaById(int id)
        {
            // effettuo connessione al database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            Scarpa scarpa = new Scarpa();

            try
            {
                connection.Open();
                string query = "SELECT * FROM Scarpe WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // leggo i dati dal database e li inserisco in un oggetto Scarpa
                            scarpa = new Scarpa(reader["Nome"].ToString(), (decimal)reader["Prezzo"], reader["Descrizione"].ToString(), reader["imgCopertina"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // scrivi nel debug l'errore
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }

            return scarpa;
        }

        // Metodo per ottenere tutte le scarpe presenti nel database e restituirle in una lista
        // Non riceve nulla in input
        // Restituisce una lista di oggetti Scarpa
        public static List<Scarpa> GetScarpe()
        {
            // effettuo connessione al database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            List<Scarpa> scarpe = new List<Scarpa>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM Scarpe";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // leggo i dati dal database e li inserisco in una lista di oggetti Scarpe con anche disponibile
                            scarpe.Add(new Scarpa(
                                    (int)reader["id_scarpa"],
                                         reader["Nome"].ToString(),
                                (decimal)reader["Prezzo"],
                                         reader["Descrizione"].ToString(),
                                         reader["imgCopertina"].ToString(),
                                   (bool)reader["Disponibile"]));
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // scrivi nel debug l'errore
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return scarpe;

        }
    }
}
