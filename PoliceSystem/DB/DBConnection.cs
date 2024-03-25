using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceSystem.DB
{
    internal class DBConnection
    {
        public static Police_SystemEntities police_System = new Police_SystemEntities();

        public static User loginedUser;

    }
}
