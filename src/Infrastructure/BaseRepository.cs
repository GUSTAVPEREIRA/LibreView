namespace Infrastructure;

public abstract class BaseRepository
{
    public DatabaseContext Context { get; set; }

    public BaseRepository(DatabaseContext context)
    {
        Context = context;
    }
}