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

        Task<bool> StartQuest(int questId, UserDTO userDTO);
        Task<PageResponse?> GetQuestPage(int questId, UserDTO userDTO);
        Task<bool> CheckTaskResponse(int questId, UserDTO userDTO, TaskResponseDTO response);
        Task<bool> FinishQuest(int questId, UserDTO userDTO);
    }
}
