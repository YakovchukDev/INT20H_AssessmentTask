
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestPlatform.Server.Data;
using QuestPlatform.Server.Enums;
using QuestPlatform.Server.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Page = QuestPlatform.Server.Models.Page;

namespace QuestPlatform.Server.Services
{
    public class QuestsService : IQuestsService
    {
        private readonly QuestPlatformDbContext _context;

        public QuestsService(QuestPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<QuestResponse?> GetQuestByIdAsync(int id)
        {
            if (id == null || id <= 0) return null;

            Quest? quest = await _context.Quests.FirstOrDefaultAsync(q => q.Id == id);
            return quest != null ? ConvertToQuestResponse(quest.Id) : null;
        }

        public async Task<QuestResponse[]?> GetQuestsByCategoryAsync(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) return null;

            int[] questIds = await _context.Quests
                .Where(q => q.Category != null && q.Category.Name == category)
                .Select(q => q.Id)
                .ToArrayAsync();

            return questIds.Length > 0 ? ConvertToQuestsResponse(questIds) : null;
        }

        public async Task<QuestResponse[]?> GetQuestsByUserComplitedQuestsAsync(UserDTO user)
        {
            if (user == null || user.Id <= 0) return null;

            int[] completedQuestIds = await _context.UserQuestHistories
                .Where(uqh => uqh.Status == QuestStatus.Success && uqh.UserId == user.Id)
                .Select(uqh => uqh.QuestId)
                .ToArrayAsync();

            if (completedQuestIds.Length == 0) return null;

            return ConvertToQuestsResponse(completedQuestIds);
        }

        public async Task<QuestResponse[]?> GetQuestsByUserCreatedQuestAsync(UserDTO user)
        {
            if (user == null || user.Id <= 0) return null;

            int[] questIds = await _context.Quests
                .Where(q => q.Author != null && q.Author.Id == user.Id)
                .Select(q => q.Id)
                .ToArrayAsync();

            return questIds.Length > 0 ? ConvertToQuestsResponse(questIds) : null;
        }

        public async Task<QuestResponse[]?> GetQuestsByFilterAsync(SearchFilter filter)
        {
            if(filter == null) return null;

            int[] questIds = await _context.Quests
                .Where(q => (
                q.Category.Name == filter.Category)
                && ((filter.NoLimitTimer) || (q.Timer.Minutes >= filter.Timer.Min && q.Timer.Minutes <= filter.Timer.Max))
                && (q.Participants >= filter.Participants.Min && q.Participants <= filter.Participants.Max)
                && (q.Difficulty >= filter.Difficulty.Min && q.Difficulty <= filter.Difficulty.Max)
                && (q.Rating >= filter.Rating.Min && q.Rating <= filter.Rating.Max)
                && (q.Tags.Intersect(filter.Tags).Any())).Select(q => q.Id)
                .ToArrayAsync();

            return questIds != null ? ConvertToQuestsResponse(questIds) : null;
        }

        public async Task<bool> CreateQuestAsync(QuestRequest quest)
        {
            if(quest == null) return false;

            QuestText title = _context.QuestTexts.Add(new QuestText() { Text = quest.Title.Text, Color = quest.Title.Color }).Entity;
            QuestText description = _context.QuestTexts.Add(new QuestText() { Text = quest.Description.Text, Color = quest.Description.Color }).Entity;

            if (quest.Author.Id == null || quest.Author.Id < 0) return false;
            User author = _context.Users.FirstOrDefault(u => u.Id == quest.Author.Id);
            if (author == null)
            {
                return false;
            }

            if (quest.PreviewMediaFile == null) return false;
            string fileName = $"{title.Id}{description.Id}{author.Id}.{Path.GetExtension(quest.PreviewMediaFile.FileName).ToLower()}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Previews", fileName);
            MediaFile previewMediaFile = _context.MediaFiles.Add(new MediaFile() { FilePath = filePath, FileType = FileType.Image }).Entity;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await quest.PreviewMediaFile.CopyToAsync(stream);
            }

            if (quest.Category == null) return false;
            Category category;
            if (!_context.Categories.Select(c => c.Name).Contains(quest.Category))
            {
                category = _context.Categories.Add(new Category() { Name = quest.Category }).Entity;
            }
            else
            {
                category = _context.Categories.FirstOrDefault(c => c.Name == quest.Category);
            }

