using EncryptorFactory.Domain;
using EncryptorFactory.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg =>
    {
        cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((ctx, services) =>
    {
        services.AddTransient<DataService>();

        var alg = ctx.Configuration["Crypto:Algorithm"]?.Trim().ToUpperInvariant() ?? "AES";

        if (alg == "RSA")
            services.AddSingleton<EncryptorCreatorFactory, RsaEncryptorCreatorFactory>();
        else
            services.AddSingleton<EncryptorCreatorFactory, AesEncryptorCreatorFactory>();
    })
    .Build();

// --- Diagnóstico de selección ---
Console.WriteLine($"Config Crypto:Algorithm = {host.Services.GetRequiredService<IConfiguration>()["Crypto:Algorithm"]}");

var factory = host.Services.GetRequiredService<EncryptorCreatorFactory>();
Console.WriteLine($"Factory concreta registrada: {factory.GetType().Name}");

var encryptor = factory.Create();
Console.WriteLine($"Producto concreto creado: {encryptor.GetType().Name}");

// --- Prueba rápida ---
var svc = host.Services.GetRequiredService<DataService>();
var original = "5489 5246 8545 5214";
var cipher = svc.Save(original);
var plain = svc.Read(cipher);

Console.WriteLine($"Tarjeta original: {original}");
Console.WriteLine($"Tarjeta cifrada({cipher.Length} chars): {cipher}");
Console.WriteLine($"Tarjeta lectura   : {plain}");
