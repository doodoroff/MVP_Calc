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
        string argument;
        bool operationButtonIsBeanClickedBefore;
        string decimalSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

        public Presenter(MainWindow mainwindow)
        {
            this.mainWindow = mainwindow;
            this.model = new Model();
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
            if (argument == null)
            {
                argument = "-";
                mainWindow.output.Text = "-";
            }
            else if (argument.Contains("-"))
            {
                argument = argument.Remove(0, 1);
                mainWindow.output.Text = argument;
            }
                else
                {
                    argument = "-" + argument;
                    mainWindow.output.Text = argument;
                }
        }

        void mainwindow_decimalSeparator_clicked(object sender, EventArgs e)
        {
            if (argument == null)
            {
                argument = "0" + decimalSeparator;
                mainWindow.output.Text = argument ;
            }
            else if (argument.Contains(decimalSeparator))
            {
                return;
            }
                else
                {
                    this.argument += decimalSeparator;
                    mainWindow.output.Text = argument;
                }
        }

        void mainWindow_reset_clicked(object sender, EventArgs e)
        {
            calculate = null;
            mainWindow.output.Text = "0";
            argument = null;
            operationButtonIsBeanClickedBefore = false;
        }

        void mainWindow_eql_clicked(object sender, EventArgs e)
        {
            if (operationButtonIsBeanClickedBefore)
            {
                if (argument == null || argument == "-")
                {
                    argument = "0";
                }
                model.Argument2 = double.Parse(argument);
            }
            if (calculate == null)
            {
                argument = "0";
            }
                else
                {
                    argument = Convert.ToString(calculate());
                }
            model.Argument1 = double.Parse(argument);
            mainWindow.output.Text = argument;
            operationButtonIsBeanClickedBefore = false;
        }

        void mainWindow_div_clicked(object sender, EventArgs e)
        {
            PerformMathOperation("/");
        }

        void mainWindow_mult_clicked(object sender, EventArgs e)
        {
            PerformMathOperation("*");
        }

        void mainWindow_minus_clicked(object sender, EventArgs e)
        {
            PerformMathOperation("-");
        }

        void mainWindow_plus_clicked(object sender, EventArgs e)
        {
            PerformMathOperation("+");
        }

        void PerformMathOperation(string opType)
        {
            if (argument != null && argument != "-")
            {
                model.Argument1 = double.Parse(argument);
            }
            argument = null;
            calculate = ChooseMathOperation(opType);
            mainWindow.output.Text = opType + " ";
            operationButtonIsBeanClickedBefore = true;
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
            if (argument == null)
            {
                this.argument = digit;
            }
            else if (argument.Contains(decimalSeparator))
            {
                this.argument += digit;
            }
            else if (argument.StartsWith("0"))
            {
                this.argument = digit;
            }
            else if (argument.StartsWith("-0"))
            {
                this.argument = "-" + digit;
            }
                else
                {
                    this.argument += digit;
                }
            mainWindow.output.Text = argument;
        }
    }
}
