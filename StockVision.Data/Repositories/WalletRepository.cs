using StockVision.Core.Interfaces.Repositories;
using StockVision.Core.Models;
using StockVision.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {

        public WalletRepository(StockVisionContext context) : base(context)
        {

        }
        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
