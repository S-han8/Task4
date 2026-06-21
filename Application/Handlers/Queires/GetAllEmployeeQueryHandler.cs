using Application.Queires;
using Application.Responses;
using AutoMapper;
using Core.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queires
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);
        }

        public Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
