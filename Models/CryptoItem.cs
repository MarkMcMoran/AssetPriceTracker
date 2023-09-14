using System.Numerics;

namespace AssetPriceTracker.Models
{
    public class CryptoItem
    {
        public long Id { get; set;  }
        public string? Name { get; }
        public string? Ticker { get; }
        public decimal? Price { get; }

        public BigInteger volume1hr { get; }
        public BigInteger volume24hr { get; }

        public BigInteger volume7day { get; }
        
        public BigInteger marketCap { get; }   

        public int SizeRanking { get; }

    }
}
