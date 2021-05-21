using AutoMapper;
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
    public class Edit
    {
        //Command do not return data
        public class Request : IRequest
        {
            public Activity activity { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly DataContext db;
            private readonly IMapper mapper;

            public Handler(DataContext db ,IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }


            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var activity = await db.Activities.FindAsync(request.activity.Id);
                mapper.Map(request.activity, activity);
                await db.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
