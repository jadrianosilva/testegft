using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface IRangeBS
    {
        int insert(List<RangeDTO> pRange);
        bool update(List<RangeDTO> pRange);
        bool delete(int pIdRange);
        List<RangeDTO> listCategory();
        List<RangeDTO> getCategoryByID(int pIdRange)
    }
}
