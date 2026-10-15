using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectPractica.DBModels;

namespace ProiectPractica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly CozyStayDBContext _context;

        public PropertiesController(CozyStayDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Property>> GetProperties()
        {
            var listaHoteluri = _context.Properties.ToList();
            return Ok(listaHoteluri);
        }

        [HttpGet("{id}")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            var hotel = _context.Properties.FirstOrDefault(p => p.Id == id);

            if (hotel == null)
            {
                return NotFound("Hotelul nu a fost găsit.");
            }

            return Ok(hotel);
        }
    }
}