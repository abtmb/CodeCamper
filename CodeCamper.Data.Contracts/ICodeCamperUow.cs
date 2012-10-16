using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
    public interface ICodeCamperUow
    {
        IRepository<Room> Rooms { get; }
        IRepository<TimeSlot> TimeSlots { get; }
        IRepository<Track> Tracks { get; }
        ISessionsRepository Sessions { get; }
        IPersonsRepository Persons { get; }
        IAttendanceRepository Attendance { get; }

        void Commit();
    }
}
