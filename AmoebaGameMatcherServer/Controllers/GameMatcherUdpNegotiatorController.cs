﻿using AmoebaGameMatcherServer.Experimental;
using AmoebaGameMatcherServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmoebaGameMatcherServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameMatcherUdpNegotiatorController : ControllerBase
    {
        private readonly GameMatcherService gameMatcher;

        public GameMatcherUdpNegotiatorController(GameMatcherService gameMatcher)
        {
            this.gameMatcher = gameMatcher;
        }

        /// <summary>
        /// Метод вызывается из udp сервером при окончании игровой сессии
        /// </summary>
        [HttpDelete]
        public ActionResult DeleteRoom([FromForm]string secretKey, [FromForm] int roomNumber)
        {
            bool requestCameFromARealGameServer = CheckSecretKey(secretKey);
            if (!requestCameFromARealGameServer)
                return new ForbidResult();

            if(roomNumber == 0)
                return new BadRequestResult();

            gameMatcher.DeleteRoom(roomNumber);
            return Ok();
        }
        
        private bool CheckSecretKey(string secretKey)
        {
            return Globals.secretKey == secretKey;
        }
    }
}