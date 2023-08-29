using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IActionResultController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            IActionResult ret;
            List<Product> list;

            //Get all data
            list = new ProductRepository().Get();

            //list.Clear();

            if (list != null && list.Count>0)
            {
                ret = StatusCode(StatusCodes.Status200OK, list);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound, "No products are available");
            }

            return ret;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            IActionResult ret;
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
    }
}
