using System;
using System.Collections.Generic;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}
