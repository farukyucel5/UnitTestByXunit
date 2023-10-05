using NetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
	public class NetworkService
	{
		private readonly IDNS _dNS;
        public NetworkService(IDNS dNS)
        {
			_dNS=dNS;
            
        }
        public string SendPing()
		{
			var dnsSuccess=_dNS.SendDNS();
			if (dnsSuccess)
			{
				return "Success:Ping sent!";
			}
			else
			{
				return "Failed!: Ping not sent!";
			}
			
		}

		public int PingTimeout(int a, int b)
		{
		     return a+ b;
		}

		public DateTime LastDateTime()
		{
			return DateTime.Now;
		}

		public PingOptions GetPingOptions()
		{
			return new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			};
		}

		public IEnumerable<PingOptions> MostRecentPingList()
		{
			IEnumerable<PingOptions> pingOptions = new[]
			{
				new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			},
			new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			},
			new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			},
			new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			},
		};

			return pingOptions;
			

		}

		
	}
}
