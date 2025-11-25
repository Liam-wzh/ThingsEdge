namespace ThingsEdge.Abstractions;

/// <summary>
/// 连接结果
/// </summary>
public sealed class ConnectResult
{
    private ConnectResult(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; }

    /// <summary>
    /// 创建成功结果
    /// </summary>
    public static ConnectResult Success() => new(true);

    /// <summary>
    /// 创建失败结果
    /// </summary>
    public static ConnectResult Failure(string errorMessage) => new(false, errorMessage);
}

/// <summary>
/// 读取结果
/// </summary>
public sealed class ReadResult<T>
{
    private ReadResult(bool isSuccess, T? value = default, DataQuality quality = DataQuality.Bad, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        Value = value;
        Quality = quality;
        ErrorMessage = errorMessage;
        Timestamp = DateTime.UtcNow;
    }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// 读取的值
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// 数据质量
    /// </summary>
    public DataQuality Quality { get; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; }

    /// <summary>
    /// 创建成功结果
    /// </summary>
    public static ReadResult<T> Success(T value, DataQuality quality = DataQuality.Good)
        => new(true, value, quality);

    /// <summary>
    /// 创建失败结果
    /// </summary>
    public static ReadResult<T> Failure(string errorMessage)
        => new(false, errorMessage: errorMessage);
}

/// <summary>
/// 写入结果
/// </summary>
public sealed class WriteResult
{
    private WriteResult(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Timestamp = DateTime.UtcNow;
    }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; }

    /// <summary>
    /// 创建成功结果
    /// </summary>
    public static WriteResult Success() => new(true);

    /// <summary>
    /// 创建失败结果
    /// </summary>
    public static WriteResult Failure(string errorMessage) => new(false, errorMessage);
}

/// <summary>
/// 批量读取结果
/// </summary>
public sealed class BatchReadResult
{
    public BatchReadResult(IReadOnlyList<DataValue> values)
    {
        Values = values ?? throw new ArgumentNullException(nameof(values));
        Timestamp = DateTime.UtcNow;
    }

    /// <summary>
    /// 数据值集合
    /// </summary>
    public IReadOnlyList<DataValue> Values { get; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// 成功数量
    /// </summary>
    public int SuccessCount => Values.Count(v => v.Quality == DataQuality.Good);

    /// <summary>
    /// 失败数量
    /// </summary>
    public int FailureCount => Values.Count(v => v.Quality == DataQuality.Bad);
}

/// <summary>
/// 批量写入结果
/// </summary>
public sealed class BatchWriteResult
{
    public BatchWriteResult(IReadOnlyList<WriteItemResult> results)
    {
        Results = results ?? throw new ArgumentNullException(nameof(results));
        Timestamp = DateTime.UtcNow;
    }

    /// <summary>
    /// 写入项结果集合
    /// </summary>
    public IReadOnlyList<WriteItemResult> Results { get; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// 成功数量
    /// </summary>
    public int SuccessCount => Results.Count(r => r.IsSuccess);

    /// <summary>
    /// 失败数量
    /// </summary>
    public int FailureCount => Results.Count(r => !r.IsSuccess);
}

/// <summary>
/// 数据值
/// </summary>
public sealed class DataValue
{
    public DataValue(string name, object? value, DataQuality quality, string? errorMessage = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value;
        Quality = quality;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// 点名
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 值
    /// </summary>
    public object? Value { get; }

    /// <summary>
    /// 数据质量
    /// </summary>
    public DataQuality Quality { get; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; }
}

/// <summary>
/// 写入项
/// </summary>
public sealed class WriteItem
{
    public WriteItem(string address, object value)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// 值
    /// </summary>
    public object Value { get; }
}

/// <summary>
/// 写入项结果
/// </summary>
public sealed class WriteItemResult
{
    public WriteItemResult(string address, bool isSuccess, string? errorMessage = null)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage { get; }
}

/// <summary>
/// 数据质量枚举
/// </summary>
public enum DataQuality
{
    /// <summary>
    /// 良好
    /// </summary>
    Good = 0,

    /// <summary>
    /// 不确定
    /// </summary>
    Uncertain = 1,

    /// <summary>
    /// 坏值
    /// </summary>
    Bad = 2
}
