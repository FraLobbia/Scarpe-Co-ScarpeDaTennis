using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

public class AccountController : Controller
{
    // GET: /Account/Login
    public ActionResult Login()
    {

        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model)
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            string query = "SELECT * FROM Utenti WHERE username = @Username AND password = @Password";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", model.Username);
                command.Parameters.AddWithValue("@Password", model.Password);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // se reader restituisce almeno una riga, quindi vero l'utente è autenticato
                        // questo perchè la query seleziona tutti i campi dell'utente che ha username e password uguali a quelli inseriti
                        // quindi imposta la sessione con il tipo di utente
                        Session["permission"] = reader["TipoUtente"].ToString();
                        // scrivi nel debug la tipologia di utente
                        System.Diagnostics.Debug.WriteLine(Session["permission"]);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // L'utente non è autenticato
                        ModelState.AddModelError("", "Username o password non validi.");
                        return View(model);
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            ModelState.AddModelError("", "Errore durante l'autenticazione: " + ex.Message);
            return View(model);
        }
        finally
        {
            connection.Close();
        }


    }
}
