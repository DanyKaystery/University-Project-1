//Марьин Даниил Олегович БПИ2410-2 4 Вариант
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
namespace additional_task
{
    internal class Program
    {
        /// <summary>
        /// Считываем из файла все строки для массивов в массив basearr, из которого будем брать строки для массивов в заивисимости от иттерации
        /// </summary>
        /// <param name="basearr"></param>Инициализируем массив basearr как массив всех строк из файла, ранее в программе массив basearr не инициализирован
        public static void Vvod(out string[] basearr)
        {
            basearr = [];
            try
            {
                string namepath = $"../../../../input.txt";//указываем путь к файлу
                basearr = File.ReadAllLines(namepath);//считываем файл в виде массива из строк
            }
            catch (FileNotFoundException)//Файл, заданный параметром path, не найден.
            {
                Console.WriteLine("Входной файл input.txt на диске отсутствует");
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла input.txt");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу input.txt имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу input.txt");
            }
        }


        /// <summary>
        /// Инициализируем массивы sarr1 и sarr2 как строчные массив состоящие из элементов строки itteration в массиве basearr
        /// </summary>
        /// <param name="basearr"></param>Массив всех строк файла
        /// <param name="itteration"></param>Номер иттерации на которой мы находимся
        /// <param name="sarr1"></param>Методу передается неиницилизированные до этого в программе строчные массивы sarr1 и sarr2
        /// <param name="sarr2"></param>которые будут инициализированы в методе, то есть заполненные строчными элементами из файла
        public static void ArrCreate(string[] basearr, int itteration, out string[] sarr1, out string[] sarr2)
        {
            sarr1 = basearr[itteration * 2].Split(' ');
            sarr2 = basearr[(itteration * 2) + 1].Split(' ');
        }


        /// <summary>
        /// По данным из строчного массива, полученного из файла, создаем массив корректных целочисленных данных
        /// </summary>
        /// <param name="sarr"></param> Передается массив строчных элементой из файла
        /// <param name="arr"></param> и по нему инициализируется массив целочисленных элементов, неиницилизированный до этого в самой программе
        public static void CorrectData(string[] sarr, out int[] arr)
        {
            int arri = 0; //Подсчитываем количество корректных данных arr1
            arr = new int[sarr.Length];//Задаем длину массива корректных arr1 sarr1.Length, т.к. корректных данных не больше, чем некорректных 
            for (int i = 0; i < sarr.Length; i++)//Последовательно заполняем массив корректных данных
            {
                try //Обрабатываем данные на корректность
                {
                    arr[arri] = int.Parse(sarr[i]); //Переводим из строчного типа в целочисленный
                    arri++;
                }
                catch (FormatException)//Некоректный тип данных, по условию задачи ничего не выводим
                {

                }
                catch (OverflowException)//Переполнения типа данных, по условию задачи ничего не выводим
                {

                }
            }
            Array.Resize(ref arr, arri);//Изменяем длину массива корректных данных на количество корректных данных
        }


