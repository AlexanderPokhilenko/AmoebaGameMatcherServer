﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AmoebaGameMatcherServer.Services.Queues
{
    //TODO говно
    public class MyQueue
    {
        //key is playerServiceId
        private readonly ConcurrentDictionary<string, QueueInfoForPlayer> unsortedPlayers;

        public MyQueue()
        {
            unsortedPlayers = new ConcurrentDictionary<string, QueueInfoForPlayer>();
        }
        
        public bool TryEnqueuePlayer(string playerServiceId, QueueInfoForPlayer playerInfo)
        {
            return unsortedPlayers.TryAdd(playerServiceId, playerInfo);
        }

        public bool TryRemove(string playerServiceId)
        {
            return unsortedPlayers.TryRemove(playerServiceId, out var value);
        }

        public bool ContainsPlayer(string playerServiceId)
        {
            return unsortedPlayers.ContainsKey(playerServiceId);
        }

        public int GetCountOfPlayers()
        {
            return unsortedPlayers.Count;
        }

        public DateTime? GetOldestRequestTime()
        {
            if (unsortedPlayers.Count == 0)
            {
                return null;
            }
            DateTime oldestRequestTime = unsortedPlayers
                .Select(pair => pair.Value.DictionaryEntryTime)
                .Min(dateTime => dateTime);
            return oldestRequestTime;
        }

        public List<QueueInfoForPlayer> TakeHead(int maxNumberOfPlayersInBattle)
        {
            var playersInfo = unsortedPlayers.Values
                .OrderBy(info => info.DictionaryEntryTime)
                .Take(maxNumberOfPlayersInBattle)
                .ToList();
            return playersInfo;
        }
    }
}