using System;
using System.Collections.Generic;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Assets
{
    public class Asset
    {
        public int Id { get; set; }
        public AssetEnum Currency { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}
