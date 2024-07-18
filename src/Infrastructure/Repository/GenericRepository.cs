using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Interfaces;
using TaskManagementInfrastructure.Data;

namespace TaskManagementInfrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T enitity)
        {
            await _context.Set<T>().AddAsync(enitity);
            await _context.SaveChangesAsync();
            return enitity;
        }

        public async Task Delete(int id)
        {
            var data=await _context.Set<T>().FindAsync(id);
            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetById(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            return data;
        }

        public async Task Update(T enitity)
        {
             _context.Set<T>().Update(enitity);
            await _context.SaveChangesAsync();
        }
    }
}
