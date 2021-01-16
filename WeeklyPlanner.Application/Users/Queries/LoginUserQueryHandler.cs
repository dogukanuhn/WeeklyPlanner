using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Users.Queries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRedisHandler _redisHandler;

        public LoginUserQueryHandler(IUserRepository userRepository, IRedisHandler redisHandler)
        {
            _userRepository = userRepository;
            _redisHandler = redisHandler;
        }

        public async Task<Guid> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Email == request.Email);

            if (user == null)
                return Guid.Empty;

            if (await _redisHandler.GetFromCache($"LoginCodes:{request.Email}") != null)
                return Guid.Empty;

            var codeGuid = Guid.NewGuid();

            Random rnd = new Random();
            var code = rnd.Next(100000, 1000000);

            var temp = new
            {
                code = code.ToString(),
                accessGuid = codeGuid

            }; 
            await _redisHandler.AddToCache($"LoginCodes:{request.Email}", TimeSpan.FromMinutes(2), JsonSerializer.Serialize(temp));

            return codeGuid;
        }
    }
}
