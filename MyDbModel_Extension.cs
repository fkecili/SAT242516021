namespace MyDbModels;

public static class MyDbModel_Extension
{
    public static IDictionary<object, object> GetOrderByItems<T>(this MyDbModel<T> myDbModel) where T : class, new()
    {
        var sortByItems = new Dictionary<object, object>();

        return sortByItems;
    }
}
