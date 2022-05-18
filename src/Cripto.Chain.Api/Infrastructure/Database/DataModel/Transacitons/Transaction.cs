using System;
using Cripto.Chain.Api.Infrastructure.Database.DataModel.Wallets;

namespace Cripto.Chain.Api.Infrastructure.Database.DataModel.Transacitons
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CreditWalletId { get; set; }
        public int DebitWalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Wallet CreditWallet { get; set; }
        public Wallet DebitWallet { get; set; }
    }
}
