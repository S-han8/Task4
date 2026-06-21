using Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queires
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {
    }
}
