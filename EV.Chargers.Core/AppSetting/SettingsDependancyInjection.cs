﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EV.Chargers.Core.AppSetting
{
    public static class SettingsDependancyInjection
    {
        public static SqlAppSetting SqlSettings { get; } = new();
        public static PosAppSetting PosSettings { get; } = new();
        public static FilesPathSetting FilesPathSettings { get; } = new();
        public static AuthenticationAppSetting AuthenticationSettings { get; } = new();
        public static EncryptionAppSetting EncryptionSetting { get; } = new();
        public static RedisAppSetting RedisSettings { get; } = new();
        public static ServiceAppSettings ServiceSettings { get; } = new();



        public static void Init(IConfiguration configuration)
        {
            var sqlSection = configuration.GetSection(SqlAppSetting.SectionName);
            sqlSection.Bind(SqlSettings);
            var posSection = configuration.GetSection(PosAppSetting.SectionName);
            posSection.Bind(PosSettings);
            var FilesPathSection = configuration.GetSection(FilesPathSetting.SectionName);
            FilesPathSection.Bind(FilesPathSettings);
            var authenticationSection = configuration.GetSection(AuthenticationAppSetting.SectionName);
            authenticationSection.Bind(AuthenticationSettings);
            var encryptionSection = configuration.GetSection(EncryptionAppSetting.SectionName);
            encryptionSection.Bind(EncryptionSetting);
            var redisSection = configuration.GetSection(RedisAppSetting.SectionName);
            redisSection.Bind(RedisSettings);
            var serviceSection = configuration.GetSection(ServiceAppSettings.SectionName);
            serviceSection.Bind(ServiceSettings);
        }
        public static void AddSettingsDependancyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlAppSetting>(configuration.GetSection(SqlAppSetting.SectionName));
            services.Configure<PosAppSetting>(configuration.GetSection(PosAppSetting.SectionName));
            services.Configure<FilesPathSetting>(configuration.GetSection(FilesPathSetting.SectionName));
            services.Configure<AuthenticationAppSetting>(configuration.GetSection(AuthenticationAppSetting.SectionName));
            services.Configure<EncryptionAppSetting>(configuration.GetSection(EncryptionAppSetting.SectionName));
            services.Configure<RedisAppSetting>(configuration.GetSection(RedisAppSetting.SectionName));
            services.Configure<ServiceAppSettings>(configuration.GetSection(ServiceAppSettings.SectionName));



            Init(configuration);
        }

    }
}
