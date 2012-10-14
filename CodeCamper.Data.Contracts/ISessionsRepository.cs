using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
    public interface ISessionsRepository : IRepository<Session>
    {
        /// <summary>
        /// Get <see cref="SessionBrief"/>s of sessions.
        /// </summary>
        /// <remarks>
        /// <see cref="SessionBried" /> is a subset of 
        /// <see cref="Session"/> properties suitable for
        /// quick client-side filtering and presentation.
        /// </remarks>
        IQueryable<SessionBrief> GetSessionBriefs();
    }
}
