using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }     
        public List<Product> GetLast4Product()
		{
			return _productDal.GetListAll().OrderByDescending(x => x.ProductId).Take(4).ToList();
		}

        public List<Product> GetList()
        {
            return _productDal.GetListAll();
        }

        public List<Product> GetProductById(int id)
        {
            return _productDal.GetListAll(x => x.ProductId == id);
        }

        public List<Product> GetProductListWithCategory(int id)
        {
            return _productDal.GetListAll(x => x.CategoryId == id);
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
            
        }
    }
}
