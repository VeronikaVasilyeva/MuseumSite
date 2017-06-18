namespace MuseumProject.Models.Interfaces
{
    public interface IPageable
    {
        int Page { get; set; }
        int PageCount { get; set; }
        string Action { get; set; }
    }
}