using System;

namespace smartfy.portal_api.domain.Entities
{
    public class Entity
    {

        public Guid Id { get; set; }

        public DateTime CreationDate { get; private set; }

        public bool Excluded { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Excluded = false;
        }

        public bool Delete()
        {
            Excluded = true;
            return Excluded;
        }


        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
