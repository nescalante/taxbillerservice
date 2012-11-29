using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace TaxBiller.WindowsService
{
    public class CorsFormatter : IDispatchMessageFormatter
    {
        private readonly IDispatchMessageFormatter _originalFormatter;

        public CorsFormatter(IDispatchMessageFormatter formatter)
        {
            _originalFormatter = formatter;
        }

        public void DeserializeRequest(Message message, object[] parameters)
        {
            if (message.Properties.ContainsKey(CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName))
            {
                var state = message.Properties[CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName] as CorsState;
                if (state != null)
                {
                    //if we have a message ready, skip normal deserialization
                    if (state.Message != null)
                    {
                        OperationContext.Current.OutgoingMessageProperties.Add(CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName, state);
                        return;
                    }
                }
            }

            message.Properties["WebBodyFormatMessageProperty"] = new WebBodyFormatMessageProperty(WebContentFormat.Json);

            _originalFormatter.DeserializeRequest(message, parameters);
        }

        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            //see if we have a cors state with a predefined message.
            //in that case where we can ignore the whole serialization process
            if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName))
            {
                var state = OperationContext.Current.OutgoingMessageProperties[CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName] as CorsState;
                if (state != null && state.Message != null)
                {
                    return state.Message;
                }
            }
            return _originalFormatter.SerializeReply(messageVersion, parameters, result);
        }
    }
}
