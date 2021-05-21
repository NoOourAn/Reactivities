using Domain;
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
    public class Create
    {
        //Command do not return data
        public class Request : IRequest
        {
            public Activity activity  { get; set; }
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
                //we do not need to use AddAsync as we r not touching
                //database at this point
                db.Add(request.activity);
                await db.SaveChangesAsync();

                //void = Unit in c#
                return Unit.Value; 
            }
        }
    }
}
