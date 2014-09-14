    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter something in polar notation, numbers first, then arithmetic operators:");
            string usersPolishNotation = Console.ReadLine();
            calculate(usersPolishNotation);
            //calculate("48 4 6 * /");
        }

        public static void calculate(string myString)
        {
            string[] myArray = myString.Split(' ');

            LinkedList<int> numberList = new LinkedList<int>();
            LinkedList<string> operatorsList = new LinkedList<string>();

            int numberListCounter = 0;
            int operatorsListCounter = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(myArray[i], out num);

                if (isNum)
                {
                    //Is a Number
                    numberList.AddLast(Convert.ToInt32(myArray[i]));
                    numberListCounter++;
                }
                else
                {
                    //Not a number
                    operatorsList.AddLast(myArray[i]);
                    operatorsListCounter++;
                }
            }

            int[] numberArray = numberList.ToArray();
            string[] operatorsArray = operatorsList.ToArray();

            string evaluationString = numberArray[0].ToString();
            int j = operatorsArray.Length-1;
            for (int i = 1; i < numberArray.Length; i++)
            {
                evaluationString += operatorsArray[j] + "(" + numberArray[i].ToString();
                j--;
            }

            for (int i = 0; i < operatorsArray.Length; i++)
            {
                evaluationString += ")";
            }

            DataTable dt = new DataTable();
            var v = dt.Compute(evaluationString, "");

            Console.WriteLine("Simplified Formula: " + evaluationString + "\n\nResult: " + v.ToString());
            Console.ReadLine();
        }
    }