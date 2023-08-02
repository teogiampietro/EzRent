using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;

namespace EzRent.Client.Pages.Property;

public partial class AddProperty
{
    private PropertyDto Property = new();

    private async Task CreateProperty()
    {
        await Http.PostAsJsonAsync(Constants.API_PROPERTY, Property);
        NavManager.NavigateTo(Constants.ROUTE_PROPERTY_MAIN);
    }
}