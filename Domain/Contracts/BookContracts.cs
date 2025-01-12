namespace repositorypattern.Domain.Contracts
{
    public record CreateBook
    {
        public string Title {get;init;}
        public double Price {get;set;}
        public string Description {get;set;}
        public Guid AuthorId {get;set;}
    }
    public record UpdateBook
    {
        public string Title { get; init; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
    public record DeleteBook
    {
        public Guid Id {get;init;}
    }

    public record GetBook
    {
        public Guid Id {get;init;}
    }
}