using System;
using UnityEngine;

public class CalcMV : MonoBehaviour
{
    private string _firstNum = "";
    private string _secondNum = "";
    private char _oper;
    private bool _isFirstNum = true;
    private bool _isOperSet;
    private bool _isFirstNumReset;

    public static Action<string> OnInputUpdate;

    public void GetInput(char val)
    {
        if (_firstNum != "")
            switch (val)
            {
                case '/': SetOper(ref val); break;
                case '*': SetOper(ref val); break;
                case '+': SetOper(ref val); break;
                case '-': SetOper(ref val); break;
                case 'c': ResetVals(); break;
                case '=':
                            _isFirstNumReset = true;
                            string firstNum = CalcM.Calculate(_oper, _firstNum, _secondNum);
                            OnInputUpdate?.Invoke(firstNum);
                            ResetVals(firstNum);
                            return;
            }
        SetNums(val);

        OnInputUpdate?.Invoke(SetInputFieldVal());
    }

    private void SetNums(char num)
    {
        // check for negativity
        if (num == '-')
            if (_isFirstNum)
                _firstNum += "-";
            else
                _secondNum += "-";

        //check input for num or not
        bool isParsed = int.TryParse(num.ToString(), out int valInt);

        
        if (isParsed && _isFirstNum)//fill first num
        {
            //reset result with new inputted num
            if (_isFirstNumReset)
            {
                _firstNum = "";
                _isFirstNumReset = false;
            }

            _firstNum += num;
        }
        else if (isParsed && !_isFirstNum)//fill second num
            _secondNum += num;
    }

    private void SetOper(ref char oper)
    {
        //clear operator  and prevent it from being used twice
        if (!_isOperSet)
        {
            _oper = oper;
            oper = ' ';
        }

        _isOperSet = true;
        _isFirstNum = false;
    }

    private string SetInputFieldVal() => $"{_firstNum}{_oper}{_secondNum}";

    private void ResetVals(string str = "")
    {
        _isOperSet = false;
        _isFirstNum = true;
        _secondNum = "";
        _oper = ' ';
        _firstNum = str;
    }
}