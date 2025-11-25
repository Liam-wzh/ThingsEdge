namespace ThingsEdge.Abstractions;

/// <summary>
/// 连接状态变化事件参数
/// </summary>
public sealed class ConnectionStateChangedEventArgs : EventArgs
{
    public ConnectionStateChangedEventArgs(ConnectionState oldState, ConnectionState newState, string? reason = null)
    {
        OldState = oldState;
        NewState = newState;
        Reason = reason;
        Timestamp = DateTime.UtcNow;
    }

    /// <summary>
    /// 旧状态
    /// </summary>
    public ConnectionState OldState { get; }

    /// <summary>
    /// 新状态
    /// </summary>
    public ConnectionState NewState { get; }

    /// <summary>
    /// 原因
    /// </summary>
    public string? Reason { get; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public DateTime Timestamp { get; }
}
