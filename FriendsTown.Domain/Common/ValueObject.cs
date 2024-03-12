using System.Reflection;

namespace FriendsTown.Domain.Common
{
    public class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj) 
        {
            if (obj is null) return false;

            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();
            int startValue = 17, multiplier = 59, hashCode = startValue;

            foreach (FieldInfo field in fields) 
            {
                object value = field.GetValue(this);

                if (value is not null) 
                {
                    hashCode = hashCode * multiplier + value.GetHashCode();
                }
            }

            return hashCode;
        }

        public virtual bool Equals(T other) 
        {
            if (other is null) return false;

            Type t = GetType();
            Type otherType = other.GetType();

            if (t != otherType) return false;

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | 
                BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields) 
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 is null)
                {
                    if (value2 is not null) return false;
                }
                else if (!value1.Equals(value2)) return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields() 
        {
            Type t = GetType();
            List<FieldInfo> fields = new List<FieldInfo>();

            while (t != typeof(object)) 
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance |
                    BindingFlags.NonPublic | BindingFlags.Public));
                t = t.BaseType;
            }

            return fields;
        }
    }
}
