using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Model
{
    public class EmployeeStatusRequestModel
    {
        public int LookupCode { get; set; }
        public string? Description { get; set; }
        public string? ABBR { get; set; }
    }
}
