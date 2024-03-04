using PatientApplication.Data.Entities.BaseEntity;

namespace PatientApplication.Data.Entities
{
    public class Name : Entity<Guid>
    {
        public string Use { get; set; }

        public string Family { get; set; }

        public string[] Given { get; set; }

        #region Virtual Properties

        public virtual Patient Patient { get; set; }

        #endregion
    }
}
