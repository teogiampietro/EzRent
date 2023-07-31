using System.Net.Http.Json;
using EzRent.Shared;

namespace EzRent.Client.Pages.Property;

public partial class ListProperty
{
    private PropertyDto[]? properties;

    protected override async Task OnInitializedAsync()
    {
        properties = await Http.GetFromJsonAsync<PropertyDto[]>("Property");
    }

    private async Task Edit(int PropertyId)
    {
        NavManager.NavigateTo($"propiedades/{PropertyId}");
    }

    private async Task Delete(int PropertyId)
    {
        var propertyToDelete = properties.FirstOrDefault(x => x.PropertyId == PropertyId);
        if (propertyToDelete != null)
        {
            await Http.DeleteAsync($"property/{PropertyId}");
            properties = await Http.GetFromJsonAsync<PropertyDto[]>("Property");
        }
    }
}