using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		//ICategoryDal'dan 1 tane _categoryDal isminde Field örnekleyecek.
		//field olduğunu class içerisinde direkt olarak tanımladığı için anlaşılıyor
		//eğer metot içerisinde tanımlansaydı değişken olacaktı
		private readonly ICategoryDal _categoryDal;

		// field sonrasında yapıcı bir metot(Constructor) oluşturmamız gerekiyor
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void TDelete(Category entity)
		{
			_categoryDal.Delete(entity);
		}

		public List<Category> TGetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category TGetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void TInsert(Category entity)
		{
			_categoryDal.Insert(entity);
		}

		public void TUpdate(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
