using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class List
    {
        //Query do return data
        public class Request : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Request, List<Activity>>
        {
            private readonly DataContext db;

            public Handler(DataContext db)
            {
                this.db = db;
            }

            public async Task<List<Activity>> Handle(Request request, CancellationToken cancellationToken)
            {
                return await db.Activities.ToListAsync();
            }
        }
    }
}
