using System.Data.Entity;

namespace WPF_mapCourseWork
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }
        public DbSet<AnyBuilding> AnyBuildings { get; set; }
    }
}
