﻿using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Domain.Entities;

namespace NetPress.Persistence;

public static class DbInitializer
{
    public static void Seed(IApplicationBuilder appBuilder)
    {
        var context = appBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<NetPressDbContext>();


        if (!context.Categories.Any())
        {
            var categories = new Faker<Category>()
                .RuleFor(p => p.Name, _ => _.Commerce.Categories(1)[0])
                .Generate(10);
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        if (!context.Posts.Any())
        {
            var categories = context.Categories.ToList();

            var posts = new Faker<Post>()
                .RuleFor(p => p.Title, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Content, _ => _.Lorem.Paragraphs(3, 10))
                .RuleFor(p => p.Excerpt, _ => _.Lorem.Sentence())
                .RuleFor(p => p.Slug, _ => _.Random.String2(10))
                .RuleFor(p => p.Categories, _ => _.PickRandom(categories, 3).ToList())
                .Generate(100);

            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
    }
}