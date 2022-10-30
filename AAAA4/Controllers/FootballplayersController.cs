using AAAA4.Managers;
using AAAA4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AAAA4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballplayersController : ControllerBase
    {
        private readonly FootballplayersManger _manager = new FootballplayersManger();

        // GET: api/<FootballplayersController>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Footballplayer>> Get()
        {
            IEnumerable<Footballplayer> players = _manager.GetAll();
            if (players == null) return NotFound("No list found");
            return Ok(players);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET api/<FootballplayersController>/5
        [HttpGet("{id}")]
        public ActionResult <Footballplayer> Get(int id)
        {
            Footballplayer player = _manager.GetById(id);
            if (player == null) return NotFound("No such class, id: " + id);
            return Ok(player);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        // POST api/<FootballplayersController>
        [HttpPost]
        public ActionResult< Footballplayer > Post([FromBody] Footballplayer value)
        {
            Footballplayer player = _manager.Add(value);
            if (player == value) return Created("Api/IPAs/" + value.Id, value);
            return Created("", player);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // PUT api/<FootballplayersController>/5
        [HttpPut("{id}")]
        public ActionResult< Footballplayer> Put(int id, [FromBody] Footballplayer value)
        {
            Footballplayer player = _manager.Update(id, value);
            if (player.ShirtNumber > 99) return BadRequest("BAAAD");
            return BadRequest();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // DELETE api/<FootballplayersController>/5
        [HttpDelete("{id}")]
        public ActionResult < Footballplayer> Delete(int id)
        {
            Footballplayer player = _manager.Delete(id);
            if (player == null) return NoContent();
            return NoContent();
        }
    }
}
