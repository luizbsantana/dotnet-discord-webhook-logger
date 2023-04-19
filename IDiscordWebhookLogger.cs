using System;
using CSharpDiscordWebhook.NET.Discord;

namespace Discord.Webhook.Logger
{
	public interface IDiscordWebhookLogger
	{
        void Information(string title, string message);

        void Information(string title, string message, List<EmbedField> embedFields);

        void Warning(string title, string message);

        void Warning(string title, string message, List<EmbedField> embedFields);

        void Error(string title, string message);

        void Error(string title, string message, List<EmbedField> embedFields);

        void Error(Exception exception);

        void Error(Exception exception, string message);
    }
}

