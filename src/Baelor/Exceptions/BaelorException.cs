using System;

namespace Baelor.Exceptions
{
	public class BaelorException
		: Exception
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="errorDescription"></param>
		/// <param name="errorStatus"></param>
		public BaelorException(string errorDescription, int errorStatus)
		{
			ErrorDescription = errorDescription;
			ErrorStaus = errorStatus;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="errorDescription"></param>
		/// <param name="errorStatus"></param>
		/// <param name="errorDetails"></param>
		public BaelorException(string errorDescription, int errorStatus, object errorDetails)
			: this(errorDescription, errorStatus)
		{
			ErrorDetails = errorDetails;
		}

		/// <summary>
		/// 
		/// </summary>
		public string ErrorDescription { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public int ErrorStaus { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public object ErrorDetails { get; private set; }
	}
}
