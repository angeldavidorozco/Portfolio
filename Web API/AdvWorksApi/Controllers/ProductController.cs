using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            
            List<Product> list;

            //Get all data
            list = new ProductRepository().Get();

            //list.Clear();

            if (list != null && list.Count > 0)
            {
                return StatusCode(StatusCodes.Status200OK, list);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "No products are available");
            }

            
        }

        [HttpGet]
        //[Route("")]
        [Route("GetAllProducts")]//you can assing multiple URL to the same endpoint
        [Route("GetAll")] //you have to specify another rout if you wan to have another get method, even if it has a different name
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Product>> GetAll()
        {

            List<Product> list;

            //Get all data
            list = new ProductRepository().Get();

            //list.Clear();

            if (list != null && list.Count > 0)
            {
                return StatusCode(StatusCodes.Status200OK, list);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "No products are available");
            }


        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product?> Get(int id)
        {
            ActionResult<Product?> ret;
            Product? entity;


            entity = new ProductRepository().Get(id);



            if (entity != null)
            {
                // Found data, return 200 ok
                ret = StatusCode(StatusCodes.Status200OK, entity);

                //Alternatively you can use one of:
                // ret = OK(entity);
                // ret = new OkObjectResult(entity);
            }
            else
            {
                // Data not found, return 404 not found
                ret = StatusCode(StatusCodes.Status404NotFound, $"No products are available with id: {id}.");
                //Alternatively you can use one of:
                // ret = NotFound(entity);
                // ret = new NotFoundObjectResult(entity);
            }

            return ret;
        }


        [HttpGet]
        [Route("ByCategory/{categoryId}")] // Passing a parameter to the uRL
        public ActionResult<IEnumerable<Product>> SearchByCategory(int categoryId) 
        {
            
            //TODO: Locate data by category id
            Console.WriteLine(categoryId.ToString());

            return StatusCode(StatusCodes.Status200OK);
        
        
        }

        [HttpGet]
        [Route("ByNameAndPrice/Name/{name:alpha}/Price/{price:decimal:min(1)}")] // Passing multiple parameters to the uRL
        //you can also pass parameter constrains
        public ActionResult<IEnumerable<Product>> ByNameAndPrice(string name, decimal price)
        {

            //TODO: Locate data by category id
            Console.WriteLine(price.ToString());
            Console.WriteLine(name);

            return StatusCode(StatusCodes.Status200OK);


        }

        //another way of passing parameters to the query string

        [HttpGet]
        [Route("SearchByNameAndPrice")]
        public ActionResult<IEnumerable<Product>> SearchByNameAndPrice(string name, decimal price)
        {
            Console.WriteLine(price.ToString());
            Console.WriteLine(name);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
