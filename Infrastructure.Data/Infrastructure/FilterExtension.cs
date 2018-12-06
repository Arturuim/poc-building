using Domain.Interfaces;
using System;

namespace Infrastructure.Data.Infrastructure
{
    internal static class FilterExtension
    {
        internal static string ToSql(this Filter filter)
        {
            if(filter.PageSize <= 0) { throw  new ArgumentException("Page Size cannot be less or equals to zero."); }
            if(filter.Page < 0) { throw  new ArgumentException("Page cannot be negative."); }
            return $"OFFSET {filter.Page * filter.PageSize} ROWS FETCH NEXT {filter.PageSize} ROWS ONLY";
        }
    }
}
