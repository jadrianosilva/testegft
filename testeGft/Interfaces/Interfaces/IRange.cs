using System;
using System.Collections.Generic;
using System.Text;
using Repository.Repositorio;

namespace Interfaces.Interfaces
{
    public interface IRange
    {
        int insert(RangeDTO oRange);
        bool update(RangeDTO oRange);
        bool delete(int pIdRange);
        List<RangeDTO> listRange();
        List<RangeDTO> getRangeByID(int pIdRange);
    }
}
