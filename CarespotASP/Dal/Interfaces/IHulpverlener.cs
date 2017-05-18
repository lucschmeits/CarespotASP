using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IHulpverlener
    {
        List<Hulpverlener> GetAll();

        Hulpverlener GetById(int id);

        void Create(int id);

        // void Update(Hulpverlener hulpverlener);

        void Delete(int id);
    }
}