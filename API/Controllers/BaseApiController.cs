using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController] ///can do auto binding
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        ///to use it as a property using lambda expression
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        

    }
}
