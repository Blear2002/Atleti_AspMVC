using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atleti_AspMVC.Models;

namespace Atleti_AspMVC.Controllers
{
    public class LoginController : Controller
    {
        SqlCommand comando;
        string connString;

        // GET: Login
        [Route("Login/Index")]
        public ActionResult Index()
        {
            return View();
        }

        //post: login

        [HttpPost]
        public ActionResult Index(UserLoginData user)
        {
            #region password
            connString = "Server=DESKTOP-QJEETFU\\SQLEXPRESSNEW;Database=Olympics;User Id=sa;Password=albania4Ever";
            #endregion //non andrebbe salvato così

            if (user == null || user.Password == null || String.IsNullOrEmpty(user.UserName) || String.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction("Index");
            }
            else
            {
                using (SqlConnection connessione = new SqlConnection(connString))
                {
                    int righe = 0;
                    connessione.Open();
                    string query = "SELECT * FROM Users Where UserName = @username AND Password = @password";
                    comando = new SqlCommand(query, connessione);
                    comando.Parameters.AddWithValue("@username", user.UserName);
                    comando.Parameters.AddWithValue("@password", user.Password);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return RedirectToAction("Index", "Athletes");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    connessione.Close();
                }
            }
        }
    }
}