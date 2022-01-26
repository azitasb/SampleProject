using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabahat.Common
{
    public static class Constants
    {
        public static class JobLevelName
        {
            public const string Junior = "Junior";
            public const string MidLevel = "Mid-level";
            public const string Senior = "Senior";
            public const string Staff = "Staff";
            public const string Manager = "Manager";
            public const string CTO = "CTO";
            public const string CEO = "CEO";
        }

        public static class JobLevelId
        {
            public const string Junior = "1";
            public const string MidLevel = "2";
            public const string Senior = "3";
            public const string Staff = "4";
            public const string Manager = "5";
            public const string CTO = "6";
            public const string CEO = "7";
        }

        public static class Uri
        {
            public const string GetUsersAddress = "{0}api/user";
            
        }
    }
}
