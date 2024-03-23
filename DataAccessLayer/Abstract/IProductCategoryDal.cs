using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductCategoryDal: IEntityRepository<ProductCategory>
    {

    }
}
