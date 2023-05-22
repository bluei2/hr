using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eches.Hr.Core.Setting
{
    public class TenantDbSetting
    {
        public string DataSource { get; set; }
        public bool IntergratedSecurity { get; set; } = true;
    }
}
