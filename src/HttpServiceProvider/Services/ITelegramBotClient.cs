using TvMaze.HttpServiceProvider.Models.Telegram;

namespace TvMaze.HttpServiceProvider.Services;

public interface ITelegramBotClient
{
    // curl -s -X POST https://api.telegram.org/bot7126013546:AAG-kR-aakLB8jUE5Qi6dA-ZhCOQJxmUThM/sendMessage -d chat_id=7126013546 -d text="Hello World"
    Task<SendMessageResponse> SendMessageAsync(long chatId, string message);

    //curl https://api.telegram.org/bot7126013546:AAG-kR-aakLB8jUE5Qi6dA-ZhCOQJxmUThM/getUpdates
    Task<UpdateResponse> GetUpdates();

    // curl --request POST \
    //--url https://api.telegram.org/bot7126013546:AAG-kR-aakLB8jUE5Qi6dA-ZhCOQJxmUThM/getMe \
    //--header 'Content-Type: application/json'
    Task<GetMeResponse> GetMe();

    // curl https://api.telegram.org/bot7126013546:AAG-kR-aakLB8jUE5Qi6dA-ZhCOQJxmUThM/getchat?chat_id=5819600493
    Task<ChatResponse> GetChat(int chatId);

}