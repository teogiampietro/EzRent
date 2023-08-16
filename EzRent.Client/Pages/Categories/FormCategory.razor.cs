using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Categories;

public partial class FormCategory
{
    [Parameter] public CategoryDto Category { get; set; } = new();
    [Parameter] public string ButtonText { get; set; } = "Guardar";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
}