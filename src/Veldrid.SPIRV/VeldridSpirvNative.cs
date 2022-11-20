using System.Runtime.InteropServices;

namespace Veldrid.SPIRV
{
    internal static unsafe class VeldridSpirvNative
    {
#if IOS
        private const string LibName = "__Internal";
#elif ANDROID
        private const string LibName = "veldrid-spirv";
#elif MACCATALYST
        private const string LibName = "libveldrid-spirv";
#else
        private const string LibName = "libveldrid-spirv";
#endif

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CompilationResult* CrossCompile(CrossCompileInfo* info);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CompilationResult* CompileGlslToSpirv(GlslCompileInfo* info);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeResult(CompilationResult* result);
    }
}
