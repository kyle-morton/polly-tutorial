using RequestService.Policies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ImmediateRetryClient").AddPolicyHandler(
    request => request.Method == HttpMethod.Get 
        ? new ClientPolicy().LinearHttpRetry
        : new ClientPolicy().ExponentialHttpRetry
);
builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();