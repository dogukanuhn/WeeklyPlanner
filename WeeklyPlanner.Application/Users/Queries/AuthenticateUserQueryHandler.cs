﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;
using WeeklyPlanner.Domain.Common;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Users.Queries
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, string>
    {
        private readonly IRedisHandler _redisHandler;
        private readonly IUserRepository _userRepository;

        private readonly IJwtHandler _jwtHandler;

        public AuthenticateUserQueryHandler(IJwtHandler jwtHandler, IRedisHandler redisHandler, IUserRepository userRepository)
        {

            _jwtHandler = jwtHandler;
            _redisHandler = redisHandler;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var raw = await _redisHandler.GetFromCache($"LoginCodes:{request.Email}");
         

            if (raw == null)
                return null;

             var data = JsonSerializer.Deserialize<RedisData>(raw);

            if (Guid.Parse(data.accessGuid) != request.AccessGuid || data.code != request.AccessCode)
                return null;

            var user = await _userRepository.GetAsync(x => x.Email == request.Email);

            return _jwtHandler.Authenticate(user);
        }
    }

    public class RedisData
    {
        public string code { get; set; }
        public string accessGuid { get; set; }

    }
}
