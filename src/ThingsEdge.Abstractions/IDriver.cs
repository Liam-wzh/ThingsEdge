namespace ThingsEdge.Abstractions;

/// <summary>
/// 设备驱动核心接口
/// </summary>
public interface IDriver : IAsyncDisposable
{
    /// <summary>
    /// 驱动名称
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 当前连接状态
    /// </summary>
    ConnectionState State { get; }

    /// <summary>
    /// 连接到设备
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>连接结果</returns>
    Task<ConnectResult> ConnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 断开连接
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task DisconnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 读取单个数据点
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="address">地址</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>读取结果</returns>
    Task<ReadResult<T>> ReadAsync<T>(string address, CancellationToken cancellationToken = default);

    /// <summary>
    /// 批量读取数据点
    /// </summary>
    /// <param name="points">数据点集合</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>批量读取结果</returns>
    Task<BatchReadResult> ReadBatchAsync(IEnumerable<DataPoint> points, CancellationToken cancellationToken = default);

    /// <summary>
    /// 写入数据
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="address">地址</param>
    /// <param name="value">值</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>写入结果</returns>
    Task<WriteResult> WriteAsync<T>(string address, T value, CancellationToken cancellationToken = default);

    /// <summary>
    /// 批量写入数据
    /// </summary>
    /// <param name="writes">写入项集合</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>批量写入结果</returns>
    Task<BatchWriteResult> WriteBatchAsync(IEnumerable<WriteItem> writes, CancellationToken cancellationToken = default);

    /// <summary>
    /// 连接状态变化事件
    /// </summary>
    event EventHandler<ConnectionStateChangedEventArgs>? ConnectionStateChanged;
}
