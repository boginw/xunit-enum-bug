using System.Globalization;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EnumBug.Tests;

public sealed class LocaleAssemblyFixture : XunitTestFramework
{
    public LocaleAssemblyFixture(IMessageSink messageSink)
        : base(messageSink)
    {
        CultureInfo ci = new CultureInfo("fo-FO");
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
    }
}
