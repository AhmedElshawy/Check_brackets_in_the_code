using System.Collections.Generic;
using System;

namespace Check_brackets_in_the_code
{
    public struct CharWithPosition
    {
        public char c;
        public int postion;
    }
    public static class StackExtension
    {
        public static bool Empty<T>(this Stack<T> stack)
        {
            if (stack.Count == 0) return true;

            return false;
        }
    }

    public class Program
    {
        static string CheckBracketsInCode(string code)
        {
            var stack = new Stack<CharWithPosition>();
            var oppeningsChars = new List<char>() { '(', '[', '{' };
            var closingChars = new List<char>() { ')', ']', '}' };
            int errorIndex = 1;

            for (int i = 0; i < code.Length; i++)
            {
                if (!oppeningsChars.Contains(code[i]) && !closingChars.Contains(code[i]))
                    continue;

                if (oppeningsChars.Contains(code[i]))
                {
                    var charWithPos = new CharWithPosition() { c = code[i], postion = i };
                    stack.Push(charWithPos);
                }
                    
                else
                {
                    // dose not have an oppening barcket
                    if (stack.Empty()) return (errorIndex += i).ToString();

                    var top = stack.Pop().c;
                    if ((top == '(' && code[i] != ')') ||
                        (top == '{' && code[i] != '}') ||
                        (top == '[' && code[i] != ']')
                        )
                    {
                        // closing bracket closes wrong oppening barcket
                        return (errorIndex += i).ToString();
                    }
                }
            }

            if (!stack.Empty())
                return (stack.Pop().postion + 1).ToString();

            return "Success";
        }
        static void Main(string[] args)
        {
            string inputCode = Console.ReadLine();

            var result = CheckBracketsInCode(inputCode);

            Console.WriteLine(result);
        }
    }
}