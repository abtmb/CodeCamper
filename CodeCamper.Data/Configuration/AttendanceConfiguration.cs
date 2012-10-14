using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data
{
    class AttendanceConfiguration 
        : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            // Composite key on SessionId and PersonId
            HasKey(a => new { a.PersonId, a.SessionId });

            // Attendance has 1 Session,
            // Session have many attendance records
            HasRequired(a => a.Session)
                .WithMany(s => s.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);

            // Attendance has 1 Person
            // Persons have many attendance records
            HasRequired(a => a.Person)
                .WithMany(p => p.AttendanceList)
                .HasForeignKey(a => a.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
}
