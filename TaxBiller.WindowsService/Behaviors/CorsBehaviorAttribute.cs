using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TaxBiller.WindowsService
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Interface)]
    public class CorsBehaviorAttribute : Attribute, IEndpointBehavior, IOperationBehavior
    {
        public string AllowOrigin
        {
            get { return _allowOrigin; }
            set { _allowOrigin = value; }
        }

        private string _allowOrigin = "*";
        
        public string AllowMethods
        {
            get { return _allowMethods; }
            set { _allowMethods = value; }
        }
        
        private string _allowMethods = "POST, OPTIONS, GET";
        
        public string AllowHeaders
        {
            get { return _allowHeaders; }
            set { _allowHeaders = value; }
        }
        
        private string _allowHeaders = "Content-Type, Accept, Authorization, x-requested-with";
        
        public void Validate(ServiceEndpoint endpoint) { }
        
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            //adds an inspector that detect cors requests and marks them so the operation invoker/formatter can detect it
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsDispatchMessageInspector(endpoint, this));
        }
        
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }
        
        public void Validate(OperationDescription operationDescription) { }
        
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            //For every opertation we inject a formatter and an invoker to detect Cors calls
            dispatchOperation.Formatter = new CorsFormatter(dispatchOperation.Formatter);
            dispatchOperation.Invoker = new CorsInvoker(dispatchOperation.Invoker);
        }
        
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) { }
        
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters) { }
    }
}