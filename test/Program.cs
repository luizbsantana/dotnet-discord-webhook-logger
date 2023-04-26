using Discord.Webhook.Logger;

var divider = "==========";
var webhookUrl = "https://discord.com/api/webhooks/1100910293250478080/JoVKzeCJB2IMhzonyeQrPFFh_PKlD1zb0Rjo6VrIDeiEZPYLkpQcvLy2UIBnZD24gEke";

Console.WriteLine($"{divider} DISCORD WEBHOOK LOGGER TEST!!! {divider}");

var logger = new DiscordWebhookLogger(new DiscordWebhookLoggerSettings(webhookUrl));

logger.Information("PROJETO DE TESTE INICIANDO", $"{divider} DISCORD WEBHOOK LOGGER TEST!!! {divider}");

try
{
    throw new Exception("TESTE DO WEBHOOK LOGGER");
}
catch (Exception ex)
{
    logger.Error(ex);
}

logger.Warning("PROJETO DE TESTE DEU TUDO CERTO", $"{divider} DISCORD WEBHOOK LOGGER TEST!!! {divider}");