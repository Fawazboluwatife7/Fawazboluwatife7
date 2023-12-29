using aBookApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aBookApp.Data
{
    public class appDbContext: IdentityDbContext
	{
        public appDbContext(DbContextOptions<appDbContext>options): base (options)
        {
            
        }
        public DbSet<Order> orders { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Order>().HasData(
				new Order { Id = 1,Name = "Action", DisplayOrder = 1 },
				new Order { Id = 2, Name = "Sci-fi", DisplayOrder = 2 },
				new Order { Id = 3, Name = "Romance", DisplayOrder = 3 }
			
                );


            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    PriceList = 99,
                    OrderId = 1,
                    ImageUrl= ""
                    
                },
                new Products
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    PriceList = 40,
                    OrderId = 2,
                    ImageUrl = ""

                },
                new Products
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    PriceList= 50,
                    OrderId = 3,
                    ImageUrl = ""
                },
                new Products
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    PriceList = 70,
                    OrderId = 1,
                    ImageUrl = ""

                },
                new Products
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    PriceList = 30,
                    OrderId = 2,
                    ImageUrl = ""

                },
                new Products
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    PriceList = 25,
                    OrderId = 2,
                    ImageUrl = ""

                }

             );

        }
	} 
















}
