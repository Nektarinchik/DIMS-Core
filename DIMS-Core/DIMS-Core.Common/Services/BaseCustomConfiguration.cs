using System;
using DIMS_Core.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DIMS_Core.Common.Services
{
    public abstract class BaseCustomConfiguration : ICustomConfiguration
    {
        protected BaseCustomConfiguration()
        {
            Configuration = BuildConfiguration();
        }

        public IConfiguration Configuration { get; }

        public string GetSection(string name)
        {
            return Configuration?.GetSection(name)
                                ?.Value
                   ?? throw new Exception($"Incorrect configuration file. Section name: '{name}'");
        }

        protected abstract IConfiguration BuildConfiguration();
    }
}