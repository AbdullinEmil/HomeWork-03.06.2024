using System;
using System.Collections.Generic;

public class Builder : IComparable
{
    public int YearBuilt { get; set; }
    public int NumberOfOffices { get; set; }
    public double TotalArea { get; set; }

    public Builder(int yearBuilt, int numberOfOffices, double totalArea)
    {
        YearBuilt = yearBuilt;
        NumberOfOffices = numberOfOffices;
        TotalArea = totalArea;
    }


    public int CompareTo(object obj)
    {
        if (obj is Builder otherBuilder)
        {
            return YearBuilt.CompareTo(otherBuilder.YearBuilt);
        }
        else
        {
            throw new ArgumentException("Объект не является Builder.");
        }
    }

    public override string ToString()
    {
        return $"Здание: Год постройки: {YearBuilt}, Количество офисов: {NumberOfOffices}, Общая площадь: {TotalArea}";
    }
}

public class SortOfficeBuilderComparer : IComparer<Builder>
{

    public int Compare(Builder x, Builder y)
    {
        return x.NumberOfOffices.CompareTo(y.NumberOfOffices);
    }
}

public class SortAreaBuilderComparer : IComparer<Builder>
{

    public int Compare(Builder x, Builder y)
    {
        return x.TotalArea.CompareTo(y.TotalArea);
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        List<Builder> buildings = new List<Builder>()
        {
            new Builder(2004, 10, 2000),
            new Builder(2024, 5, 500),
            new Builder(2018, 20, 1000),
            new Builder(2021, 15, 1500)
        };

        Console.WriteLine("Исходный список зданий:");
        foreach (Builder building in buildings)
        {
            Console.WriteLine(building);
        }


        buildings.Sort();
        Console.WriteLine("Список зданий, отсортированный по году постройки:\n");
        foreach (Builder building in buildings)
        {
            Console.WriteLine(building);
        }

        buildings.Sort(new SortOfficeBuilderComparer());
        Console.WriteLine("Список зданий, отсортированный по количеству офисов:\n");
        foreach (Builder building in buildings)
        {
            Console.WriteLine(building);
        }

        buildings.Sort(new SortAreaBuilderComparer());
        Console.WriteLine("Список зданий, отсортированный по общей площади:\n");
        foreach (Builder building in buildings)
        {
            Console.WriteLine(building);
        }
    }
}