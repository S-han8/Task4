using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entites;

namespace Application.Repository
{
    public interface IEmployeeRepository
    {
        Task<(IEnumerable<Employee> Employees, int TotalCount)> GetAllAsync(
            int pageNumber,
            int pageSize,
            string? search,
            string? sortBy,
            bool desc,
            CancellationToken cancellationToken = default);
    }
}