using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BussinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingCpncerns.Validation;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class AirplaneMeneger : IAirplaneService
    {
        //iş kodları

        IAirplaneDal _airplaneDal;

        ICategoryService _categoryService;

        public AirplaneMeneger(IAirplaneDal airplaneDal,ICategoryService categoryService)
        {
            _airplaneDal = airplaneDal;
            _categoryService = categoryService;
        }

        //-----------------------------------İmplementasyonlar------------------------------------------------

        #region Implemantasyonlar


        //[SecuredOperation("airplane.add,admin")]
        //[ValidationAspect(typeof(AirplaneValidator))]
        //[CacheRemoveAspect("IAirplaneService.Get")] //IAirplaneService.get altındaki tüm get operasyonlarında ceche leri temzle (ki db deki kayıt yenilendi)
        public IResult AddAirplane(Airplane airplane)
        {
            //iş kurallarınnı çalıştır.
            IResult result = BussinessRules.Run(CheckIfAirplaneNameExists(airplane.AirplaneName), CheckIfAirplaneCountOfCategoryCorrect(airplane.CategoryId), CheckIfCategoryLimitExceded());
            //Eğer kurala uymayan varsa
            if (result != null)
            {
                return result;
            }
                _airplaneDal.Add(airplane);
                return new SuccessResult(Messages.AirplaneAdded);
   
        }

        //[TransactionScopeAspect] //.net in transaction scope u için aspect
        public IResult AddTransactionTest(Airplane airplane)
        {
            AddAirplane(airplane);
            if (airplane.UnitPrice < 10)
            {
                throw new Exception("");
            }
            AddAirplane(airplane);
            return null;
        }


        //[PerformanceAspect(5)] //çalışma 5sn geçerse uyar
        public IDataResult<List<AirplaneDetailDto>> GetAirplaneDetail()
        {
            return new SuccessDataResult<List<AirplaneDetailDto>>(_airplaneDal.GetAirplaneDetail());
        }


        [CacheAspect] //key, value
        public IDataResult<List<Airplane>> GetAll()
        {
           

            return new SuccessDataResult<List<Airplane>>(_airplaneDal.GetAll(), Messages.AirplaneListed);
        }

        public IDataResult<List<Airplane>> GetAllByCategoryId(int CategoryId)
        {
            return new SuccessDataResult<List<Airplane>>(_airplaneDal.GetAll(a => a.CategoryId == CategoryId));
        }

        [CacheAspect]
        public IDataResult<Airplane> GetById(int AirplaneId)
        {
            return new SuccessDataResult<Airplane>(_airplaneDal.Get(a => a.AirplaneId == AirplaneId));
        }

        public IDataResult<List<Airplane>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Airplane>>(_airplaneDal.GetAll(a => a.UnitPrice >= min && a.UnitPrice <= max));
        }

        [ValidationAspect(typeof(AirplaneValidator))]
        [CacheRemoveAspect("IAirplaneService.Get")]
        public IResult UpdateAirplane(Airplane airplane)
        {

            _airplaneDal.Update(airplane);
            return new SuccessResult("Güncelleme Başarılı");
        }

        #endregion

        //-------------------------------------İş kuralları---------------------------------------------------
        #region IsKurallari

        //Katagorideki ürün sayısını doğrula
        private IResult CheckIfAirplaneCountOfCategoryCorrect(int categoryId)
        {
            //bir katagoride en fazka 10 ürün eklenebilir

            var result = _airplaneDal.GetAll(a => a.CategoryId == categoryId).Count;
            if (result >= 100)
            {
                
                return new ErrorResult(Messages.AirplanceCountOfCategory);
            }
            return new SuccessResult();
        }

        //aynı isimde ürün eklenemez
        private IResult CheckIfAirplaneNameExists(string name)
        {
            var result = _airplaneDal.GetAll(a => a.AirplaneName == name).Any();
            if(result)
            {
                return new ErrorResult(Messages.AirplaneNameAlreadyExists);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 100)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        #endregion
    }
}