            if (quest.Timer == null || quest.IsPublish == null || quest.Participants == null || quest.Difficulty == null) return false;
            Quest newQuest = _context.Quests.Add(new Quest()
            {
                TitleId = title.Id,
                DescriptionId = description.Id,
                AuthorId = author.Id,
                CreatedAt = DateTime.UtcNow,
                PreviewMediaFileId = previewMediaFile.Id,
                Timer = TimeSpan.FromMinutes(quest.Timer),
                CategoryId = category.Id,
                Participants = quest.Participants,
                Difficulty = quest.Difficulty,
                Tags = quest.Tags,
                Visible = quest.IsPublish,
                Title = title,
                Description = description,
                Author = author,
                PreviewMediaFile = previewMediaFile,
                Category = category,
            }).Entity;

            if (quest.Pages == null) return false;
            for(int i = 0; i < quest.Pages.Count; i++)
            {
                if (quest.Pages[i].Title == null) return false;
                Page page = _context.Pages.Add(new Page() { QuestId = newQuest.Id, PageNumber = i, Title = quest.Pages[i].Title, Quest = newQuest }).Entity;

                if (quest.Pages[i].Elements == null) continue;
                List<PageElement> pageElements = new List<PageElement>();
                for (int j = 0; j < quest.Pages[i].Elements.Count; j++)
                {
                    MediaFile mediaFile;
                    if (quest.Pages[i].Elements[j].ContentType != ContentType.Text)
                    {
                        string elementFileName = $"{newQuest.Id}{page.Id}{pageElements[j].Order}.{Path.GetExtension(quest.PreviewMediaFile.FileName).ToLower()}";
                        string elementFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageContents", elementFileName);
                        mediaFile = _context.MediaFiles.Add(new MediaFile() { FilePath = elementFilePath, FileType = (FileType)Enum.Parse(typeof(FileType), quest.Pages[i].Elements[j].ContentType.ToString()) }).Entity;
                        using (var stream = new FileStream(elementFilePath, FileMode.Create))
                        {
                            await quest.PreviewMediaFile.CopyToAsync(stream);
                        }
                        pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = page.Id, ContentType = quest.Pages[i].Elements[j].ContentType, Content = quest.Pages[i].Elements[j].Content, MediaFileId = mediaFile.Id, MediaFile = mediaFile, Order = quest.Pages[i].Elements[j].Order, Page = page }).Entity);
                    }
                    else
                    {
                        pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = page.Id, ContentType = quest.Pages[i].Elements[j].ContentType, Content = quest.Pages[i].Elements[j].Content, Order = quest.Pages[i].Elements[j].Order, Page = page }).Entity);
                    }
                    _context.Quests.FirstOrDefault(q => q.Id == newQuest.Id).Pages.Add(page);
                }
                page.PageElements = pageElements;

                TaskResponseType responseType = _context.TaskResponseTypes.Add(new TaskResponseType() { Type = quest.Pages[i].Task.Type }).Entity;
                QuestTask task = _context.QuestTasks.Add(new QuestTask() { PageId = page.Id, TaskDescription = quest.Pages[i].Task.Description, ResponseTypeId = responseType.Id, ResponseType = responseType }).Entity;
                TaskResponse taskResponse = _context.TaskResponses.Add(new TaskResponse() { TaskId = task.Id, ResponseTypeId = responseType.Id, Answer = quest.Pages[i].Response.Answer, AdditionalData = quest.Pages[i].Response.AdditionalData, Task = task, Type = responseType }).Entity;
                List<TaskOption> optionsList = new List<TaskOption>();
                for (int k = 0; k < quest.Pages[k].Task.Option.Count; k++)
                {
                    optionsList.Add(_context.TaskOptions.Add(new TaskOption() { TaskId = task.Id, Task = task, OptionText = quest.Pages[i].Task.Option[k] }).Entity);
                }
                _context.QuestTasks.FirstOrDefault(t => t.Id == task.Id).TaskOptions = optionsList;
            }

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateQuestAsync(int id, QuestRequest updatedQuest)
        {
            if (id == null || id < 0 || updatedQuest == null) return false;
            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == id);
            if(quest != null)
            {
                return false;
            }

            quest.Title.Text = updatedQuest.Title.Text;
            quest.Title.Color = updatedQuest.Title.Color;

            quest.Description.Text = updatedQuest.Description.Text;
            quest.Description.Color = updatedQuest.Description.Color;

            if (updatedQuest.PreviewMediaFile == null) return false;
            if (File.Exists(quest.PreviewMediaFile.FilePath))
            {
                File.Delete(quest.PreviewMediaFile.FilePath);
            }
            using (var stream = new FileStream(quest.PreviewMediaFile.FilePath, FileMode.Create))
            {
                await updatedQuest.PreviewMediaFile.CopyToAsync(stream);
            }

            Category category = _context.Categories.FirstOrDefault(c => c.Name == updatedQuest.Category);
            if (category == null)
            {
                category = _context.Categories.Add(new Category() { Name = updatedQuest.Category }).Entity;
                quest.CategoryId = category.Id;
                quest.Category = category;
            }
            else
            {
                quest.CategoryId = category.Id;
                quest.Category = category;
            }

            if (updatedQuest.Timer == null || updatedQuest.Participants == null || updatedQuest.Difficulty == null || updatedQuest.Tags == null || updatedQuest.IsPublish == null) return false;
            quest.UpdatedAt = DateTime.UtcNow;
            quest.Timer = TimeSpan.FromMinutes(updatedQuest.Timer);
            quest.Participants = updatedQuest.Participants;
            quest.Difficulty = updatedQuest.Difficulty;
            quest.Tags = updatedQuest.Tags;
            quest.Visible = updatedQuest.IsPublish;

            if (updatedQuest.Pages == null) return false;
            List<Page> pages = _context.Pages.Where(p => p.QuestId == quest.Id).ToList();
            for (int i = 0; i < updatedQuest.Pages.Count; i++)
            {
                if (updatedQuest.Pages[i].Elements == null) continue;
                if(pages.Count > i)
                {
                    pages[i].Title = updatedQuest.Pages[i].Title;
                    pages[i].PageNumber = i;

                    List<PageElement> pageElements = _context.PageElements.Where(p => p.PageId == pages[i].Id).ToList();
                    for (int j = 0; j < updatedQuest.Pages[i].Elements.Count; j++)
                    {
                        if (pageElements.Count > j)
                        {
                            pageElements[j].ContentType = updatedQuest.Pages[i].Elements[j].ContentType;
                            pageElements[j].Content = updatedQuest.Pages[i].Elements[j].Content;
                            pageElements[j].Order = updatedQuest.Pages[i].Elements[j].Order;

                            if (File.Exists(pageElements[j].MediaFile.FilePath))
                            {
                                File.Delete(pageElements[j].MediaFile.FilePath);
                            }
                            if (updatedQuest.Pages[i].Elements[j].ContentType == ContentType.Text && pageElements[j].MediaFile != null)
                            {
                                _context.MediaFiles.Remove(pageElements[j].MediaFile);
                                pageElements[j].MediaFileId = 0;
                                pageElements[j].MediaFile = null;
                            }
                            else
                            {
                                using (var stream = new FileStream(pageElements[j].MediaFile.FilePath, FileMode.Create))
                                {
                                    await updatedQuest.Pages[i].Elements[j].MediaFile.CopyToAsync(stream);
                                }
                            }
                        }
                        else
                        {
                            MediaFile mediaFile;
                            if (updatedQuest.Pages[i].Elements[j].ContentType != ContentType.Text)
                            {
                                string elementFileName = $"{quest.Id}{pages[i].Id}{pageElements[j].Order}.{Path.GetExtension(updatedQuest.PreviewMediaFile.FileName).ToLower()}";
                                string elementFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageContents", elementFileName);
                                mediaFile = _context.MediaFiles.Add(new MediaFile() { FilePath = elementFileName, FileType = (FileType)Enum.Parse(typeof(FileType), updatedQuest.Pages[i].Elements[j].ContentType.ToString()) }).Entity;
                                using (var stream = new FileStream(elementFileName, FileMode.Create))
                                {
                                    await updatedQuest.PreviewMediaFile.CopyToAsync(stream);
                                }
                                pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = pages[i].Id, ContentType = updatedQuest.Pages[i].Elements[j].ContentType, Content = updatedQuest.Pages[i].Elements[j].Content, MediaFileId = mediaFile.Id, MediaFile = mediaFile, Order = updatedQuest.Pages[i].Elements[j].Order, Page = pages[i] }).Entity);
                            }
                            else
                            {
                                pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = pages[i].Id, ContentType = updatedQuest.Pages[i].Elements[j].ContentType, Content = updatedQuest.Pages[i].Elements[j].Content, Order = updatedQuest.Pages[i].Elements[j].Order, Page = pages[i] }).Entity);
                            }
                            _context.Quests.FirstOrDefault(q => q.Id == quest.Id).Pages.Add(pages[i]);
                        }
                    }
                    pages[i].PageElements = pageElements;


                    QuestTask task = _context.QuestTasks.FirstOrDefault(t => t.PageId == pages[i].Id);
                    if (task == null) return false;
                    task.TaskDescription = updatedQuest.Pages[i].Task.Description;
                    _context.TaskResponseTypes.FirstOrDefault(rt => rt.Id == task.ResponseTypeId).Type = updatedQuest.Pages[i].Task.Type;
                   
                    TaskResponse taskResponse = _context.TaskResponses.FirstOrDefault(tr => tr.TaskId == task.Id);
                    if(taskResponse == null) return false;
                    taskResponse.Answer = updatedQuest.Pages[i].Response.Answer;
                    taskResponse.AdditionalData = updatedQuest.Pages[i].Response.AdditionalData;

                    List<TaskOption> optionsList = _context.TaskOptions.Where(to => to.TaskId == task.Id).ToList();
                    for (int k = 0; k < updatedQuest.Pages[i].Task.Option.Count; k++)
                    {
                        if (optionsList.Count > k)
                        {
                            optionsList[k].OptionText = updatedQuest.Pages[k].Task.Option[k];
                        }
                        else
                        {
                            optionsList.Add(_context.TaskOptions.Add(new TaskOption()).Entity);
                        }
                    }
                    if(updatedQuest.Pages[i].Task.Option.Count < optionsList.Count)
                    {
                        for(int k = updatedQuest.Pages[i].Task.Option.Count; k < optionsList.Count; )
                        {
                            _context.TaskOptions.Remove(optionsList[k]);
                            optionsList.RemoveAt(k);
                        }
                    }
                    _context.QuestTasks.FirstOrDefault(t => t.Id == task.Id).TaskOptions = optionsList;
                }
                else
                {
                    Page page = _context.Pages.Add(new Page() { QuestId = quest.Id, PageNumber = i, Title = updatedQuest.Pages[i].Title, Quest = quest }).Entity;

                    if (updatedQuest.Pages[i].Elements == null) continue;
                    List<PageElement> pageElements = new List<PageElement>();
                    for (int j = 0; j < updatedQuest.Pages[i].Elements.Count; j++)
                    {
                        MediaFile mediaFile;
                        if (updatedQuest.Pages[i].Elements[j].ContentType != ContentType.Text)
                        {
                            string elementFileName = $"{quest.Id}{page.Id}{pageElements[j].Order}.{Path.GetExtension(updatedQuest.PreviewMediaFile.FileName).ToLower()}";
                            string elementFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PageContents", elementFileName);
                            mediaFile = _context.MediaFiles.Add(new MediaFile() { FilePath = elementFilePath, FileType = (FileType)Enum.Parse(typeof(FileType), updatedQuest.Pages[i].Elements[j].ContentType.ToString()) }).Entity;
                            using (var stream = new FileStream(elementFileName, FileMode.Create))
                            {
                                await updatedQuest.PreviewMediaFile.CopyToAsync(stream);
                            }
                            pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = page.Id, ContentType = updatedQuest.Pages[i].Elements[j].ContentType, Content = updatedQuest.Pages[i].Elements[j].Content, MediaFileId = mediaFile.Id, MediaFile = mediaFile, Order = updatedQuest.Pages[i].Elements[j].Order, Page = page }).Entity);
                        }
                        else
                        {
                            pageElements.Add(_context.PageElements.Add(new PageElement() { PageId = page.Id, ContentType = updatedQuest.Pages[i].Elements[j].ContentType, Content = updatedQuest.Pages[i].Elements[j].Content, Order = updatedQuest.Pages[i].Elements[j].Order, Page = page }).Entity);
                        }
                        _context.Quests.FirstOrDefault(q => q.Id == quest.Id).Pages.Add(page);
                    }
                    page.PageElements = pageElements;

                    TaskResponseType responseType = _context.TaskResponseTypes.Add(new TaskResponseType() { Type = updatedQuest.Pages[i].Task.Type }).Entity;
                    QuestTask task = _context.QuestTasks.Add(new QuestTask() { PageId = page.Id, TaskDescription = updatedQuest.Pages[i].Task.Description, ResponseTypeId = responseType.Id, ResponseType = responseType }).Entity;
                    TaskResponse taskResponse = _context.TaskResponses.Add(new TaskResponse() { TaskId = task.Id, ResponseTypeId = responseType.Id, Answer = updatedQuest.Pages[i].Response.Answer, AdditionalData = updatedQuest.Pages[i].Response.AdditionalData, Task = task, Type = responseType }).Entity;
                    List<TaskOption> optionsList = new List<TaskOption>();
                    for (int k = 0; k < updatedQuest.Pages[k].Task.Option.Count; k++)
                    {
                        optionsList.Add(_context.TaskOptions.Add(new TaskOption() { TaskId = task.Id, Task = task, OptionText = updatedQuest.Pages[i].Task.Option[k] }).Entity);
                    }
                    _context.QuestTasks.FirstOrDefault(t => t.Id == task.Id).TaskOptions = optionsList;
                }
            }
            if(updatedQuest.Pages.Count < pages.Count)
            {
                for (int i = updatedQuest.Pages.Count; i < pages.Count;)
                {
                    _context.Pages.Remove(pages[i]);
                    pages.RemoveAt(i);
                }
            }
            quest.Pages = pages;

            try
            {
                _context.SaveChanges();
                return true;
            }catch {  return false; }
        }

        public async Task<bool> DeleteQuestAsync(int id)
        {
            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == id);
            if(quest == null)
            {
                return false;
            }

            foreach (Page page in quest.Pages)
            {
                QuestTask task = _context.QuestTasks.FirstOrDefault(t => t.PageId == page.Id);
                if (task == null) 
                {
                    return false;
                }
                TaskResponse taskResponse = _context.TaskResponses.FirstOrDefault(t => t.TaskId == task.Id);
                if (taskResponse == null)
                {
                    return false;
                }
                List<PageElement> pageElements = _context.PageElements.Where(pe => pe.PageId == page.Id).ToList();
                
                _context.TaskOptions.RemoveRange(_context.TaskOptions.Where(to => to.TaskId == task.Id).ToList());
                _context.TaskResponseTypes.Remove(taskResponse.Type);
                _context.QuestTasks.Remove(task);
                foreach (PageElement element in pageElements)
                {
                    _context.MediaFiles.Remove(element.MediaFile);
                    _context.PageElements.Remove(element);
                }
                _context.Pages.Remove(page);
            }

            _context.QuestTexts.Remove(quest.Title);
            _context.QuestTexts.Remove(quest.Description);
            _context.QuestRatings.RemoveRange(_context.QuestRatings.Where(r => r.QuestId == id).ToList());
            _context.UserQuestHistories.RemoveRange(_context.UserQuestHistories.Where(qh => qh.QuestId == id).ToList());
            _context.MediaFiles.Remove(quest.PreviewMediaFile);
            _context.Quests.Remove(quest);

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> StartQuestAsync(int questId, int userId)
        {
            if (questId == null || questId < 0 || userId == null || userId <= 0) return false;
            
            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == questId);
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if(user == null || quest == null) return false;
            
            _context.UserQuestHistories.Add(new UserQuestHistory() { QuestId = quest.Id, Quest = quest, Status = QuestStatus.InProgress, Step = 0, UserId = user.Id, User = user, TimeSpent = TimeSpan.FromMinutes(0) });

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public async Task<PageResponse?> GetCurrentPageAsync(int questId, int userId)
        {
            if (questId == null || questId < 0 || userId == null || userId <= 0) return null;
            
            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == questId);
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null || quest == null) return null;
            UserQuestHistory userQuestHistory = _context.UserQuestHistories.FirstOrDefault(uqh => uqh.QuestId == quest.Id && uqh.UserId == user.Id);


            var fileStream = new FileStream(quest.PreviewMediaFile.FilePath, FileMode.Open);
            IFormFile preview = new FormFile(fileStream, 0, fileStream.Length, "Preview", "Preview.png");
            QuestTask task = await _context.QuestTasks.FirstOrDefaultAsync(t => t.PageId == quest.Pages[userQuestHistory.Step].Id);
            TaskDTO taskDTO = new TaskDTO(task.TaskDescription, task.TaskOptions.Select(to => to.OptionText).ToList(), task.ResponseType.Type);
            if (task == null) return null;
            if (userQuestHistory.Step < quest.Pages.Count)
            {
                PageResponse pageResponse = new PageResponse(userQuestHistory.Step, quest.Pages[userQuestHistory.Step].Title,
                    quest.Pages[userQuestHistory.Step].PageElements.Select(pe => new PageElementDTO(pe.ContentType, pe.Content, preview, pe.Order)).ToList(), taskDTO);

                return pageResponse;
            }
            return null;
        }

        public async Task<bool> CheckAnswerAsync(int questId, int userId, TaskResponseDTO response)
        {
            if (questId == null || questId <= 0 || userId == null || userId <= 0 || response != null) return false;

            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == questId);
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || quest == null) return false;
            UserQuestHistory userQuestHistory = _context.UserQuestHistories.FirstOrDefault(uqh => uqh.QuestId == quest.Id && uqh.UserId == user.Id);
            if (userQuestHistory == null) return false;
            QuestTask task = _context.QuestTasks.FirstOrDefault(t => t.PageId == quest.Pages[userQuestHistory.Step].Id);
            TaskResponse taskResponse = _context.TaskResponses.FirstOrDefault(t => t.TaskId == task.Id);
            if(task == null || taskResponse == null) return false;

            if (response.Answer == taskResponse.Answer && response.AdditionalData == taskResponse.AdditionalData)
            {
                userQuestHistory.Step++;
                return true;
            }
            return false;
        }

        public async Task<bool> FinishQuestAsync(int questId, int userId)
        {
            if (questId == null || questId <= 0 || userId == null || userId <= 0) return false;

            Quest quest = _context.Quests.FirstOrDefault(q => q.Id == questId);
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || quest == null) return false;
            UserQuestHistory userQuestHistory = _context.UserQuestHistories.FirstOrDefault(uqh => uqh.QuestId == quest.Id && uqh.UserId == user.Id);
            if (userQuestHistory == null) return false;
            if (userQuestHistory.Step == quest.Pages.Count) 
            {
                return true;
            }
            return false;
        }

        public async Task<QuestResponse[]> GetCompletedQuestsAsync(string username)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return Array.Empty<QuestResponse>();

            int[] completedQuestIds = await _context.UserQuestHistories
                .Where(qh => qh.UserId == user.Id)
                .Select(qh => qh.QuestId)
                .ToArrayAsync();

            return ConvertToQuestsResponse(completedQuestIds);
        }

        public async Task<QuestResponse[]> GetCreatedQuestsAsync(string username)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return Array.Empty<QuestResponse>();

            int[] createdQuestIds = await _context.Quests
                .Where(q => q.AuthorId == user.Id)
                .Select(q => q.Id)
                .ToArrayAsync();

            return ConvertToQuestsResponse(createdQuestIds);
        }


        private QuestResponse[] ConvertToQuestsResponse(int[] questIds) 
        {
            QuestResponse[] questResponses = new QuestResponse[questIds.Length]; 
            for(int i = 0; i < questIds.Length; i++)
            {
                questResponses[i] = ConvertToQuestResponse(questIds[i]);
            }
            return questResponses;
        }

        private QuestResponse ConvertToQuestResponse(int questId)
        {
            Quest quest = _context.Quests
                .Include(q => q.PreviewMediaFile)
                .Include(q => q.Title)
                .Include(q => q.Description)
                .Include(q => q.Category)
                .Include(q => q.Author)
                .Include(q => q.QuestRatings)
                .Include(q => q.Pages)
                .FirstOrDefault(q => q.Id == questId);

            var fileStream = new FileStream(quest.PreviewMediaFile.FilePath, FileMode.Open);
            QuestResponse questResponse = new QuestResponse(
                quest.Id,
                new TextDTO(quest.Title.Text, quest.Title.Color),
                new TextDTO(quest.Description.Text, quest.Description.Color),
                new UserDTO(quest.Author.Id, quest.Author.Name, quest.Author.Username),
                new FormFile(fileStream, 0, fileStream.Length, "Preview", "Preview.png"),
                quest.Rating,
                quest.CreatedAt,
                quest.Timer.Minutes,
                quest.Category.Name,
                quest.Participants,
                quest.Difficulty,
                quest.Tags
                );
            return questResponse;
        }
    }
}
