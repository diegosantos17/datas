using System;
using System.Collections.Generic;
using System.Linq;

namespace Datas
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = new DateTime(2019, 1, 1);
            var endDate = new DateTime(2019, 1, 31); ;
            var period = "semanal"; //"quinzenal, mensal, semestral";

            var breakDates = 7;

            switch (period)
            {
                case "quinzenal":
                    breakDates = 15;
                    break;
                case "mensal":
                    breakDates = 30;
                    break;
                case "semestral":
                    breakDates = 180;
                    break;
                default:
                    breakDates = 7;
                    break;
            }


            var weekDays = new bool[7];
            weekDays[0] = false; // Sunday
            weekDays[1] = false; // Monday
            weekDays[2] = true; // Tuesday
            weekDays[3] = false; // Wednesday
            weekDays[4] = true; // Thursday
            weekDays[5] = false; // Friday
            weekDays[6] = false; // Saturday

            List<DateTime> listDates = new List<DateTime>();
            DateTime date = startDate;            
            DateTime startRecurrancy = startDate;
            List<int> daysSelected = new List<int>();
            var countMaths = 0;

            // Obtendo os dias selecionados
            for (int day = 0; day < 7; day++)
            {
                if (weekDays[day]) {
                    daysSelected.Add(day);
                }
            }


            // Obtendo o primeiro dia válido para inicio dos agendamentos
            for (int day = 0; day < 7; day++)
            {
                if (weekDays[day])
                {
                    if ((int)startDate.DayOfWeek == day)
                    {
                        date = startDate;
                        startRecurrancy = startDate;
                    }
                }
            }

            // Selecionando os dias dias respeitando a recorrência informada
            while (date <= endDate)
            {
                while (countMaths < daysSelected.Count())
                {
                    if (daysSelected.Any(w => w.Equals((int)date.DayOfWeek)))
                    {
                        listDates.Add(date);
                        countMaths++;
                    }

                    date = date.AddDays(1);
                }

                startRecurrancy = startRecurrancy.AddDays(breakDates);
                countMaths = 0;
            }


            foreach (var day in listDates)
            {
                Console.WriteLine(day);
            }

            Console.ReadKey();           
        }
    }
}
