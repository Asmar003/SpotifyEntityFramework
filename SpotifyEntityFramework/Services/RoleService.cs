using SpotifyEntityFramework.DAL;
using SpotifyEntityFramework.Models;

namespace SpotifyEntityFramework.Services
{
    internal class RoleService
    {
        public Role GetById(int id)
        {
            Role role;
            using (AppDbContext dbContext = new AppDbContext())
            {
                role = dbContext.Roles.FirstOrDefault(r => r.Id == id);
            }
            return role;
        }
        public void CreateRole(string type)
        {
            Role role = new Role
            {
                Type=type
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
                Console.WriteLine("Successfully Added!");
            }
        }
        public void Remove(int id)
        {
            Role existed;
            using (AppDbContext dbContext = new AppDbContext())
            {
                existed = dbContext.Roles.FirstOrDefault(r => r.Id == id);
                if (existed != null)
                {
                    dbContext.Roles.RemoveRange();
                    dbContext.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                }
            }
        }
        public List<Role> GetAll()
        {
            List<Role> roles;

            using (AppDbContext context = new AppDbContext())
            {
                roles = context.Roles.ToList();
            }
            return roles;
        }
        public void Update(string type)
        {
            Role role = new Role()
            {
                Type= type
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Roles.Update(role);
                context.SaveChanges();
                Console.WriteLine("Successfully Update!");
            }
        }
    }
}
