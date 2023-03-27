public class Converter
{
    static void Main()
    {

        bool endApp = false;
        Converter conveter = new();
        while (!endApp)
        {
            string numInput1 = "";
            string numInput2 = "";
            Console.WriteLine("Enter number");
            numInput1 = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(numInput1, out number))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }

            Console.WriteLine("Enter basis of new system from 2 to 20");
            numInput2 = Console.ReadLine();
            int basis = 0;
            while (!int.TryParse(numInput2, out basis) || Convert.ToInt32(numInput2) < 2
                || Convert.ToInt32(numInput2) > 20)
            {
                Console.Write("This is not valid input. Please enter an integer value in range 2 to 20: ");
                numInput2 = Console.ReadLine();
            }

            string InvertedResult = "";    //result of number translation that need to revert
            string[] SymbolList = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            string result = "";

            if (number < 0)
            {
                //adding a "-" to correct work with negative values
                result += "-";
                number /= -1;
            }

            do
            {
                int remainder = number % basis;
                number = number / basis;
                if (remainder > 9)
                {
                    remainder = remainder - 10;
                    InvertedResult += SymbolList[remainder];
                }
                else
                {
                    InvertedResult += Convert.ToString(remainder);
                }
            }
            while (number >= basis);

            if (number != 0)
            {
                if (number > 9)
                {
                    number -= 10;
                    InvertedResult += SymbolList[number];
                }
                else InvertedResult += Convert.ToString(number);    //last symbol
            }

            for (int i = InvertedResult.Length - 1; i >= 0; i--)
            {
                result += InvertedResult[i];
            }

            Console.WriteLine("value in " + basis + " basis is " + result);
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;
            Console.WriteLine("\n");

        }
    }
}

