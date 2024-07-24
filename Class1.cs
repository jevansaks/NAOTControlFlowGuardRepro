using System.Runtime.CompilerServices;

namespace NAOTControlFlowGuardRepro
{
    public sealed class Class1
    {
    }

#if false // Enable this to see a workaround
    static class CFGWorkaround
    {
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
        [ModuleInitializer]
#pragma warning restore CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
        public unsafe static void Dummy()
        {
            var fnptr = (delegate* unmanaged[Stdcall]<int>)&WinRT.Module.DllCanUnloadNow;
            PinMe((void*)fnptr);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private unsafe static void PinMe(void* pin_it)
        {

        }

    }
#endif
}
