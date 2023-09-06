using System;

namespace mitoSoft.Holidays.UnitedStates
{
    [Flags]
    public enum States : ulong
    {
        None = 0,

        Alabama = 1UL << 0,
        Alaska = 1UL << 1,
        Arizona = 1UL << 2,
        Arkansas = 1UL << 3,
        California = 1UL << 4,
        Colorado = 1UL << 5,
        Connecticut = 1UL << 6,
        Delaware = 1UL << 7,
        Florida = 1UL << 8,
        Georgia = 1UL << 9,
        Hawaii = 1UL << 10,
        Idaho = 1UL << 11,
        Illinois = 1UL << 12,
        Indiana = 1UL << 13,
        Iowa = 1UL << 14,
        Kansas = 1UL << 15,
        Kentucky = 1UL << 16,
        Louisiana = 1UL << 17,
        Maine = 1UL << 18,
        Maryland = 1UL << 19,
        Massachusetts = 1UL << 20,
        Michigan = 1UL << 21,
        Minnesota = 1UL << 22,
        Mississippi = 1UL << 23,
        Missouri = 1UL << 24,
        Montana = 1UL << 25,
        Nebraska = 1UL << 26,
        Nevada = 1UL << 27,
        NewHampshire = 1UL << 28,
        NewJersey = 1UL << 29,
        NewMexico = 1UL << 30,
        NewYork = 1UL << 31,
        NorthCarolina = 1UL << 32,
        NorthDakota = 1UL << 33,
        Ohio = 1UL << 34,
        Oklahoma = 1UL << 35,
        Oregon = 1UL << 36,
        Pennsylvania = 1UL << 37,
        RhodeIsland = 1UL << 38,
        SouthCarolina = 1UL << 39,
        SouthDakota = 1UL << 40,
        Tennessee = 1UL << 41,
        Texas = 1UL << 42,
        Utah = 1UL << 43,
        Vermont = 1UL << 44,
        Virginia = 1UL << 45,
        Washington = 1UL << 46,
        WestVirginia = 1UL << 47,
        Wisconsin = 1UL << 48,
        Wyoming = 1UL << 49,

        DistrictOfColumbia = 1UL << 50,

        National = Alabama | Alaska | Arizona | Arkansas
            | California | Colorado | Connecticut
            | Delaware
            | Florida
            | Georgia
            | Hawaii
            | Idaho | Illinois | Indiana | Iowa
            | Kansas | Kentucky
            | Louisiana
            | Maine | Maryland | Massachusetts | Michigan | Minnesota | Mississippi | Missouri | Montana
            | Nebraska | Nevada | NewHampshire | NewJersey | NewMexico | NewYork | NorthCarolina | NorthDakota
            | Ohio | Oklahoma | Oregon
            | Pennsylvania
            | RhodeIsland
            | SouthCarolina | SouthDakota
            | Tennessee | Texas
            | Utah
            | Vermont | Virginia
            | Washington | WestVirginia | Wisconsin | Wyoming
            | DistrictOfColumbia,
    }
}