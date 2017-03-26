using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Calc
{
    class Presenter
    {
        delegate double MathOp();
        MainWindow mainWindow;
        Model model;
        MathOp calculate;
        CalcException exception;
        string number;
        bool operationButtonIsBeanClickedBefore;
        string decimalSeparator;

        public Presenter(MainWindow mainwindow)
        {
            this.decimalSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
            this.mainWindow = mainwindow;
            this.model = new Model();
            this.exception = new CalcException();
            this.operationButtonIsBeanClickedBefore = false;
            mainWindow.one_clicked += mainWindow_one_clicked;
            mainWindow.two_clicked += mainWindow_two_clicked;
            mainWindow.three_clicked += mainWindow_three_clicked;
            mainWindow.four_clicked += mainWindow_four_clicked;
            mainWindow.five_clicked += mainWindow_five_clicked;
            mainWindow.six_clicked += mainWindow_six_clicked;
            mainWindow.seven_clicked += mainWindow_seven_clicked;
            mainWindow.eight_clicked += mainWindow_eight_clicked;
            mainWindow.nine_clicked += mainWindow_nine_clicked;
            mainWindow.zero_clicked += mainWindow_zero_clicked;
            mainWindow.plus_clicked += mainWindow_plus_clicked;
            mainWindow.minus_clicked += mainWindow_minus_clicked;
            mainWindow.mult_clicked += mainWindow_mult_clicked;
            mainWindow.div_clicked += mainWindow_div_clicked;
            mainWindow.eql_clicked += mainWindow_eql_clicked;
            mainWindow.reset_clicked += mainWindow_reset_clicked;
            mainwindow.decimalSeparator_clicked += mainwindow_decimalSeparator_clicked;
            mainwindow.sign_clicked += mainwindow_sign_clicked;
        }

        void mainwindow_sign_clicked(object sender, EventArgs e)
        {
            if (number == null)
            {
                number = "-";
                mainWindow.display.Text = "-";
            }
            else if (number.Contains("-"))
            {
                number = number.Remove(0, 1);
                mainWindow.display.Text = number;
            }
                else
                {
                    number = "-" + number;
                    mainWindow.display.Text = number;
                }
        }

        void mainwindow_decimalSeparator_clicked(object sender, EventArgs e)
        {
            if (number == null)
            {
                number = "0" + decimalSeparator;
                mainWindow.display.Text = number;
            }
            else if (number.Contains(decimalSeparator))
            {
                return;
            }
                else
                {
                    this.number += decimalSeparator;
                    mainWindow.display.Text = number;
                }
        }

        void mainWindow_reset_clicked(object sender, EventArgs e)
        {
            calculate = null;
            mainWindow.display.Text = "0";
            number = null;
            operationButtonIsBeanClickedBefore = false;
            mainWindow.NotCEButtons.IsEnabled = true;
            model.Argument1 = 0;
            model.Argument2 = 0;
        }

        void mainWindow_eql_clicked(object sender, EventArgs e)
        {
            if (operationButtonIsBeanClickedBefore)
            {
                if (number == null || number == "-")
                {
                    number = "0";
                }
                model.Argument2 = double.Parse(number);
            }
            if (calculate == null)
            {
                number = "0";
            }
                else
                {
                    PerformAndShowResult();
                }
            model.Argument1 = double.Parse(number);
            operationButtonIsBeanClickedBefore = false;
        }

        void PerformAndShowResult()
        {
            double result = calculate();
            try
            {
                if (double.IsInfinity(result) || double.IsNaN(result))
                {
                    exception.ExceptionComment = "zero divisor error";
                    throw exception;
                }
                else
                {
                    number = Convert.ToString(result);
                    mainWindow.display.Text = number;
                }
            }
            catch
            {
                model.Argument1 = 0;
                mainWindow.display.Text = exception.ExceptionComment;
                mainWindow.NotCEButtons.IsEnabled = false;
                number = "0";
            }
        }

        void mainWindow_div_clicked(object sender, EventArgs e)
        {
            PerformAndShowMathOperation("/");
        }

        void mainWindow_mult_clicked(object sender, EventArgs e)
        {
            PerformAndShowMathOperation("*");
        }

        void mainWindow_minus_clicked(object sender, EventArgs e)
        {
            PerformAndShowMathOperation("-");
        }

        void mainWindow_plus_clicked(object sender, EventArgs e)
        {
            PerformAndShowMathOperation("+");
        }

        void PerformAndShowMathOperation(string opType)
        {
            if (operationButtonIsBeanClickedBefore)
            {
                PerformSecondExpressionMember(opType);
            }
            calculate = ChooseMathOperation(opType);
            model.Argument1 = double.Parse(number);
            mainWindow.display.Text = number + " " + opType;
            number = null;
            operationButtonIsBeanClickedBefore = true;
        }

        void PerformSecondExpressionMember(string opType)
        {
            if (number == null || number == "-")
            {
                calculate = ChooseMathOperation(opType);
                number = SetDefaultArgumentForMathOperation(opType);
            }
            model.Argument2 = double.Parse(number);
            PerformAndShowResult();
        }

        string SetDefaultArgumentForMathOperation(string opType)
        {
            if (opType == "+" || opType == "-")
            {
                return "0";
            }
            if (opType == "*" || opType=="/")
            {
                return "1";
            }
            else
            {
                HandleWrongMathOperationSign();
                return null;
            }
        }

        string HandleWrongMathOperationSign()
        {
            exception.ExceptionComment = "wrong math operation sign";
            throw exception;
        }

        MathOp ChooseMathOperation(string opType)
        {
            if (opType == "+")
            {
                return new MathOp(model.Sum);
            }
            if (opType == "-")
            {
                return new MathOp(model.Sub);
            }
            if (opType == "*")
            {
                return new MathOp(model.Mult);
            }
            if (opType == "/")
            {
                return new MathOp(model.Div);
            }
            else
            {
                HandleWrongMathOperationSign();
                return null;
            }
        }

        void mainWindow_zero_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("0");
        }

        void mainWindow_nine_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("9");
        }

        void mainWindow_eight_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("8");
        }

        void mainWindow_seven_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("7");
        }

        void mainWindow_six_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("6");
        }

        void mainWindow_five_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("5");
        }

        void mainWindow_four_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("4");
        }

        void mainWindow_three_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("3");
        }

        void mainWindow_two_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("2");
        }

        void mainWindow_one_clicked(object sender, EventArgs e)
        {
            HandleDigitButtonPush("1");
        }

        void HandleDigitButtonPush(string digit)
        {
            if (number == null)
            {
                number = digit;
            }
            else if (number.Contains(decimalSeparator))
            {
                number += digit;
            }
            else if (number.StartsWith("0"))
            {
                number = digit;
            }
            else if (number.StartsWith("-0"))
            {
                number = "-" + digit;
            }
                else
                {
                    number += digit;
                }
            mainWindow.display.Text = number;
        }
    }
}
