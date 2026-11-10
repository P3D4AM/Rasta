namespace IdealBridge.Domain.Common;

/// <summary>وضعیت نتیجهٔ درخواست — معادل بهبودیافتهٔ ServiceResultStatus در API قدیمی Ideal.</summary>
public enum ResultStatus
{
    Success = 1,
    Fail = 2,
    Error = 3
}

/// <summary>قالب یکنواخت پاسخ IdealBridge: data / status / message / pagination.</summary>
public class ApiResponse<T>
{
    public T? Data { get; set; }
    public ResultStatus Status { get; set; } = ResultStatus.Success;
    public string Message { get; set; } = string.Empty;
    public PaginationInfo? Pagination { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "عملیات با موفقیت انجام شد.", PaginationInfo? pagination = null)
        => new() { Data = data, Status = ResultStatus.Success, Message = message, Pagination = pagination };

    public static ApiResponse<T> Failed(string message, ResultStatus status = ResultStatus.Fail)
        => new() { Data = default, Status = status, Message = message };
}
