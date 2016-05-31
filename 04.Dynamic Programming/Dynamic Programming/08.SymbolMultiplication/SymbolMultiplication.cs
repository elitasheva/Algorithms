namespace _08.SymbolMultiplication
{
    using System.Linq.Expressions;

    public class SymbolMultiplication
    {
        private static char[] alphabet;
        private static char[][] multiplicationTable;

        public static void Main(string[] args)
        {
            alphabet = new[] {'a', 'b', 'c'};

            multiplicationTable = new[]
            {
                new char[] {'b', 'b', 'a'},
                new char[] {'c', 'b', 'a'},
                new char[] {'a', 'a', 'c'}
            };

            string str = "abc";

            bool a = isSymbolPossible(str, 'a', str.Length);
            int b = 5;

        }

        private static bool isSymbolPossible(string str, char symbol, int n)
        {
            if (n == 1)
            {
                return str == symbol.ToString();
            }

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    for (int k = 0; k < alphabet.Length; k++)
                    {
                        if (multiplicationTable[j][k] == symbol)
                        {
                            if (isSymbolPossible(str,symbol,i+1))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
