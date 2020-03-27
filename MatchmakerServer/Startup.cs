﻿using AmoebaGameMatcherServer.Services;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmoebaGameMatcherServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connectionString = DbConfigIgnore.GetConnectionString();
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(
                    opt => opt.UseNpgsql(connectionString))
                .BuildServiceProvider();

            //Работа с покупками
            services.AddSingleton<PurchasesValidatorService>();
            services.AddSingleton<CustomGoogleApiAccessTokenService>();
            services.AddSingleton<IpAppProductsService>();
            
            //Работа с данными игрока в лобби
            services.AddTransient<PlayerLobbyInitializeService>();
            
            //Создание боёв и данные игрока в бою
            services.AddTransient<QueueExtenderService>();
            services.AddTransient<PlayersAchievementsService>();
            services.AddTransient<DoubleTokensManagerService>();
            services.AddTransient<MatchmakerDichService>();
            services.AddTransient<GameServersManagerService>();
            services.AddTransient<QueueHelperSukaService>();
            
            services.AddTransient<BattleRoyaleMatchFinisherService>();
            services.AddTransient<MatchCreationInitiatorSingletonService>();
            services.AddTransient<BattleRoyaleMatchCreatorService>();
            services.AddTransient<BattleRoyaleMatchPackerService>();
            services.AddTransient<IPlayerTimeoutManager, PlayerTimeoutManagerService>();
            services.AddTransient<MatchDataDbWriterService>();
            services.AddTransient<QueueHelperSukaService>();
            services.AddTransient<IWarshipValidatorService, WarshipValidatorService>();
            
            services.AddSingleton<BattleRoyaleQueueSingletonService>();
            services.AddSingleton<BattleRoyaleUnfinishedMatchesSingletonService>();


            //Работа с гейм севером
            services.AddTransient<IGameServerNegotiatorService, GameServerNegotiatorService>();
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            MatchCreationInitiatorSingletonService matchCreationInitiator, ApplicationDbContext dbContext, 
            CustomGoogleApiAccessTokenService googleApiAccessTokenManagerService)
        {
            matchCreationInitiator.StartThread();
            googleApiAccessTokenManagerService.Initialize().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}