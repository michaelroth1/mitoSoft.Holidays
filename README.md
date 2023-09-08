# mitoSoft.Holidays
A lightweight library to determine German / US holidays

Can be extended for other coutries.

## Example usage

```c#

        var date = new DateTime(2023, 5, 4);

        Assert.AreEqual(false, date.IsHoliday(_holidays, Places.Earth));
        Assert.AreEqual(true, date.IsHoliday(_holidays, Places.AGalaxyFarFarAway));

        var holiday = date.GetHoliday(_holidays);

        Assert.AreEqual("May the 4th", holiday.GetDisplayName());
  
```

For more examples see the testclasses in [testproject](mitoSoft.Holidays.Tests).