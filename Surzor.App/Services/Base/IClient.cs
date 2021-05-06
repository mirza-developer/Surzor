using System.Net.Http;

namespace Surzor.App.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
