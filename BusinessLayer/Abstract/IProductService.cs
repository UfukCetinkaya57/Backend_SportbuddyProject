using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int Id);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategoryId(int ProductCatalogId);
        IDataResult<List<Product>> GetListByProductName(string Name);
        IDataResult<List<Product>> GetListByUnitsOnOrder(int UnitsOnOrder);
        IDataResult<List<Product>> GetListByQuantityPerUnit(int QuantityPerUnit);
        IDataResult<List<Product>> GetListByUnitsInStock(int UnitsInStock);
        IDataResult<List<Product>> GetListByPriceRange(int price1, int price2);
        IResult Add(Product product);
        IResult Update(List<Product> product);
        IResult Delete(int id);


    }
}
