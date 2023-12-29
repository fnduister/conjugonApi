using ConjugonApi.Configuration.Extensions;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

builder.ConfigureMongo();

builder.ConfigureJwt();

builder.ConfigureSwagger();

var app = builder.Build();

app.ConfigureApplication();

// Configure the HTTP request pipeline.

await app.RunAsync();

[ExcludeFromCodeCoverage]
public partial class Program { }

