using PatientApplication.Data.Entities.BaseEntity;
using PatientApplication.Data.Enums;

namespace PatientApplication.Data.Entities
{
    public class Patient : Entity<Guid>
    {
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
        
        public bool IsActive { get; set; }

        #region Virtual Properties

        public virtual Name Name { get; set; }

        #endregion
    }
}
