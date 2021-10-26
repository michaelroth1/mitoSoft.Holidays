# mitoSoft.Holidays
A .net graph library to determine german holidays

## Example usage

```c#

   var date = new DateTime(2019, 12, 25);
   
   Assert.AreEqual(true, date.IsHoliday(States.RheinlandPfalz));
   Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
   Assert.AreEqual("1. Weihnachtstag", date.GetHoliday().Name);

   Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
   Assert.AreEqual("first christmas day", date.GetHoliday().Name);
  ...  
  
```

For more examples see the testclasses in [testproject](mitoSoft.Holidays.Tests).