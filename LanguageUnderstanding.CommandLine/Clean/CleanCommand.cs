﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace LanguageUnderstanding.CommandLine.Clean
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Models;

    internal class CleanCommand : BaseCommand<CleanOptions>
    {
        public CleanCommand(CleanOptions options)
            : base(options)
        {
        }

        public override int Main()
        {
            this.RunAsync().Wait();
            return 0;
        }

        private async Task RunAsync()
        {
            this.Log("Cleaning NLU service... ", false);
            await this.LanguageUnderstandingService.CleanupAsync();
            this.Log("Done.");

            if (this.Options.DeleteConfig)
            {
                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.{this.Options.Service}.json");
                File.Delete(configPath);
            }
        }
    }
}