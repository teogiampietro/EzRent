using System.Net.Http.Json;
using EzRent.Client.Shared;
using EzRent.Shared;

namespace EzRent.Client.Pages.Categories;

public partial class ListCategory
{
    private CategoryDto[]? categories;
    
    protected override async Task OnInitializedAsync()
    {
        categories = await Http.GetFromJsonAsync<CategoryDto[]>(Constants.API_CATEGORY);
    }
    private async Task Edit(int categoryId)
    {
        NavManager.NavigateTo($"{Constants.ROUTE_CATEGORY_EDIT}/{categoryId}");
    }
    private async Task Delete(int categoryId)
    {
        var categoryToDelete = categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (categoryToDelete != null)
        {
            await Http.DeleteAsync($"{Constants.API_CATEGORY}/{categoryId}");
            categories = await Http.GetFromJsonAsync<CategoryDto[]>(Constants.API_CATEGORY);
        }
    }
}