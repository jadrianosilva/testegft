using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface ISectorBS
    {
        int insert(string pDsSector);
        bool update(List<SectorDTO> pDtoSector);
        bool delete(int pIdSector);
        List<SectorDTO> listSectory();
        List<SectorDTO> getSectorByID(int pIdSector);
    }
}
