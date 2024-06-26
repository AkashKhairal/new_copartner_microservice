﻿using MediatR;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using MigrationDB.Data;
using MigrationDB.Model;
using SubscriptionService.Queries;

namespace SubscriptionService.Handlers
{
    public class GetSubscriberByIdHandler : IRequestHandler<GetSubscriberIdQuery, Subscriber>
    {
        private readonly CoPartnerDbContext _dbContext;
        public GetSubscriberByIdHandler(CoPartnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subscriber> Handle(GetSubscriberIdQuery request, CancellationToken cancellationToken)
        {
            var subscribersList = await _dbContext.Subscribers.Where(a => a.Id == request.Id && a.IsDeleted!=true).SingleOrDefaultAsync(cancellationToken: cancellationToken);
            return subscribersList;
        }
    }
}
