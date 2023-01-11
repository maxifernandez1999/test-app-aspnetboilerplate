using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using myTestProject.Authorization.Roles;
using myTestProject.Authorization.Users;
using myTestProject.MultiTenancy;
using myTestProject.Domain;

namespace myTestProject.EntityFrameworkCore
{
    public class myTestProjectDbContext : AbpZeroDbContext<Tenant, Role, User, myTestProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Player> Players { get; set; }
        public myTestProjectDbContext(DbContextOptions<myTestProjectDbContext> options)
            : base(options)
        {
        }
    }
}
