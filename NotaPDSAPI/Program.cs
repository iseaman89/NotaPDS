using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using NotaPDSAPI.Data;
using NotaPDSAPI.Model;
using NotaPDSAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<APIDBContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgreeConnection")));
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();


//Get
app.MapGet("api/project", async (APIDBContext context) =>
{
    var items = await context.Projects.Include(nameof(Customer)).ToListAsync();

    return Results.Ok(items);
});

app.MapGet("api/customer", async (APIDBContext context) =>
{
    var items = await context.Customers.ToListAsync();

    return Results.Ok(items);
});

app.MapGet("api/user", async (APIDBContext context) =>
{
    var items = await context.Users.ToListAsync();

    return Results.Ok(items);
});

app.MapGet("api/chatmessage", async (APIDBContext context) =>
{
    var items = await context.ChatMessages.ToListAsync();

    return Results.Ok(items);
});

//Post
app.MapPost("api/project", async(APIDBContext context, Project project) =>
{
    await context.Projects.AddAsync(project);
    await context.SaveChangesAsync();

    return Results.Created($"api/project/{project.Id}", project);
});

app.MapPost("api/customer", async (APIDBContext context, Customer customer) =>
{
    await context.Customers.AddAsync(customer);
    await context.SaveChangesAsync();

    return Results.Created($"api/customer/{customer.Id}", customer);
});

app.MapPost("api/user", async (APIDBContext context, User user) =>
{
    await context.Users.AddAsync(user);
    await context.SaveChangesAsync();

    return Results.Created($"api/customer/{user.Id}", user);
});

app.MapPost("api/chatmessage", async (APIDBContext context, ChatMessage chatMessage) =>
{
    await context.ChatMessages.AddAsync(chatMessage);
    await context.SaveChangesAsync();

    return Results.Created($"api/customer/{chatMessage.Id}", chatMessage);
});

//Put
app.MapPut("api/project/{id}", async (APIDBContext context, int id, Project project) =>
{
    var projectModel = await context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    if (projectModel is null) return Results.NotFound();
    projectModel.YearNumber = project.YearNumber;
    projectModel.ProjectManagerNumber = project.ProjectManagerNumber;
    projectModel.ProjectNumber = project.ProjectNumber;
    projectModel.FullNumber = project.FullNumber;
    projectModel.Customer = project.Customer;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPut("api/customer/{id}", async (APIDBContext context, int id, Customer customer) =>
{
    var customerModel = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customerModel is null) return Results.NotFound();
    customerModel.Name = customer.Name;
    customerModel.ContactPersonFullName = customer.ContactPersonFullName;
    customerModel.ContactPersonTel = customer.ContactPersonTel;
    customerModel.Adresse = customer.Adresse;
    customerModel.ImportantInformation = customer.ImportantInformation;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPut("api/user/{id}", async (APIDBContext context, int id, User user) =>
{
    var userModel = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    if (userModel is null) return Results.NotFound();
    userModel.Name = user.Name;
    userModel.Surname = user.Surname;
    userModel.Email = user.Email;
    userModel.Password = user.Password;
    userModel.MobileNumber = user.MobileNumber;
    userModel.ProjectLeiterNumber = user.ProjectLeiterNumber;
    userModel.ProjectLeiter = user.ProjectLeiter;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPut("api/chatmessage/{id}", async (APIDBContext context, int id, ChatMessage chatMessage) =>
{
    var chatMessageModel = await context.ChatMessages.FirstOrDefaultAsync(c => c.Id == id);
    if (chatMessageModel is null) return Results.NotFound();
    chatMessageModel.Date = chatMessage.Date;
    chatMessage.Text = chatMessage.Text;
    chatMessage.Sender = chatMessage.Sender;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

//Delete
app.MapDelete("api/project/{id}", async (APIDBContext context, int id) =>
{
    var projectModel = await context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    if (projectModel is null) return Results.NotFound();

    context.Projects.Remove(projectModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/customer/{id}", async (APIDBContext context, int id) =>
{
    var customerModel = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    if (customerModel is null) return Results.NotFound();

    context.Customers.Remove(customerModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/user/{id}", async (APIDBContext context, int id) =>
{
    var userModel = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    if (userModel is null) return Results.NotFound();

    context.Users.Remove(userModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("api/chatmessage/{id}", async (APIDBContext context, int id) =>
{
    var chatMessageModel = await context.ChatMessages.FirstOrDefaultAsync(c => c.Id == id);
    if (chatMessageModel is null) return Results.NotFound();

    context.ChatMessages.Remove(chatMessageModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

//Hub
app.MapHub<ChatHub>("/chathub");

app.Run();