using System.Net.Http.Json;
using System.Reflection.Metadata;
using EzRent.Client.Shared;
using EzRent.Shared;

namespace EzRent.Client.Pages.Clients;

public partial class ListClient
{
    private ClientDto[]? clients;
    
    protected override async Task OnInitializedAsync()
    {
        clients = await Http.GetFromJsonAsync<ClientDto[]>("Client");
    }
    private async Task Edit(int ClientId)
    {
        NavManager.NavigateTo($"{Constants.ROUTE_CLIENT_EDIT}/{ClientId}");
    }
    private async Task Delete(int ClientId)
    {
        var clientToDelete = clients.FirstOrDefault(x => x.ClientId == ClientId);
        if (clientToDelete != null)
        {
            await Http.DeleteAsync($"client/{ClientId}");
            clients = await Http.GetFromJsonAsync<ClientDto[]>("Client");
        }
    }
}