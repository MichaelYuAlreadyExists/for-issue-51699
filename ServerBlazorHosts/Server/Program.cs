﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ServerBlazorHosts
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

         
            builder.Services.AddServerSideBlazor();

            // just a try, NOT this way
           // builder.Services.AddScoped<Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider,
           //     Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationService<Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationState,
          //  Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount, Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>>();

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

         
            builder.Services.AddScoped(sp => new HttpClient());          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();

            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}