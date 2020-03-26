﻿using System;
using System.Collections.Generic;
using Google.Apis.Upload;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Services
{
    /// <summary>
    /// Отвечает за добавление/удаление игроков в очередь батл рояль режима
    /// </summary>
    public class BattleRoyaleQueueSingletonService
    {
        private readonly MyQueue unsortedPlayers = new MyQueue();
        
        /// <summary>
        /// Добавляет данные в очередь без проверки.
        /// </summary>
        /// <param name="playerServiceId"></param>
        /// <param name="warshipCopy"></param>
        /// <returns></returns>
        public bool TryEnqueuePlayer(string playerServiceId, WarshipCopy warshipCopy)
        {
            return unsortedPlayers.TryEnqueuePlayer(playerServiceId, warshipCopy);
        }

        public bool TryRemovePlayerFromQueue(string playerServiceId)
        {
            Console.WriteLine("Удаление игрока с id = "+playerServiceId + " из очереди.");
            return unsortedPlayers.TryRemove(playerServiceId);
        }
        
        public bool IsPlayerInQueue(string playerId)
        {
            Console.WriteLine($"Обработка запроса от игрока. кол-во в очереди {unsortedPlayers.GetCountOfPlayers()}. ");
            return unsortedPlayers.ContainsPlayer(playerId);
        }
        
        public int GetNumberOfPlayersInQueue()
        {
            return unsortedPlayers.GetCountOfPlayers();
        }

        /// <summary>
        /// Нужно для сервиса запуска боя.
        /// </summary>
        /// <returns>Возвращает время самого запроса на вход в бой, если запросы есть.</returns>
        public DateTime? GetOldestRequestTime()
        {
            return unsortedPlayers.GetOldestRequestTime();
        }

        /// <summary>
        /// Возвращает игроков без исключения из очереди 
        /// </summary>
        /// <param name="maxNumberOfPlayersInBattle"></param>
        public List<PlayerInfo> GetPlayersFromQueue(int maxNumberOfPlayersInBattle)
        {
            return unsortedPlayers.TakeHead(maxNumberOfPlayersInBattle);
        }
    }
}