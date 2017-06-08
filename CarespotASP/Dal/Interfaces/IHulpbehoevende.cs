using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IHulpbehoevende
    {
        List<Hulpbehoevende> GetAllHulpbehoevenden();

        Hulpbehoevende GetHulpbehoevendeById(int id);

        void CreateHulpbehoevende(int id, int hulpverlenerId);

        void UpdateHulpbehoevende(int id, Hulpbehoevende hulpbehoevende);

        void DeleteHulpbehoevendeById(int id);

        int BepaalHulpverlener();
    }
}