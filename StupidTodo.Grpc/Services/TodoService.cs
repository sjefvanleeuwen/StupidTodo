﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using StupidTodo.Domain;
using StupidTodo.Grpc;

namespace StupidTodo.GrpcService
{
    public class TodoService : TodoSvc.TodoSvcBase
    {
        public TodoService(GrpcDataProvider dataProvider, ILogger<TodoService> logger)
        {
            DataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public override Task<TodoMessage> First(EmptyMessage request, ServerCallContext context)
        {
            return DataProvider.First();
        }

        public override async Task Get(EmptyMessage request, IServerStreamWriter<TodoMessage> responseStream, ServerCallContext context)
        {
            (await DataProvider.Get())
                                .ToList()
                                .ForEach(t => responseStream.WriteAsync(t));
        }

        public override async Task<TodosMessage> GetPackage(EmptyMessage request, ServerCallContext context)
        {
            var todosMessage = new TodosMessage();
            todosMessage.Todos.AddRange(await DataProvider.Get());
            return todosMessage;
        }

        public override async Task<ResultMessage> Send(IAsyncStreamReader<TodoMessage> requestStream, ServerCallContext context)
        {
            var todos = new List<TodoMessage>();
            await foreach(var todo in requestStream.ReadAllAsync())
            {
                todos.Add(todo);
            }
            return new ResultMessage() { Success = true };
        }

        public override async Task<ResultMessage> SendOne(TodoMessage request, ServerCallContext context)
        {
            var result = await DataProvider.SendOne(request);
            return new ResultMessage() { Success = result };
        }

        public override async Task<ResultMessage> SendPackage(TodosMessage request, ServerCallContext context)
        {
            var result = await DataProvider.Send(request.Todos);
            return new ResultMessage() { Success = true };
        }

        private readonly GrpcDataProvider DataProvider;
        private readonly ILogger<TodoService> Logger;
    }
}
