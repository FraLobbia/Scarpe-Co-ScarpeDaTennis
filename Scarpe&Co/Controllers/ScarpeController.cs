using Scarpe_Co.Models;
using System;
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
            List<Scarpa> scarpe = Scarpa.GetScarpe();
            return View(scarpe);
        }

        public ActionResult Vetrina()
        {
            List<Scarpa> scarpe = Scarpa.GetScarpe();
            return View(scarpe);
        }

        // GET: Scarpe/Details/5
        public ActionResult Details(int id)
        {
            Scarpa scarpa = Scarpa.GetScarpaById(id);
            return View(scarpa);
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
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Scarpa scarpa = Scarpa.GetScarpaById(id);
            return View(scarpa);
        }

        // POST: Scarpe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Scarpa formScarpa)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            // Ottengo i dati dal form
            string Nome = formScarpa.Nome;
            decimal Prezzo = formScarpa.Prezzo;
            string Descrizione = formScarpa.Descrizione;
            string imgCopertina = formScarpa.imgCopertina;

            // e l'id dal parametro
            int id_Scarpa = id;

            // Ottengo l'oggetto Scarpa 
            Scarpa scarpa = Scarpa.GetScarpaById(id_Scarpa);
            //ottengo l'id dell'employee
            int id_Employee = scarpa.id_scarpa;

            try
            {
                // Apro la connessione
                conn.Open();

                // Creo il comando SQL
                SqlCommand cmd = new SqlCommand("UPDATE Scarpe SET " +
                    "Nome = @Nome," +
                    " Prezzo = @Prezzo," +
                    " Descrizione = @Descrizione," +
                    " imgCopertina = @imgCopertina" +
                    " WHERE id = @id", conn);

                // Aggiungo i parametri
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Prezzo", Prezzo);
                cmd.Parameters.AddWithValue("@Descrizione", Descrizione);
                cmd.Parameters.AddWithValue("@imgCopertina", imgCopertina);
                cmd.Parameters.AddWithValue("@id", id_Scarpa);



                // Eseguo il comando SQL
                cmd.ExecuteNonQuery();

                // Gestione dell'eccezione
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            // Ritorno alla vista Index dopo aver eseguito l'update
            return RedirectToAction("Index");
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
