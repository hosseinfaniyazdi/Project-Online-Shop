using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectNA.DataLayer.Entities.Clothing;
using ProjectNA.DataLayer.Entities.Order;
using ProjectNA.DataLayer.Entities.Permissions;
using ProjectNA.DataLayer.Entities.User;
using ProjectNA.DataLayer.Entities.Wallet;

namespace ProjectNA.DataLayer.Context
{
    public class ShoppingNaContext:DbContext
    {
        public ShoppingNaContext(DbContextOptions<ShoppingNaContext> options):base(options)
        {
            
        }

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Wallet
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        #endregion

        #region Permission

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }


        #endregion

        #region Clothing

        public DbSet<ClothingGroup> ClothingGroups { get; set; }
        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<ClothingStatus> ClothingStatuses { get; set; }
        public DbSet<ClothingComment> ClothingComments { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
            modelBuilder.Entity<ClothingGroup>().HasQueryFilter(cg => !cg.IsDelete);
            base.OnModelCreating(modelBuilder);
        }
    }
}
