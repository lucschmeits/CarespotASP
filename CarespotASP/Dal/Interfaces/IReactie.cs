using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IReactie
    {
        List<Reactie> GetAllReacties();
        Reactie GetReactieById(int id);
        int CreateReactie(Reactie reactie);
        void DeleteReactieById(int id);
    }
}
