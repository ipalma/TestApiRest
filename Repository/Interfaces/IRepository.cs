using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TModel, TViewModel> where TModel : class where TViewModel: IViewModel<TModel>
    {
        ICollection<TViewModel> Get();
        TViewModel Get(params object[] keys);
        TViewModel Get(params Guid[] keys);
        TViewModel Get(int key);
        TViewModel Get(params string[] keys);
        ICollection<TViewModel> Get(Expression<Func<TModel, bool>> query);
        TViewModel Add(TViewModel model);
        int Delete(TViewModel model);
        int Delete(Expression<Func<TModel, bool>> query);
        int Update(TViewModel model);
    }
}
