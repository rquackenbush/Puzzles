using Microsoft.AspNetCore.Mvc;
using Puzzle1.Services;
using System.Threading.Tasks;

namespace Puzzle1.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly SolvedStateService _solvedStateService;
        private readonly NotificationService _notificationService;

        public NotifyController(
            SolvedStateService solvedStateService, 
            NotificationService notificationService)
        {
            _solvedStateService = solvedStateService;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<ActionResult<NotifyResult>> Post()
        {
            if (_solvedStateService.IsSolved)
            {
                return new NotifyResult
                {
                    Message = "The puzzle has already been solved. Let it go."
                };
            }

            //TODO: Send an email!
            await _notificationService.NotifyAsync();

            _solvedStateService.SetSolved();

            return new NotifyResult
            {
                Message = "Congratulations! You have solved puzzle 1!"
            };
        }
    }
}
