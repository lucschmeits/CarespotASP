using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IBeheerder
    {
        List<Beheerder> GetAllBeheerders();
        Beheerder GetBeheerderById(int id);
        int CreateBeheerder();
        void UpdateBeheerder();
        void DeleteBeheerderById(int id);
    }
}
