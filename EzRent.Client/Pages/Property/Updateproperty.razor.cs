using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Property;

public partial class UpdateProperty
{
    [Parameter] public int PropertyId { get; set; }
    private PropertyDto Property = new();

    protected override async Task OnParametersSetAsync()
    {
        Property = await Http.GetFromJsonAsync<PropertyDto>($"{Constants.API_PROPERTY}/{PropertyId}");
    }

    private async Task PutProperty()
    {
        await Http.PutAsJsonAsync(Constants.API_PROPERTY, Property);
        NavManager.NavigateTo(Constants.ROUTE_PROPERTY_MAIN);
    }
}