using System.Globalization;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EnumBug.Tests;

public sealed class LocaleAssemblyFixture : XunitTestFramework
{
    public LocaleAssemblyFixture(IMessageSink messageSink)
        : base(messageSink)
    {
        var ci = new CultureInfo(Environment.GetEnvironmentVariable("TESTLANG") ?? "fo-FO");
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
    }
}
