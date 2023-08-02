namespace EzRent.Client.Shared;

public static class Constants
{
    public const string ACTION_ADD = "agregar";
    public const string ACTION_EDIT = "editar";

    public const string ROUTE_PROPERTY_MAIN = "/propiedades";
    public const string ROUTE_PROPERTY_ADD = $"{ROUTE_PROPERTY_MAIN}/{ACTION_ADD}";
    public const string ROUTE_PROPERTY_EDIT = $"{ROUTE_PROPERTY_MAIN}/{ACTION_EDIT}"; 

    public const string ROUTE_CLIENT_MAIN = "/clientes";
    public const string ROUTE_CLIENT_ADD = $"{ROUTE_CLIENT_MAIN}/{ACTION_ADD}";
    public const string ROUTE_CLIENT_EDIT = $"{ROUTE_CLIENT_MAIN}/{ACTION_EDIT}";

    public const string API_CLIENT = "client";
    public const string API_PROPERTY = "property";

}