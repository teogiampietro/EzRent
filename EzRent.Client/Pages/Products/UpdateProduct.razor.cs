using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Products;

public partial class UpdateProduct
{
    [Parameter] public int PropertyId { get; set; }
    private ProductDto _product = new();

    protected override async Task OnParametersSetAsync()
    {
        _product = await Http.GetFromJsonAsync<ProductDto>($"{Constants.API_PRODUCT}/{PropertyId}");
    }

    private async Task PutProperty()
    {
        await Http.PutAsJsonAsync(Constants.API_PRODUCT, _product);
        NavManager.NavigateTo(Constants.ROUTE_PRODUCT_MAIN);
    }
}