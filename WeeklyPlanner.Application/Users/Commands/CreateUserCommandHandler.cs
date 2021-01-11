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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var isValidMail = EmailVerify.EmailIsValid(request.Email);

            if (!isValidMail) return false;

            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Surname = request.Surname
            };

            var result = await _userRepository.AddAsync(user, cancellationToken);

            if (result == null)
                return false;

            return true;
        }
    }
}
