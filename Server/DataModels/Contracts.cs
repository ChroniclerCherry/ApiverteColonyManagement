using System;

namespace Server.DataModels
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModifiedDate { get; set; }

        bool IsActive { get; set; }
    }

    public interface ILookupEntity
    {
        public string Name { get; set; }
    }
}
