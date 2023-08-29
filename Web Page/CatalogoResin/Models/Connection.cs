using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CatalogoResin.Models
{
    public class Connection
    {
        private string Base;
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Clave;
        private static Connection Con = null;

        private Connection()
        {
            this.Base = "resinotaku";
            this.Servidor = "localhost";
            this.Puerto = "3306";
            this.Usuario = "root";
            this.Clave = "95696675";

        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection conString = new MySqlConnection();

            try
            {
                conString.ConnectionString = "datasource=" + this.Servidor +
                                          "; port=" + this.Puerto +
                                          ";username=" + this.Usuario +
                                          ";password=" + this.Clave +
                                          ";Database=" + this.Base;
            }
            catch (Exception ex)
            {
                conString = null;
                throw ex;
            }
            return conString;
        }

        public static Connection getInstancia()
        {

            if (Con == null)
            {

                Con = new Connection();

            }

            return Con;

        }

    }
}
