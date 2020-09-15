using Microsoft.Extensions.Logging;

namespace Puzzle1.Services
{
    public class SolvedStateService
    {
        private readonly ILogger _logger;

        public SolvedStateService(ILogger<SolvedStateService> logger)
        {
            _logger = logger;
        }

        public void SetSolved()
        {
            if (!IsSolved)
            {
                IsSolved = true;

                _logger.LogInformation("The puzzle has now been solved.");
            }
        }

        public bool IsSolved { get; private set; }
    }
}
