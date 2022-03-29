using HIS.Rule;
using HIS.Service.OrderHub;
using HIS.Service.Pub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//注入订单
builder.Services.AddScoped<IOrderHubService, OrderHubService>();
//注入规则
builder.Services.AddScoped<IOrderHubRule, OrderHubRule>();
//注入公共服务
builder.Services.AddScoped<IPubServices, PubServices>();
//使用内存缓存
builder.Services.AddMemoryCache();

/*
builder.Services.AddLogging(logBuilder =>
{
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console(new JsonFormatter())
    .CreateLogger();
    logBuilder.AddSerilog();
});*/

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
