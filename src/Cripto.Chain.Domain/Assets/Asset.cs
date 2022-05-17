using System;
using System.Collections.Generic;
using Cripto.Chain.Domain.Wallets;

namespace Cripto.Chain.Domain.Assets
{
    public class Asset
    {
        public int Id { get; set; }
        public AssetEnum Currency { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}
