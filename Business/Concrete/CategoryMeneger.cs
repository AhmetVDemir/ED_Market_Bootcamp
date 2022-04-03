using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryMeneger : ICategoryService
    {

        ICategoryDal _catDal;
        public CategoryMeneger(ICategoryDal catDal)
        {
            _catDal = catDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_catDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_catDal.Get(c => c.CategoryId == categoryId));
        }
    }
}
