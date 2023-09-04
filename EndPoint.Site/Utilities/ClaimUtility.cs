using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static int? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                int userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch (Exception)
            {

                return null;
            }

        }



        public static string GetUserFullName(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                return claimsIdentity.FindFirst(ClaimTypes.Name).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetUserNationalNumber(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                return claimsIdentity.FindFirst(ClaimTypes.SerialNumber).Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> GetRolse(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                List<string> rolse = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    rolse.Add(item.Value);
                }
                return rolse;
            }
            catch (Exception )
            {
                return null;
            }

        }
    }
}
