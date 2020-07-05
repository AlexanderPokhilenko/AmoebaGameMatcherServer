﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopFactoryService shopFactoryService;

        public ShopController(ShopFactoryService shopFactoryService)
        {
            this.shopFactoryService = shopFactoryService;
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

            ShopModel shopModel = await shopFactoryService.GetShopModelAsync(playerId);
            if (shopModel == null)
            {
                return StatusCode(500);
            }
            
            return shopModel.SerializeToBase64String();
        }

        [Route(nameof(BuyProduct))]
        [HttpPost]
        public async Task<ActionResult<string>> BuyProduct([FromForm] string playerId, [FromForm] string productId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                return BadRequest();
            }
            //todo достать продукт по id из БД
            // создать транзакцию по модели продукта

            //записать транзакцию
            //перезаписать модель продукта
            
            Console.WriteLine($"{nameof(playerId)} {playerId} {nameof(productId)} {productId}");
            
            return Ok();
        }
    }
}