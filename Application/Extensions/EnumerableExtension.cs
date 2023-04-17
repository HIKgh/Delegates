namespace Application.Extensions;

public static class EnumerableExtension
{
    public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
    {
        if (e == null)
        {
            throw new Exception("Коллекция null");
        }

        if (getParameter is null)
        {
            throw new Exception("Делегат null");
        }

        using var enumerator = e.GetEnumerator();
        
        if (!enumerator.MoveNext())
        {
            throw new Exception("Коллекция не содержит элементов");
        }

        var parameter = getParameter(enumerator.Current);
        var item = enumerator.Current;

        while (enumerator.MoveNext())
        {
            var currentParameter = getParameter(enumerator.Current);
            if (currentParameter > parameter)
            {
                parameter = currentParameter;
                item = enumerator.Current;
            }
        }

        return item;
    }
}