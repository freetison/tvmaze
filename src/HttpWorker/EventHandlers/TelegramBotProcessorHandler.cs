﻿using MediatR;

using TvMaze.HttpServiceProvider.Services;

using Tx.Core.Extensions.String;

namespace TvMaze.HttpWorker.EventHandlers;

public class TelegramBotProcessorHandler(ILogger<TelegramBotProcessorHandler> logger, ITelegramBotClient telegramBotClient)
    : INotificationHandler<ExchangeRatesEvent>
{
    private readonly ITelegramBotClient _telegramBotClient = telegramBotClient;

    public async Task Handle(ExchangeRatesEvent notification, CancellationToken cancellationToken)
    {
        var message = notification.Data.ToJson();
        var result = await _telegramBotClient.SendMessageAsync(-4277423125, message);

        logger.LogInformation($"Message was sent to Telegram");
    }

}

