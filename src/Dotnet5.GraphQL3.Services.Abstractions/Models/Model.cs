namespace Dotnet5.GraphQL3.Services.Abstractions.Models
{
    public abstract class Model<TId>
        where TId : struct
    {
        private TId? Id { get; set; }
    }
}