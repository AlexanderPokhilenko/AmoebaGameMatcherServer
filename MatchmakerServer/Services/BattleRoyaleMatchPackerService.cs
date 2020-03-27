﻿using System;
using System.Collections.Generic;
using System.Linq;
using AmoebaGameMatcherServer.Utils;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Services
{
    /// <summary>
    /// Отвечает за доставание набора игроков для матча.
    /// Есть возможность дополнять игроков ботами.
    /// </summary>
    public class BattleRoyaleMatchPackerService
    {
        private readonly BattleRoyaleQueueSingletonService battleRoyaleQueueService;

        public BattleRoyaleMatchPackerService(BattleRoyaleQueueSingletonService battleRoyaleQueueService)
        {
            this.battleRoyaleQueueService = battleRoyaleQueueService;
        }
        
        public (bool success, GameUnitsForMatch, List<PlayerQueueInfo> playersQueueInfo) GetPlayersForMatch(
            int maxNumberOfPlayersInBattle, bool botsCanBeUsed)
        {
            //Если мало игроков и нельзя дополнять ботами, то матч собрать не получится
            if (battleRoyaleQueueService.GetNumberOfPlayersInQueue() < Globals.NumbersOfPlayersInBattleRoyaleMatch
                && !botsCanBeUsed)
            {
                Console.WriteLine("Если мало игроков и нельзя дополнять ботами, то матч собрать не получится");
                return (false, null, null);
            }

            GameUnitsForMatch gameUnitsForMatch = new GameUnitsForMatch();
            
            //Достать игроков из очереди без извлечения
            List<PlayerQueueInfo> playersQueueInfo = 
                battleRoyaleQueueService.GetPlayersQueueInfo(maxNumberOfPlayersInBattle);
            gameUnitsForMatch.Players = playersQueueInfo.Select(info => info.ToMatchInfo()).ToList();
            
            //Дополнить ботами, если нужно
            if (gameUnitsForMatch.Players.Count < Globals.NumbersOfPlayersInBattleRoyaleMatch)
            {
                Console.WriteLine("gameUnitsForMatch.Players.Count < Globals.NumbersOfPlayersInBattleRoyaleMatch");
                //Дополнить ботами, если можно
                if (botsCanBeUsed)
                {
                    Console.WriteLine("botsCanBeUsed");
                    int countOfBots = maxNumberOfPlayersInBattle - gameUnitsForMatch.Players.Count;
                    gameUnitsForMatch.Bots = CreateBots(countOfBots);
                }
            }
        
            
            //Если игроков достаточно, то матч может быть запущен
            if (gameUnitsForMatch.Count() == Globals.NumbersOfPlayersInBattleRoyaleMatch)
            {
                return (true, gameUnitsForMatch, playersQueueInfo);
            }
            //Иначе собрать матч не удалось
            else
            {
                Console.WriteLine("Иначе собрать матч не удалось");
                return (false, null, null);
            }
        }
        
        /// <summary>
        /// Создаёт список ботов для дополнения списка игроков
        /// </summary>
        /// <param name="numberOdBots"></param>
        /// <returns></returns>
        private List<BotInfo> CreateBots(int numberOdBots)
        {
            List<BotInfo> bots = new List<BotInfo>();
            for (int i = 0; i < numberOdBots; i++)
            {
                BotInfo botInfo = new BotInfo()
                {
                    BotName = "Игорь",
                    PrefabName = "Bird",
                    TemporaryId = 0, //TODO suka
                    WarshipCombatPowerLevel = 1
                };
                bots.Add(botInfo);
            }
            
            return bots;
        }
    }
}