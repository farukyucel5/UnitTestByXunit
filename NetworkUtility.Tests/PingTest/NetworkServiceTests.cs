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

		[Theory]
		[InlineData(1,2,3)]
		[InlineData(2,3,5)]
		[InlineData(3,4,7)]
		public void NetworkService_PingTimeout_ReturnInt(int value1, int value2, int output)
		{
			var pingServices = new NetworkService();

			var result = pingServices.PingTimeout(value1, value2);

			result.Should().Be(output);
			result.Should().BeGreaterThanOrEqualTo(3);
			result.Should().NotBeInRange(-1, 0);

		}


	}
}
