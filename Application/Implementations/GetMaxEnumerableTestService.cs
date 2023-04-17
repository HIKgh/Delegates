using Application.Dto;
using Application.Extensions;
using Application.Interfaces;

namespace Application.Implementations;

public class GetMaxEnumerableTestService : IGetMaxEnumerableTestService
{
    public void Test()
    {
        var personArray = new PersonDto[]
        {
            new() { Name = "Иванов", Salary = 99 },
            new() { Name = "Петров", Salary = 90 },
            new() { Name = "Сидоров", Salary = 95 },
            new() { Name = "Бендер", Salary = 125 }
        };

        Console.Clear();
        Console.WriteLine("Тест поиска максимальной зарплаты сотрудника");
        try
        {
            foreach (var person in personArray)
            {
                Console.WriteLine($"Имя:{person.Name}, Зарплата:{person.Salary}");
            }
            var personWithMaxSalary = personArray.GetMax(GetSalary);
            Console.WriteLine($"Максимальная зарплата у Имя:{personWithMaxSalary.Name}, Зарплата:{personWithMaxSalary.Salary}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Произошла ошибка при расчете максимальной зарплаты: {exception.Message}");
        }
        Console.WriteLine("Нажмите любую клавишу ...");
        Console.ReadKey();
    }

    private static float GetSalary(PersonDto person)
    {
        return person.Salary;
    }
}