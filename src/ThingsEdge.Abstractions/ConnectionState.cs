namespace ThingsEdge.Abstractions;

/// <summary>
/// 连接状态枚举
/// </summary>
public enum ConnectionState
{
    /// <summary>
    /// 已断开
    /// </summary>
    Disconnected = 0,

    /// <summary>
    /// 连接中
    /// </summary>
    Connecting = 1,

    /// <summary>
    /// 已连接
    /// </summary>
    Connected = 2,

    /// <summary>
    /// 断开连接中
    /// </summary>
    Disconnecting = 3,

    /// <summary>
    /// 连接失败
    /// </summary>
    Faulted = 4
}
