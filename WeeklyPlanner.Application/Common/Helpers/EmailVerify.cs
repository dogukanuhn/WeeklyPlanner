using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Helpers
{
    public static class EmailVerify
    {   
       
        public static bool EmailIsValid(string email)
        {
            List<string> publicDomain = new List<string> { "google", "yandex", "hotmail" };

            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    foreach (var item in publicDomain)
                    {
                        if (email.Contains(item)) return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
