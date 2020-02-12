using System;

namespace MPG.EncapsulateClassesWithFactory.Before.Descriptors
{
    public abstract class AttributeDescriptor
    {
        public readonly string Name;
        public readonly Type ClassType;
        public readonly Type AttributeType;

        protected AttributeDescriptor(string name, Type classType, Type attributeType)
        {
            Name = name;
            ClassType = classType;
            AttributeType = attributeType;
        }

        protected bool Equals(AttributeDescriptor other)
        {
            return string.Equals(Name, other.Name) && ClassType == other.ClassType && AttributeType == other.AttributeType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AttributeDescriptor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClassType != null ? ClassType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AttributeType != null ? AttributeType.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
