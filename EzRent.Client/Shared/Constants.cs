namespace EzRent.Client.Shared;

public static class Constants
{
    private const string ACTION_ADD = "agregar";
    private const string ACTION_EDIT = "editar";

    public const string ROUTE_PRODUCT_MAIN = "/productos";
    public const string ROUTE_PRODUCT_ADD = $"{ROUTE_PRODUCT_MAIN}/{ACTION_ADD}";
    public const string ROUTE_PRODUCT_EDIT = $"{ROUTE_PRODUCT_MAIN}/{ACTION_EDIT}";

    public const string ROUTE_CLIENT_MAIN = "/clientes";
    public const string ROUTE_CLIENT_ADD = $"{ROUTE_CLIENT_MAIN}/{ACTION_ADD}";
    public const string ROUTE_CLIENT_EDIT = $"{ROUTE_CLIENT_MAIN}/{ACTION_EDIT}";

    public const string ROUTE_STOCK_MAIN = "stock";
    public const string ROUTE_CATALOG_MAIN = "catalogo";

    public const string ROUTE_CATEGORY_MAIN = "/categorias";
    public const string ROUTE_CATEGORY_ADD = $"{ROUTE_CATEGORY_MAIN}/{ACTION_ADD}";
    public const string ROUTE_CATEGORY_EDIT = $"{ROUTE_CATEGORY_MAIN}/{ACTION_EDIT}";

    public const string API_CLIENT = "client";
    public const string API_PRODUCT = "product";
    public const string API_STOCK = "stock";
    public const string API_CATEGORY = "category";
}