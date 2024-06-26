﻿namespace Models
{
    public class Car
    {
        public static readonly string INSERT = "INSERT INTO Car(name, color, year, insurance_id) VALUES (@name, @color, @year, @insurance_id)";
        public static readonly string UPDATE = "UPDATE Car SET name = @name, color = @color, year = @year WHERE id = @id";
        public static readonly string DELETE = "DELETE FROM Car WHERE id = @id";
        public static readonly string GETALL = "SELECT id, name, color, year FROM Car";
        public static readonly string GET = "SELECT id, name, color, year FROM Car WHERE id = @id";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Insurance Insurance { get; set; }

        public Car()
        {

        }

        public Car(string name, string color, int year, Insurance insurance)
        {
            Name = name;
            Color = color;
            Year = year;
            Insurance = insurance;
        }

        public override string ToString() => $"Id: {Id}, Nome: {Name}, Cor: {Color}, Ano: {Year}";
    }
}
