﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;

namespace SignalRServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddSignalR((obj) => {
                obj.EnableDetailedErrors = true;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors((Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder obj) => 
            {
                obj.AllowAnyHeader();
                obj.AllowAnyMethod();
                obj.AllowAnyOrigin();
            });

            app.UseWebSockets();

            app.UseSignalR((HubRouteBuilder obj) => 
            {
                obj.MapHub<MessagingHub>("/messanger",HandleAction);

            });

            app.UseMvc();
        }

        void HandleAction(Microsoft.AspNetCore.Http.Connections.HttpConnectionDispatcherOptions obj)
        {
            obj.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
        }

    }
}
