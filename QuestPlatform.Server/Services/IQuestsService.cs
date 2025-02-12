using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public interface IQuestsService
    {
        Task<QuestResponse?> GetQuestByIdAsync(int id);
        Task<QuestResponse[]?> GetQuestsByCategoryAsync(string category);
        Task<QuestResponse[]?> GetQuestsByUserComplitedQuestsAsync(UserDTO user);
        Task<QuestResponse[]?> GetQuestsByUserCreatedQuestAsync(UserDTO user);
        Task<QuestResponse[]?> GetQuestsByFilterAsync(SearchFilter filter);

        Task<bool> CreateQuestAsync(QuestRequest quest);
        Task<bool> UpdateQuestAsync(int id, QuestRequest quest);
        Task<bool> DeleteQuestAsync(int id);

        Task<bool> StartQuestAsync(int questId, int userId);
        Task<PageResponse?> GetCurrentPageAsync(int questId, int userId);
        Task<bool> CheckAnswerAsync(int questId, int userId, TaskResponseDTO response);
        Task<bool> FinishQuestAsync(int questId, int userId);
        Task<QuestResponse[]> GetCompletedQuestsAsync(string username);
        Task<QuestResponse[]> GetCreatedQuestsAsync(string username);
    }
}
