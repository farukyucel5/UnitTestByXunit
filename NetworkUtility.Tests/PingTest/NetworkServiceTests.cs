using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTest
{
	public class NetworkServiceTests
	{
		private readonly NetworkService _pingService;
		private readonly IDNS _dNS;
        public NetworkServiceTests()
        {
			_dNS = A.Fake<IDNS>();

            _pingService = new NetworkService(_dNS);
        }
        [Fact]
		public void NetworkService_SendPing_ReturnString()
		{
			A.CallTo(() => _dNS.SendDNS()).Returns(true);

			//Act

			var result = _pingService.SendPing();


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
			

			var result = _pingService.PingTimeout(value1, value2);

			result.Should().Be(output);
			result.Should().BeGreaterThanOrEqualTo(3);
			result.Should().NotBeInRange(-1, 0);

		}

		[Fact]

		public void NetworkService_LastPingDate_ReturnDate()
		{
			var result = _pingService.LastDateTime();

			result.Should().BeAfter(1.January(2020));
			result.Should().BeBefore(1.January(2024));

		}

		[Fact]

		public void NetworkServices_GetPingOptions()
		{
			var expected = new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			};

			var result = _pingService.GetPingOptions();

			result.Should().BeOfType<PingOptions>();
			result.Should().BeEquivalentTo(expected);
			result.Ttl.Should().Be(expected.Ttl);

		}

		[Fact]
		public void NetworkServices_GetMostRecentPingOptionsList()
		{
			var expected = new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			};

			var result = _pingService.MostRecentPingList();

			//result.Should().BeOfType<IEnumerable<PingOptions>>();
			result.Should().ContainEquivalentOf(expected);
			result.Should().Contain(x => x.DontFragment == true);

		}



	}
}
