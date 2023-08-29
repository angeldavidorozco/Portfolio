using CatalogoResin.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace CatalogoResin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //creting a list for each row of each table in the db
            List<Base> baseModelList = new List<Base>();
            List<Image> imageModelList = new List<Image>();
            List<Effects> EffectsModelList = new List<Effects>();
            List<Extra> ExtraModelList = new List<Extra>();

            List<Product> ProductModelList = new List<Product>();  //For administration purposes

            //Connecting to the database
            MySqlConnection conn = Connection.getInstancia().CrearConexion();
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                //Connecting to base tabe
                string sql = "SELECT * from base";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Base baseModel = new Base();

                        baseModel.BaseID = (string)rdr[0];
                        baseModel.NormalName = (string)rdr[1];
                        baseModel.Descrip = (string)rdr[2];
                        baseModel.BasePath = (string)rdr[3];

                        baseModelList.Add(baseModel);

                    }

                    //rdr.Close();
                }

                //Connecting to image table
                string sql2 = "SELECT * from image ORDER BY ImageType";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                using (MySqlDataReader rdr = cmd2.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Image imageModel = new Image();

                        imageModel.ImageID = (string)rdr[0];
                        imageModel.ImagePath = (string)rdr[1];
                        imageModel.ImageType = (string)rdr[2];

                        imageModelList.Add(imageModel);

                    }

                    //rdr.Close();
                }



                //connecting to Extra table
                string sql4 = "SELECT * from extra";
                MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                using (MySqlDataReader rdr = cmd4.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Extra ExtraModel = new Extra();

                        ExtraModel.ExtraID = (string)rdr[0];
                        ExtraModel.ExtraPath = (string)rdr[1];
                        ExtraModel.ExtraType = (string)rdr[2];


                        ExtraModelList.Add(ExtraModel);

                    }

                    //rdr.Close();
                }

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            //return View();
            ViewBag.EffectsTable = EffectsModelList;
            ViewBag.ExtrasTable = ExtraModelList;
            ViewBag.BaseTable = baseModelList;
            ViewBag.ImageTable = imageModelList;
            return View();
        }

        public IActionResult ExtraQuery(string arg)
        {


            //creating a list for the bases fetched 
            List<Extra> ExtraModelList = new List<Extra>();

            //Connecting to the database
            MySqlConnection conn = Connection.getInstancia().CrearConexion();
            try
            {

                conn.Open();

                //Connecting to base tabe
                string sql = $"SELECT ExtraID, ExtraPath FROM image WHERE ExtraType LIKE \"" + arg + "\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Extra ExtraModel = new Extra();

                        ExtraModel.ExtraID = (string)rdr[0];
                        ExtraModel.ExtraPath = (string)rdr[1];



                        ExtraModelList.Add(ExtraModel);

                    }

                    //rdr.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            // Return the filtered data as JSON
            return Json(ExtraModelList);
        }

        public IActionResult ImageQuery(string arg)
        {


            //creating a list for the bases fetched 
            List<Image> imageModelList = new List<Image>();

            //Connecting to the database
            MySqlConnection conn = Connection.getInstancia().CrearConexion();
            try
            {


                conn.Open();

                //Connecting to base tabe
                string sql = $"SELECT ImageID, imagePath, imageBase FROM image WHERE ImageType LIKE \"" + arg + "\"";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Image imageModel = new Image();

                        imageModel.ImageID = (string)rdr[0];
                        imageModel.ImagePath = (string)rdr[1];
                        imageModel.ImageBase = (string)rdr[2];
                        /*
                        imageModel.ImageID = (string)rdr[0];
                        
                        */

                        imageModelList.Add(imageModel);

                    }

                    //rdr.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            // Return the filtered data as JSON
            return Json(imageModelList);
        }

        public IActionResult BaseQuery(string arg)
        {

            // Creating lists to store the fetched data
            List<Base> baseModelList = new List<Base>();


            // Connecting to the database
            MySqlConnection conn = Connection.getInstancia().CrearConexion();
            try
            {
                conn.Open();

                // Query to fetch data from the base table
                string baseSql = $"SELECT Descrip, BasePath FROM base WHERE NormalName LIKE \"{arg}\"";
                MySqlCommand baseCmd = new MySqlCommand(baseSql, conn);
                using (MySqlDataReader baseReader = baseCmd.ExecuteReader())
                {
                    while (baseReader.Read())
                    {
                        Base baseModel = new Base();
                        baseModel.Descrip = (string)baseReader[0];
                        baseModel.BasePath = (string)baseReader[1];

                        baseModel.NormalName = "";
                        baseModel.BaseID = "";
                        baseModelList.Add(baseModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // Return the object as JSON
            return Json(baseModelList);
        }

        public IActionResult AnimeQuery(string arg)
        {
            List<Image> imageModelList = new List<Image>();
            // Connecting to the database
            MySqlConnection conn = Connection.getInstancia().CrearConexion();
            try
            {
                conn.Open();
                // Query to fetch data from the image table
                string imageSql = $"SELECT Imagetype FROM image WHERE ImageBase LIKE \"{arg}\" order by ImageType";
                MySqlCommand imageCmd = new MySqlCommand(imageSql, conn);
                using (MySqlDataReader imageReader = imageCmd.ExecuteReader())
                {
                    while (imageReader.Read())
                    {
                        Image imageModel = new Image();
                        imageModel.ImageType = (string)imageReader[0];

                        imageModel.ImageID = "";
                        imageModel.ImagePath = "";
                        imageModel.ImageID = "";
                        imageModel.ImageBase = "";
                        imageModelList.Add(imageModel);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Json(imageModelList);

        }
    
        public IActionResult Product_Selector()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}