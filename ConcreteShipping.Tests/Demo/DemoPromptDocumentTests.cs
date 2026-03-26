namespace ConcreteShipping.Tests.Demo;

/// <summary>
/// Tests for demo/AI開発デモ_投入プロンプト.md
/// Validates that the demo prompt document contains required sections,
/// correctly specifies 3 parallel terminal tasks, and preserves key constraints.
/// </summary>
public class DemoPromptDocumentTests
{
    private static readonly string DocumentPath = Path.Combine(
        GetRepositoryRoot(),
        "demo",
        "AI開発デモ_投入プロンプト.md");

    private static string GetRepositoryRoot()
    {
        // Walk up from the test assembly directory to find the repo root
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, ".git")))
            dir = dir.Parent;
        return dir?.FullName ?? AppContext.BaseDirectory;
    }

    private string ReadDocument() => File.ReadAllText(DocumentPath);

    // ── File existence ──────────────────────────────────────────────────

    [Fact]
    public void PromptDocument_FileExists()
    {
        Assert.True(File.Exists(DocumentPath),
            $"Demo prompt document not found at: {DocumentPath}");
    }

    [Fact]
    public void PromptDocument_IsNotEmpty()
    {
        var content = ReadDocument();
        Assert.False(string.IsNullOrWhiteSpace(content));
    }

    // ── Top-level heading ───────────────────────────────────────────────

    [Fact]
    public void PromptDocument_HasExpectedH1Title()
    {
        var content = ReadDocument();
        Assert.Contains("# Claude Code投入用プロンプト集", content);
    }

    [Fact]
    public void PromptDocument_TitleIndicatesThreeTerminalParallelVersion()
    {
        var content = ReadDocument();
        Assert.Contains("3ターミナル並列版", content);
    }

    // ── Task A: ValueObject ─────────────────────────────────────────────

    [Fact]
    public void PromptDocument_ContainsTaskA_Section()
    {
        var content = ReadDocument();
        Assert.Contains("Task A", content);
    }

    [Fact]
    public void PromptDocument_TaskA_TargetsTerminal1()
    {
        var content = ReadDocument();
        Assert.Contains("ターミナル1", content);
    }

    [Fact]
    public void PromptDocument_TaskA_DescribesDomainLayerImprovement()
    {
        var content = ReadDocument();
        Assert.Contains("ドメイン層", content);
        Assert.Contains("ValueObject", content);
    }

    [Fact]
    public void PromptDocument_TaskA_PromptMentionsConcreteQuantity()
    {
        var content = ReadDocument();
        // The prompt must suggest the ConcreteQuantity class name
        Assert.Contains("ConcreteQuantity", content);
    }

    [Fact]
    public void PromptDocument_TaskA_ConstrainsChangeToViewModelAndViewLayerOnly()
    {
        var content = ReadDocument();
        // Critical safety constraint: DB/EF must not be changed
        Assert.Contains("ViewModelとView層の修正のみ", content);
    }

    [Fact]
    public void PromptDocument_TaskA_ProhibitsDbChanges()
    {
        var content = ReadDocument();
        Assert.Contains("DB（Entity Framework Core構成、DbContext、マイグレーション等）", content);
        Assert.Contains("一切行わないでください", content);
    }

    [Fact]
    public void PromptDocument_TaskA_SpecifiesTwoDecimalPlacePrecision()
    {
        var content = ReadDocument();
        Assert.Contains("小数点以下2桁", content);
    }

    // ── Task B: Dark mode ───────────────────────────────────────────────

    [Fact]
    public void PromptDocument_ContainsTaskB_Section()
    {
        var content = ReadDocument();
        Assert.Contains("Task B", content);
    }

    [Fact]
    public void PromptDocument_TaskB_TargetsTerminal2()
    {
        var content = ReadDocument();
        Assert.Contains("ターミナル2", content);
    }

    [Fact]
    public void PromptDocument_TaskB_DescribesUiModernization()
    {
        var content = ReadDocument();
        Assert.Contains("ダークモード", content);
        Assert.Contains("UIのモダナイズ", content);
    }

    [Fact]
    public void PromptDocument_TaskB_RequiresToggleSwitchWithSunMoonIcon()
    {
        var content = ReadDocument();
        Assert.Contains("太陽/月のアイコン", content);
        Assert.Contains("トグルスイッチ", content);
    }

    [Fact]
    public void PromptDocument_TaskB_RequiresLocalStoragePersistence()
    {
        var content = ReadDocument();
        Assert.Contains("LocalStorage", content);
    }

    [Fact]
    public void PromptDocument_TaskB_RequiresBootstrap5DarkModeIntegration()
    {
        var content = ReadDocument();
        Assert.Contains("Bootstrap 5", content);
        Assert.Contains("data-bs-theme", content);
    }

    // ── Task C: Weather API ─────────────────────────────────────────────

    [Fact]
    public void PromptDocument_ContainsTaskC_Section()
    {
        var content = ReadDocument();
        Assert.Contains("Task C", content);
    }

    [Fact]
    public void PromptDocument_TaskC_TargetsTerminal3()
    {
        var content = ReadDocument();
        Assert.Contains("ターミナル3", content);
    }

    [Fact]
    public void PromptDocument_TaskC_DescribesExternalApiIntegration()
    {
        var content = ReadDocument();
        Assert.Contains("外部API連携", content);
    }

    [Fact]
    public void PromptDocument_TaskC_SpecifiesOpenMeteoApiUrl()
    {
        var content = ReadDocument();
        Assert.Contains("https://api.open-meteo.com/v1/forecast", content);
    }

    [Fact]
    public void PromptDocument_TaskC_HighlightsApiKeyNotRequired()
    {
        var content = ReadDocument();
        Assert.Contains("APIキー不要", content);
    }

    [Fact]
    public void PromptDocument_TaskC_RequiresAsynchronousFetch()
    {
        var content = ReadDocument();
        // Must use JavaScript fetch or similar for async data retrieval
        Assert.Contains("fetch", content);
        Assert.Contains("非同期", content);
    }

    [Fact]
    public void PromptDocument_TaskC_ProhibitsBackendModelChanges()
    {
        var content = ReadDocument();
        Assert.Contains("バックエンドのModelsや既存のDB構造は一切変更しないこと", content);
    }

    // ── Backup task ─────────────────────────────────────────────────────

    [Fact]
    public void PromptDocument_ContainsBackupTask_Section()
    {
        var content = ReadDocument();
        Assert.Contains("予備タスク", content);
    }

    [Fact]
    public void PromptDocument_BackupTask_DescribesBugFix()
    {
        var content = ReadDocument();
        Assert.Contains("バグ修正デモ", content);
    }

    [Fact]
    public void PromptDocument_BackupTask_DescribesNullReferenceException()
    {
        var content = ReadDocument();
        Assert.Contains("Object reference not set to an instance of an object", content);
    }

    [Fact]
    public void PromptDocument_BackupTask_RequiresUserFriendlyValidationMessage()
    {
        var content = ReadDocument();
        Assert.Contains("バリデーションメッセージ", content);
    }

    // ── Structural integrity ─────────────────────────────────────────────

    [Fact]
    public void PromptDocument_HasExactlyThreeMainTerminalTasks()
    {
        var content = ReadDocument();
        // Count "Task A", "Task B", "Task C" headers
        int taskCount = 0;
        foreach (var letter in new[] { "A", "B", "C" })
        {
            if (content.Contains($"Task {letter}"))
                taskCount++;
        }
        Assert.Equal(3, taskCount);
    }

    [Fact]
    public void PromptDocument_TasksAreInConflictFreeDesign()
    {
        var content = ReadDocument();
        // The document should mention tasks are designed to avoid file conflicts
        Assert.Contains("コンフリクト", content);
    }

    [Fact]
    public void PromptDocument_AllTasksContainCodeBlocks()
    {
        var content = ReadDocument();
        // Each prompt is wrapped in a ```text code block
        var codeBlockCount = 0;
        var index = 0;
        while ((index = content.IndexOf("```text", index, StringComparison.Ordinal)) >= 0)
        {
            codeBlockCount++;
            index++;
        }
        // 3 main tasks + 1 backup = at least 4 code blocks
        Assert.True(codeBlockCount >= 4,
            $"Expected at least 4 code blocks (3 tasks + 1 backup), found {codeBlockCount}");
    }

    [Fact]
    public void PromptDocument_EachTaskHasGoalAnnotation()
    {
        var content = ReadDocument();
        // Each main task section should describe its demo purpose (狙い)
        var aimCount = content.Split("**狙い**").Length - 1;
        Assert.True(aimCount >= 3,
            $"Expected at least 3 '狙い' annotations (one per task), found {aimCount}");
    }

    // ── Edge/regression cases ────────────────────────────────────────────

    [Fact]
    public void PromptDocument_DoesNotContainPlaceholderText()
    {
        var content = ReadDocument();
        Assert.DoesNotContain("TODO", content);
        Assert.DoesNotContain("FIXME", content);
        Assert.DoesNotContain("TBD", content);
    }

    [Fact]
    public void PromptDocument_OpenMeteoUrlIsWellFormed()
    {
        var content = ReadDocument();
        Assert.Contains("https://api.open-meteo.com/v1/forecast", content);
        var uri = new Uri("https://api.open-meteo.com/v1/forecast");
        Assert.Equal("https", uri.Scheme);
        Assert.Equal("api.open-meteo.com", uri.Host);
    }

    [Fact]
    public void PromptDocument_TerminalNumbersAreSequential()
    {
        var content = ReadDocument();
        // Terminals 1, 2, 3 must all appear
        Assert.Contains("ターミナル1", content);
        Assert.Contains("ターミナル2", content);
        Assert.Contains("ターミナル3", content);
    }
}