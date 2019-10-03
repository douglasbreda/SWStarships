namespace SWStarships.Domain.API
{
    public interface IApi
    {
        string BaseUrl { get; }

        T Get<T>( string path ) where T : class;
    }
}
