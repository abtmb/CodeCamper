using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
    public interface IPersonsRepository : IRepository<Person>
    {
        /// <summary>
        /// Get <see cref="Speaker"/>s at sessions.
        /// </summary>
        /// <remarks>
        /// <see cref="Speaker" /> is a subset of 
        /// <see cref="Person"/> properties suitable for
        /// quick client-side filtering and presentation.
        /// </remarks>
        IQueryable<Speaker> GetSpeakers();
    }
}