        /// <summary>
        /// По корректным данным вычисляем сумму по формуле из варианта
        /// </summary>
        /// <param name="arr1"></param>Передаем методу массивы коррекнтых целочисленных чисел
        /// <param name="arr2"></param>
        /// <returns></returns>Возвращаем вещественную сумму, посчитанную по формуле из варианта 
        public static double Task(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) //Возращаем 0 при неравных длинах первого и 2 массива
            {
                return 0;
            }
            else
            {
                double sum = 0;
                try
                {
                    for (int i = 0; i < arr1.Length; i++)// При равных длинах подсчитываем сумму
                    {
                        if (arr1[i] + arr2[i] == 0) //Проверяем является ли делитель 0, ведь при деление значения с плавающей запятой на ноль не приводит к возникновению исключения;
                                                    //это приводит к положительной бесконечности, отрицательной бесконечности или не числу (NaN)
                        {
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            sum += 2.0 / (arr1[i] + arr2[i]);// Для подсчета используем формулу из варианта
                        }
                    }
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Возникло деление на 0. Введите новые данные в файл");
                }
                return sum;
            }
        }


        /// <summary>
        /// Считываем значение из config.txt для файла output.txt.
        /// </summary>
        /// <returns></returns>Возвращаем целочисленное значения номера из файла config.txt
        public static int NumberConfig()
        {
            int num = 0;
            string namepath = $"../../../../config.txt";//Указываем путь к файлу
            try
            {
                num = int.Parse(File.ReadAllLines(namepath)[0]);//Cчитываем файл в виде массива из строк
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла config.txt");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу config.txt имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу config.txt");
            }
            catch (FormatException)//Некоректный тип данных
            {
                Console.WriteLine("Неверный формат данных в файле config.txt");
            }
            catch (OverflowException)//Переполнения типа данных
            {
                Console.WriteLine("Переполнение данных в файле config.txt");
            }
            return num;//Возвращаем целочисленное значения номера 
        }


        /// <summary>
        /// Увеличиваем значение в файлу config.txt на 1,
        /// </summary>
        public static void Configplusplus()
        {
            string namepath = $"../../../../config.txt";//Указываем путь к файлу
            int num = NumberConfig();//Считываем текущее значение из файла config.txt
            try
            {
                File.WriteAllText(namepath, $"{++num}");//Записываем полученную значение увеличеннное на 1 в файл
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла config.txt");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу config.txt имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу config.txt");
            }
        }


        /// <summary>
        /// Выводим полученные суммы в файл
        /// </summary>
        /// <param name="sum"></param>Передаем вычисленную ранее сумму по формуле из варианта
        public static void Vivod(double sum)
        {
            try
            {
                string namepath = $"../../../../output-{NumberConfig()}.txt"; //Указываем путь к файлу
                File.AppendAllText(namepath, $"{sum:f3}\n");//Дозаписываем новую сумму к предыдущим
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла output.txt");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу output.txt имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу output.txt");
            }
        }


        /// <summary>
        /// Метод проверяет существует ли файл config.txt. В случае если config.txt не найден то создает его с значением 0
        /// </summary>
        public static void CheckConfig()
        {
            try
            {
                string namepath = $"../../../../config.txt";
                if (!File.Exists(namepath))
                {
                    File.WriteAllText(namepath, $"0");//Cоздаем файл config.txt со значением 0
                    Console.WriteLine("Файл config.txt не найден. Он был сформирован автоматически с начальным значением 0");
                }
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла config.txt");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу config.txt имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу config.txt");
            }
        }
        /// <summary>
        /// По данным из входного файла, считаем сумму по формуле из варианта и выводим ее в выходной файл
        /// Ждем ответ от пользователя, хочет ли он закрыть программу и начать все с начала
        /// </summary>
        private static void Main()
        {
            ConsoleKeyInfo keyToExit; //Создаем переменную для хранения типа клавиши, считанной из консоли
            do
            {
                CheckConfig();
                Vvod(out string[] basearr);
                for (int i = 0; i < basearr.Length / 2; i++)
                {
                    ArrCreate(basearr, i, sarr1: out string[] sarr1, sarr2: out string[] sarr2);//По данным из файла формируем строчные массивы
                    CorrectData(sarr: sarr1, arr: out int[] arr1);//Из строчного первого массива создаем первый целочисленный массив заполненный корректными данными
                    CorrectData(sarr: sarr2, arr: out int[] arr2);//Из строчного второго массива создаем второй целочисленный массив заполненный корректными данными
                    if (arr1.Length != 0 || arr2.Length != 0)//Проверяем есть ли корректные данные
                    {
                        double sum = Task(arr1: arr1, arr2: arr2);//По целочисленным массивам высчитываем сумму, указанную в варианте
                        Vivod(sum: sum);//Выводим полученную сумму в файл
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные");
                    }
                }
                Configplusplus();//Записываем последнее значение для output.txt в config.txt
                Console.WriteLine("Cеанс завершен");
                Console.WriteLine("Для запуска нового сеанса нажмите enter");
                Console.WriteLine("Для выхода из программы любую другую клавишу....");
                keyToExit = Console.ReadKey();//Считываем ответ от пользователя
            } while (keyToExit.Key == ConsoleKey.Enter); //Если пользователь ввел enter то перезапускаем програму
            
        }
    }
}