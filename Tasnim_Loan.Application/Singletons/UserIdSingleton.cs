using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Singletons
{
    public class UserIdSingleton
    {
        private static UserIdSingleton _instance;
        private int _userId;

        private UserIdSingleton() { }
      
        public static UserIdSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserIdSingleton();
                }
                return _instance;
            }
        }

        public int GetUserId()
        {
            return _userId;
        }

        public void SetUserId(int userId)
        {
            _userId = userId;
        }
    }
}
