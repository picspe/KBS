﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebShopKBS.UoW
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		TEntity GetByUsername(string username);
		TEntity GetById(object id);
		TEntity Insert(TEntity entity);
		TEntity Delete(object id);
		TEntity Delete(TEntity entityToDelete);
		TEntity Update(TEntity entityToUpdate);
	}
}
