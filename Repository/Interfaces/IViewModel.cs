using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IViewModel<TModel> where TModel : class
    {
        TModel ToDataBase();
        void FromDataBase(TModel model);
        void UpdateDataBase(TModel model);
        Guid[] GetGuids();
        int[] GetKeys();
    }
}
