using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MelosBookStore.Models;
using MelosBookStore.Data;
using MelosBookStore.Seed;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Host=localhost;Port=5432;Username=kodjocode;Password=kodjocode1234;Database=melosbookstore";
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => {
      options.AddPolicy(name: MyAllowSpecificOrigins,
                        builder => {
                           builder.WithOrigins("http://localhost:3000",
                                                "http://localhost:3001");
                        });
});
builder.Services.AddTransient<Seed>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<BookStoreContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "MelosBookStore API", Description = "Reading maketh man", Version = "v1" });
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<Seed>();
    service?.SeedDataContext();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "MelosBookStore API V1");
});

app.MapGet("/", () => "Welcome to Melobookstore!");

// Authors
app.MapGet("/authors", async (BookStoreContext db) => {
    var authorsWithBooks = await db.Authors
        .Include(a => a.BookAuthors)
        .ThenInclude(ba => ba.Book)
        .ToListAsync();

    return authorsWithBooks;
});
app.MapPost("/author", async (BookStoreContext db, Author Author) =>
{
   await db.Authors.AddAsync(Author);
   await db.SaveChangesAsync();
   return Results.Created($"/author/{Author.Id}", Author);
});
app.MapGet("/author/{id}", async (BookStoreContext db, int id) => await db.Authors.FindAsync(id));
app.MapPut("/author/{id}", async (BookStoreContext db, Author updateAuthor, int id) =>
{
      var Author = await db.Authors.FindAsync(id);
      if (Author is null) return Results.NotFound();
      Author.FirstName = updateAuthor.FirstName;
      Author.LastName = updateAuthor.LastName;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/author/{id}", async (BookStoreContext db, int id) =>
{
   var Author = await db.Authors.FindAsync(id);
   if (Author is null)
   {
      return Results.NotFound();
   }
   db.Authors.Remove(Author);
   await db.SaveChangesAsync();
   return Results.Ok();
});

// Books
app.MapGet("/books", async (BookStoreContext db) => await db.Books.ToListAsync());
app.MapPost("/book", async (BookStoreContext db, Book Book) =>
{
   await db.Books.AddAsync(Book);
   await db.SaveChangesAsync();
   return Results.Created($"/book/{Book.Id}", Book);
});
app.MapGet("/book/{id}", async (BookStoreContext db, int id) => await db.Books.FindAsync(id));
app.MapPut("/book/{id}", async (BookStoreContext db, Book updateBook, int id) =>
{
      var Book = await db.Books.FindAsync(id);
      if (Book is null) return Results.NotFound();
      Book.Title = updateBook.Title;
      Book.Description = updateBook.Description;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/book/{id}", async (BookStoreContext db, int id) =>
{
   var Book = await db.Books.FindAsync(id);
   if (Book is null)
   {
      return Results.NotFound();
   }
   db.Books.Remove(Book);
   await db.SaveChangesAsync();
   return Results.Ok();
});

// Users
app.MapGet("/users", async (BookStoreContext db) => await db.Users.ToListAsync());
app.MapPost("/user", async (BookStoreContext db, User User) =>
{
   await db.Users.AddAsync(User);
   await db.SaveChangesAsync();
   return Results.Created($"/seller/{User.Id}", User);
});
app.MapGet("/user/{id}", async (BookStoreContext db, int id) => await db.Users.FindAsync(id));
app.MapPut("/user/{id}", async (BookStoreContext db, User updateUser, int id) =>
{
      var User = await db.Users.FindAsync(id);
      if (User is null) return Results.NotFound();
      User.FirstName = updateUser.FirstName;
      User.LastName = updateUser.LastName;
      User.Email = updateUser.Email;
      User.Password = updateUser.Password;
      User.PhoneNumber = updateUser.PhoneNumber;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/user/{id}", async (BookStoreContext db, int id) =>
{
   var User = await db.Users.FindAsync(id);
   if (User is null)
   {
      return Results.NotFound();
   }
   db.Users.Remove(User);
   await db.SaveChangesAsync();
   return Results.Ok();
});

// Sellers
app.MapGet("/sellers", async (BookStoreContext db) => await db.Sellers.ToListAsync());
app.MapPost("/seller", async (BookStoreContext db, Seller Seller) =>
{
   await db.Sellers.AddAsync(Seller);
   await db.SaveChangesAsync();
   return Results.Created($"/seller/{Seller.Id}", Seller);
});
app.MapGet("/seller/{id}", async (BookStoreContext db, int id) => await db.Sellers.FindAsync(id));

// Buyers
app.MapGet("/buyers", async (BookStoreContext db) => await db.Buyers.ToListAsync());
app.MapPost("/buyer", async (BookStoreContext db, Buyer Buyer) =>
{
   await db.Buyers.AddAsync(Buyer);
   await db.SaveChangesAsync();
   return Results.Created($"/buyer/{Buyer.Id}", Buyer);
});
app.MapGet("/buyer/{id}", async (BookStoreContext db, int id) => await db.Buyers.FindAsync(id));

// Reviews
app.MapGet("/reviews", async (BookStoreContext db) => await db.Reviews.ToListAsync());
app.MapPost("/review", async (BookStoreContext db, Review Review) =>
{
   await db.Reviews.AddAsync(Review);
   await db.SaveChangesAsync();
   return Results.Created($"/review/{Review.Id}", Review);
});
app.MapGet("/review/{id}", async (BookStoreContext db, int id) => await db.Reviews.FindAsync(id));
app.MapDelete("/review/{id}", async (BookStoreContext db, int id) =>
{
   var Review = await db.Reviews.FindAsync(id);
   if (Review is null)
   {
      return Results.NotFound();
   }
   db.Reviews.Remove(Review);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.UseHttpsRedirection();

app.Run();
