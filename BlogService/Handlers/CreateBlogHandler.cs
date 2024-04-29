﻿using MediatR;
using MigrationDB.Data;
using BlogService.Commands;
using MigrationDB.Model;


namespace BlogService.Handlers;

public class  CreateBlogHandler : IRequestHandler<CreateBlogCommand, Blog>
{
    private readonly CoPartnerDbContext _dbContext;
    public CreateBlogHandler(CoPartnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Blog;
        await _dbContext.Blogs.AddAsync(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        request.Blog.Id = entity.Id;
        return request.Blog;
    }
}