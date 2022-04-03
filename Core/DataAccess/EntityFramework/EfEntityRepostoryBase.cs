﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepostoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class, IEntity,new()
        where TContext:DbContext,new()
    {

        //Ekleme Operasyonnu
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        //Silme Operasyonu
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleterEntity = context.Entry(entity);
                deleterEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Filtreye göre getirme operasyonu
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        //Hepsini getirme operasyonu
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        //Güncelleme Operasyonu
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
