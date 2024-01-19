using ApiTarea.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YuGiOhZexalController : ControllerBase
    {
        private static List<YuGiOhZexal> _yuGiOhZexals = new List<YuGiOhZexal>
        {

            new YuGiOhZexal
            {
                Id = 1,
                NCartaMoustro ="Mago Oscuro",
                Atributo="OSCURIDAD", 
                Atk= 2500,
                Def= 2100
            },
             new YuGiOhZexal
            {
                Id = 2,
                NCartaMoustro ="Dragón Blanco de Ojos Azules",
                Atributo="LUZ",
                Atk= 3000,
                Def= 2500
            },
              new YuGiOhZexal
            {
                Id = 3,
                NCartaMoustro ="Súper Asesino Estelar TY-PHON - Crisis Celeste",
                Atributo="OSCURIDAD",
                Atk= 2900,
                Def= 2900
            },
        };
        [HttpGet]
        public IEnumerable<YuGiOhZexal> GetAllCards()
        {
            return _yuGiOhZexals;
        }

        [HttpGet("{id}")]
        public YuGiOhZexal GetCardById(int id)
        {
            return _yuGiOhZexals.Find(card => card.Id == id);
        }

        [HttpPost]
        public IActionResult SaveCard([FromBody] YuGiOhZexal newCard)
        {
            _yuGiOhZexals.Add(newCard);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCard(int id, [FromBody] YuGiOhZexal updatedCard)
        {
            var card = _yuGiOhZexals.FirstOrDefault(c => c.Id == id);

            if (card != null)
            {
                card.NCartaMoustro = updatedCard.NCartaMoustro;
                card.Atributo = updatedCard.Atributo;
                card.Atk = updatedCard.Atk;
                card.Def = updatedCard.Def;
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            var existingCard = _yuGiOhZexals.FirstOrDefault(card => card.Id == id);

            if (existingCard != null)
            {
                _yuGiOhZexals.Remove(existingCard);
                return Ok();
            }

            return NotFound();
        }
    }
}