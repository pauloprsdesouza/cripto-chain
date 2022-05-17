using System;
using System.Collections.Generic;
using Cripto.Chain.Domain.Wallets;

namespace Cripto.Chain.Domain.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}
