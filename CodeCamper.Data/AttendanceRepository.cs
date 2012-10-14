using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    public class AttendanceRepository : EFRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DbContext context) : base(context) { }

        public override Attendance GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single Attendance object using a single id.  Call GetByIds instead.");
        }

        public Attendance GetByIds(int personId, int sessionId)
        {
            return DbSet.FirstOrDefault(ps => ps.PersonId == personId && ps.SessionId == sessionId);
        }

        public IQueryable<Attendance> GetByPersonId(int id)
        {
            return DbSet.Where(ps => ps.PersonId == id);
        }

        public IQueryable<Attendance> GetBySessionId(int id)
        {
            return DbSet.Where(ps => ps.SessionId == id);
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot delete an attendance ovject using a single id.  Call Delete(int personId, int sessionId) instead.");
        }
        public void Delete(int personId, int sessionId)
        {
            var entity = GetByIds(personId, sessionId);
            if (entity == null) return; //Not found, assume already deleted.
            Delete(entity);
        }
    }
}
