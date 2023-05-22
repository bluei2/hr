using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.Core.Enum
{
    public class StatusFlags
    {

        public const int New = 0;
        public const int Pending = 1;
        public const int Aproved = 2;
        public const int Rejected = 3;
        public const int Canceled = 4;
        public const int Failed = 5;


        public const int Error = -1;
        public const int Unknown = -2;
    }
}
