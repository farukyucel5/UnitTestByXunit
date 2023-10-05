using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTest
{
	public class NetworkServiceTests
	{
		[Fact]
		public void NetworkService_SendPing_ReturnString()
		{
			//Arrange-Variable, Classes, mocks
			var pingServices = new NetworkService();

			//Act

			var result = pingServices.SendPing();


			//Assert

			result.Should().NotBeNullOrWhiteSpace();
			result.Should().Be("Success:Ping sent!");
			result.Should().Contain("Success", Exactly.Once());


		}
	}
}
