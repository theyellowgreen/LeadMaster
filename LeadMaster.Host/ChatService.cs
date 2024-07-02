using LeadMaster.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LeadMaster;

public class ChatService
{
    private readonly AppDbContext _dbContext;

    public ChatService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Chat>> GetChatsAsync() => 
        await _dbContext.Set<Chat>().ToListAsync();

    public async Task<IReadOnlyCollection<ChatMessage>> GetMessagesAsync(Guid chatId) =>
        await _dbContext.Set<ChatMessage>()
            .Where(p => p.Chat.Id == chatId)
            .ToListAsync();

    public async Task UpdateChatAsync(Chat chat)
    {
        chat.Messages.Where(p => p.Id == Guid.Empty)
            .ToList()
            .ForEach(p => _dbContext.Add(p));

        _dbContext.Update(chat);

        await _dbContext.SaveChangesAsync();


    }
}