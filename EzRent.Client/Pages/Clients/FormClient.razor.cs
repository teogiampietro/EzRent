using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Clients;

public partial class FormClient
{
    [Parameter] public ClientDto Client { get; set; } = new();
    [Parameter] public string ButtonText { get; set; } = "Guardar";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
}