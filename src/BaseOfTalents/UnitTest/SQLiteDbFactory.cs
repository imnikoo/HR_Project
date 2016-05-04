using Data.EFData;
using Data.EFData.Infrastructure;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class SQLiteDbFactory : Disposable, IDbFactory
    {
        BOTContext dbContext;

        public BOTContext Init()
        {
            return dbContext ?? (dbContext = new BOTContext("IntegrationTestContext"));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
