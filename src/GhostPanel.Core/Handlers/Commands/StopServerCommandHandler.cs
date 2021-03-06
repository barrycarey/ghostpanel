﻿using GhostPanel.Core.Management;
using GhostPanel.Core.Providers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GhostPanel.Core.Data;
using GhostPanel.Core.Data.Model;
using GhostPanel.Core.Data.Specifications;
using GhostPanel.Core.Commands;
using Microsoft.Extensions.Logging;

namespace GhostPanel.Core.Handlers.Commands
{
    public class StopServerCommandHandler : IRequestHandler<StopServerCommand, CommandResponseGameServer>
    {
        private readonly IMediator _mediator;
        private readonly IServerProcessManager _procManager;
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public StopServerCommandHandler(IMediator mediator, IServerProcessManagerProvider procProvider, IRepository repository, ILogger<StopServerCommandHandler> logger)
        {
            _mediator = mediator;
            _repository = repository;
            _logger = logger;
            _procManager = procProvider.GetProcessManagerProvider();
        }

        public Task<CommandResponseGameServer> Handle(StopServerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Running Handler StopServerCommandHandler");
            var response = new CommandResponseGameServer();
            var gameServer = _repository.Single(DataItemPolicy<GameServer>.ById(request.gameServerId));
            _repository.Single(DataItemPolicy<GameServerCurrentStats>.ById(request.gameServerId));
            if (gameServer == null)
            {
                response.status = CommandResponseStatusEnum.Error;
                response.message = $"Unable located game server with ID {request.gameServerId}";
                return Task.FromResult(response);
            }
            response.payload = gameServer;
            try
            {
                _procManager.StopServer(gameServer);
                gameServer.GameServerCurrentStats.Status = ServerStatusStates.Stopped;
                gameServer.GameServerCurrentStats.Pid = null;
                _repository.Update(gameServer);
                response.status = CommandResponseStatusEnum.Success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.status = CommandResponseStatusEnum.Error;
                response.message = e.ToString();
            }
            
            return Task.FromResult(response);
        }
    }


}
