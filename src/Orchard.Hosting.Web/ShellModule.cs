﻿using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Orchard.Data;
using Orchard.DependencyInjection;
using Orchard.Environment.Shell;
using Orchard.FileSystem;
using Orchard.Hosting.FileSystem;
using Orchard.Hosting.Mvc.Routing;
using Orchard.Hosting.Routing.Routes;

namespace Orchard.Hosting
{
    /// <summary>
    /// These services are registered on the tenant service collection
    /// </summary>
    public class ShellModule : IModule
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataAccess();

            serviceCollection.AddScoped<IOrchardShellEvents, OrchardShell>();
            serviceCollection.AddSingleton<IRunningShellRouterTable, DefaultRunningShellRouterTable>();
            serviceCollection.AddSingleton<IRouteBuilder, DefaultShellRouteBuilder>();

            serviceCollection.AddSingleton<IOrchardFileSystem, HostedFileSystem>();
        }
    }
}