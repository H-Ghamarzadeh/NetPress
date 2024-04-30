using Bogus;
using HGO.Hub.Interfaces.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Application.Actions;
using NetPress.Domain.Entities;
using NetPress.Application.ExtensionMethods.Common;

namespace NetPress.Persistence;

public class DbInitializer: IActionHandler<BeforeAppRunAction>
{

    public async Task Handle(BeforeAppRunAction action)
    {
        var dbContext = action.ApplicationBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<NetPressDbContext>();

        await dbContext.Database.MigrateAsync();

        if (!dbContext.Pictures.Any())
        {
            //Category images
            var pictures = new Faker<Picture>()
                .RuleFor(p => p.Title, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Url, _ => _.Image.PicsumUrl(128, 128))
                .RuleFor(p => p.Width, _ => 128)
                .RuleFor(p => p.Height, _ => 128)
                .Generate(200);
            dbContext.Pictures.AddRange(pictures);

            //Post images
            pictures = new Faker<Picture>()
                .RuleFor(p => p.Title, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Url, _ => _.Image.PicsumUrl(640, 480))
                .RuleFor(p => p.Width, _ => 640)
                .RuleFor(p => p.Height, _ => 480)
                .Generate(2000);
            dbContext.Pictures.AddRange(pictures);

            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Categories.Any())
        {
            var pictures = dbContext.Pictures.Where(p => p.Width <= 128).ToList();

            var categories = new Faker<Category>()
                .RuleFor(p => p.Name, _ => _.Commerce.Categories(1)[0])
                .RuleFor(p=> p.Slug, _ => _.Commerce.Categories(1)[0].ToUrlSlug())
                .Generate(200);
            dbContext.Categories.AddRange(categories);
            await dbContext.SaveChangesAsync();

            foreach (var category in categories)
            {
                foreach (var picture in pictures.OrderBy(x => new Random().Next()).Take(new Random().Next(0, 2)))
                {
                    category.Pictures.Add(new CategoryPicture()
                    {
                        CategoryId = category.Id,
                        PictureId = picture.Id
                    });
                }
            }
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Posts.Any())
        {
            var categories = dbContext.Categories.ToList();
            var pictures = dbContext.Pictures.Where(p=> p.Width >= 640).ToList();

            var posts = new Faker<Post>()
                .RuleFor(p => p.Type, _ => "post")
                .RuleFor(p => p.Title, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Content, _ => _.Lorem.Paragraphs(10, 60))
                .RuleFor(p => p.Excerpt, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Slug, _ => _.Lorem.Sentence().ToUrlSlug())
                .RuleFor(p => p.Categories, _ => _.PickRandom(categories, 5).ToList().GetRange(0, new Random().Next(0, 5)))
                .Generate(50000);
            dbContext.Posts.AddRange(posts);
            await dbContext.SaveChangesAsync();

            foreach (var post in posts)
            {
                foreach (var picture in pictures.OrderBy(x => new Random().Next()).Take(new Random().Next(1, 5)))
                {
                    post.Pictures.Add(new PostPicture()
                    {
                        PostId = post.Id,
                        PictureId = picture.Id
                    });
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }

    public int Order => 0;
    public bool Stop => false;
}