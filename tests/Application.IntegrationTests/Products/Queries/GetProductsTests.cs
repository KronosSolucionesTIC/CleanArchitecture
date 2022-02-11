using CleanArchitecth.Application.Products.Queries.GetProducts;
using CleanArchitecth.Domain.Entities;
using CleanArchitecth.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecth.Application.IntegrationTests.Products.Queries;

using static Testing;

public class GetProductsTests : TestBase
{
    [Test]
    public async Task ShouldReturnAllListsAndItems()
    {
        await AddAsync(new Product {
            Id = 1, Name = "Apple" 
        });

        var query = new GetProductQuery();

        var result = await SendAsync(query);

        result.ListProducts.Should().HaveCount(1);
    }
}
