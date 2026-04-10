public class Restaurant
{
    public string Name { get; set; }
    public string Cuisine { get; set; } // Кухня: італійська, українська тощо
    public List<double> Ratings { get; set; } = new List<double>();

    public Restaurant(string name, string cuisine)
    {
        Name = name;
        Cuisine = cuisine;
    }

    public void AddRating(double rating)
    {
        if (rating >= 1 && rating <= 5)
        {
            Ratings.Add(rating);
        }
        else
        {
            Console.WriteLine("Рейтинг повинен бути від 1 до 5.");
        }
    }

    public double GetAverageRating()
    {
        if (Ratings.Count == 0) return 0;
        return Ratings.Average();
    }

    public override string ToString()
    {
        double avgRating = GetAverageRating();
        return $"[{avgRating:F1}/5] {Name} ({Cuisine} кухня)";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant("Піца Плюс", "італійська"),
            new Restaurant("Борщ та Вареники", "українська"),
            new Restaurant("Суші Містер", "японська")
        };

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Переглянути всі ресторани");
            Console.WriteLine("2. Додати рейтинг ресторану");
            Console.WriteLine("3. Вийти");
            Console.Write("Виберіть опцію: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayRestaurants(restaurants);
                    break;
                case "2":
                    AddRatingToRestaurant(restaurants);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void DisplayRestaurants(List<Restaurant> restaurants)
    {
        Console.WriteLine("\nСписок ресторанів:");
        foreach (var restaurant in restaurants)
        {
            Console.WriteLine(restaurant);
        }
    }

    static void AddRatingToRestaurant(List<Restaurant> restaurants)
    {
        Console.WriteLine("\nВиберіть ресторан для додавання рейтингу:");
        for (int i = 0; i < restaurants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {restaurants[i].Name}");
        }
        Console.Write("Введіть номер ресторану: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= restaurants.Count)
        {
            Console.Write("Введіть рейтинг (1-5): ");
            if (double.TryParse(Console.ReadLine(), out double rating))
            {
                restaurants[index - 1].AddRating(rating);
                Console.WriteLine("Рейтинг додано!");
            }
            else
            {
                Console.WriteLine("Невірний рейтинг.");
            }
        }
        else
        {
            Console.WriteLine("Невірний номер ресторану.");
        }
    }
}
