using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; } //want to recieve an Activity as a parameter from the api
        }

        public class Handler : IRequestHandler<Command> //no return so no comma
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity); //adding in memory at this point, not the DB. (thus no await)

                await _context.SaveChangesAsync(); // this is what changes the DB.
            
                return Unit.Value; //this means nothing. Just lets api controller know we are done.
            }
        }
    }
}