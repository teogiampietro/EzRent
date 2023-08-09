using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using MudBlazor;

namespace EzRent.Client.Pages.Stock;

public partial class ListStock
{
    private List<StockUpdateDto> _stockList = new();
    private ProductDto[]? products;
    private ProductDto selectedProduct = new();
    private int quantity;

    protected override async Task OnInitializedAsync()
    {
        products = await Http.GetFromJsonAsync<ProductDto[]>(Constants.API_PRODUCT);
    }

    private async Task<IEnumerable<ProductDto>> SearchProduct(string value)
    {
        return string.IsNullOrEmpty(value) ? products : products.Where(x => x.Description.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    private async Task SetQuantity(ProductDto? product)
    {
       selectedProduct = product ?? new ProductDto();
       quantity = selectedProduct.Quantity;
    }
    private async Task Add()
    {
        if (selectedProduct == null || selectedProduct.ProductId == 0) return;

        if (_stockList.Any(x => selectedProduct.ProductId == x.ProductId))
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

        _stockList.Add(stockToAdd);
    }

    private async Task Remove(int ProductId)
    {
        var item = _stockList.FirstOrDefault(x => x.ProductId == ProductId);
        _stockList.Remove(item);
    }

    private static string DisplayProduct(ProductDto product)
    {
        return product == null ? string.Empty : product.Description;
    }

    private async Task Update()
    {
        await Http.PutAsJsonAsync(Constants.API_STOCK, _stockList);
    }
}