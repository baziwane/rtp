using System;

namespace Rtp.Web.Api.Tests.Acceptance.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection: ICollectionFixture<RtpApiBroker>
    {
    }
}