using System;

namespace mitoSoft.Holidays.UnitedStates
{
    /// <summary>
    /// Represents the states and federal district of the United States of America.
    /// This enum uses flags to allow combining multiple states.
    /// </summary>
    [Flags]
    public enum States : ulong
    {
        /// <summary>
        /// No state selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Alabama (AL)
        /// </summary>
        Alabama = 1UL << 0,

        /// <summary>
        /// Alaska (AK)
        /// </summary>
        Alaska = 1UL << 1,

        /// <summary>
        /// Arizona (AZ)
        /// </summary>
        Arizona = 1UL << 2,

        /// <summary>
        /// Arkansas (AR)
        /// </summary>
        Arkansas = 1UL << 3,

        /// <summary>
        /// California (CA)
        /// </summary>
        California = 1UL << 4,

        /// <summary>
        /// Colorado (CO)
        /// </summary>
        Colorado = 1UL << 5,

        /// <summary>
        /// Connecticut (CT)
        /// </summary>
        Connecticut = 1UL << 6,

        /// <summary>
        /// Delaware (DE)
        /// </summary>
        Delaware = 1UL << 7,

        /// <summary>
        /// Florida (FL)
        /// </summary>
        Florida = 1UL << 8,

        /// <summary>
        /// Georgia (GA)
        /// </summary>
        Georgia = 1UL << 9,

        /// <summary>
        /// Hawaii (HI)
        /// </summary>
        Hawaii = 1UL << 10,

        /// <summary>
        /// Idaho (ID)
        /// </summary>
        Idaho = 1UL << 11,

        /// <summary>
        /// Illinois (IL)
        /// </summary>
        Illinois = 1UL << 12,

        /// <summary>
        /// Indiana (IN)
        /// </summary>
        Indiana = 1UL << 13,

        /// <summary>
        /// Iowa (IA)
        /// </summary>
        Iowa = 1UL << 14,

        /// <summary>
        /// Kansas (KS)
        /// </summary>
        Kansas = 1UL << 15,

        /// <summary>
        /// Kentucky (KY)
        /// </summary>
        Kentucky = 1UL << 16,

        /// <summary>
        /// Louisiana (LA)
        /// </summary>
        Louisiana = 1UL << 17,

        /// <summary>
        /// Maine (ME)
        /// </summary>
        Maine = 1UL << 18,

        /// <summary>
        /// Maryland (MD)
        /// </summary>
        Maryland = 1UL << 19,

        /// <summary>
        /// Massachusetts (MA)
        /// </summary>
        Massachusetts = 1UL << 20,

        /// <summary>
        /// Michigan (MI)
        /// </summary>
        Michigan = 1UL << 21,

        /// <summary>
        /// Minnesota (MN)
        /// </summary>
        Minnesota = 1UL << 22,

        /// <summary>
        /// Mississippi (MS)
        /// </summary>
        Mississippi = 1UL << 23,

        /// <summary>
        /// Missouri (MO)
        /// </summary>
        Missouri = 1UL << 24,

        /// <summary>
        /// Montana (MT)
        /// </summary>
        Montana = 1UL << 25,

        /// <summary>
        /// Nebraska (NE)
        /// </summary>
        Nebraska = 1UL << 26,

        /// <summary>
        /// Nevada (NV)
        /// </summary>
        Nevada = 1UL << 27,

        /// <summary>
        /// New Hampshire (NH)
        /// </summary>
        NewHampshire = 1UL << 28,

        /// <summary>
        /// New Jersey (NJ)
        /// </summary>
        NewJersey = 1UL << 29,

        /// <summary>
        /// New Mexico (NM)
        /// </summary>
        NewMexico = 1UL << 30,

        /// <summary>
        /// New York (NY)
        /// </summary>
        NewYork = 1UL << 31,

        /// <summary>
        /// North Carolina (NC)
        /// </summary>
        NorthCarolina = 1UL << 32,

        /// <summary>
        /// North Dakota (ND)
        /// </summary>
        NorthDakota = 1UL << 33,

        /// <summary>
        /// Ohio (OH)
        /// </summary>
        Ohio = 1UL << 34,

        /// <summary>
        /// Oklahoma (OK)
        /// </summary>
        Oklahoma = 1UL << 35,

        /// <summary>
        /// Oregon (OR)
        /// </summary>
        Oregon = 1UL << 36,

        /// <summary>
        /// Pennsylvania (PA)
        /// </summary>
        Pennsylvania = 1UL << 37,

        /// <summary>
        /// Rhode Island (RI)
        /// </summary>
        RhodeIsland = 1UL << 38,

        /// <summary>
        /// South Carolina (SC)
        /// </summary>
        SouthCarolina = 1UL << 39,

        /// <summary>
        /// South Dakota (SD)
        /// </summary>
        SouthDakota = 1UL << 40,

        /// <summary>
        /// Tennessee (TN)
        /// </summary>
        Tennessee = 1UL << 41,

        /// <summary>
        /// Texas (TX)
        /// </summary>
        Texas = 1UL << 42,

        /// <summary>
        /// Utah (UT)
        /// </summary>
        Utah = 1UL << 43,

        /// <summary>
        /// Vermont (VT)
        /// </summary>
        Vermont = 1UL << 44,

        /// <summary>
        /// Virginia (VA)
        /// </summary>
        Virginia = 1UL << 45,

        /// <summary>
        /// Washington (WA)
        /// </summary>
        Washington = 1UL << 46,

        /// <summary>
        /// West Virginia (WV)
        /// </summary>
        WestVirginia = 1UL << 47,

        /// <summary>
        /// Wisconsin (WI)
        /// </summary>
        Wisconsin = 1UL << 48,

        /// <summary>
        /// Wyoming (WY)
        /// </summary>
        Wyoming = 1UL << 49,

        /// <summary>
        /// District of Columbia (DC)
        /// </summary>
        DistrictOfColumbia = 1UL << 50,

        /// <summary>
        /// All 50 states and the District of Columbia. Represents federal holidays observed nationwide.
        /// </summary>
        Federal = Alabama | Alaska | Arizona | Arkansas
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