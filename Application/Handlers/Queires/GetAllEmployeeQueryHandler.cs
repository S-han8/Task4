using Application.Queires;
using Application.Repository;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Queires
{
    public class GetAllEmployeeQueryHandler
        : IRequestHandler<GetAllEmployeesQuery, PagedResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<EmployeeDto>> Handle(
            GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var p = request.Parameters; 

            var (employees, totalCount) = await _employeeRepository.GetAllAsync(
                p.PageNumber, p.PageSize, p.Search, p.SortBy, p.Desc, cancellationToken);

            var dtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return new PagedResponse<EmployeeDto>(dtos, p.PageNumber, p.PageSize, totalCount);
        }
    }
}