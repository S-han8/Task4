using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Repository;
using Core.Entites;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Employee> Employees, int TotalCount)> GetAllAsync(
            int pageNumber,
            int pageSize,
            string? search,
            string? sortBy,
            bool desc,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> query = _context.Employees
                .Include(e => e.Department)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                query = query.Where(e => EF.Functions.Like(e.Name, $"%{term}%"));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                        query = desc ? query.OrderByDescending(e => e.Name) : query.OrderBy(e => e.Name);
                        break;
                    case "salary":
                        query = desc ? query.OrderByDescending(e => e.Salary) : query.OrderBy(e => e.Salary);
                        break;
                    default:
                        query = query.OrderBy(e => e.Id);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(e => e.Id);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var employees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (employees, totalCount);
        }
    }
}