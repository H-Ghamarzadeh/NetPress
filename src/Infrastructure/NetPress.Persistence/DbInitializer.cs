using Bogus;
using HGO.Hub.Interfaces.Actions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Application.Actions;
using NetPress.Domain.Entities;
using System.Reflection.PortableExecutable;

namespace NetPress.Persistence;

public class DbInitializer: IActionHandler<BeforeAppRunAction>
{

    public async Task Handle(BeforeAppRunAction action)
    {
        var context = action.ApplicationBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<NetPressDbContext>();


        if (!context.Categories.Any())
        {
            var categories = new Faker<Category>()
                .RuleFor(p => p.Name, _ => _.Commerce.Categories(1)[0])
                .Generate(20);
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }

        if (!context.Posts.Any())
        {
            var categories = context.Categories.ToList();

            var posts = new Faker<Post>()
                .RuleFor(p => p.Title, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Content, _ => _.Lorem.Paragraphs(3, 10))
                .RuleFor(p => p.Excerpt, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Slug, _ => _.Random.String2(10))
                .RuleFor(p => p.Categories, _ => _.PickRandom(categories, 5).ToList().GetRange(0, new Random().Next(0, 5)))
                .Generate(1000);

            context.Posts.AddRange(posts);
            await context.SaveChangesAsync();
        }
    }

    public int Order => 0;
    public bool Stop => false;
}