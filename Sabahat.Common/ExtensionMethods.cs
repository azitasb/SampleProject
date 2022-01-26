using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabahat.Common
{
    public static class ExtensionMethods
    {
        public static bool IsNumber(this string str)
        {
            try
            {
                int n = 0;
                return int.TryParse(str, out n);
            }
            catch
            {

                throw;
            }
        }

        public static bool Is2ColumnIn1(this string str)
        {
            try
            {
                return str.Trim().Split(' ').Count() > 1;
            }
            catch
            {

                throw;
            }
        }

        public static string ToJobLevel(this string str)
        {
            try
            {
                string name = string.Empty;
                switch (str)
                {
                    case Constants.JobLevelId.Junior:
                        name = Constants.JobLevelName.Junior;
                        break;
                    case Constants.JobLevelId.MidLevel:
                        name = Constants.JobLevelName.MidLevel;
                        break;
                    case Constants.JobLevelId.Senior:
                        name = Constants.JobLevelName.Senior;
                        break;
                    case Constants.JobLevelId.Staff:
                        name = Constants.JobLevelName.Staff;
                        break;
                    case Constants.JobLevelId.Manager:
                        name = Constants.JobLevelName.Manager;
                        break;
                    case Constants.JobLevelId.CTO:
                        name = Constants.JobLevelName.CTO;
                        break;
                    case Constants.JobLevelId.CEO:
                        name = Constants.JobLevelName.CEO;
                        break;
                    default:
                        break;
                }

                return name;
            }
            catch
            {

                throw;
            }
        }
    }
}
