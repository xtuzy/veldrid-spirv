using System;
using System.IO;

namespace Veldrid.SPIRV.Tests
{
    internal static class TestUtil
    {
        public static string LoadShaderText(string name)
        {
#if ANDROID || IOS || WINDOWS || MACCATALYST
            return LoadEmbeddedText(name);
#else
            return File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "TestShaders", name));
#endif
        }

        public static byte[] LoadBytes(string name)
        {
#if ANDROID || IOS || WINDOWS || MACCATALYST
            return LoadEmbeddedBytes(name);
#else
            return File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "TestShaders", name));
#endif
        }

        static string LoadEmbeddedText(string name)
        {
            using (Stream stream = typeof(CompilationTests).Assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("No embedded asset with the name " + name);
                }

                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        static byte[] LoadEmbeddedBytes(string name)
        {
            using (Stream stream = typeof(CompilationTests).Assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("No embedded asset with the name " + name);
                }

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
