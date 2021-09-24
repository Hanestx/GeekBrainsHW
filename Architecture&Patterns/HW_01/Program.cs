using System;
using System.Numerics;

namespace ConsoleApplication1
{
  public class Program
      {
          
          public static void Main(string[] args)
          {
              string userInput;
              int userInputNumber;

              Console.WriteLine("Для завершения работы введите <q>");
              Console.WriteLine("\nЗдравствуйте вас приветствует математическая программа!");
              Console.Write("Пожалуйста введите целое число: ");

              while (!int.TryParse(userInput = Console.ReadLine(), out userInputNumber))
              {
                  if (userInput == "q")
                  {
                      Console.WriteLine("Работа программы завершена.");
                      return;
                  }
                  
                  Console.Write("Ошибка ввода! Введите целое число: ");
              }
              
              Factorial(userInputNumber);
              Sum(userInputNumber);
              MaxEvenNumber(userInputNumber);
              Console.ReadLine();
              

              void Factorial(int number)
              {
                  BigInteger factorial = new BigInteger(1);
                  
                  for (int i = 1; i <= number; i++)
                      factorial *= i;

                  Console.WriteLine("\nФакториал равен: " + factorial); 
              }

              void Sum(int number)
              {
                  int sum = 0;
                  
                  for (int i = 1; i <= number; i++)
                      sum += i;
                  
                  Console.WriteLine($"Сумма от 1 до {number} равна: " + sum);
              }
              
              void MaxEvenNumber(int number)
              {
                  int maxEvenNumber = 0;
                  
                  for (int i = 1; i < number; i++)
                  { 
                      if (i % 2 == 0)
                      {
                          maxEvenNumber = i;
                      }
                  }
                  
                  Console.WriteLine($"Максимальное четное число меньше чем {number} равно: " + maxEvenNumber);
              }
          }
  
      }
}