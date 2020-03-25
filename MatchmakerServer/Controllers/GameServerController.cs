﻿using System;
using AmoebaGameMatcherServer.Services;
using Microsoft.AspNetCore.Mvc;

//TODO добавить secretKey проверку

namespace AmoebaGameMatcherServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameServerController : ControllerBase
    {
        private readonly GameMatcherService gameMatcher;

        public GameServerController(GameMatcherService gameMatcher)
        {
            this.gameMatcher = gameMatcher;
        }

        /// <summary>
        /// Метод вызывается гейм сервером при окончании игровой сессии.
        /// </summary>
        [Route(nameof(DeleteRoom))]
        [HttpDelete]
        public ActionResult DeleteRoom([FromQuery] int gameRoomId)
        {
            if(gameRoomId == 0)
                return new BadRequestResult();

            //TODO сделать запись об окончании боя
            
            gameMatcher.DeleteRoom(gameRoomId);
            return Ok();
        }
        
        /// <summary>
        /// Метод вызывается гейм сервером при смерти игрока.
        /// </summary>
        [Route(nameof(PlayerDeath))]
        [HttpDelete]
        public ActionResult PlayerDeath([FromQuery] int playerId, [FromQuery] int placeInBattle)
        {
            Console.WriteLine($"test {nameof(playerId)} {playerId} {nameof(placeInBattle)} {placeInBattle}");
            
            //TODO дописать результат боя игрока в бд

            return Ok();
        }
    }
}