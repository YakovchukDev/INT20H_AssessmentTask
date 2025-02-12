﻿
using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Models;

namespace QuestPlatform.Server.Services
{
    public class QuestsService : IQuestsService
    {
        private readonly QuestPlatformDbContext _context;

        public QuestsService(QuestPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quest>> GetAllQuestsAsync()
        {
            return await _context.Quests.Include(q => q.Author)
                                        .Include(q => q.Pages)
                                        .ToListAsync();
        }

        public async Task<Quest?> GetQuestByIdAsync(int id)
        {
            return await _context.Quests.Include(q => q.Author)
                                         .Include(q => q.Pages)
                                         .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Quest> CreateQuestAsync(Quest quest)
        {
            quest.CreatedAt = DateTime.UtcNow;
            quest.UpdatedAt = DateTime.UtcNow;
            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();
            return quest;
        }

        public async Task<bool> UpdateQuestAsync(Quest quest)
        {
            var existingQuest = await _context.Quests.FindAsync(quest.Id);
            if (existingQuest == null)
                return false;

            existingQuest.Title = quest.Title;
            existingQuest.Description = quest.Description;
            existingQuest.UpdatedAt = DateTime.UtcNow;
            _context.Quests.Update(existingQuest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuestAsync(int id)
        {
            var quest = await _context.Quests.FindAsync(id);
            if (quest == null)
                return false;

            _context.Quests.Remove(quest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
