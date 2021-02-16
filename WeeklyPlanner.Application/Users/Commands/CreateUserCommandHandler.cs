using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Helpers;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var domainName = request.Email.Split("@")[1];
            var isUserExist = await _userRepository.GetAsync(x => x.Email == request.Email || x.CompanyDomain == domainName);

            if(isUserExist != null)
                return 0;
            
            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Surname = request.Surname,
                CompanyDomain= domainName,
                Role=new Role(request.Role)
            };

            var result = await _userRepository.AddAsync(user, cancellationToken);

            if (result == null)
                throw new ArgumentNullException();

            return 1;

        }
    }
}
