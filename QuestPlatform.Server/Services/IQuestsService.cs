using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
<<<<<<< HEAD
    public interface IQuestsService
=======
    public class IQuestsService
>>>>>>> 9f18bc24643b739e9bbb5513ca78d98132059f20
    {
        Task<IEnumerable<Quest>> GetAllQuestsAsync();
        Task<Quest?> GetQuestByIdAsync(int id);
        Task<Quest> CreateQuestAsync(Quest quest);
        Task<bool> UpdateQuestAsync(Quest quest);
        Task<bool> DeleteQuestAsync(int id);
    }
<<<<<<< HEAD

=======
>>>>>>> 9f18bc24643b739e9bbb5513ca78d98132059f20
}
