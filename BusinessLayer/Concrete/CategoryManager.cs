using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

        //public CategoryManager(ICategoryDal categoryDal)
        //{
        //	_categoryDal = categoryDal;
        //}

        //public void CategoryAdd(Category category)
        //{
        //	_categoryDal.Insert(category);
        //}

        //public void CategoryDelete(Category category)
        //{
        //	_categoryDal.Delete(category);
        //}

        //public void CategoryUpdate(Category category)
        //{
        //	_categoryDal.Update(category);
        //}

        //public List<Category> GetListAll()
        //{
        //	return _categoryDal.GetListAll();
        //}

        //public Category GetById(int id)
        //{
        //	return _categoryDal.GetById(id);
        //}
    }
}
