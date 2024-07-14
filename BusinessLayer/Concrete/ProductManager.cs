using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);

            if (product.PhotoBase64 != null && product.PhotoBase64 != "string")
            {
                byte[] photoBytes = Convert.FromBase64String(product.PhotoBase64);

                // Kullanıcının fotoğrafını belirlediğiniz klasöre kaydet
                string photoFileName = product.Id + ".jpg"; // Fotoğraf dosya adını oluştur
                                                            //LİNKLERE DOĞRU BAKACAKSIN EN SON İŞLEMLERDE
            
                var userDirectory = Path.Combine("C:\\Users\\emirg\\OneDrive\\Masaüstü\\SportBuddyProject\\SportBuddyWebAPI\\Upload\\Photos\\" + product.Id + "\\ProductPhoto");
                // Kullanıcının alt klasörünün var olup olmadığını kontrol edin; yoksa oluşturun
                if (!Directory.Exists(userDirectory))
                {
                    // Klasörü oluşturun
                    Directory.CreateDirectory(userDirectory);
                }
                // Dosyanın kaydedileceği tam yolu oluşturun
                var photoPath = Path.Combine(userDirectory, photoFileName);
                System.IO.File.WriteAllBytes(photoPath, photoBytes); // Byte dizisini dosyaya yaz

                product.PhotoPath = photoPath;
                List<Product> products = new List<Product>();
                products.Add(product);
                Update(products);
            }


            return new SuccessResult(Messages.ProductAdded);
        }
        public IResult Delete(int id)
        {
            Product product = _productDal.Get(p => p.Id == id);
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(List<Product> products)
        {
            foreach (var product in products)
            {
                _productDal.Update(product);

            }
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetList()
        {
            var allProduct = _productDal.GetList().ToList();

            foreach (var product in allProduct)
            {

                string directoryPath = Path.Combine("C:\\Users\\emirg\\OneDrive\\Masaüstü\\SportBuddyProject\\SportBuddyWebAPI\\Upload\\Photos\\" + product.Id + "\\ProductPhoto");

                if (Directory.Exists(directoryPath))
                {
                    byte[] photoBytes = File.ReadAllBytes(product.PhotoPath);
                    product.PhotoBase64 = Convert.ToBase64String(photoBytes);
                }

            }
            return new IResult<List<Product>>(allProduct);
        }

        public IDataResult<Product> GetById(int Id)
        {
            return new IResult<Product>(_productDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<Product>> GetListByCategoryId(int ProductCatalogId)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => p.ProductCatalogId == ProductCatalogId).ToList());
        }

        public IDataResult<List<Product>> GetListByPriceRange(int price1, int price2)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => (price1 <= p.Price && price2 >= p.Price)).ToList());
        }

        public IDataResult<List<Product>> GetListByProductName(string Name)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => p.Name == Name).ToList());
        }

        public IDataResult<List<Product>> GetListByQuantityPerUnit(int QuantityPerUnit)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => p.QuantityPerUnit == QuantityPerUnit).ToList());
        }

        public IDataResult<List<Product>> GetListByUnitsInStock(int UnitsInStock)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => p.UnitsInStock == UnitsInStock).ToList());
        }

        public IDataResult<List<Product>> GetListByUnitsOnOrder(int UnitsOnOrder)
        {
            return new IResult<List<Product>>(_productDal
                .GetList(p => p.UnitsOnOrder == UnitsOnOrder).ToList());
        }
    }
}
