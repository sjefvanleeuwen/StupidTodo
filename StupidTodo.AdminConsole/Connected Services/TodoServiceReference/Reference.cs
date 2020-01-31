﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://todoservice.com", ConfigurationName="TodoServiceReference.ITodoService")]
    public interface ITodoService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://todoservice.com/ITodoService/First", ReplyAction="http://todoservice.com/ITodoService/FirstResponse")]
        System.Threading.Tasks.Task<StupidTodo.Domain.Todo> FirstAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://todoservice.com/ITodoService/Get", ReplyAction="http://todoservice.com/ITodoService/GetResponse")]
        System.Threading.Tasks.Task<StupidTodo.Domain.Todo[]> GetAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://todoservice.com/ITodoService/Send", ReplyAction="http://todoservice.com/ITodoService/SendResponse")]
        System.Threading.Tasks.Task<bool> SendAsync(StupidTodo.Domain.Todo[] todos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://todoservice.com/ITodoService/SendOne", ReplyAction="http://todoservice.com/ITodoService/SendOneResponse")]
        System.Threading.Tasks.Task<bool> SendOneAsync(StupidTodo.Domain.Todo todo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ITodoServiceChannel : TodoServiceReference.ITodoService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class TodoServiceClient : System.ServiceModel.ClientBase<TodoServiceReference.ITodoService>, TodoServiceReference.ITodoService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TodoServiceClient() : 
                base(TodoServiceClient.GetDefaultBinding(), TodoServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITodoService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TodoServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TodoServiceClient.GetBindingForEndpoint(endpointConfiguration), TodoServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TodoServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TodoServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TodoServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TodoServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TodoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<StupidTodo.Domain.Todo> FirstAsync()
        {
            return base.Channel.FirstAsync();
        }
        
        public System.Threading.Tasks.Task<StupidTodo.Domain.Todo[]> GetAsync()
        {
            return base.Channel.GetAsync();
        }
        
        public System.Threading.Tasks.Task<bool> SendAsync(StupidTodo.Domain.Todo[] todos)
        {
            return base.Channel.SendAsync(todos);
        }
        
        public System.Threading.Tasks.Task<bool> SendOneAsync(StupidTodo.Domain.Todo todo)
        {
            return base.Channel.SendOneAsync(todo);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITodoService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITodoService))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44335/TodoService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TodoServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITodoService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TodoServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITodoService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITodoService,
        }
    }
}
