# mitoSoft.Holidays
A lightweight library to determine German / US holidays

Can be extended for other coutries.

## Example usage

```c#

var holidays = new Nerds.Holidays();

var date = new DateTime(2023, 5, 4);

Assert.IsFalse(date.IsHoliday(holidays, Places.Earth));
Assert.IsTrue(date.IsHoliday(holidays, Places.AGalaxyFarFarAway));

var holiday = date.GetHoliday(holidays);

Assert.AreEqual("May the 4th", holiday.GetDisplayName());
  
```

For more examples see the testclasses in [testproject](mitoSoft.Holidays.Tests).