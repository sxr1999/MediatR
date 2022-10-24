using MediatR.Interface;
using MediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatR.AppDbContext;

public class MyDbContext : DbContext
{
    private readonly IMediator _mediator;
    
    public MyDbContext(DbContextOptions<MyDbContext> options,IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    public DbSet<User>  Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //需求三
        modelBuilder.Entity<User>().Property("passwordHash");
        //需求四
        modelBuilder.Entity<User>().Property(x => x.Remark).HasField("remark");
        //需求五
        modelBuilder.Entity<User>().Ignore(x => x.Tag);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        //获取所有含有未发布事件的实体
        var domainEntities =
            this.ChangeTracker.Entries<IDomainEvents>().Where(x => x.Entity.GetDomainEvents().Any());

        //获取所有未发布的事件
        var domainEvents = domainEntities.SelectMany(x => x.Entity.GetDomainEvents()).ToList();
        
        domainEntities.ToList().ForEach(e=>e.Entity.ClearDomainEvent());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
}