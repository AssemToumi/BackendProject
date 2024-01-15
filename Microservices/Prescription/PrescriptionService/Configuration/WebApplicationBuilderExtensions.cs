using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;

namespace PrescriptionService.Configuration
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddJsonConfigurationProvider(this WebApplicationBuilder builder, params (string name, bool optional, bool reloadOnChange)[] files)
        {
            (string name, bool optional, bool reloadOnChange)[] files2 = files;
            WebApplicationBuilder builder2 = builder;
            (string name, bool optional, bool reloadOnChange)[] array = files2;
            if (array == null || !array.Any())
            {
                throw new ArgumentException("Argument files can not be null or empty!", "files");
            }

            builder2.Host.ConfigureAppConfiguration(delegate (HostBuilderContext _, IConfigurationBuilder b) {
                IConfigurationBuilder b2 = b;
                IEnumerable<JsonConfigurationSource> existingJsonConfigurationSources = b2.Sources.OfType<JsonConfigurationSource>();
                files2.ToList().ForEach(delegate ((string name, bool optional, bool reloadOnChange) f)
                {
                    List<JsonConfigurationSource> list = existingJsonConfigurationSources.Where((s) => string.Equals(f.name, s.Path, StringComparison.OrdinalIgnoreCase)).ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        b2.Sources.Remove(list[i]);
                    }

                    builder2.Configuration.AddJsonFile(f.name, f.optional, f.reloadOnChange);
                });
            });
            return builder2;
        }
    }
}
