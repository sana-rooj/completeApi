﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class PageList<T> :List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        private bool HasPrevious
        {
            get
            {
                return (CurrentPage>1);
            }
        }
        private bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public PageList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
            AddRange(items);
        }

        public static PageList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
