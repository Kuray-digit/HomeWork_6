using System;

namespace Program
{
    class Building
    {
        private static int lastBuildingNumber = 0;

        private int buildingNumber;
        private double height; 
        private int floors;
        private int apartments;
        private int entrances;


        public int BuildingNumber => buildingNumber;

        public double Height
        {
            get => height;
            set
            {
                if (value > 0) height = value;
                else Console.WriteLine("Ошибка: высота должна быть больше нуля.");
            }
        }

        public int Floors
        {
            get => floors;
            set
            {
                if (value > 0) floors = value;
                else Console.WriteLine("Ошибка: этажность должна быть больше нуля.");
            }
        }

        public int Apartments
        {
            get => apartments;
            set
            {
                if (value >= 0) apartments = value;
                else Console.WriteLine("Ошибка: количество квартир не может быть отрицательным.");
            }
        }

        public int Entrances
        {
            get => entrances;
            set
            {
                if (value > 0) entrances = value;
                else Console.WriteLine("Ошибка: количество подъездов должно быть больше нуля.");
            }
        }

        private static int GenerateBuildingNumber()
        {
            lastBuildingNumber++;
            return lastBuildingNumber;
        }

        public Building(double height, int floors, int apartments, int entrances)
        {
            buildingNumber = GenerateBuildingNumber();
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        public double GetFloorHeight()
        {
            if (floors == 0) return 0;
            return height / floors;
        }

        public double GetApartmentsPerEntrance()
        {
            if (entrances == 0) return 0;
            return (double)apartments / entrances;
        }

        public double GetApartmentsPerFloor()
        {
            int totalFloorsAllEntrances = floors * entrances;
            if (totalFloorsAllEntrances == 0) return 0;
            return (double)apartments / totalFloorsAllEntrances;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Номер здания: {buildingNumber}");
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"Этажность: {floors}");
            Console.WriteLine($"Количество квартир: {apartments}");
            Console.WriteLine($"Количество подъездов: {entrances}");
            Console.WriteLine($"--- Вычисления ---");
            Console.WriteLine($"Высота одного этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир в одном подъезде (в среднем): {GetApartmentsPerEntrance():F2}");
            Console.WriteLine($"Квартир на одном этаже (в среднем): {GetApartmentsPerFloor():F2}");
            Console.WriteLine();
        }
    }

    class HomeworkSix
    {
        public static void Main()
        {
            Building building1 = new Building(30.0, 10, 100, 4);
            Building building2 = new Building(15.5, 5, 40, 2);
            building1.PrintInfo();
            building2.PrintInfo();
            building1.Height = -10;
            Console.WriteLine($"Текущая высота здания 1: {building1.Height} м");
            Console.ReadLine();
        }
    }
}