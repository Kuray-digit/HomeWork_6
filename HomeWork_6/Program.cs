using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    public abstract class Dish
    {
        public string Name { get; set; } 
        public double Price { get; set; }
        public double Calories { get; protected set; }
        public double Weight { get; set; }
        public Dish(string name, double price, double calories, double weight)
        {
            Name = name;
            Price = price;
            Calories = calories;
            Weight = weight;
        }
        public virtual double CalculatePortionCost()
        {
            return Price;
        }
        public string AddToOrder()
        {
            return $"Блюдо '{Name}' добавлено в заказ.";
        }
        public abstract string GetDietaryMark();
        public virtual string CalculateMacros()
        {
            double proteins = (Calories * 0.2) / 4;
            double fats = (Calories * 0.3) / 9;
            double carbs = (Calories * 0.5) / 4;
            return $"КБЖУ: Белки - {proteins}г, Жиры - {fats}г, Углеводы - {carbs}г";
        }

        public virtual string GenerateReceiptLine()
        {
            return $"{Name,-20} | {Weight} г. | {Price} руб. | {Calories} ккал";
        }
    }

    public class Soup : Dish
    {
        public string BrothType { get; set; } // Свойство: тип бульона

        public Soup(string name, double price, double calories, double weight, string brothType)
            : base(name, price, calories, weight)
        {
            BrothType = brothType;
        }

        public Soup(string name, double price, double calories)
            : this(name, price, calories, 300, "Куриный")
        {
        }

        public override string GetDietaryMark()
        {
            if (Calories < 100) return "🟢 Диетическое (Легкое)";
            return "🟡 Средняя калорийность";
        }
        public override string GenerateReceiptLine()
        {
            return base.GenerateReceiptLine() + $" (Бульон: {BrothType})";
        }
    }
    public class Salad : Dish
    {
        public bool IsVegetarian { get; set; }
        public Salad(string name, double price, double calories, double weight, bool isVegetarian)
            : base(name, price, calories, weight)
        {
            IsVegetarian = isVegetarian;
        }

        public Salad(string name, double price, double calories)
            : this(name, price, calories, 200, true)
        {
        }
        public override string GetDietaryMark()
        {
            if (IsVegetarian) return "Вегетарианское";
            return "С мясом";
        }
    }
    public class Dessert : Dish
    {
        public bool HasSugar { get; set; } 
        public Dessert(string name, double price, double calories, double weight, bool hasSugar)
            : base(name, price, calories, weight)
        {
            HasSugar = hasSugar;
        }
        public Dessert(string name, double price, double calories)
            : this(name, price, calories, 150, true)
        {
        }
        public override string GetDietaryMark()
        {
            if (!HasSugar) return "Без сахара";
            return "Сладкое (Высокая калорийность)";
        }
    }
    public class Order
    {
        private List<Dish> _dishes = new List<Dish>();

        public void AddDish(Dish dish)
        {
            _dishes.Add(dish);
            Console.WriteLine(dish.AddToOrder());
        }

        public void PrintFullReceipt()
        {
            Console.WriteLine($"{"Название",-20} | {"Вес",-5} | {"Цена",-8} | {"Ккал",-5}");
            Console.WriteLine(new string('-', 50));

            double total = 0;
            foreach (var dish in _dishes)
            {
                Console.WriteLine(dish.GenerateReceiptLine());
                Console.WriteLine($"   >> {dish.GetDietaryMark()}");
                Console.WriteLine($"   >> {dish.CalculateMacros()}");
                total += dish.CalculatePortionCost();
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"ИТОГО К ОПЛАТЕ: {total} руб.");
        }
    }

    class HomeworkSix
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Добро пожаловать в кафе 'ООП'!");
            Console.WriteLine("Давайте сформируем ваш заказ.\n");

            Soup borscht = new Soup("Борщ", 350, 120);
            Salad caesar = new Salad("Цезарь", 450, 250, 220, false);
            Dessert cheesecake = new Dessert("Чизкейк", 300, 400, 120, true);
            Order myOrder = new Order();
            myOrder.AddDish(borscht);
            myOrder.AddDish(caesar);
            myOrder.AddDish(cheesecake);
            myOrder.PrintFullReceipt();
            Console.WriteLine($"Название супа: {borscht.Name}");
            borscht.Price = 380;
            Console.WriteLine($"Новая цена борща: {borscht.Price}");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}