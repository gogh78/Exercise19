using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex19
{
    class Computer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string TypeCPU { get; set; }
        public int FrequencyCPU { get; set; }
        public int SizeRAM { get; set; }
        public int SizeHDD { get; set; }
        public int SizeVideo { get; set; }
        public int Cost { get; set; }
        public int Availability { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> сomputers = new List<Computer>()
            {
                new Computer(){Code=1001, Name="HP    ", TypeCPU = "Intel Core i5", FrequencyCPU = 2900, SizeRAM = 8, SizeHDD = 240,  SizeVideo = 512, Cost = 35000, Availability = 12},
                new Computer(){Code=2001, Name="Lenovo", TypeCPU = "Intel Core i5", FrequencyCPU = 2600, SizeRAM = 16, SizeHDD = 256,  SizeVideo = 512, Cost = 50000, Availability = 9},
                new Computer(){Code=1002, Name="HP    ", TypeCPU = "Intel Core i7", FrequencyCPU = 2500, SizeRAM = 32, SizeHDD = 500,  SizeVideo = 2048, Cost = 170000, Availability = 3},
                new Computer(){Code=3001, Name="Asus  ", TypeCPU = "AMD Ryzen 7  ", FrequencyCPU = 3800, SizeRAM = 16, SizeHDD = 1000, SizeVideo = 2048, Cost = 180000, Availability = 2},
                new Computer(){Code=4001, Name="Acer  ", TypeCPU = "Intel Core i5", FrequencyCPU = 3900, SizeRAM = 16, SizeHDD = 2000, SizeVideo = 1024, Cost = 200000, Availability = 2},
                new Computer(){Code=1003, Name="HP    ", TypeCPU = "Intel Celeron", FrequencyCPU = 2000, SizeRAM = 4, SizeHDD = 120,  SizeVideo = 128, Cost = 15000, Availability = 20},
                new Computer(){Code=5001, Name="Dell  ", TypeCPU = "Intel Core i5", FrequencyCPU = 3200, SizeRAM = 8, SizeHDD = 256,  SizeVideo = 512, Cost = 75000, Availability = 7},
                new Computer(){Code=1004, Name="HP    ", TypeCPU = "AMD Ryzen 5  ", FrequencyCPU = 2900, SizeRAM = 16, SizeHDD = 500,  SizeVideo = 512, Cost = 50000, Availability = 5},
                new Computer(){Code=3002, Name="Asus  ", TypeCPU = "Intel Core i5", FrequencyCPU = 2900, SizeRAM = 16, SizeHDD = 500,  SizeVideo = 1024, Cost = 100000, Availability = 4},
                new Computer(){Code=4002, Name="Acer  ", TypeCPU = "Intel Celeron", FrequencyCPU = 3000, SizeRAM = 4, SizeHDD = 128,  SizeVideo = 256, Cost = 25000, Availability = 15},
                new Computer(){Code=5002, Name="Dell  ", TypeCPU = "Intel Core i7", FrequencyCPU = 3600, SizeRAM = 32, SizeHDD = 2000, SizeVideo = 1024, Cost = 250000, Availability = 1},
            };
            Console.WriteLine("Укажите процессор: Intel Celeron, Intel Core i5, Intel Core i7, AMD Ryzen 5, AMD Ryzen 7");
            string type = Console.ReadLine();
            List<Computer> computers1 = сomputers.Where(x => x.TypeCPU == type).ToList();
            Console.WriteLine("Список компьютеров с процессором {0}", type);
            Print(computers1);

            Console.WriteLine("Укажите требуемое значение ОЗУ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = сomputers.Where(x => x.SizeRAM >= ram).ToList();
            Console.WriteLine("Список компьютеров с ОЗУ не менее {0}", ram);
            Print(computers2);

            List<Computer> computers3 = сomputers.OrderBy(x => x.Cost).ToList();
            Console.WriteLine("Список компьютеров по увеличению стоимости");
            Print(computers3);

            IEnumerable<IGrouping<string, Computer>> сomputers4 = сomputers.GroupBy(x => x.TypeCPU);
            Console.WriteLine("Список компьютеров сгруппированных по типу процессора");
            foreach (IGrouping<string, Computer> gr in сomputers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"Код:{c.Code} Наименование:{c.Name} {c.TypeCPU} {c.FrequencyCPU}МГц  RAM:{c.SizeRAM,2}ГБ  HDD:{c.SizeHDD,4}ГБ  Video:{c.SizeVideo,4}МБ  Цена:{c.Cost,6}Руб. Количество:{c.Availability}шт.");
                }
            }
            Console.WriteLine();

            Computer сomputerMax = сomputers.OrderByDescending(x => x.Cost).FirstOrDefault();
            Console.WriteLine("Самый дорогой компьютер");
            Console.WriteLine($"Код:{сomputerMax.Code} Наименование:{сomputerMax.Name} {сomputerMax.TypeCPU} {сomputerMax.FrequencyCPU}МГц  RAM:{сomputerMax.SizeRAM,2}ГБ  HDD:{сomputerMax.SizeHDD,4}ГБ  Video:{сomputerMax.SizeVideo,4}МБ  Цена:{сomputerMax.Cost,6}Руб. Количество:{сomputerMax.Availability}шт.");
            Console.WriteLine();
            Computer сomputerMin = сomputers.OrderByDescending(x => x.Cost).LastOrDefault();
            Console.WriteLine("Самый дешевый компьютер");
            Console.WriteLine($"Код:{сomputerMin.Code} Наименование:{сomputerMin.Name} {сomputerMin.TypeCPU} {сomputerMin.FrequencyCPU}МГц  RAM:{сomputerMin.SizeRAM,2}ГБ  HDD:{сomputerMin.SizeHDD,4}ГБ  Video:{сomputerMin.SizeVideo,4}МБ  Цена:{сomputerMin.Cost,6}Руб. Количество:{сomputerMin.Availability}шт.");
            Console.WriteLine();

            Console.WriteLine("Введите требуемое количество компьютеров одной позиции");
            int availability = Convert.ToInt32(Console.ReadLine());

            if (сomputers.Any(x => x.Availability >= availability))
            {
                Console.WriteLine("Достаточное количество");
            }
            else
            {
                Console.WriteLine("Недостаточное количество");
            }

            Console.ReadKey();
        }
        static void Print(List<Computer> computers)
        {
            foreach (Computer c in computers)
            {
                Console.WriteLine($"Код:{c.Code} Наименование:{c.Name} {c.TypeCPU} {c.FrequencyCPU}МГц RAM:{c.SizeRAM,2}ГБ  HDD:{c.SizeHDD,4}ГБ   Video:{c.SizeVideo,4}МБ   Цена:{c.Cost,6}Руб.   Количество:{c.Availability}шт.");
            }
            Console.WriteLine();
        }
    }
}
