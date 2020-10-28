using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public partial class BoutiqueContext : DbContext
    {
        public virtual DbSet<ApiResourceClaims> ApiResourceClaims { get; set; }
        public virtual DbSet<ApiResourceProperties> ApiResourceProperties { get; set; }
        public virtual DbSet<ApiResourceScopes> ApiResourceScopes { get; set; }
        public virtual DbSet<ApiResourceSecrets> ApiResourceSecrets { get; set; }
        public virtual DbSet<ApiResources> ApiResources { get; set; }
        public virtual DbSet<ApiScopeClaims> ApiScopeClaims { get; set; }
        public virtual DbSet<ApiScopeProperties> ApiScopeProperties { get; set; }
        public virtual DbSet<ApiScopes> ApiScopes { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ClientClaims> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigins> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientGrantTypes> ClientGrantTypes { get; set; }
        public virtual DbSet<ClientIdPRestrictions> ClientIdPRestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUris> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientProperties> ClientProperties { get; set; }
        public virtual DbSet<ClientRedirectUris> ClientRedirectUris { get; set; }
        public virtual DbSet<ClientScopes> ClientScopes { get; set; }
        public virtual DbSet<ClientSecrets> ClientSecrets { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<IdentityResourceClaims> IdentityResourceClaims { get; set; }
        public virtual DbSet<IdentityResourceProperties> IdentityResourceProperties { get; set; }
        public virtual DbSet<IdentityResources> IdentityResources { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<tblCategory> tblCategory { get; set; }
        public virtual DbSet<tblProduct> tblProduct { get; set; }
        public virtual DbSet<tblProductQty> tblProductQty { get; set; }
        public virtual DbSet<tblProductSize> tblProductSize { get; set; }
        public virtual DbSet<tblProductSuitType> tblProductSuitType { get; set; }
        public virtual DbSet<tblSale> tblSale { get; set; }
        public virtual DbSet<tblSaleDetail> tblSaleDetail { get; set; }
        public virtual DbSet<tblSubCategory> tblSubCategory { get; set; }

        public BoutiqueContext(DbContextOptions<BoutiqueContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiResourceClaims>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceProperties>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceScopes>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceSecrets>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);
            });

            modelBuilder.Entity<ApiResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<ApiScopeClaims>(entity =>
            {
                entity.HasIndex(e => e.ScopeId);
            });

            modelBuilder.Entity<ApiScopeProperties>(entity =>
            {
                entity.HasIndex(e => e.ScopeId);
            });

            modelBuilder.Entity<ApiScopes>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<ClientClaims>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigins>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientGrantTypes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientIdPRestrictions>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientProperties>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientScopes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<ClientSecrets>(entity =>
            {
                entity.HasIndex(e => e.ClientId);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .IsUnique();
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);
            });

            modelBuilder.Entity<IdentityResourceClaims>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResourceProperties>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type });
            });

            modelBuilder.Entity<tblCategory>(entity =>
            {
                entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tblProduct>(entity =>
            {
                entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tblProductQty>(entity =>
            {
                entity.Property(e => e.ProductQtyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tblProductSize>(entity =>
            {
                entity.Property(e => e.ProductSizeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductSize).IsFixedLength();
            });

            modelBuilder.Entity<tblProductSuitType>(entity =>
            {
                entity.Property(e => e.ProductSuitTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tblSale>(entity =>
            {
                entity.Property(e => e.SaleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Balance).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SaleTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tax).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<tblSaleDetail>(entity =>
            {
                entity.Property(e => e.SaleDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SaleDetailTotal).HasComputedColumnSql("([QtySold]*[SellingPrice])");
            });

            modelBuilder.Entity<tblSubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
