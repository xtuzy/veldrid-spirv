using Microsoft.Extensions.Logging;
using Veldrid.SPIRV.Tests;
using Xunit.Runners.Maui;

namespace Veldrid.Maui.SPIRV.Tests
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                //.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.ConfigureTests(new TestOptions
            {
                Assemblies =
                {
                    typeof(MauiProgram).Assembly,
                    typeof(CompilationTests).Assembly,
                }
            })
            .UseVisualRunner();
            return builder.Build();
        }
    }
}
