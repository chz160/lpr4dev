﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lpr4dev.ApiModel
{
    public static class QueryableExtensions
    {
        public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query,
            int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}