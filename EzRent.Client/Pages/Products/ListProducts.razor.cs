using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Client.Shared.Components;
using EzRent.Shared;
using MudBlazor;

namespace EzRent.Client.Pages.Products;

public partial class ListProducts
{
    private ProductDto[]? products;

    protected override async Task OnInitializedAsync()
    {
        products = await Http.GetFromJsonAsync<ProductDto[]>(Constants.API_PRODUCT);
    }

    private async Task Edit(int ProductId)
    {
        NavManager.NavigateTo($"{Constants.ROUTE_PRODUCT_EDIT}/{ProductId}");
    }

    private async Task Delete(int ProductId)
    {
        if (!await SimpleDialog("Atención.", "Está a punto de dar de baja un producto."))
            return;
        
        var productToDelete = products.FirstOrDefault(x => x.ProductId == ProductId);
        if (productToDelete != null)
        {
            await Http.DeleteAsync($"{Constants.API_PRODUCT}/{ProductId}");
            products = await Http.GetFromJsonAsync<ProductDto[]>(Constants.API_PRODUCT);
        }
    }

    private async Task<bool> SimpleDialog(string title, string? message)
    {
        var dialogOptions = new DialogOptions { CloseOnEscapeKey = true };

        var dialogParameters = new DialogParameters<SimpleDialog>
        {
            { x => x.Message, message ?? string.Empty }
        };

        var dialog = await DialogService.ShowAsync<SimpleDialog>(title, dialogParameters, dialogOptions);
        return !(await dialog.Result).Canceled;
    }
}