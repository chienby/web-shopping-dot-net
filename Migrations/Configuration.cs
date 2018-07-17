namespace WebShopping.Migrations
{
    using FizzWare.NBuilder;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShopping.Models.WebShoppingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebShopping.Models.WebShoppingContext";
        }

        protected override void Seed(WebShopping.Models.WebShoppingContext context)
        {
            //Configure Random
            var priceGenerator = new RandomGenerator();
            Random rnd = new Random();

            //Generate categories
            List<Category> categories = new List<Category>();

            categories.Add(new Category() { ImageUrl= "https://images4.alphacoders.com/378/thumb-350-37864.jpg", Title = "Light" });
            categories.Add(new Category() { ImageUrl= "https://images6.alphacoders.com/328/thumb-350-328339.jpg", Title = "Urban" });
            categories.Add(new Category() { ImageUrl= "https://images6.alphacoders.com/389/thumb-350-389093.jpg", Title = "Landscape" });
            categories.Add(new Category() { ImageUrl= "https://images5.alphacoders.com/587/thumb-350-587323.jpg", Title = "Moody" });


            context.Categories.AddOrUpdate(c => c.Id, categories.ToArray());

            string baseImageUrl = "https://picsum.photos/252/252/?image=";

            //Generate products
            var products = Builder<Product>.CreateListOfSize(100)
                .All()
                    .With(p => p.Category = Pick<Category>.RandomItemFrom(categories))
                    .With(p => p.Title = Faker.Lorem.Sentence())
                    .With(p => p.ImageUrl = baseImageUrl + rnd.Next(1, 1000).ToString())
                    .With(p => p.Price = priceGenerator.Next(10, 1000))
                    .With(p => p.ShortDescription = Faker.Lorem.Sentence())
                    .With(p => p.LongDescription = Faker.Lorem.Paragraph())
                .Build();

            context.Products.AddOrUpdate(p => p.Id, products.ToArray());
        }
    }
}
