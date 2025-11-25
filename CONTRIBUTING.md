# 贡献指南

感谢你对 ThingsEdge 的关注！我们欢迎所有形式的贡献。

## 贡献方式

### 🐛 报告 Bug
1. 在 [Issues](https://github.com/Liam-wzh/ThingsEdge/issues) 中搜索是否已存在相关问题
2. 如果没有，创建新 Issue 并使用 **Bug Report** 模板
3. 提供详细的复现步骤和环境信息

### ✨ 提出新功能
1. 在 [Discussions](https://github.com/Liam-wzh/ThingsEdge/discussions) 中讨论你的想法
2. 获得初步反馈后，创建 **Feature Request** Issue
3. 等待维护者审核后开始实现

### 📝 改进文档
- 修正拼写错误、语法问题
- 添加缺失的文档或示例
- 翻译文档到其他语言

### 🔧 提交代码
请遵循以下流程：

## 开发流程

### 1. Fork 并克隆仓库
```bash
git clone https://github.com/YOUR_USERNAME/ThingsEdge.git
cd ThingsEdge
```

### 2. 创建特性分支
```bash
git checkout -b feature/your-feature-name
# 或
git checkout -b fix/your-bug-fix
```

### 3. 开发与测试
```bash
# 恢复依赖
dotnet restore

# 构建项目
dotnet build

# 运行测试
dotnet test

# 运行特定测试
dotnet test --filter "FullyQualifiedName~ThingsEdge.Core.Tests"
```

### 4. 遵循代码规范
- 使用 `.editorconfig` 中定义的格式规范
- 所有公共 API 必须包含 XML 文档注释
- 单元测试覆盖率 > 80%

### 5. 提交变更
遵循 [Conventional Commits](https://www.conventionalcommits.org/) 规范：

```bash
# 功能
git commit -m "feat: add Modbus RTU support"

# Bug 修复
git commit -m "fix: resolve connection timeout issue"

# 文档
git commit -m "docs: update quick start guide"

# 重构
git commit -m "refactor: simplify driver initialization"

# 测试
git commit -m "test: add integration tests for OPC UA"
```

### 6. 推送并创建 PR
```bash
git push origin feature/your-feature-name
```

在 GitHub 上创建 Pull Request，并：
- 清晰描述变更内容
- 关联相关 Issue (使用 `Closes #123`)
- 确保 CI 检查通过

## 代码规范

### C# 编码风格
```csharp
// ✅ 推荐
public interface IDriver
{
    Task<ReadResult<T>> ReadAsync<T>(string address, CancellationToken cancellationToken = default);
}

// ❌ 避免
public interface IDriver
{
    Task<ReadResult<T>> read_async<T>(string addr);  // 使用 PascalCase
}
```

### 命名约定
- **接口**: `IDriver`, `IChannel`
- **类**: `ModbusTcpDriver`, `DataPoint`
- **方法**: `ConnectAsync`, `ReadBatchAsync`
- **私有字段**: `_connectionState`, `_logger`

### 异步编程
```csharp
// ✅ 使用 Async 后缀
public async Task<ConnectResult> ConnectAsync(CancellationToken cancellationToken = default)
{
    // 始终接受 CancellationToken
}

// ✅ 避免 async void
public async Task HandleEventAsync() { }

// ❌ 避免
public async void HandleEvent() { }  // 仅在事件处理器中使用
```

### 单元测试
```csharp
[Fact]
public async Task ReadAsync_ValidAddress_ReturnsSuccessResult()
{
    // Arrange
    var driver = new ModbusTcpDriver("localhost", 502);

    // Act
    var result = await driver.ReadAsync<ushort>("400001");

    // Assert
    Assert.True(result.IsSuccess);
    Assert.Equal(DataQuality.Good, result.Quality);
}
```

## 协议驱动开发指南

### 实现新协议
1. 在 `src/ThingsEdge.Protocols/` 下创建新项目
2. 实现 `IDriver` 接口
3. 添加协议特定的配置选项
4. 编写单元测试和集成测试
5. 添加协议文档到 `docs/protocols/`

### 参考实现
查看 `ThingsEdge.Protocols.Modbus` 作为参考示例。

## 提交前检查清单

- [ ] 代码遵循项目编码规范
- [ ] 所有测试通过 (`dotnet test`)
- [ ] 添加或更新了相关文档
- [ ] 提交消息遵循 Conventional Commits
- [ ] 没有引入不必要的依赖
- [ ] 代码已格式化 (使用 `.editorconfig`)

## 许可证

通过贡献代码，你同意将你的贡献以 [MIT 许可证](LICENSE) 的形式发布。

## 需要帮助?

- 💬 [GitHub Discussions](https://github.com/Liam-wzh/ThingsEdge/discussions)
- 📧 support@thingsedge.dev

再次感谢你的贡献！ 🎉
