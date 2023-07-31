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
        NavManager.NavigateTo($"propiedades/editar/{PropertyId}");
    }

    private async Task Delete (int PropertyId)
    {
        NavManager.NavigateTo($"propiedades/editar/{PropertyId}");
    }
}
