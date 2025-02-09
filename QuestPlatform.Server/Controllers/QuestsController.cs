using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Models;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Quest quest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdQuest = await _questsService.CreateQuestAsync(quest);
            return CreatedAtAction(nameof(GetById), new { id = createdQuest.Id }, createdQuest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Quest quest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedQuest = await _questsService.UpdateQuestAsync(quest);
            return Ok(updatedQuest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _questsService.DeleteQuestAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
