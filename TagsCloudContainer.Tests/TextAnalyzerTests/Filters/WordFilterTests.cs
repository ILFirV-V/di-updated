using FluentAssertions;
using TagsCloudContainer.TextAnalyzer.Logic.Filters;
using TagsCloudContainer.TextAnalyzer.Models;

namespace TagsCloudContainer.Tests.TextAnalyzerTests.Filters;

[TestFixture]
[TestOf(typeof(WordFilter))]
public class WordFilterTests
{
    private static readonly WordSettings DefaultSettings = new();
    private static readonly string startWordFake = string.Empty;
    private static readonly string formatedWordFake = string.Empty;
    private static IReadOnlyCollection<TestCaseData> validTestCases =
    [
        new TestCaseData("V", DefaultSettings)
            .SetName("Verb"),
        new TestCaseData("S", DefaultSettings)
            .SetName("Noun"),
        new TestCaseData("A", DefaultSettings)
            .SetName("Adjective"),
        new TestCaseData("ADV", DefaultSettings)
            .SetName("Adverb"),
        new TestCaseData("NUM", DefaultSettings)
            .SetName("Numeral"),
        new TestCaseData("N", new WordSettings { ValidSpeechParts = ["N"] })
            .SetName("CustomSettings")
    ];

    private static IEnumerable<TestCaseData> notValidTestCases =
    [
        new TestCaseData("invalid", DefaultSettings)
            .SetName("InvalidSpeechPart"),
        new TestCaseData(null, DefaultSettings)
            .SetName("NullSpeechPart"),
        new TestCaseData(" ", DefaultSettings)
            .SetName("WhitespaceSpeechPart"),
        new TestCaseData("V", new WordSettings { ValidSpeechParts = ["S"] })
            .SetName("WithoutSpeechPart")
    ];

    [Test]
    [TestCaseSource(nameof(validTestCases))]
    public void IsVerify_Should_BeVerify(string expectedSpeechPart, WordSettings settings)
    {
        var filter = new WordFilter();
        var wordDetails = new WordDetails(startWordFake, formatedWordFake, expectedSpeechPart);

        var result = filter.IsVerify(wordDetails, settings);

        result.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(notValidTestCases))]
    public void IsVerify_Should_BeNotVerify(string expectedSpeechPart, WordSettings settings)
    {
        var filter = new WordFilter();
        var wordDetails = new WordDetails(startWordFake, formatedWordFake, expectedSpeechPart);

        var result = filter.IsVerify(wordDetails, settings);

        result.Should().BeFalse();
    }
}