﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ExpertService.Queries;
using MigrationDB.Data;
using MigrationDB.Models;

namespace ExpertService.Handlers;
public class GetExpertsHandler : IRequestHandler<GetExpertsQuery, IEnumerable<Experts>>
{
    private readonly CoPartnerDbContext _dbContext;
    public GetExpertsHandler(CoPartnerDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Experts>> Handle(GetExpertsQuery request, CancellationToken cancellationToken)
    {
        int skip = (request.Page - 1) * request.PageSize;

        var entities =  await _dbContext.Experts.Where(x => x.IsDeleted != true)
                        //.OrderByDescending(x => x.CreatedOn)
                        .Skip(skip)
                        .Take(request.PageSize)
                        .ToListAsync(cancellationToken);
        if (entities == null) return null; 
        return entities;

    }
}
