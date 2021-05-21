using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Details
    {
        //Query do return data
        public class Request: IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, Activity>
        {
            private readonly DataContext db;

            public Handler(DataContext db)
            {
                this.db = db;
            }

            public async Task<Activity> Handle(Request request, CancellationToken cancellationToken)
            {
                return await db.Activities.FindAsync(request.Id);

            }
        }
    }
}
