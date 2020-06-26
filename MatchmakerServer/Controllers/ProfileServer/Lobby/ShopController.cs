﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AmoebaGameMatcherServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopFacadeService shopFacadeService;

        public ShopController(ShopFacadeService shopFacadeService)
        {
            this.shopFacadeService = shopFacadeService;
        }
        
        /// <summary>
        /// Создаёт разметку магазина для игрока.
        /// </summary>
        [Route(nameof(GetShopModel))]
        [HttpGet]
        public async Task<ActionResult<string>> GetShopModel([FromQuery] string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                return BadRequest();
            }

            var shopModel = await shopFacadeService.GetShopModelAsync(playerId);
            if (shopModel == null)
            {
                return StatusCode(500);
            }
            
            return shopModel.SerializeToBase64String();
        }

        [Route(nameof(BuyProduct))]
        [HttpPost]
        public async Task<ActionResult<string>> BuyProduct([FromForm] string playerId, string productId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}