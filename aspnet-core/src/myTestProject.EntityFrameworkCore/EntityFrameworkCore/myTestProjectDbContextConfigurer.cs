using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace myTestProject.EntityFrameworkCore
{
    public static class myTestProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<myTestProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<myTestProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
