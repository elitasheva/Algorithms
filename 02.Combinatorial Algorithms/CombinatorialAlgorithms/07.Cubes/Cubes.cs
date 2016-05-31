namespace _07.Cubes
{
    using System;
    using System.Collections.Generic;

    public class Cubes
    {
        private static int count = 0;
        private static HashSet<string> usedPermutation = new HashSet<string>();

        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            GeneratePermutations(input, 0);
            Console.WriteLine(count);
        }

        private static void GeneratePermutations(string[] input, int index)
        {    
            if (index >= input.Length)
            {
                string current = string.Join("", input);
                if (!usedPermutation.Contains(current))
                {
                    usedPermutation.Add(current);
                    count++;
                    MarkAsUsed(input);
                }
                
            }
            else
            {
                HashSet<string> set = new HashSet<string>();

                for (int i = index; i < input.Length; i++)
                {
                    if (!set.Contains(input[i]))
                    {
                        Swap(ref input[index], ref input[i]);
                        GeneratePermutations(input, index + 1);
                        Swap(ref input[index], ref input[i]);
                        set.Add(input[i]);
                    }
                }
            }
        }

        private static void Swap(ref string current, ref string next)
        {
            string temp = current;
            current = next;
            next = temp;
        }

        private static void MarkAsUsed(string[] input)
        {
            //string[] current = new string[input.Length];
            //Array.Copy(input, current, input.Length);

            for (int x = 0; x < 4; x++)
            {
                input = RotateX(input);
                for (int y = 0; y < 4; y++)
                {
                    input = RotateY(input);
                    for (int z = 0; z < 4; z++)
                    {
                        input = RotateZ(input);
                        usedPermutation.Add(string.Join("", input));
                    }
                }
            }
        }

        private static string[] RotateZ(string[] current)
        {
            string[] temp = new string[12];

            temp[0] = current[11];      //8
            temp[1] = current[8];      //4
            temp[2] = current[10];      //0
            temp[3] = current[1];      //7

            temp[4] = current[2];       //9
            temp[5] = current[3];      //1
            temp[6] = current[0];      //3
            temp[7] = current[4];     //11

            temp[8] = current[5];     //10
            temp[9] = current[6];      //5
            temp[10] = current[7];      //2
            temp[11] = current[9];     //6

            return temp;
        }

        private static string[] RotateY(string[] current)
        {
            string[] temp = new string[12];

            temp[0] = current[9];       //4
            temp[1] = current[11];       //9
            temp[2] = current[0];       //5
            temp[3] = current[6];      //1

            temp[4] = current[3];       //8
            temp[5] = current[4];       //10
            temp[6] = current[5];       //2
            temp[7] = current[2];       //0

            temp[8] = current[10];       //7
            temp[9] = current[7];      //11
            temp[10] = current[1];      //6
            temp[11] = current[8];      //3

            return temp;
        }

        private static string[] RotateX(string[] current)
        {
            string[] temp = new string[12];

            temp[0] = current[3];      //3
            temp[1] = current[0];      //0
            temp[2] = current[1];      //1
            temp[3] = current[2];      //2

            temp[4] = current[10];      //7
            temp[5] = current[7];      //4
            temp[6] = current[4];      //5
            temp[7] = current[8];      //6

            temp[8] = current[9];     //11
            temp[9] = current[5];      //8
            temp[10] = current[11];     //9
            temp[11] = current[6];    //10

            return temp;
        }


    }
}
