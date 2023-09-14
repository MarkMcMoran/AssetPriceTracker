using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AssetPriceTracker.Models
{
    public class CryptoItemContext : DbContext
    {
        public CryptoItemContext(DbContextOptions<CryptoItemContext> options)
    : base(options)
        {
        }

        public DbSet<CryptoItem> CryptoItem { get; set; } = null!;

    }
}
