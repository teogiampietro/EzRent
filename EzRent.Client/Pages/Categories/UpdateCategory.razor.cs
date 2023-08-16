using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;
using Microsoft.AspNetCore.Components;

namespace EzRent.Client.Pages.Categories;

public partial class UpdateCategory
{
    [Parameter] public int CategoryId { get; set; }
    private CategoryDto Category = new();

    protected override async Task OnParametersSetAsync()
    {
        Category = await Http.GetFromJsonAsync<CategoryDto>($"{Constants.API_CATEGORY}/{CategoryId}");
    }

    private async Task PutClient()
    {
        await Http.PutAsJsonAsync(Constants.API_CATEGORY, Category);
        NavManager.NavigateTo(Constants.ROUTE_CATEGORY_MAIN);
    }
}