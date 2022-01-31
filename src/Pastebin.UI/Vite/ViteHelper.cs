// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

using Microsoft.AspNetCore.SpaServices;
using System.Net.NetworkInformation;

namespace Pastebin.UI.Vite
{
    public static class ViteHelper
    {
        /// <summary>
        /// Default port number of 'npm run dev'
        /// </summary>
        private static int Port { get; } = 3000;

        /// <summary>
        /// Default endpoint for node development server.
        /// </summary>
        private static Uri DevelopmentServerEndpoint { get; } = new Uri($"http://localhost:{Port}");
        
        /// <summary>
        /// Ensure development server is running and return its endpoint.
        /// </summary>
        /// <param name="spa"></param>
        /// <exception cref="DevelopmentServerNotRunningException">When development server is not running.</exception>
        public static void UseViteDevelopmentServer(this ISpaBuilder spa)
        {
            if (!IsRunning())
            {
                throw new DevelopmentServerNotRunningException($"Node development server is not running on port: {Port}. Please run 'npm run dev'.");
            }

            spa.UseProxyToSpaDevelopmentServer(DevelopmentServerEndpoint);
        }

        /// <summary>
        /// Checks if the development server is running on port VueHelper.Port.
        /// </summary>
        /// <returns>True if running otherwise false.</returns>
        private static bool IsRunning() => IPGlobalProperties.GetIPGlobalProperties()
                .GetActiveTcpListeners()
                .Select(x => x.Port)
                .Contains(Port);
    }
}