public class Restaurant
{
    public string Name { get; set; }
    public string Cuisine { get; set; } // Кухня: італійська, українська тощо
    public double Rating { get; set; }

    public Restaurant(string name, string cuisine, double rating)
    {
        Name = name;
        Cuisine = cuisine;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"[{Rating}/5] {Name} ({Cuisine} кухня)";
    }
}
