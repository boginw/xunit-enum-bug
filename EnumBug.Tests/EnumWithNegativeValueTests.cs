[assembly: TestFramework("EnumBug.Tests.LocaleAssemblyFixture", "EnumBug.Tests")]

namespace EnumBug.Tests;

public class EnumWithNegativeValueTests
{
    [Theory]
    [InlineData(EnumWithNegativeValue.NegativeOne, -1)]
    [InlineData(EnumWithNegativeValue.NegativeTwo, -2)]
    public void Test1(EnumWithNegativeValue enumValue, int intValue)
    {
        Assert.Equal(intValue, (int)enumValue);
    }
}
