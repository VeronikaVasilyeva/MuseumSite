namespace MuseumProject.Models.Interfaces
{
    public interface IViewModel<in TEntity>
    {
        void ApplyChange(TEntity entity);
    }
}