using System;
namespace Discord.Webhook.Logger
{
	public class DiscordWebhookLoggerSettings
	{
		public DiscordWebhookLoggerSettings(string webhookUrl)
		{
			WebhookUrl = webhookUrl;
		}

		public string WebhookUrl { get; set; }
	}
}

