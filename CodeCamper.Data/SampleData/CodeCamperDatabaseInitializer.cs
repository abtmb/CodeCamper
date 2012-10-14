using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeCamper.Data.SampleData
{
    class CodeCamperDatabaseInitializer :
        DropCreateDatabaseIfModelChanges<CodeCamperDbContext>
    {
        private const int AttendeesWithFavoritesCount = 4;

        protected override void Seed(CodeCamperDbContext context)
        {
            base.Seed(context);
        }
    }
}
