using Application.Responses;
using MediatR;

namespace Application.Queires
{
    public class GetAllEmployeesQuery : IRequest<PagedResponse<EmployeeDto>>
    {
        public EmployeeQueryParameters Parameters { get; }

        public GetAllEmployeesQuery(EmployeeQueryParameters parameters)
        {
            Parameters = parameters;
        }
    }
}