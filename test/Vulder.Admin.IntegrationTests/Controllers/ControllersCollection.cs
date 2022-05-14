using Vulder.Admin.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.Admin.IntegrationTests.Controllers;

[CollectionDefinition("Controllers collection")]
public class ControllersCollection : ICollectionFixture<AdminCredentialsFixture>
{
}