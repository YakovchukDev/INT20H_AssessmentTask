using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Services;

namespace QuestPlatform.Server.Controllers
{
    [ApiController]
    [Route("api/quest")]
    public class QuestsController : ControllerBase
    {
        private readonly QuestsService _questsService;
        public QuestsController(QuestsService questsService)
        {
            _questsService = questsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quests = await _questsService.GetAllQuestsAsync();
            return Ok(quests);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quest = await _questsService.GetQuestByIdAsync(id);
            if (quest == null)
                return NotFound();

            return Ok(quest);
        }

    }
}
