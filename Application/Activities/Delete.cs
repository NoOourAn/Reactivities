using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    //Command do not return data
    public class Delete
    {
        public class Request : IRequest
        {
            public Guid id { get; set; }
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly DataContext db;

            public Handler(DataContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var activity = await db.Activities.FindAsync(request.id);
                db.Remove(activity);
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
