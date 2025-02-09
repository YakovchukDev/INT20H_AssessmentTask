using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public class IQuestsService
    {
        Task<IEnumerable<Quest>> GetAllQuestsAsync();
        Task<Quest?> GetQuestByIdAsync(int id);
        Task<Quest> CreateQuestAsync(Quest quest);
        Task<bool> UpdateQuestAsync(Quest quest);
        Task<bool> DeleteQuestAsync(int id);
    }
}
