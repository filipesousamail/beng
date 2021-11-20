namespace beng.user.service.Application.Common;

public class Maybe<T>
{
    public Maybe(){}

    private Maybe(T? data)
    {
        Data = data;
    }

    public bool HasData => this.Data is not null;
    public T? Data { get; set; }

    internal static Maybe<T> Of(T? data)
    {
        return new Maybe<T>(data);
    }
}