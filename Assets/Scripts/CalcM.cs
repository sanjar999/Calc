using System;

public static class CalcM 
{
    public static string Calculate(char oper, string firstNum, string secondNum)
    {
        float.TryParse(firstNum, out float num1);
        float.TryParse(secondNum, out float num2);

        switch (oper)
        {
            case '/': firstNum = $"{num1 / num2}"; break;
            case '*': firstNum = $"{num1 * num2}"; break;
            case '+': firstNum = $"{num1 + num2}"; break;
            case '-': firstNum = $"{num1 - num2}"; break;
        }
        return firstNum;
    }
}