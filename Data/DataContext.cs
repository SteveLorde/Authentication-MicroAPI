using EnterpriseAuthentication_MicroAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAuthentication_MicroAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    //Tables Sets
    public DbSet<User> Users { get; set; }
    

}