using Application.Commands;
using Application.Responses;
using AutoMapper;
using Core.Entites;
using Core.Repository;
using MediatR;
namespace Application.Handlers.Commands
{
    public class CreateEmployeeHandler(IEmployeeRepository repository, IMapper mapper) : IRequestHandler<CreateEmployeeCommand,EmployeeResponse>
    {
        private readonly IEmployeeRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            var created = await _repository.AddAsync(employee);

            // Fetch the fully populated employee details (including Department info) to map properly
            var fullEmployee = await _repository.GetByIdAsync(created.Id);

            return _mapper.Map<EmployeeResponse>(fullEmployee ?? created);
        }
    }
}
