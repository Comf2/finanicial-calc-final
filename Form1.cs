using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_calc_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btn0.Click += click_btn;
            btn1.Click += click_btn;
            btn2.Click += click_btn;
            btn3.Click += click_btn;
            btn4.Click += click_btn;
            btn5.Click += click_btn;
            btn6.Click += click_btn;
            btn7.Click += click_btn;
            btn8.Click += click_btn;
            btn9.Click += click_btn;
            btnPeriod.Click += click_btn;

            btnPlus.Click += operator_clicked;
            btnMinus.Click += operator_clicked;
            btnMultiply.Click += operator_clicked;
            btnDivide.Click += operator_clicked;

            btnEquals.Click += checkVal;
        }
        string firstVal = "";
        string secondVal = "";
        string opVal = "";
        bool opClicked;
        private void click_btn(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if(button.Text != ".")
            {
                if (opClicked && firstVal != "")
                {
                    outputBox.Text = "";
                    opClicked = false;
                }
                if (outputBox.Text == "0") outputBox.Text = button.Text;
                else outputBox.Text += button.Text;
            }
        }
        private void operator_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string operatorVal = button.Text;
            if(opVal != "")
            {
                secondVal = outputBox.Text;
                checkVal(sender, e);
               
                opVal = operatorVal;
                opClicked = true;

            }
            else if (opVal == "")
            {
                opClicked = false;
                firstVal = outputBox.Text;
                opVal = operatorVal;
                outputBox.Text = "";
            }
        }
        //method that checks if the first value and the second value, then if they both exist run a method
        private void checkVal(object sender, EventArgs e) 
        {
            if(firstVal !="" && opVal != "")
            {

            }
            if (firstVal != "" && secondVal != "" && opVal != "")
            {
                double finalVal = calculate_val(firstVal, secondVal, opVal);
                outputBox.Text = finalVal.ToString();
                firstVal = outputBox.Text;
                Button button = sender as Button;
                if(button.Text == "=")
                {
                    this.BackColor = Color.Red;

                    opVal = "";
                }
            }
        }
        private double calculate_val(string firstVal, string secondVal, string opType)
        {
            double finalVal = 0;

            double valOne = double.Parse(firstVal);
            double valTwo = double.Parse(secondVal);
            if (opType == "/") {
                this.BackColor = Color.BlueViolet;
                finalVal = valOne / valTwo;
            }
            else if(opType == "x") {
                finalVal = valOne * valTwo;
            }
            else if(opType == "-") { 
                finalVal = valOne - valTwo;
            }
            else if(opType == "+") { 
                finalVal = valOne + valTwo;
            }

            return finalVal;
        }
        
    }
}
