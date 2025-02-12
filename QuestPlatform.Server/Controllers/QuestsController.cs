using Microsoft.AspNetCore.Mvc;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Models;
using QuestPlatform.Server.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace QuestPlatform.Server.Controllers
{

    [ApiController]
    [Route("api/quests")]
    public class QuestsController : ControllerBase
    {
        private readonly IQuestsService _questsService;

        public QuestsController(IQuestsService questsService)
        {
            _questsService = questsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestById([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Invalid quest ID.");

            var quest = await _questsService.GetQuestByIdAsync(id);
            return quest != null ? Ok(quest) : NotFound("Quest not found.");
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetQuestsByCategory([FromRoute, Required] string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return BadRequest("Category is required.");

            var quests = await _questsService.GetQuestsByCategoryAsync(category);
            return quests != null ? Ok(quests) : NotFound("No quests found for this category.");
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetQuestsByFilter([FromBody] SearchFilter filter)
        {
            if (filter == null) return BadRequest("Filter parameters are required.");

            var quests = await _questsService.GetQuestsByFilterAsync(filter);
            return quests != null ? Ok(quests) : NotFound("No matching quests found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuest([FromForm] QuestRequest quest)
        {
            if (quest == null) return BadRequest("Invalid quest data.");
            if (quest.Author == null || string.IsNullOrWhiteSpace(quest.Category))
                return BadRequest("Author and category are required.");

            var result = await _questsService.CreateQuestAsync(quest);
            return result ? Ok("Quest created successfully.") : StatusCode(500, "Failed to create quest.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuest([FromRoute] int id, [FromForm] QuestRequest quest)
        {
            if (id <= 0 || quest == null) return BadRequest("Invalid input data.");

            var result = await _questsService.UpdateQuestAsync(id, quest);
            return result ? Ok("Quest updated successfully.") : NotFound("Quest not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuest([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Invalid quest ID.");

            var result = await _questsService.DeleteQuestAsync(id);
            return result ? Ok("Quest deleted successfully.") : NotFound("Quest not found.");
        }
    }

}
