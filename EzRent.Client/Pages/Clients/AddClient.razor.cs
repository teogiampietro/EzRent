using EzRent.Shared;
using System.Net.Http.Json;

namespace EzRent.Client.Pages.Clients;

public partial class AddClient
{
    private ClientDto client = new();

    private async Task CreateClient()
    {
        await Http.PostAsJsonAsync("Client", client);
        NavManager.NavigateTo("clientes");
    }
}