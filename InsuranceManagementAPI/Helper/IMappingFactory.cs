using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementAPI.Helper
{
    public interface IMappingFactory<T>
    {
        T CreateFrom<S>(S sourceObject);

        IEnumerable<T> CreateMultipleFrom<S>(S sourceObject);
    }
}
