using CarespotASP.Models;
using System.Collections.Generic;

namespace CarespotASP.Dal.Interfaces
{
    public interface IBeheerder
    {
        List<Beheerder> GetAllBeheerders();

        Beheerder GetBeheerderById(int id);

        void CreateBeheerder(int id);

        void DeleteBeheerderById(int id);
    }
}