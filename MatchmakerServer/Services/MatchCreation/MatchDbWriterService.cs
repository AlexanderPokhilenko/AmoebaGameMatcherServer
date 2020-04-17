﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmoebaGameMatcherServer.Services.PlayerQueueing;
using AmoebaGameMatcherServer.Services.Queues;
using DataLayer;
using DataLayer.Tables;

namespace AmoebaGameMatcherServer.Services.MatchCreation
{
    public class MatchDbWriterService
    {
        private readonly IDbContextFactory dbContextFactory;

        public MatchDbWriterService(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Возвращает id матча после успешной записи в БД
        /// </summary>
        public async Task<Match> WriteMatchDataToDb(MatchRoutingData matchRoutingData, 
            List<QueueInfoForPlayer> playersQueueInfo)
        {
            ApplicationDbContext dbContext = dbContextFactory.Create();
            
            //Создать объекты для результатов боя игроков
            var playersResult = new List<MatchResultForPlayer>();
            foreach (var playerQueueInfo in playersQueueInfo)
            {
                MatchResultForPlayer matchResultForPlayer = new MatchResultForPlayer
                {
                    WarshipId = playerQueueInfo.GetWarshipId(),
                    WasShown = false
                };
                
                Console.WriteLine($"{nameof(matchResultForPlayer.WarshipId)} {matchResultForPlayer.WarshipId}");
                playersResult.Add(matchResultForPlayer);
            }

            //Создать матч
            Match match = new Match
            {
                StartTime = DateTime.UtcNow,
                GameServerIp = matchRoutingData.GameServerIp,
                GameServerUdpPort = matchRoutingData.GameServerPort,
                MatchResultForPlayers = playersResult
            };

            await dbContext.Matches.AddAsync(match);
            await dbContext.SaveChangesAsync();

            return match;
        }
    }
}