# Dotnet Logger Using Discord Webhook
Log errors, informations and warnings using a discord webhook to receive these log messages.

<br>

## :electric_plug: Configuring the Service

bulb: Configure this service correctly in your application (in Startup.cs or your custom configuration file):

```
...
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton(x => new Discord.Webhook.Logger.DiscordWebhookLoggerSettings(YOUR_DISCORD_WEBOOK_URL));
    services.AddScoped<Discord.Webhook.Logger.IDiscordWebhookLogger, Discord.Webhook.Logger.DiscordWebhookLogger>();
    ...
}
...
```

<br>

## :floppy_disk: Injecting Into Your Services

:bulb: Inject Discord.Webhook.Logger.IDiscordWebhookLogger to log all you want:

```
...
private readonly Discord.Webhook.Logger.IDiscordWebhookLogger _logger;

public void YourService(Discord.Webhook.Logger.IDiscordWebhookLogger logger)
{
    ...
    _logger = logger;
    ...
}
...
```

<br>

## :v: Contributors

[luizb_santana](https://twitter.com/luizb_santana)

## :mailbox_with_mail: License

This software was created for study purposes only. Feel free to try it out.