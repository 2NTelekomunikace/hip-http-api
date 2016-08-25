using System;

namespace HIPHttpApi
{
	internal struct SubscribeJson
	{
		public bool Success { get; set; }
		public HIPHttpApi.Subscribe.Result Result { get; set; }
	}

	namespace HIPHttpApi.Subscribe
	{
		internal struct Result
		{
			public uint Id { get; set; }
		}
	}
}
