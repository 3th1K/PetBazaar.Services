using Ethik.Utility.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;

namespace ProductService.Infrastructure.Repositories;

public class FoodProductRepository : BaseRepository<FoodProduct, ApplicationDbContext>, IFoodProductRepository
{
    public FoodProductRepository(IDbContextFactory<ApplicationDbContext> contextFactory, ILogger<FoodProductRepository> logger) : base(contextFactory, logger)
    {
        using var context = _contextFactory.CreateDbContext();
        // Create 5 cat food products
        var catFood1 = new FoodProduct
        {
            Id = Guid.NewGuid().ToString(),
            CategoryId = "CF123",
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            IsDeleted = false,
            Name = "Whiskas Ocean Fish Flavor",
            Price = 5.99M,
            DescriptionShort = "Delicately cooked ocean fish in a savory gravy",
            DescriptionMedium = "Whiskas Ocean Fish Flavor provides your feline friend with the delicious taste of real ocean fish in a gravy they'll love. Packed with essential nutrients, it helps support their overall health and well-being.",
            DescriptionLarge = "Made with high-quality ingredients, Whiskas Ocean Fish Flavor cat food is a complete and balanced meal that's formulated to meet the nutritional needs of adult cats. It contains essential vitamins and minerals to support healthy skin and coat, strong muscles, and a healthy immune system.",
            Ingredients = "Chicken by-products (meat & bone meal), fish (ocean fish), corn gluten meal, wheat flour, soy flour, soybean meal, animal fat (preserved with mixed-tocopherols), brewers dried yeast, taurine, vitamins (DL-methionine, vitamin E supplement, thiamine mononitrate (vitamin B1), niacin (vitamin B3), calcium pantothenate, vitamin B6, riboflavin (vitamin B2), folic acid, biotin, vitamin A supplement, vitamin D3), minerals (potassium chloride, calcium carbonate, salt, ferrous sulfate, manganese sulfate, copper sulfate, zinc oxide), red 40, yellow 5, yellow 6"
        };

        var catFood2 = new FoodProduct
        {
            Id = Guid.NewGuid().ToString(),
            CategoryId = "CF123",
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            IsDeleted = false,
            Name = "Purina One Tender Favorites with Real Chicken",
            Price = 7.49M,
            DescriptionShort = "Tender, shredded chicken in a gravy your cat will crave",
            DescriptionMedium = "Purina One Tender Favorites with Real Chicken is a delicious wet cat food made with real, shredded chicken in a gravy that cats love. It's formulated to provide 100% complete and balanced nutrition for adult cats.",
            DescriptionLarge = "Purina One Tender Favorites with Real Chicken is a high-protein formula that helps support strong muscles. It also contains essential vitamins and minerals to support your cat's overall health and well-being.",
            Ingredients = "Water, chicken, chicken by-products (liver, gizzards), meat broth, corn gluten meal, wheat gluten, soy flour, carrots (for color), taurine, guar gum, carrageenan, vitamins (DL-methionine, vitamin E supplement, thiamine mononitrate (vitamin B1), niacin (vitamin B3), calcium pantothenate, vitamin B6, riboflavin (vitamin B2), folic acid, biotin, vitamin A supplement, vitamin D3), minerals (potassium chloride, calcium carbonate, salt, ferrous sulfate, manganese sulfate, copper sulfate, zinc oxide)"
        };

        var catFood3 = new FoodProduct
        {
            Id = Guid.NewGuid().ToString(),
            CategoryId = "CF123",
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            IsDeleted = false,
            Name = "Friskies Classic Pate with Tuna & Chicken",
            Price = 3.99M,
            DescriptionShort = "A classic pate with tuna and chicken in a rich gravy",
            DescriptionMedium = "Friskies Classic Pate with Tuna & Chicken is a delicious and affordable wet cat food that your cat will love. It's made with real tuna and chicken in a savory gravy, and it's packed with essential nutrients to help keep your cat healthy and happy.",
            DescriptionLarge = "Friskies Classic Pate is a complete and balanced meal that provides 100% of your cat's daily nutritional needs. It's a great way to show your cat you care, and it's easy on your budget.",
            Ingredients = "Water, chicken by-product meal, tuna, liver, meat broth, corn gluten meal, wheat gluten, soy flour, dried egg product, carrots (for color), taurine, guar gum, carrageenan, vitamins (DL-methionine, vitamin E supplement, thiamine mononitrate (vitamin B1), niacin (vitamin B3), calcium pantothenate, vitamin B6, riboflavin (vitamin B2), folic acid, biotin, vitamin A supplement, vitamin D3), minerals (potassium chloride, calcium carbonate, salt, ferrous sulfate, manganese sulfate, copper sulfate, zinc oxide)"
        };

        var catFood4 = new FoodProduct
        {
            Id = Guid.NewGuid().ToString(),
            CategoryId = "CF123",
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            IsDeleted = false,
            Name = "Fancy Feast Classic Pate with Chicken & Liver",
            Price = 1.99M,
            DescriptionShort = "A gourmet pate with chicken and liver in a rich gravy",
            DescriptionMedium = "Fancy Feast Classic Pate with Chicken & Liver is a gourmet wet cat food that's made with high-quality ingredients. It's a delicious and nutritious meal that your cat will love.",
            DescriptionLarge = "Fancy Feast Classic Pate is a complete and balanced meal that provides 100% of your cat's daily nutritional needs. It's a great way to show your cat you care, and it's a delicious way to start or end their day.",
            Ingredients = "Water, chicken, chicken liver, meat broth, corn gluten meal, wheat gluten, soy flour, dried egg product, carrots (for color), taurine, guar gum, carrageenan, vitamins (DL-methionine, vitamin E supplement, thiamine mononitrate (vitamin B1), niacin (vitamin B3), calcium pantothenate, vitamin B6, riboflavin (vitamin B2), folic acid, biotin, vitamin A supplement, vitamin D3), minerals (potassium chloride, calcium carbonate, salt, ferrous sulfate, manganese sulfate, copper sulfate, zinc oxide)"
        };

        var catFood5 = new FoodProduct
        {
            Id = Guid.NewGuid().ToString(),
            CategoryId = "CF123",
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            IsDeleted = true,
            Name = "Hill's Science Diet Adult 7+ Savory Chicken",
            Price = 12.99M,
            DescriptionShort = "A premium cat food for senior cats with natural ingredients",
            DescriptionMedium = "Hill's Science Diet Adult 7+ Savory Chicken is a premium cat food that's specially formulated to meet the unique nutritional needs of senior cats. It's made with high-quality ingredients, including real chicken, and it's packed with antioxidants to support a healthy immune system.",
            DescriptionLarge = "Hill's Science Diet Adult 7+ Savory Chicken helps maintain lean muscle mass, healthy kidneys, and a shiny coat. It also supports brain health and cognitive function, helping your senior cat stay sharp and alert.",
            Ingredients = "Chicken, corn gluten meal, wheat flour, animal fat, pork liver flavor, dried beet pulp, brewers rice, fish oil, soybean oil, potassium chloride, taurine, vitamins (vitamin E supplement, niacin, vitamin A supplement, vitamin B12 supplement, vitamin D3 supplement, thiamine mononitrate, pyridoxine hydrochloride, folic acid, biotin, menadione sodium bisulfite complex (source of vitamin K activity), ascorbic acid (vitamin C), calcium pantothenate), minerals (zinc oxide, ferrous sulfate, copper sulfate, manganese sulfate, calcium iodate, sodium selenite), natural flavors, beta-carotene"
        };
        context.FoodProducts.AddRange([catFood1, catFood2, catFood3, catFood4, catFood5]);
        context.SaveChanges();
    }
}