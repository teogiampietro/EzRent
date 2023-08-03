using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;

namespace EzRent.Client.Pages.Products;

public partial class AddProduct
{
    private ProductDto _product = new();

    private async Task CreateProperty()
    {
        await Http.PostAsJsonAsync(Constants.API_PRODUCT, _product);
        NavManager.NavigateTo(Constants.ROUTE_PRODUCT_MAIN);
    }
}