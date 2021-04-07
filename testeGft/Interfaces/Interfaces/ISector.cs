using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface ISector
    {
        int insert(string pDsSector);
        bool update(SectorDTO oSector);
        bool delete(int pIdSector);
        List<SectorDTO> listSector();
        List<SectorDTO> getSectorByID(int pIdSector);
    }
}
