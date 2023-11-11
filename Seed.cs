using MelosBookStore.Data;
using MelosBookStore.Models;

namespace MelosBookStore.Seed
{
    public class Seed 
    {
        private readonly BookStoreContext bookStoreContext;
        public Seed(BookStoreContext context)
        {
            this.bookStoreContext = context;
        }
        public void SeedDataContext()
        {
            if (!bookStoreContext.BookSellers.Any())
            {
                var Authors = new List<Author>()
                {
                    new()
                    {
                        FirstName = "Paulo",
                        LastName = "Coelho"
                    },
                    new()
                    {
                        FirstName = "Aba",
                        LastName = "Hagan"
                    },
                    new()
                    {
                        FirstName = "Sydney",
                        LastName = "Pratt"
                    },
                };
                bookStoreContext.Authors.AddRange(Authors);
                bookStoreContext.SaveChanges();
                var Sellers = new List<Seller>()
                {
                    new ()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@jdbooks.com",
                    Password= "password",
                    PhoneNumber = "0201234567",
                    ShopName = "JD Books"
                },
                    new ()
                {
                    FirstName = "Elizabeth",
                    LastName = "Deer",
                    Email = "elizabethdeer@edbooks.com",
                    Password= "password",
                    PhoneNumber = "0201234567",
                    ShopName = "ED Stationery"
                },
                    new ()
                {
                    FirstName = "Kwame",
                    LastName = "Pocho",
                    Email = "thepocho@kpbooks.com",
                    Password= "password",
                    PhoneNumber = "0201234567",
                    ShopName = "The Pocho Literature"
                },
                };
                bookStoreContext.Sellers.AddRange(Sellers);
                bookStoreContext.SaveChanges();

                var Categories = new List<Category>()
                {
                    new()
                    {
                        Name = "Fiction"
                    },
                    new()
                    {
                        Name = "Science"
                    },
                    new()
                    {
                        Name = "French"
                    },
                };
                bookStoreContext.Categories.AddRange(Categories);
                bookStoreContext.SaveChanges();
                
                var bookSellers = new List<BookSeller>()
                {
                    new()
                    {
                        Book = new()
                        {
                            Title = "The Alchemist",
                            Author = Authors[0].FirstName + " " + Authors[0].LastName,
                            Description = "",
                            Price = 20.00f,
                        },
                        Seller = Sellers[0]
                    },
                    new()
                    {
                        Book = new()
                        {
                            Title = "The Market Day",
                            Author = Authors[1].FirstName + " " + Authors[1].LastName,
                            Description = "",
                            Price = 45.00f,
                        },
                        Seller = Sellers[1]
                    },
                    new()
                    {
                        Book = new()
                        {
                            Title = "Le Petit Kofi",
                            Author = Authors[2].FirstName + " " + Authors[2].LastName,
                            Description = "",
                            Price = 60.50f,
                        },
                        Seller = Sellers[2]
                    },
                };
                bookStoreContext.BookSellers.AddRange(bookSellers);
                bookStoreContext.SaveChanges();
            }
        }
    }
}