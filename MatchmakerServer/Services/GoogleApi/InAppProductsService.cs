﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmoebaGameMatcherServer.Services.GoogleApi
{
    /// <summary>
    /// Нужно для тестирования правильности refresh token-а при его перезагрузки вречную
    /// </summary>
    public class InAppProductsService
    {
        private readonly AllProductsUrlFactory urlFactory;

        public InAppProductsService()
        {
            urlFactory = new AllProductsUrlFactory();
        }
        public async Task<string> InAppProducts(string accessToken)
        {
            HttpClient httpClient = new HttpClient();
            string url = urlFactory.Create(accessToken);
            var result = await httpClient.GetAsync(url);
            
            string content = await result.Content.ReadAsStringAsync();
            
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(content);

            if (result.IsSuccessStatusCode)
            {
                return content;
            }
            else
            {
                Console.WriteLine($"{nameof(result.StatusCode)} {result.StatusCode}");
                return content;
            }
        }
    }
}