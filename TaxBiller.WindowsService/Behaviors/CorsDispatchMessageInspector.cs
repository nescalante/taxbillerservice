using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace TaxBiller.WindowsService
{
    public class CorsDispatchMessageInspector : IDispatchMessageInspector
    {
        private readonly ServiceEndpoint _serviceEndpoint;
        private readonly CorsBehaviorAttribute _behavior;
        internal const string CrossOriginResourceSharingPropertyName = "CrossOriginResourceSharingState";
        
        public CorsDispatchMessageInspector(ServiceEndpoint serviceEndpoint, CorsBehaviorAttribute behavior)
        {
            _serviceEndpoint = serviceEndpoint;
            _behavior = behavior;
        }
        
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            CorsState state = null;
            HttpRequestMessageProperty responseProperty = null;
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                responseProperty = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            }

            if (responseProperty != null)
            {

                //Handle cors requests
                var origin = responseProperty.Headers["Origin"];
                if (!string.IsNullOrEmpty(origin))
                {
                    state = new CorsState();
                    //if a cors options request (preflight) is detected, we create our own reply message and don't invoke any operation at all.
                    if (responseProperty.Method == "OPTIONS")
                    {
                        state.Message = Message.CreateMessage(request.Version, FindReplyAction(request.Headers.Action), new EmptyBodyWriter());
                    }
                    request.Properties.Add(CrossOriginResourceSharingPropertyName, state);
                }
            }
            return state;
        }
        
        private string FindReplyAction(string requestAction)
        {
            foreach (var operation in _serviceEndpoint.Contract.Operations)
            {
                if (operation.Messages[0].Action == requestAction)
                {
                    return operation.Messages[1].Action;
                }
            }
            return null;
        }
        
        class EmptyBodyWriter : BodyWriter
        {
            public EmptyBodyWriter() : base(true) { }

            protected override void OnWriteBodyContents(XmlDictionaryWriter writer) { }
        }
        
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var state = correlationState as CorsState;
            if (state != null)
            {
                if (state.Message != null)
                {
                    reply = state.Message;
                }
                HttpResponseMessageProperty responseProperty = null;
                if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    responseProperty = reply.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                }
                if (responseProperty == null)
                {
                    responseProperty = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name, responseProperty);
                }
                //Acao should be added for all cors responses
                responseProperty.Headers.Set("Access-Control-Allow-Origin", _behavior.AllowOrigin);
                if (state.Message != null)
                {
                    //the following headers should only be added for OPTIONS requests
                    responseProperty.Headers.Set("Access-Control-Allow-Methods", _behavior.AllowMethods);
                    responseProperty.Headers.Set("Access-Control-Allow-Headers", _behavior.AllowHeaders);
                }
            }
        }
    }

    class CorsState
    {
        public Message Message;
    }
}