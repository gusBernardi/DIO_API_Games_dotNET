using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using game_api.InputModel;
using game_api.ViewModel;
using game_api.Services;
using game_api.Exceptions;

namespace game_api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetAll([FromQuery, Range(1, int.MaxValue)] int pages = 1, [FromQuery, Range(1, 50)] int itens = 5)
        {
            var games = await _gameService.GetAll(pages, itens);

            if (games.Count() == 0) return NoContent();
            return Ok(games);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GameViewModel>> GetById([FromRoute] Guid id)
        {
            var game = await _gameService.GetById(id);
            if (game == null) return NoContent();
            return Ok(game);
        }


        [HttpPost]
        public async Task<ActionResult> AddGame([FromBody] GameInputModel game)
        {
            try
            {
                var newGame = await _gameService.AddGame(game);
                return Ok(newGame);
            }
            catch (GameAlreadyExistsException e)
            {
                return UnprocessableEntity("A game with name '" + game.name + "' already exists.");
            }
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid id, [FromBody] GameInputModel game)
        {
            try
            {
                await _gameService.UpdateGame(id, game);
                return Ok();
            }
            catch (GameNotFoundException e)
            {
                return NotFound("No game with id: " + id);
            }
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveGame([FromRoute] Guid id)
        {
            try
            {
                await _gameService.RemoveGame(id);
                return Ok();
            }
            catch (GameNotFoundException e)
            {
                return NotFound("No game with id: " + id);
            }
        }
    }
}