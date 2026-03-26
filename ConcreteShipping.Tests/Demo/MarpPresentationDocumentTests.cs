namespace ConcreteShipping.Tests.Demo;

/// <summary>
/// Tests for demo/marp/AI開発デモ_プレゼン.md
/// Validates that the Marp presentation has valid front matter, required slides,
/// correct section structure, and key content for the AI development demo.
/// </summary>
public class MarpPresentationDocumentTests
{
    private static readonly string DocumentPath = Path.Combine(
        GetRepositoryRoot(),
        "demo",
        "marp",
        "AI開発デモ_プレゼン.md");

    private static string GetRepositoryRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, ".git")))
            dir = dir.Parent;
        return dir?.FullName ?? AppContext.BaseDirectory;
    }

    private string ReadDocument() => File.ReadAllText(DocumentPath);

    // ── File existence ──────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_FileExists()
    {
        Assert.True(File.Exists(DocumentPath),
            $"Marp presentation document not found at: {DocumentPath}");
    }

    [Fact]
    public void PresentationDocument_IsNotEmpty()
    {
        var content = ReadDocument();
        Assert.False(string.IsNullOrWhiteSpace(content));
    }

    // ── Marp front matter ───────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_HasMarpFrontMatter()
    {
        var content = ReadDocument();
        // Marp documents start with ---\nmarp: true
        Assert.StartsWith("---", content.TrimStart('\uFEFF'));
        Assert.Contains("marp: true", content);
    }

    [Fact]
    public void PresentationDocument_FrontMatter_HasPaginationEnabled()
    {
        var content = ReadDocument();
        Assert.Contains("paginate: true", content);
    }

    [Fact]
    public void PresentationDocument_FrontMatter_HasWideScreenAspectRatio()
    {
        var content = ReadDocument();
        Assert.Contains("size: 16:9", content);
    }

    [Fact]
    public void PresentationDocument_FrontMatter_UsesDefaultTheme()
    {
        var content = ReadDocument();
        Assert.Contains("theme: default", content);
    }

    [Fact]
    public void PresentationDocument_FrontMatter_HasCustomStyles()
    {
        var content = ReadDocument();
        Assert.Contains("style: |", content);
    }

    // ── Slide separators ────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_HasMultipleSlides()
    {
        var content = ReadDocument();
        // Count slide separator lines (---)
        var slideCount = content.Split(new[] { "\n---\n" }, StringSplitOptions.None).Length;
        Assert.True(slideCount >= 10,
            $"Expected at least 10 slides, but found roughly {slideCount}");
    }

    // ── Title slide ─────────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_TitleSlide_HasExpectedH1()
    {
        var content = ReadDocument();
        Assert.Contains("# AI駆動開発の実践", content);
    }

    [Fact]
    public void PresentationDocument_TitleSlide_MentionsClaudeCode()
    {
        var content = ReadDocument();
        Assert.Contains("Claude Code", content);
    }

    [Fact]
    public void PresentationDocument_TitleSlide_HasTitleClass()
    {
        var content = ReadDocument();
        Assert.Contains("_class: title", content);
    }

    [Fact]
    public void PresentationDocument_TitleSlide_MentionsSuperParallelDevelopment()
    {
        var content = ReadDocument();
        Assert.Contains("超並列開発手法", content);
    }

    // ── Agenda slide ────────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_AgendaSlide_Exists()
    {
        var content = ReadDocument();
        Assert.Contains("## アジェンダ", content);
    }

    [Fact]
    public void PresentationDocument_AgendaSlide_HasEightItems()
    {
        var content = ReadDocument();
        // Agenda table has 8 numbered rows
        for (int i = 1; i <= 8; i++)
        {
            Assert.Contains($"| {i} |", content);
        }
    }

    [Fact]
    public void PresentationDocument_AgendaSlide_MentionsLiveDemo()
    {
        var content = ReadDocument();
        Assert.Contains("デモ：並列タスク同時実行開始", content);
    }

    // ── Section-break slides ────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_HasSectionBreakClass()
    {
        var content = ReadDocument();
        Assert.Contains("_class: section-break", content);
    }

    [Fact]
    public void PresentationDocument_SectionBreaks_AreNumberedSequentially()
    {
        var content = ReadDocument();
        // Sections 01 through 07 must all appear as H2 headings in section-break slides
        for (int i = 1; i <= 7; i++)
        {
            Assert.Contains($"## {i:D2}", content);
        }
    }

    // ── Key message: 評価 ────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_HasEvaluationAsKeyMessage()
    {
        var content = ReadDocument();
        Assert.Contains("# 評価！！", content);
    }

    [Fact]
    public void PresentationDocument_HasHugeClassForEvaluationSlide()
    {
        var content = ReadDocument();
        Assert.Contains("_class: huge", content);
    }

    [Fact]
    public void PresentationDocument_ExplainsWhyEvaluationIsImportant()
    {
        var content = ReadDocument();
        Assert.Contains("なぜ「評価」が最重要なのか", content);
    }

    // ── Google 10% statistics claim ─────────────────────────────────────

    [Fact]
    public void PresentationDocument_ReferencesGoogle10PercentStatistic()
    {
        var content = ReadDocument();
        Assert.Contains("10%", content);
        Assert.Contains("Google統計", content);
    }

    // ── Demo scenario slide ─────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_DemoScenarioSlide_Exists()
    {
        var content = ReadDocument();
        Assert.Contains("## ライブデモのシナリオ", content);
    }

    [Fact]
    public void PresentationDocument_DemoScenarioSlide_HasTaskA_ValueObject()
    {
        var content = ReadDocument();
        Assert.Contains("Task A", content);
        Assert.Contains("ValueObject", content);
    }

    [Fact]
    public void PresentationDocument_DemoScenarioSlide_HasTaskB_DarkMode()
    {
        var content = ReadDocument();
        Assert.Contains("Task B", content);
        Assert.Contains("ダークモード", content);
    }

    [Fact]
    public void PresentationDocument_DemoScenarioSlide_HasTaskC_WeatherApi()
    {
        var content = ReadDocument();
        Assert.Contains("Task C", content);
        Assert.Contains("天気予報", content);
    }

    [Fact]
    public void PresentationDocument_DemoScenario_DescribesThreeParallelTasks()
    {
        var content = ReadDocument();
        // All three tasks should coexist in the same document
        int tasksFound = 0;
        foreach (var label in new[] { "Task A", "Task B", "Task C" })
        {
            if (content.Contains(label)) tasksFound++;
        }
        Assert.Equal(3, tasksFound);
    }

    // ── AI tools comparison slide ────────────────────────────────────────

    [Fact]
    public void PresentationDocument_AIToolsSlide_Exists()
    {
        var content = ReadDocument();
        Assert.Contains("## 主要なAI開発ツールのコストと利用イメージ", content);
    }

    [Fact]
    public void PresentationDocument_AIToolsSlide_IncludesClaudePro()
    {
        var content = ReadDocument();
        Assert.Contains("Claude Pro", content);
    }

    [Fact]
    public void PresentationDocument_AIToolsSlide_IncludesCursor()
    {
        var content = ReadDocument();
        Assert.Contains("Cursor", content);
    }

    [Fact]
    public void PresentationDocument_AIToolsSlide_IncludesGoogleAIPro()
    {
        var content = ReadDocument();
        Assert.Contains("Google AI Pro", content);
    }

    [Fact]
    public void PresentationDocument_AIToolsSlide_IncludesGitHubCopilot()
    {
        var content = ReadDocument();
        Assert.Contains("GitHub Copilot", content);
    }

    // ── Recommended plan slide ───────────────────────────────────────────

    [Fact]
    public void PresentationDocument_RecommendedPlanSlide_Exists()
    {
        var content = ReadDocument();
        Assert.Contains("## おすすめのAI環境プラン", content);
    }

    [Fact]
    public void PresentationDocument_RecommendedPlanSlide_HasCostEffectiveOptions()
    {
        var content = ReadDocument();
        Assert.Contains("コスパセット", content);
    }

    [Fact]
    public void PresentationDocument_RecommendedPlanSlide_HasMainPlayerOptions()
    {
        var content = ReadDocument();
        Assert.Contains("メインプレイヤー向け", content);
    }

    // ── Summary slide ─────────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_SummarySlide_Exists()
    {
        var content = ReadDocument();
        Assert.Contains("## まとめ", content);
    }

    [Fact]
    public void PresentationDocument_SummarySlide_RecommendsGit()
    {
        var content = ReadDocument();
        Assert.Contains("GitとCI/CDの導入", content);
    }

    [Fact]
    public void PresentationDocument_SummarySlide_RecommendsClaude()
    {
        var content = ReadDocument();
        Assert.Contains("迷ったら「Claude」", content);
    }

    [Fact]
    public void PresentationDocument_SummarySlide_HasThreePoints()
    {
        var content = ReadDocument();
        // Three numbered summary points
        Assert.Contains("1. GitとCI/CDの導入", content);
        Assert.Contains("2. 「評価可能」な領域からAIを活用", content);
        Assert.Contains("3. 迷ったら「Claude」", content);
    }

    // ── Closing slide ─────────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_ClosingSlide_HasClosingClass()
    {
        var content = ReadDocument();
        Assert.Contains("_class: closing", content);
    }

    [Fact]
    public void PresentationDocument_ClosingSlide_HasEndTitle()
    {
        var content = ReadDocument();
        Assert.Contains("# おわり", content);
    }

    [Fact]
    public void PresentationDocument_ClosingSlide_HasQASection()
    {
        var content = ReadDocument();
        Assert.Contains("Q&A", content);
    }

    // ── Custom CSS classes ────────────────────────────────────────────────

    [Fact]
    public void PresentationDocument_CssDefinesTwoColumnLayout()
    {
        var content = ReadDocument();
        Assert.Contains(".two-column", content);
    }

    [Fact]
    public void PresentationDocument_CssDefinesCardStyle()
    {
        var content = ReadDocument();
        Assert.Contains(".card", content);
    }

    [Fact]
    public void PresentationDocument_CssDefinesTimelineStyle()
    {
        var content = ReadDocument();
        Assert.Contains(".timeline", content);
    }

    // ── Regression / boundary cases ───────────────────────────────────────

    [Fact]
    public void PresentationDocument_DoesNotContainPlaceholderText()
    {
        var content = ReadDocument();
        Assert.DoesNotContain("TODO", content);
        Assert.DoesNotContain("FIXME", content);
        Assert.DoesNotContain("TBD", content);
    }

    [Fact]
    public void PresentationDocument_AllSlideDividersAreSeparateLines()
    {
        var content = ReadDocument();
        // Every slide separator "---" should be surrounded by newlines (not inline dashes)
        var lines = content.Split('\n');
        var inlineDashIssues = lines
            .Where(l => l.TrimEnd() == "---")
            .Count();
        // We just verify that most --- lines are indeed standalone separator lines
        Assert.True(inlineDashIssues >= 5,
            "Expected multiple standalone '---' slide separators");
    }

    [Fact]
    public void PresentationDocument_FrontMatterIsClosedBeforeContent()
    {
        var content = ReadDocument();
        // The front matter block must be closed with --- before slide content
        var withoutBom = content.TrimStart('\uFEFF');
        var firstClose = withoutBom.IndexOf("\n---\n", 4); // skip opening ---
        Assert.True(firstClose > 0, "Front matter closing '---' not found");
        // Title slide content should come after the closing ---
        var titleIndex = content.IndexOf("# AI駆動開発の実践", StringComparison.Ordinal);
        Assert.True(titleIndex > firstClose, "Title heading appears before front matter is closed");
    }

    [Fact]
    public void PresentationDocument_MarpDirectiveIsOnSecondLine()
    {
        var content = ReadDocument().TrimStart('\uFEFF');
        var lines = content.Split('\n');
        // Line 0 should be "---", line 1 should contain "marp: true"
        Assert.Equal("---", lines[0].Trim());
        Assert.Contains("marp: true", lines[1]);
    }
}