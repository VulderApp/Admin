using Xunit;
using Vulder.Admin.IntegrationTests.Fixtures;

namespace Vulder.Admin.IntegrationTests.Controllers;

[CollectionDefinition("Controllers collection")]
public class ControllersCollection : ICollectionFixture<AdminCredentialsFixture>
{
}