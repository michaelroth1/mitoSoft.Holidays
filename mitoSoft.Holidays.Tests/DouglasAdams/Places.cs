using System;

namespace mitoSoft.Holidays.Tests.DouglasAdams;

[Flags]
internal enum Places : byte
{
    None = 0,

    Earth = 1 << 0,
}