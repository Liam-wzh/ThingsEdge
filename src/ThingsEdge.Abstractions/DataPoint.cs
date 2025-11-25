namespace ThingsEdge.Abstractions;

/// <summary>
/// 数据点定义
/// </summary>
public sealed class DataPoint
{
    /// <summary>
    /// 初始化数据点
    /// </summary>
    /// <param name="name">点名</param>
    /// <param name="address">地址</param>
    /// <param name="dataType">数据类型</param>
    public DataPoint(string name, string address, DataType dataType)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        DataType = dataType;
    }

    /// <summary>
    /// 点名
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// 数据类型
    /// </summary>
    public DataType DataType { get; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// 扩展属性
    /// </summary>
    public Dictionary<string, object>? Properties { get; init; }
}

/// <summary>
/// 数据类型枚举
/// </summary>
public enum DataType
{
    Boolean,
    Byte,
    Int16,
    UInt16,
    Int32,
    UInt32,
    Int64,
    UInt64,
    Float,
    Double,
    String,
    DateTime
}
