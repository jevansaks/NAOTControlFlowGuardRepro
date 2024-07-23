To repro:

1. `dotnet publish .\NAOTControlFlowGuardRepro.sln -r win-x64 -c Release`
2. `dumpbin /symbols .\obj\Release\net8.0-windows10.0.22621.0\win-x64\native\NAOTControlFlowGuardRepro.obj /rawdata:4 > repro.syms.txt`
3. `dumpbin /symbols .\obj\Release\net8.0-windows10.0.22621.0\win-x64\native\NAOTControlFlowGuardRepro.obj > repro.syms.txt`
4. `findstr /sip DllCanUnloadNow repro.syms.txt`

Observe:
```
repro.syms.txt:114B 00000000 SECT5C8 notype       External    | _unwind0NAOTControlFlowGuardRepro_WinRT_Module__DllCanUnloadNow
repro.syms.txt:13498 00002898 SECT527 notype       External    | NAOTControlFlowGuardRepro_WinRT_Module__DllCanUnloadNow
repro.syms.txt:13499 00002898 SECT527 notype       External    | DllCanUnloadNow
```

Now look for 13498 and 13499 in repro.gfids, see that it's absent.

As comparison, DllGetActivationFactory (the other export) is present.
5. `findstr /sip DllGetActivationFactory repro.syms.txt`

```
repro.syms.txt:6CA 00000000 SECT247 notype       External    | __ehinfo_NAOTControlFlowGuardRepro_WinRT_Module__DllGetActivationFactory
repro.syms.txt:1145 00000000 SECT5C6 notype       External    | _unwind0NAOTControlFlowGuardRepro_WinRT_Module__DllGetActivationFactory
repro.syms.txt:1148 00000000 SECT5C7 notype       External    | _unwind1NAOTControlFlowGuardRepro_WinRT_Module__DllGetActivationFactory
repro.syms.txt:13491 000027DC SECT527 notype       External    | NAOTControlFlowGuardRepro_WinRT_Module__DllGetActivationFactory
repro.syms.txt:13492 000027DC SECT527 notype       External    | DllGetActivationFactory
```

See that 13491 is in the repro.gfids file.
