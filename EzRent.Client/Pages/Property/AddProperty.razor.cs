using System.Net.Http.Json;
using EzRent.Shared;

namespace EzRent.Client.Pages.Property;

public partial class AddProperty
{
    private PropertyDto Property = new();

    private async Task CreateProperty()
    {
        await Http.PostAsJsonAsync("property", Property);
        NavManager.NavigateTo("propiedades");
    }
}