using System.Drawing;
using Brazil.Datetime;
using CSharpDiscordWebhook.NET.Discord;

namespace Discord.Webhook.Logger;
public class DiscordWebhookLogger : IDiscordWebhookLogger
{
    private readonly DiscordWebhookLoggerSettings _discordWebhookLoggerSettings;

    public DiscordWebhookLogger(DiscordWebhookLoggerSettings discordWebhookLoggerSettings)
    {
        _discordWebhookLoggerSettings = discordWebhookLoggerSettings;
    }

    public void Information(string title, string message)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Blue)
        });
    }

    public void Information(string title, string message, List<EmbedField> embedFields)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Blue),
            Fields = embedFields
        });
    }

    public void Warning(string title, string message)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Yellow)
        });
    }

    public void Warning(string title, string message, List<EmbedField> embedFields)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Yellow),
            Fields = embedFields
        });
    }

    public void Error(string title, string message)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Red)
        });
    }

    public void Error(string title, string message, List<EmbedField> embedFields)
    {
        SendMessage(new DiscordEmbed
        {
            Title = title,
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Red),
            Fields = embedFields
        });
    }

    public void Error(Exception exception)
    {
        SendMessage(new DiscordEmbed
        {
            Title = $"Exceção",
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Red),
            Fields = GetEmbedFields(exception)
        });
    }

    public void Error(Exception exception, string message)
    {
        SendMessage(new DiscordEmbed
        {
            Title = $"Exceção",
            Description = message,
            Timestamp = new DiscordTimestamp(DateTime.UtcNow.ToBrazilianTimeZone()),
            Color = new DiscordColor(Color.Red),
            Fields = GetEmbedFields(exception)
        });
    }

    private List<EmbedField> GetEmbedFields(Exception exception)
    {
        return new List<EmbedField>
            {
                new EmbedField { Name = "Type", Value = exception.GetType().ToString(), Inline = false },
                new EmbedField { Name = "Message", Value = exception.Message, Inline = false },
                new EmbedField { Name = "Stack Trace", Value = exception.StackTrace?.ToString(), Inline = false }
            };
    }

    private void SendMessage(DiscordEmbed discordEmbed)
    {
        var webhook = new DiscordWebhook();

        webhook.Uri = new Uri(_discordWebhookLoggerSettings.WebhookUrl);
        DiscordMessage message = new();
        message.Embeds.Add(discordEmbed);

        webhook.SendAsync(message);
    }
}

