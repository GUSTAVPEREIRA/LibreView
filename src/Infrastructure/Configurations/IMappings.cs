using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;

public interface IMappings
{
    public void Mapping(ref ModelBuilder builder);
}