using Microsoft.EntityFrameworkCore;
using dotNETwepApi;

namespace dotNETwepApi.Controllers
{
    public class PracticeContext: DbContext
    {
        public PracticeContext(DbContextOptions<PracticeContext> options) : base (options) { }
        public DbSet<dotNETwepApi.Product>? products { get; set; }
    }
}
