﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Services.Queues
{
    /// <summary>
    /// Отвечает за добавление/удаление игроков в очередь батл рояль режима
    /// </summary>
    public class BattleRoyaleQueueSingletonService
    {
        private readonly PlayersQueue unsortedPlayers = new PlayersQueue();
        
        public bool TryEnqueue(MatchEntryRequest matchEntryRequest)
        {
            return unsortedPlayers.TryEnqueue(matchEntryRequest.GetPlayerServiceId(), matchEntryRequest);
        }

        public bool TryRemove(string playerServiceId)
        {
            Console.WriteLine("Удаление игрока с id = "+playerServiceId + " из очереди.");
            return unsortedPlayers.TryRemove(playerServiceId);
        }
        
        public bool Contains(string playerServiceId)
        {
            Console.WriteLine($"Обработка запроса от игрока. кол-во в очереди {unsortedPlayers.GetNumberOfPlayers()}. ");
            return unsortedPlayers.Contains(playerServiceId);
        }
        
        public int GetNumberOfPlayers()
        {
            return unsortedPlayers.GetNumberOfPlayers();
        }

        [CanBeNull]
        public DateTime? GetOldestRequestTime()
        {
            return unsortedPlayers.GetOldestRequestTime();
        }

        /// <summary>
        /// Возвращает игроков без исключения из очереди 
        /// </summary>
        /// <param name="maxNumberOfPlayersInBattle"></param>
        public List<MatchEntryRequest> TakeMatchEntryRequests(int maxNumberOfPlayersInBattle)
        {
            return unsortedPlayers.TakeHead(maxNumberOfPlayersInBattle);
        }
        
        public void RemovePlayersFromQueue(List<PlayerModel> playerModels)
        {
            foreach (PlayerModel playerModel in playerModels)
            {
                TryRemove(playerModel.ServiceId);
            }
        }
    }
}