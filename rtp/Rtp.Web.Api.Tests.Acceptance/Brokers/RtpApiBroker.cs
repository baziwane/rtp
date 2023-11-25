
namespace Rtp.Web.Api.Tests.Acceptance.Brokers
{
    public class RtpApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactory apiFactoryClient;

        public RtpApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactory(this.httpClient);
        }
    }
}