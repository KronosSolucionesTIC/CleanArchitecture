using CleanArchitecth.Application.Common.Exceptions;
using CleanArchitecth.Application.Products.Commands.CreateProduct;
using CleanArchitecth.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using Serilog;

namespace CleanArchitecth.Application.IntegrationTests.Products.Commands;

using static Testing;

public class CreateProductTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateProductCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }


    [Test]
    public async Task ShouldCreateProduct()
    {
        Log.Debug($"Inicia CreateProductTest/ShouldCreateProduct");
        try
        {
            var command = new CreateProductCommand
            {
                Name = "Tasks",
                Image = "123",
                Code = "123",
                Price = 1900,
                Description = "prueba"
            };

            var id = await SendAsync(command);

            var list = await FindAsync<Product>(id);

            list.Should().NotBeNull();
            list!.Name.Should().Be(command.Name);
        }
        catch (Exception ex)
        {
            Log.Debug($"Error CreateProductTest/ShouldCreateProduct: {ex.Message}-{ex.InnerException}");
            throw;
        }
        Log.Debug($"Termina CreateProductTest/ShouldCreateProduct");
    }
}