using System.Net.Http.Json;
using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Property;

public partial class UpdateProperty
{
    [Parameter] public int PropertyId { get; set; }
    private PropertyDto Property = new();

    protected override async Task OnParametersSetAsync()
    {
        Property = await Http.GetFromJsonAsync<PropertyDto>($"property/{PropertyId}");
    }

    private async Task PutProperty()
    {
        var asd = await Http.PutAsJsonAsync("property", Property);
        NavManager.NavigateTo($"propiedades");
    }
}