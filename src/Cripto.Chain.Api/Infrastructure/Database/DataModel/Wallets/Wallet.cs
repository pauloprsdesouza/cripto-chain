using System;
using System.Collections.Generic;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Assets;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Customers;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Transacitons;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets
{
    public class Wallet
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AssetId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Customer Customer { get; set; }
        public Asset Asset { get; set; }
        public List<Transaction> DebitTransactions {get;set;}
        public List<Transaction> CreditTransactions {get;set;}
    }
}
