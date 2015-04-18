using System;

namespace Baelor.Exceptions
{
	public class AuthenticationRequiredException
		: Exception
	{
		public AuthenticationRequiredException(string message)
			: base(message)
		{ }
	}
}
