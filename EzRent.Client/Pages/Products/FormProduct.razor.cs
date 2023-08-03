using EzRent.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Extensions;

namespace EzRent.Client.Pages.Products;

public partial class FormProduct
{
    [Parameter] public ProductDto Product { get; set; } = new();
    [Parameter] public string ButtonText { get; set; } = "Guardar";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
}