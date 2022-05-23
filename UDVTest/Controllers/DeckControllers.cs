using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UDVTest.Dtos;
using UDVTest.Repository;
using UDVTest.SortingAlgorithms;

namespace UDVTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckControllers : ControllerBase
    {
        private readonly IRepository<CardDeck> _repository;
        private readonly IShuffle _shuffleAlgorithm;

        public DeckControllers(IRepository<CardDeck> repository, IShuffle shuffleAlgorithm)
        {
            _repository = repository;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        [HttpGet("GetDecksNames")]
        public IActionResult GetDecksNames()
        {
            var decksNames = _repository.GetNames();
            return Ok(decksNames);
        }

        [HttpGet("GetDeck")]
        public IActionResult GetDeck([FromQuery] string name)
        {
            var deck  = _repository.Get(name);
            if (deck == null)
                return NotFound();
            var deckDto = new DeckDto(deck);
            return Ok(deckDto);
        }

        [HttpPost("CreateDeck")]
        public IActionResult CreateDeck([FromQuery] string name)
        {
            var deck  = _repository.Get(name);
            if (deck != null)
                return BadRequest();
            _repository.Add(name);
            return Ok();
        }

        [HttpDelete("DeleteDeck")]
        public IActionResult DeleteDeck([FromQuery] string name)
        {
            var deck  = _repository.Get(name);
            if (deck == null)
                return NotFound();
            _repository.Delete(name);
            return Ok();
        }

        [HttpPut("Shuffle")]
        public IActionResult Shuffle([FromQuery] string name)
        {
            var deck  = _repository.Get(name);
            if (deck == null)
                return NotFound();
            _shuffleAlgorithm.Shuffle(deck);
            return Ok();
        }
        
    }
}