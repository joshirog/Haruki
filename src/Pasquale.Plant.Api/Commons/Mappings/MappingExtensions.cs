using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pasquale.Plant.Api.Commons.Bases;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Pasquale.Plant.Api.Commons.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedBase<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
    {
        return PaginatedBase<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
    {
        return queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
