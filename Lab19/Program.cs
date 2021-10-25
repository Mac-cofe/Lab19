using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comps> listComps = new List<Comps>()
            {
                new Comps() { Id = 1, Name = "Asus",  Cpu = "Intel Core i5", Frequency = 2.5, OZU = 16,  PZU = 1000, MemoryVideo = 4, Price = 40000, Count = 12 },
                new Comps() { Id = 2, Name = "Irbis", Cpu = "AMD A6",        Frequency = 3.2, OZU = 6,   PZU = 2000, MemoryVideo = 8, Price = 50000, Count = 6 },
                new Comps() { Id = 3, Name = "Acer",  Cpu = "AMD Phenom II", Frequency = 2.5, OZU = 8,   PZU = 500,  MemoryVideo = 6, Price = 45000, Count = 15 },
                new Comps() { Id = 4, Name = "HP",    Cpu = "Intel Core i5", Frequency = 3.3, OZU = 16,  PZU = 2000, MemoryVideo = 4, Price = 60000, Count = 8 },
                new Comps() { Id = 5, Name = "Asus",  Cpu = "AMD Athlon",    Frequency = 2.8, OZU = 6,   PZU = 1500, MemoryVideo = 8, Price = 55000, Count = 10 },
                new Comps() { Id = 6, Name = "Acer",  Cpu = "Intel Core i5", Frequency = 3.2, OZU = 4,   PZU = 1000, MemoryVideo = 8, Price = 68000, Count = 14 },
                new Comps() { Id = 7, Name = "DNS",   Cpu = "Intel Core i7", Frequency = 2.5, OZU = 8,   PZU = 800,  MemoryVideo = 8, Price = 65000, Count = 32 },
                new Comps() { Id = 8, Name = "HP",    Cpu = "AMD A6",        Frequency = 3.2, OZU = 2,   PZU = 1200, MemoryVideo = 4, Price = 55000, Count = 4 },
                new Comps() { Id = 9, Name = "Irbis", Cpu = "AMD Phenom II", Frequency = 2.7, OZU = 6,   PZU = 1000, MemoryVideo = 6, Price = 48000, Count = 9 },
                new Comps() { Id = 10, Name = "Acer", Cpu = "AMD Athlon",    Frequency = 3.3, OZU = 16,  PZU = 2000, MemoryVideo = 8, Price = 52000, Count = 11 }
            };

            Console.WriteLine("Какой тип процессора вас интересует?");
            Console.WriteLine("1. Intel Core i5");
            Console.WriteLine("2. Intel Core i7");
            Console.WriteLine("3. AMD Phenom II");
            Console.WriteLine("4. AMD A6");
            Console.WriteLine("5. AMD Athlon");
            string cpuQuery = "";
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    { cpuQuery = "Intel Core i5"; break; }
                case 2:
                    { cpuQuery = "Intel Core i7"; break; }
                case 3:
                    { cpuQuery = "AMD Phenom II"; break; }
                case 4:
                    { cpuQuery = "AMD A6"; break; }
                case 5:
                    { cpuQuery = "AMD Athlon"; break; }
                default:
                    { Console.WriteLine("Некорректный выбор"); break; }
            }

            List<Comps> Procc = (from d in listComps                         // запрос по типу процессора
                                 where d.Cpu == cpuQuery
                                 select d).ToList();
            Console.WriteLine("---------- Результат запроса по типу процессора ----------------------------");

            foreach (Comps d in Procc)
            {
                Console.WriteLine($"{d.Id} {d.Name} {d.OZU} {d.PZU} {d.MemoryVideo}");         // вывод на экран результата запроса по типу процессора
            }


            Console.WriteLine();
            Console.WriteLine("Какой минимальный объем ОЗУ вас интересует?");
            int volumeOZU = Convert.ToInt32(Console.ReadLine());
            List<Comps> OzuVolume = (from d in listComps                             // запрос по объему ОЗУ
                                     where d.OZU >= volumeOZU
                                     select d).ToList();

            Console.WriteLine("-------- Результат запроса по объему ОЗУ ------------------------------");
            foreach (Comps d in OzuVolume)
            {
                Console.WriteLine($"ID:{d.Id} Марка:{d.Name} Тип ЦПУ:{d.Cpu} Объем ПЗУ:{d.PZU} Объем видеопамяти:{d.MemoryVideo} Стоимость:{d.Price}");         // вывод на экран результата запроса по объему ОЗУ
            }


            Console.WriteLine();
            Console.WriteLine("------ Сортировка по возрастанию стоимости --------------------------------");
            List<Comps> Sort = (from d in listComps                             // сортировка по возрастанию стоимости
                                orderby d.Price
                                select d).ToList();

            foreach (Comps d in Sort)
            {
                Console.WriteLine($"ID:{d.Id,3} Стоимость:{d.Price,7:n} Марка:{d.Name,7} Тип ЦПУ:{d.Cpu,14} Частота:{d.Frequency,5} Объем ПЗУ:{d.PZU,6} Объем видеопамяти:{d.MemoryVideo,3} ");                                            
            }

            Console.WriteLine();
            Console.WriteLine("-------- Группировка по типу процессора  ------------------------------");
            var Group = (from d in listComps                             // группировка по типу типу процессора
                         group d by d.Name into g
                         select new { Name = g.Key, Count = g.Count() })
                         .ToList();

            foreach (var group in Group)                                        // вывод результата по группировке
                Console.WriteLine($"{group.Name,3} : {group.Count,3}");

            Console.WriteLine();
            Console.WriteLine("-------- Самый дорогой компьютер  ------------------------------");

            double resultMax = listComps.Max(t => t.Price);
            foreach (Comps d in listComps)
            {
                if (d.Price == resultMax)
                    Console.WriteLine($"ID:{d.Id,3} Стоимость:{d.Price,7:n} Марка:{d.Name,7} Тип ЦПУ:{d.Cpu,14} Частота:{d.Frequency,5} Объем ПЗУ:{d.PZU,6} Объем видеопамяти:{d.MemoryVideo,3} ");                                           
            }

            Console.WriteLine();
            Console.WriteLine("-------- Самый дешевый компьютер  ------------------------------");

            double resultMin = listComps.Min(t => t.Price);
            foreach (Comps d in listComps)
            {
                if (d.Price == resultMin)
                    Console.WriteLine($"ID:{d.Id,3} Стоимость:{d.Price,7:n} Марка:{d.Name,7} Тип ЦПУ:{d.Cpu,14} Частота:{d.Frequency,5} Объем ПЗУ:{d.PZU,6} Объем видеопамяти:{d.MemoryVideo,3} ");                                            
            }

            Console.WriteLine();
            Console.WriteLine("-------- Есть ли компьютеры в количестве более 30?  ------------------------------");

            bool resultCount = listComps.Any(t => t.Count > 30);
           if (resultCount)
                    Console.WriteLine("Есть в наличии 30 экземпляров одного вида компьютеров");
           else
                 Console.WriteLine("Нет в наличии 30 экземпляров одного вида компьютеров");


            Console.ReadKey();

        }

        class Comps
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Cpu { get; set; }
            public double Frequency { get; set; }
            public int OZU { get; set; }
            public int PZU { get; set; }
            public int MemoryVideo { get; set; }
            public double Price { get; set; }
            public int Count { get; set; }


        }
    }
}
