using System;

namespace CopaFilmes.Domain.Util
{
	public class CommandResult
	{
		public dynamic ResultData { get; set; }
		public ErrorCode ErrorCode { get; set; }
		public string ErrorName { get { return Convert.ToString(ErrorCode); } }
		public string ErrorMessage { get; set; }

		public CommandResult(dynamic resultData) : this(ErrorCode.None, null, resultData as object) { }
		public CommandResult(ErrorCode errorCode, string errorMessage = null, dynamic resultData = null)
		{
			ResultData = resultData;
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
		}

		public bool ShouldSerializeErrorCode()
		{
			return ErrorCode != ErrorCode.None;
		}

		public bool ShouldSerializeErrorName()
		{
			return ErrorCode != ErrorCode.None;
		}

		public bool ShouldSerializeResultData()
		{
			return ResultData != null;
		}
	}

	public enum ErrorCode
	{
		None = 0,
		NotFound = 2,
		InvalidParameters = 3,
		NotAllowedCommand = 4,
	}
}
