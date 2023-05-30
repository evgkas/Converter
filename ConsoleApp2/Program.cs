public class Converter
{
    public static void Main()
    {
        bool endApp = false;
        Converter conveter = new();
        while (!endApp)
        {
            string numberInput1 = "";
            string numberInput2 = "";
            Console.WriteLine("Enter number");
            numberInput1 = Console.ReadLine();
            int numberToConver = 0;

            while (!int.TryParse(numberInput1, out numberToConver))
            {
                Console.WriteLine("This is not valid input. Please enter an integer value: ");
                numberInput1 = Console.ReadLine();
            }

            Console.WriteLine("Enter basis of new system from 2 to 20");
            numberInput2 = Console.ReadLine();
            int newBasis = 0;

            while ((!int.TryParse(numberInput2, out newBasis)) || (Convert.ToInt32(numberInput2) < 2)
                || (Convert.ToInt32(numberInput2) > 20))
            {
                Console.WriteLine("This is not valid input. Please enter an integer value in range 2 to 20: ");
                numberInput2 = Console.ReadLine();
            }

            string invertedResult = "";    //result of number translation that need to revert
            string[] symbolList = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };    //for numbers above 9
            string result = "";

            if (numberToConver < 0)
            {
                //add "-" to correct work with negative values
                result += "-";
                numberToConver /= -1;
            }

            do
            {
                int remainder = numberToConver % newBasis;
                numberToConver /= newBasis;

                if (remainder > 9)
                {
                    remainder = remainder - 10;
                    invertedResult += symbolList[remainder];
                }
                else
                {
                    invertedResult += Convert.ToString(remainder);
                }
            } while (numberToConver >= newBasis);

            if (numberToConver != 0)
            {
                if (numberToConver > 9)
                {
                    numberToConver -= 10;
                    invertedResult += symbolList[numberToConver];
                }
                else
                {
                    invertedResult += Convert.ToString(numberToConver);    //last symbol
                }
            }

            for (int i = invertedResult.Length - 1; i >= 0; i--)
            {
                result += invertedResult[i];
            }

            Console.WriteLine("value in " + newBasis + " basis = " + result);
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            
            if (Console.ReadLine() == "n")
            {
                endApp = true;
            }

            Console.WriteLine("\n");
        }
    }
}

