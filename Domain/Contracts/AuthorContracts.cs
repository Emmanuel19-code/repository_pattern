namespace repositorypattern.Domain.Contracts
{
    public record CreateAuthor
    {
        public string Name {get;init;}
        public string Bio {get;init;}
    }

    public record UpdateAuthor
    {
        public string Name { get; init; }
        public string Bio { get; init; }
    }

    public record DeleteAuthor
    {
        public Guid Id {get;init;}
    }

    public record GetAuthor 
    {
        public Guid Id {get;init;}
    }
}