using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using MudBlazor;

namespace EzRent.Client.Pages.Stock;

public partial class ListStock
{
    private ProductDto[]? products;
    private List<StockUpdateDto> stockList = new();
    private ProductDto selectedProduct = new();
    private int quantity;

    protected override async Task OnInitializedAsync()
    {
        products = await Http.GetFromJsonAsync<ProductDto[]>(Constants.API_PRODUCT);
    }

    private async Task<IEnumerable<ProductDto>> SearchProduct(string value)
    {
        return string.IsNullOrEmpty(value)
            ? products
            : products.Where(x => x.Description.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    private async Task SetQuantity(ProductDto? product)
    {
        selectedProduct = product ?? new ProductDto();
        quantity = selectedProduct.Quantity;
    }

    private async Task Add()
    {
        if (selectedProduct == null || selectedProduct.ProductId == 0) return;

        if (stockList.Any(x => selectedProduct.ProductId == x.ProductId))
        {
            Snackbar.Add($"El producto {selectedProduct.Description} ya está incluido en el stock.", Severity.Warning);
            return;
        }

        var stockToAdd = new StockUpdateDto
        {
            ProductId = selectedProduct.ProductId,
            Description = selectedProduct.Description,
            Quantity = quantity
        };

        stockList.Add(stockToAdd);
    }

    private async Task Remove(int ProductId)
    {
        var item = stockList.FirstOrDefault(x => x.ProductId == ProductId);
        stockList.Remove(item);
    }

    private static string DisplayProduct(ProductDto product)
    {
        return product == null ? string.Empty : product.Description;
    }

    private async Task Update()
    {
        var response = await Http.PutAsJsonAsync(Constants.API_STOCK, stockList);
        if (!response.IsSuccessStatusCode)
        {
            Snackbar.Add($"Error al intentar actualizar el stock.", Severity.Error);
            return;
        }

        Snackbar.Add("El stock fue actualizado.", Severity.Success);
        Thread.Sleep(3000);
        NavManager.NavigateTo(Constants.ROUTE_PRODUCT_MAIN);
    }
}