using System;
using System.Collections.Generic;

namespace Datas
{
    class Program
    {
        static void Main(string[] args)
        {

            var startDate = new DateTime(2019, 1, 1);
            var endDate = new DateTime(2019, 1, 31); ;

            var weekDays = new bool[7];
            weekDays[0] = false; // Sunday
            weekDays[1] = false; // Monday
            weekDays[2] = true; // Tuesday
            weekDays[3] = false; // Wednesday
            weekDays[4] = true; // Thursday
            weekDays[5] = false; // Friday
            weekDays[6] = false; // Saturday

            List<DateTime> listDates = new List<DateTime>();
            var totalDays = endDate.Subtract(startDate).TotalDays;
            DateTime date = startDate;

            while (date <= endDate)
            {                               
                date = date.AddDays(1);

                for (int day = 0; day < 7; day++)
                {
                    if (weekDays[day])
                    {
                        if((int)date.DayOfWeek == day)
                        {
                            listDates.Add(date);
                        }
                    }
                }
            }


            foreach (var day in listDates)
            {
                Console.WriteLine(day);
            }

            Console.ReadKey();
            

            //






            // Desbrindo qual a próxima data

        }
    }
}
