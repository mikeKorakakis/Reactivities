using System;
using System.Threading;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
  public class Details
  {
    public class Query : IRequest<Activity>
    {
      public Guid Id { get; set; }

    }



    public class Handler : IRequestHandler<Query, Activity>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        this._context = context;

      }
      public async System.Threading.Tasks.Task<Activity> Handle(Query request, CancellationToken cancellationToken)
      {
        var activity = await _context.Activities.FindAsync(request.Id);

        return activity;
      }
    }
  }
}