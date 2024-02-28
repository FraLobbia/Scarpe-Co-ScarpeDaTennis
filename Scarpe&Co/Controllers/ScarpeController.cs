using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Scarpe_Co.Controllers
{
    public class ScarpeController : Controller
    {
        // GET: Scarpe
        public ActionResult Index()
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
                            // leggo i dati dal database e li inserisco in una lista di oggetti Scarpe

                            scarpe.Add(new Scarpa(reader["Nome"].ToString(), (decimal)reader["Prezzo"], reader["Descrizione"].ToString(), reader["imgCopertina"].ToString()));
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // scrivi nel debug l'errore
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                connection.Close();
            }


            return View(scarpe);
        }

        public ActionResult Vetrina()
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
                            // leggo i dati dal database e li inserisco in una lista di oggetti Scarpe

                            scarpe.Add(new Scarpa(reader["Nome"].ToString(), (decimal)reader["Prezzo"], reader["Descrizione"].ToString(), reader["imgCopertina"].ToString()));
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // scrivi nel debug l'errore
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                connection.Close();
            }


            return View(scarpe);
        }

        // GET: Scarpe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Scarpe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scarpe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scarpe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Scarpe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scarpe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scarpe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
