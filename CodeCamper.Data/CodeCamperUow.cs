using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Helpers;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    public class CodeCamperUow : ICodeCamperUow, IDisposable
    {
        private CodeCamperDbContext DbContext { get; set; }

        public CodeCamperUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Room> Rooms {  get { return GetStandardRepo<Room>(); }  }
        public IRepository<TimeSlot> TimeSlots { get { return GetStandardRepo<TimeSlot>(); } }
        public IRepository<Track> Tracks { get { return GetStandardRepo<Track>(); } }
        public ISessionsRepository Sessions { get { return GetRepo<ISessionsRepository>(); } }
        public IPersonsRepository Persons { get { return GetRepo<IPersonsRepository>(); } }
        public IAttendanceRepository Attendance { get { return GetRepo<IAttendanceRepository>(); } }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new CodeCamperDbContext();

            // Do not enable proxied entities
            DbContext.Configuration.ProxyCreationEnabled = false;

            DbContext.Configuration.LazyLoadingEnabled = false;

            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }
    }
}
