using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class SendInviteCommandHandler : IRequestHandler<SendInviteCommand, bool>
    {
        private IEmailService _emailService;
        private readonly IRedisHandler _redisHandler;
        public SendInviteCommandHandler(IEmailService emailService, IRedisHandler redisHandler)
        {
            _emailService = emailService;
            _redisHandler = redisHandler;
        }
        public async  Task<bool> Handle(SendInviteCommand request, CancellationToken cancellationToken)
        {
            var securityGuid = Guid.NewGuid();

            //TODO: SENT MAIL TO USERS

            await _redisHandler.AddToCache($"InviteLinks:{securityGuid}", TimeSpan.FromMinutes(1), JsonSerializer.Serialize(request));

            return true;

        }

    }


}
