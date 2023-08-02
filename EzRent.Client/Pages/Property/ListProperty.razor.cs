using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using MudBlazor;

namespace EzRent.Client.Pages.Property;

public partial class ListProperty
{
    private PropertyDto[]? properties;

    protected override async Task OnInitializedAsync()
    {
        properties = await Http.GetFromJsonAsync<PropertyDto[]>(Constants.API_PROPERTY);
    }

    private async Task Edit(int PropertyId)
    {
        NavManager.NavigateTo($"{Constants.ROUTE_PROPERTY_EDIT}/{PropertyId}");
    }

    private async Task Delete(int PropertyId)
    {
        if (!await SimpleDialog("Atención.", "Está a punto de dar de baja una propiedad."))
            return;
        
        var propertyToDelete = properties.FirstOrDefault(x => x.PropertyId == PropertyId);
        if (propertyToDelete != null)
        {
            await Http.DeleteAsync($"{Constants.API_PROPERTY}/{PropertyId}");
            properties = await Http.GetFromJsonAsync<PropertyDto[]>(Constants.API_PROPERTY);
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