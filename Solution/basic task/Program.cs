//Марьин Даниил Олегович БПИ2410-2 4 Вариант
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace basic_task
{
    internal class Program
    {
        /// <summary>
        /// Вводим данные для двух массива с файла, для последующей их обработки
        /// </summary>
        /// <param name="sarr1"></param>  Методу передается неиницилизированные до этого в программе строчные массивы sarr1 и sarr2
        /// <param name="sarr2"></param>  которые будут инициализированы в методе, то есть заполненные строчными элементами из файла
        public static void Vvod(out string[] sarr1, out string[] sarr2)
        {
            sarr1 = [];//создаем пустые строчные массивы
            sarr2 = [];
            try {
                string namepath = $"../../../../input.txt";//указываем путь к файлу
                string[] readText = File.ReadAllLines(namepath);//считываем файл в виде массива из 2 строк
                sarr1 = readText[0].Split(' ');//разбиваем первую строку на элементы
                sarr2 = readText[1].Split(' ');//разбиваем вторую строку на элементы
            }
            catch(FileNotFoundException)//Файл, заданный параметром path, не найден.
            {
                Console.WriteLine("Входной Файл input.txt на диске отсутствует");
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
                catch(FormatException)//Некоректный тип данных, по условию задачи ничего не выводим
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
                            sum += 2.0 / (arr1[i] + arr2[i]);// Для подсчета суммы используем формулу из варианта
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
        /// Выводим полученную сумму в файл
        /// </summary>
        /// <param name="sum"></param>//Передаем вычисленную ранее сумму по формуле из варианта
        public static void Vivod(double sum)
        {
            try
            {
                string namepath = $"../../../../output.txt"; //Указываем путь к файлу
                File.WriteAllText(namepath, $"{sum:f3}");//Записываем полученную сумму в файл
            }
            catch (IOException)//При открытии файла произошла ошибка ввода-вывода.
            {
                Console.WriteLine("Проблемы с открытием файла");
            }
            catch (ArgumentException) //path строка нулевой длины, содержит только пробелы или содержит один или несколько недопустимых символов.
            {
                Console.WriteLine("Путь к файлу имеет значение null.");
            }
            catch (NotSupportedException)//Параметр path задан в недопустимом формате.
            {
                Console.WriteLine("Неверный формат путя к файлу");
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
                Vvod(sarr1: out string[] sarr1, sarr2: out string[] sarr2);//По данным из файла формируем строчные массивы
                CorrectData(sarr: sarr1, arr: out int[] arr1);//Из строчного первого массива создаем первый целочисленный массив заполненный корректными данными
                CorrectData(sarr: sarr2, arr: out int[] arr2);//Из строчного второго массива создаем второй целочисленный массив заполненный корректными данным
                if (arr1.Length != 0 || arr2.Length != 0)//Проверяем есть ли корректные данные
                {
                    double sum = Task(arr1: arr1, arr2: arr2);//По целочисленным массивам высчитываем сумму, указанную в варианте
                    Vivod(sum: sum);//Выводим полученную сумму в файл
                }
                else
                {
                    Console.WriteLine("Корректных данных в файле нет");
                }
                Console.WriteLine("Cеанс завершен");
                Console.WriteLine("Для запуска нового сеанса нажмите enter");
                Console.WriteLine("Для выхода из программы любую другую клавишу....");
                keyToExit = Console.ReadKey();//Считываем ответ от пользователя
            } while (keyToExit.Key == ConsoleKey.Enter); //Если пользователь ввел enter то перезапускаем програму
        }
    }
}
