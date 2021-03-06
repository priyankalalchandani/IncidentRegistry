﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Repository;
using System.Data.Entity;
using System.Collections.Concurrent;

namespace IncidentInfrastructure.Repositories
{
    
    public class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : IncidentDomain.Entities.Incident
    {
        protected DbContext Context { get; private set; }
        
        protected DbSet<TEntity> DbSet { get; set; }

        protected virtual IQueryable<TEntity> QuerySet { get { return DbSet; } }

        public AbstractRepository(DbContext Context)
        {
            this.Context = Context;
            this.DbSet = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return (TEntity)DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity Insert(TEntity model)
        {
            DbSet.Add(model);
            return model;
        }

        public TEntity Delete(int id)
        {
            TEntity data = DbSet.Find(id);
            DbSet.Remove(data);
            return data;
        }

        public TEntity Update(TEntity data)
        {
            TEntity entity = DbSet.Find(data.IncidentID);
            
            Context.Entry(entity).CurrentValues.SetValues(data);
            return data;
        }
    }
}
