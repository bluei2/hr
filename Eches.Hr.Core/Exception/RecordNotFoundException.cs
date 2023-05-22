using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.Core.Exceptions
{
    public class RecordNotFoundExceptionBase : Exception
    {
        public RecordNotFoundExceptionBase(string message = "A record for the provided Id was not found") : base(message)
        {
        }
        public RecordNotFoundExceptionBase(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public static void ThrowIfNull(object? entity)
        {
            if (entity == null)
            {
                throw new RecordNotFoundExceptionBase();
            }
        }
    }


    public class RecordNotFoundException<T> : RecordNotFoundExceptionBase
    {
        public RecordNotFoundException() : base($"{typeof(T).Name} record for the provided Id was not found")
        {
        }
        public RecordNotFoundException(string message) : base(String.Concat($"{typeof(T).Name} record for the provided Id was not found", $". {message}"))
        {
        }
        public RecordNotFoundException(int entityId) : base($"{typeof(T).Name} record for the Id: [{entityId}] was not found")
        {
        }
        public RecordNotFoundException(int entityId, string message) : base(String.Concat($"{typeof(T).Name} for the Id: [{entityId}] was not found", $". {message}"))
        {
        }

        public static void ThrowIfNull(T? entity)
        {
            if (entity == null)
            {
                throw new RecordNotFoundException<T>();
            }
        }
        public static void ThrowIfNull(T? entity, int entityId)
        {
            if (entity == null)
            {
                throw new RecordNotFoundException<T>(entityId);
            }
        }
    }
}
