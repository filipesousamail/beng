using System;
using beng.InventoryService.Domain;
using beng.InventoryService.Domain.Inventory;
using FluentAssertions;
using Xunit;

namespace tests;

public class InventoryTests
{
    [Fact]
    public void A_valid_sku_should_be_generated_for_each_new_product_inventory()
    {
        // Arrange
        var product = new Inventory
        {
            Qty = 1,
            StockUnit = new StockUnit() {Name = EStockUnit.Unit.Name},
            ProductId = Guid.NewGuid(),
        };

        // Act, Assert
        product.Sku.Should().NotBeNullOrWhiteSpace();
        product.Sku.Length.Should().Be(16);
    }
}