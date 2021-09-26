using Newtonsoft.Json;

namespace CicekSepeti.Application.BaseResponses
{
    public class BaseResponse
    {
        [JsonProperty(Required = Required.Always)]
        public bool hasError { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string message { get; set; }

        public BaseResponse()
        {
            hasError = false;
            message = "Registration Successful";
        }

        public BaseResponse SetError(string message = null)
        {
            hasError = true;
            this.message = message ?? "System Error.";
            return this;
        }

        public BaseResponse SetSuccess(string message = "Registration Successful")
        {
            hasError = false;
            this.message = message;
            return this;
        }

        public static T GetError<T>(string message) where T : BaseResponse, new()
        {
            var ret = new T();
            ret.SetError(message);
            return ret;
        }

        public static T GetSuccess<T>(string message = "Registration Successful") where T : BaseResponse, new()
        {
            var ret = new T();
            ret.SetSuccess(message);
            return ret;
        }
    }
}
