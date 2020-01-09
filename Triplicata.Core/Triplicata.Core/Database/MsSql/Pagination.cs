﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Types;

namespace Triplicata.Core.Database.MsSql
{
    public static class Pagination
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, PagedQueryBase query) where T : BaseEntity
            => await collection.PaginateAsync(query.Page, query.Results);

        public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
            int page = 1, int resultsPerPage = 10) where T : BaseEntity
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }
            var isEmpty = await collection.AnyAsync() == false;
            if (isEmpty)
            {
                return PagedResult<T>.Empty;
            }
            var totalResults = await collection.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
            var data = await collection.Limit(page,resultsPerPage).ToListAsync();

            return PagedResult<T>.Create(data, page, resultsPerPage, totalPages, totalResults);
        }

        public static IQueryable<T> Limit<T>(this IQueryable<T> collection, PagedQueryBase query) where T : BaseEntity
            => collection.Limit(query.Page, query.Results);

        public static IQueryable<T> Limit<T>(this IQueryable<T> collection,
            int page = 1, int resultsPerPage = 10) where T : BaseEntity
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }
            var skip = (page - 1) * resultsPerPage;
            var data = collection.Skip(skip).Take(resultsPerPage);

            return data;
        }
    }
}
