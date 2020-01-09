using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Triplicata.Core.Extensions;
using Triplicata.Core.Types;

namespace Triplicata.Core.Database.MsSql
{
    public static class Extensions
    {
        private static readonly string SectionName = "mssql";

        public static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.Configure<MsSqlOptions>(configuration.GetSection(SectionName));
            var options = configuration.GetOptions<MsSqlOptions>(SectionName);
            if (options.UsePool)
            {
                services.AddDbContextPool<DbContext>(o =>o.UseSqlServer(options.ConnectionString));
            }
            else {
                services.AddDbContext<DbContext>(o => o.UseSqlServer(options.ConnectionString));
            }          

            return services;
        }

        public static void AddSqlServerRepository<TEntity>(this ContainerBuilder builder)
            where TEntity : BaseEntity
            => builder.Register(ctx => new MsSqlRepository<TEntity>(ctx.Resolve<DbContext>()))
                .As<IMsSqlRepository<TEntity>>().InstancePerLifetimeScope();
    }
}
