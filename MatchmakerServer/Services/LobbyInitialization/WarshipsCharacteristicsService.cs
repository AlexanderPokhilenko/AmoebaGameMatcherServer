﻿using System;
using System.Collections.Generic;
using DataLayer.Tables;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Controllers
{
    public class WarshipsCharacteristicsService
    {
        private readonly Dictionary<WarshipTypeEnum, WarshipCharacteristics> warshipParameters =
            new Dictionary<WarshipTypeEnum, WarshipCharacteristics>
            {
                {
                    WarshipTypeEnum.Bird, new WarshipCharacteristics
                    {
                        DefenceParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Health",
                                Values = new []{null, "2000", "2200", "2600", "2900", "3000", "3300", "3900", "3900", "3900", "3900", "3900", "3900", "3900", },
                                Increments = new []{null, "200","400","300","100","300","600","600","600","600","600","600","600","600","600","600"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }  ,
                            new WarshipParameter
                            {
                                Name = "Movement speed",
                                Values = new []{"NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL"},
                                Increments = null,
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None
                            }
                        },
                        AttackName = "Laser",
                        AttackDescription = "The bird shoots a laser that ignores all obstacles. Shields and asteroids can't protect against hitting.",
                        AttackParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Damage per second",
                                Values = new []{null,"200","250","350","350","350","350","350","350"},
                                Increments = new []{null, "50", "100", "100", "100", "100", "100", "100"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }, 
                            new WarshipParameter
                            {
                                Name = "Range",
                                Values = new[]{"Big","Big","Big","Big","Big","Big","Big","Big","Big","Big","Big","Big","Big"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None,
                                Increments = null
                            }
                        },
                        UltimateName = "DRONE SUPPORTER",
                        UltimateDescription = "The bird is creating a drone behind itself. The drone automatically hits the target and attacks it.",
                        UltimateParameters = new[]
                        {
                            new WarshipParameter
                            {
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus,
                                Name = "Damage",
                                Values = new[]
                                {
                                    null,
                                    "5 x 650",
                                    "5 x 665",
                                    "5 x 675",
                                    "5 x 690",
                                    "5 x 700",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                },
                                Increments = new[]
                                {
                                    null,
                                    "15",
                                    "10",
                                    "15",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "20"
                                }
                                
                            }
                        }
                    }
                },
                {
                    WarshipTypeEnum.Hare, new WarshipCharacteristics
                    {
                        DefenceParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Health",
                                Values = new []{null, "2000", "2200", "2600", "2900", "3000", "3300", "3900", "3900", "3900", "3900"},
                                Increments = new []{null, "200","400","300","100","300","600","600","600","600","600","600"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }  ,
                            new WarshipParameter
                            {
                                Name = "Movement speed",
                                Values = new []{"NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL","NORMAL"},
                                Increments = null,
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None
                            }
                        },
                        AttackName = "Machine gun",
                        AttackDescription = "The bunny shoots four guns continuously.",
                        AttackParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Damage per second",
                                Values = new []{null,"200","250","350","350","350","350","350","350","350","350","350","350","350"},
                                Increments = new []{null, "50", "100", "100", "100", "100", "100", "100", "100", "100", "100"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }, 
                            new WarshipParameter
                            {
                                Name = "RANGE",
                                Values = new[]{"BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None,
                                Increments = null
                            }
                        },
                        UltimateName = "large plasma shot",
                        UltimateDescription = "The hare fires a large projectile from the plasma. This projectile ignores any obstacles.",
                        UltimateParameters = new[]
                        {
                            new WarshipParameter
                            {
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus,
                                Name = "Damage",
                                Values = new[]
                                {
                                    null,
                                    "5 x 650",
                                    "5 x 665",
                                    "5 x 675",
                                    "5 x 690",
                                    "5 x 700",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                },
                                Increments = new[]
                                {
                                    null,
                                    "15",
                                    "10",
                                    "15",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "20"
                                }
                                
                            }
                        }
                    }
                },
                {
                    WarshipTypeEnum.Smiley, new WarshipCharacteristics
                    {
                        DefenceParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Health",
                                Values = new []{null, "2000", "2200", "2600", "2900", "3000", "3300", "3900", "3900", "3900", "3900", "3900", "3900"},
                                Increments = new []{null, "200","400","300","100","300","600","600","600","600","600","600"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }  ,
                            new WarshipParameter
                            {
                                Name = "Movement speed",
                                Values = new []{"LOW","LOW","LOW","LOW","LOW","LOW","LOW","LOW","LOW","LOW" },
                                Increments = null,
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None
                            }
                        },
                        AttackName = "Название атаки для улыбаки",
                        AttackDescription = "Описание атаки для улыбаки",
                        AttackParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Damage per second",
                                Values = new []{null,"200","250","350","350","350","350","350","350","350"},
                                Increments = new []{null, "50", "100", "100", "100", "100", "100", "100"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }, 
                            new WarshipParameter
                            {
                                Name = "Range",
                                Values = new[]{"BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None,
                                Increments = null
                            }
                        },
                        UltimateName = "НАЗВАНИЕ УЛЬТЫ ДЛЯ ПТИЦЫ",
                        UltimateDescription = "ОПИСАНИЕ УЛЬТЫ ДЛЯ ПТИЦЫ",
                        UltimateParameters = new[]
                        {
                            new WarshipParameter
                            {
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus,
                                Name = "Damage",
                                Values = new[]
                                {
                                    null,
                                    "5 x 650",
                                    "5 x 665",
                                    "5 x 675",
                                    "5 x 690",
                                    "5 x 700",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                    "5 x 720",
                                },
                                Increments = new[]
                                {
                                    null,
                                    "15",
                                    "10",
                                    "15",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "10",
                                    "20"
                                }
                            }
                        }
                    }
                },
                {
                    WarshipTypeEnum.Sage, new WarshipCharacteristics
                    {
                        DefenceParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Health",
                                Values = new []{null, "1450", "1558.75", "1667.5", "1776.25", "1885", "1993.75", "2102.5", "2211.25", "2320", "2428.75", "2537.5", "2646.25"},
                                Increments = new []{null, "108.75","400","300", "108.75", "108.75", "108.75", "108.75", "108.75", "108.75", "108.75", "108.75"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            }  ,
                            new WarshipParameter
                            {
                                Name = "Movement speed",
                                Values = new []{"HIGH", "HIGH", "HIGH", "HIGH", "HIGH", "HIGH", "HIGH", "HIGH", "HIGH", "HIGH" },
                                Increments = null,
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None
                            }
                        },
                        AttackName = "Blaster",
                        AttackDescription = "Two fast blasters will destroy your enemies.",
                        AttackParameters = new[]
                        {
                            new WarshipParameter
                            {
                                Name = "Damage per second",
                                Values = new []{null,"600", "630", "660", "690", "720", "750", "780", "810", "840"},
                                Increments = new []{null, "30", "30", "30", "30", "30", "30", "30"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus
                            },
                            new WarshipParameter
                            {
                                Name = "Range",
                                Values = new[]{"BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG","BIG"},
                                UiIncrementTypeEnum = UiIncrementTypeEnum.None,
                                Increments = null
                            }
                        },
                        UltimateName = "Interceptor",
                        UltimateDescription = "Warship summons interceptor behind itself. It has 10 seconds lifetime and 5 seconds ability cooldown.",
                        UltimateParameters = new[]
                        {
                            new WarshipParameter
                            {
                                UiIncrementTypeEnum = UiIncrementTypeEnum.Plus,
                                Name = "Damage per second",
                                Values = new []{null,"600", "630", "660", "690", "720", "750", "780", "810", "840"},
                                Increments = new []{null, "30", "30", "30", "30", "30", "30", "30"}
                            }
                        }
                    }
                }
            };
        
        public WarshipCharacteristics GetWarshipCharacteristics(WarshipTypeEnum warshipTypeEnum)
        {
            if (warshipParameters.TryGetValue(warshipTypeEnum, out var result))
            {
                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(warshipTypeEnum));
            }
        }
    }
}