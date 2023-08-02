using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Clients;

public partial class UpdateProperty
{
    [Parameter] public int ClientId { get; set; }
    private ClientDto Client = new();

    protected override async Task OnParametersSetAsync()
    {
        Client = await Http.GetFromJsonAsync<ClientDto>($"{Constants.API_CLIENT}/{ClientId}");
    }

    private async Task PutClient()
    {
        await Http.PutAsJsonAsync(Constants.API_CLIENT, Client);
        NavManager.NavigateTo(Constants.ROUTE_CLIENT_MAIN);
    }
}