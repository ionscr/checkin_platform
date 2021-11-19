using System;

namespace Checkin_Platform.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, object key)
        :base($"Entity '{name}' ({key}) was not found.")
        {
        }
    }
}
