using TextToHtmlConvertor;

using Xunit;

namespace TextToHtmlConvertorTests;

public class TextProcessorTests
{
    private readonly TextProcessor textProcessor;

    private readonly MdTextProcessor mdTextProcessor;

    public TextProcessorTests()
    {
        var tagsToReplace = new Dictionary<string, (string, string)>
            {
                { "**", ("<strong>", "</strong>") },
                { "*", ("<em>", "</em>") },
                { "~~", ("<del>", "</del>") }
            };

        mdTextProcessor = new MdTextProcessor(tagsToReplace);
        textProcessor = new TextProcessor();
    }

    [Fact]
    public void TextProcessor_ConvertText()
    {
        var originalText = "This is the first paragraph. It has * and *.\r\n" +
            "This is the second paragraph. It has ** and **.";

        var expectedSting = "<p>This is the first paragraph. It has * and *.</p>\r\n" +
            "<p>This is the second paragraph. It has ** and **.</p>\r\n" +
            "<br/>\r\n";

        Assert.Equal(expectedSting, textProcessor.ConvertText(originalText));
    }

    [Fact]
    public void MdTextProcessor_ConvertText()
    {
        var originalText = "This is the first paragraph. It has * and *.\r\n" +
            "This is the second paragraph. It has ** and **.";

        var expectedSting = "<p>This is the first paragraph. It has * and *.</p>\r\n" +
            "<p>This is the second paragraph. It has ** and **.</p>\r\n" +
            "<br/>\r\n";

        Assert.Equal(expectedSting, mdTextProcessor.ConvertText(originalText));
    }

    [Fact]
    public void MdTextProcessor_ConvertMdText()
    {
        var originalText = "This is the first paragraph. It has * and *.\r\n" +
            "This is the second paragraph. It has ** and **.";

        var expectedSting = "<p>This is the first paragraph. It has <em> and </em>.</p>\r\n" +
            "<p>This is the second paragraph. It has <strong> and </strong>.</p>\r\n" +
            "<br/>\r\n";

        Assert.Equal(expectedSting, mdTextProcessor.ConvertMdText(originalText));
    }
}