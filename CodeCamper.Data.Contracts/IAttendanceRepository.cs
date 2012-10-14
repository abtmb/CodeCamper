using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {

        /// <summary>
        /// Returns a single <see cref="Attendance"/> entity.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="sessionId"></param>
        Attendance GetByIds(int personId, int sessionId);

        /// <summary>
        /// Gets all <see cref="Attendance"/> entities for a person by id.
        /// </summary>
        /// <param name="id"></param>
        IQueryable<Attendance> GetByPersonId(int id);

        /// <summary>
        /// Gets all <see cref="Attendance"/> entities for a session by session id.
        /// </summary>
        /// <param name="id"></param>
        IQueryable<Attendance> GetBySessionId(int id);

        void Delete(int personId, int sessionId);
    }
}
