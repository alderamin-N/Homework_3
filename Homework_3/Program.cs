namespace Homework_3
{

    enum Severity
    {
        Warning,
        Error
    }

    internal class Program
    {

        private static int intA;
        private static int intB;
        private static int intC;
        private static double _D;
        private static string _A;
        private static string _B;
        private static string _C;


        private static Dictionary<string, string> _data = new Dictionary<string, string>();



        static void Main(string[] args)
        {
            Console.WriteLine("Решение квадратного уравнения: a * x ^ 2 + b * x + c = 0");
            //запуск ввода
            while (InputValue() == false)
            {
                _data.Clear();
            }

            //решение квадратного уравнения
            MyDiscriminant(intA, intB, intC);

            if (_D > 0)
            {
                double x1 = ((-intB - Math.Sqrt(_D)) / (2 * intA));
                double x2 = ((-intB + Math.Sqrt(_D)) / (2 * intA));
                Console.WriteLine($"x1={x1}");
                Console.WriteLine($"x2={x2}");
            }
            else if (_D == 0)
            {
                double x = (-intB / (2 * intA));
                Console.WriteLine($"x={x}");
            }
        }

        static bool InputValue()
        {
            try
            {
                InputA();
                InputB();
                InputC();
                if (myParse() == false)
                {
                    throw new FormatException("Неверный формат параметра");
                }
                return true;
            }
            catch (FormatException exception)
            {
                FormatData(exception.Message, Severity.Error, _data);
                return false;
            }
        }
        static void InputA()
        {
            Console.WriteLine("Ведите значение a: ");
            _A = Console.ReadLine();
            _data.Add("A", _A);

        }
        static void InputB()
        {
            Console.WriteLine("Ведите значение b: ");
            _B = Console.ReadLine();
            _data.Add("B", _B);
        }

        static void InputC()
        {
            Console.WriteLine("Ведите значение c: ");
            _C = Console.ReadLine();
            _data.Add("C", _C);
        }

        static bool myParse()
        {
            bool result = true;
            if (int.TryParse(_A, out intA) == false)
            {

                result = false;
            }
            if (int.TryParse(_B, out intB) == false)
            {

                result = false;
            }
            if (int.TryParse(_C, out intC) == false)
            {

                result = false;
            }
            return result;
        }

        static double MyDiscriminant(int a, int b, int c)
        {
            try
            {
                _D = Math.Pow(b, 2) - 4 * a * c;
                if (_D < 0)
                {
                    throw new Exception("Вещественных значений не найдено");
                }
                return _D;
            }
            catch (Exception ex)
            {
                FormatData(ex.Message, Severity.Warning);
                return 0;
            }
        }

        static void FormatData(string message, Severity severity, Dictionary<string, string> data = null)
        {
            if (severity == Severity.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
            if (data != null)
            {
                foreach (var i in data)
                {
                    Console.WriteLine(i.Key + "=" + i.Value);
                }
            }
            Console.ResetColor();
        }






    }
}
