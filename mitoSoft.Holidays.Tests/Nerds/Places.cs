using System;

namespace mitoSoft.Holidays.Tests.Nerds;

[Flags]
internal enum Places : byte
{
    None = 0,

    Earth = 1 << 0,

    Arrakis = 1 << 1,

    AGalaxyFarFarAway = 1 << 2,

    TheKnownUniverse = Earth
        | Arrakis
        | AGalaxyFarFarAway,
}