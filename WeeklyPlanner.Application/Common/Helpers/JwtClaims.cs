using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Helpers
{
    public class JwtClaims 
    {
        public JwtClaims(string claim)
        {
            Claim = claim;
        }
        public string Claim { get; set; }

        public override string ToString() => Claim;

        public static JwtClaims Email => new JwtClaims(nameof(Email));
        public static JwtClaims UserId => new JwtClaims(nameof(UserId));
        public static JwtClaims Company => new JwtClaims(nameof(Company));
    }
}
