using BlazorServerCRUD.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlazorServerCRUD.Services
{
    public class UserServices
    {
        protected readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user is not null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var userToEdit = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (userToEdit is not null)
                {
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var userToDelete = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (userToDelete is not null)
                {
                    _context.Entry(user).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
