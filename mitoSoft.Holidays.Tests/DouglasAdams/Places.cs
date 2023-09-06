using System;

namespace mitoSoft.Holidays.Tests.DouglasAdams;

[Flags]
internal enum Places : ulong
{
    None = 0,

    Earth = 1UL << 0,
}