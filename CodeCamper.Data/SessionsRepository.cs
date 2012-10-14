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
    public class SessionsRepository : EFRepository<Session>, ISessionsRepository
    {
        public SessionsRepository(DbContext context) : base(context) { }

        /// <summary>
        /// Get <see cref="SessionBrief"/>s, 
        /// a cutdown version of <see cref="Session"/> entities.
        /// </summary>
        /// <remarks>See <see cref="ISessionsRepository.GetSessionBriefs"/> for details.</remarks>
        public IQueryable<SessionBrief> GetSessionBriefs()
        {
            return DbSet.Select(s => new SessionBrief
                        {
                            Id = s.Id,
                            Title = s.Title,
                            Code = s.Code,
                            SpeakerId = s.SpeakerId,
                            TrackId = s.TrackId,
                            TimeSlotId = s.TimeSlotId,
                            RoomId = s.RoomId,
                            Level = s.Level,
                            Tags = s.Tags
                        });
        }

        // Another method needs to be added here, no visible yet.

    }
}
