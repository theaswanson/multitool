using AdamsMultiTool.Core.Services;
using FluentAssertions;

namespace AdamsMultiTool.Core.Tests.Services;

[TestFixture]
public class NatoServiceTests
{
    private NatoService _natoService;

    [SetUp]
    public void Setup()
    {
        _natoService = new NatoService();
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void GivenEmptyString_ReturnsEmptyArray(string? emptyString)
    {
        _natoService.ConvertStringToNatoWords(emptyString).Should().BeEmpty();
    }
    
    [TestCase("!@#$%^&*()-=_+[]{};':\"<>?,./`~")]
    public void GivenStringWithNonNatoCharacters_ReturnsEmptyArray(string nonNatoString)
    {
        _natoService.ConvertStringToNatoWords(nonNatoString).Should().BeEmpty();
    }
    
    [TestCase("Adam")]
    [TestCase("adam")]
    [TestCase("ADAM")]
    public void GivenStringWithNatoCharacters_ReturnsOneNatoWordPerCharacter(string adam)
    {
        _natoService.ConvertStringToNatoWords(adam).Should().BeEquivalentTo([
            "Alfa",
            "Delta",
            "Alfa",
            "Mike"
        ]);
    }

    [Test]
    public void GivenStringWithMultipleWords_IncludesBlankStringBetweenWords()
    {
        _natoService.ConvertStringToNatoWords("a b").Should().BeEquivalentTo([
            "Alfa",
            "",
            "Bravo"
        ]);
    }
}