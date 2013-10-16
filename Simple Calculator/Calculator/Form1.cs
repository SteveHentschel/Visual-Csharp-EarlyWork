using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double total1 = 0, total2 = 0;
        string theOperator=null;

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnOne.Text;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnTwo.Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnThree.Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFour.Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnFive.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSix.Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnSeven.Text;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnEight.Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnNine.Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnZero.Text;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnPoint.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            plusButtonClicked = false;
            minusButtonClicked = false;
            divideButtonClicked = false;
            multiplyButtonClicked = false;
            
            txtDisplay.Clear();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            total1 += double.Parse(txtDisplay.Text);
            txtDisplay.Clear();

            theOperator = "+";
            plusButtonClicked = true;
            minusButtonClicked = false;
            divideButtonClicked = false;
            multiplyButtonClicked = false;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch(theOperator) {
                case "+":
                    total2 = total1 + double.Parse(txtDisplay.Text);
                    break;
                case "-":
                    total2 = total1 - double.Parse(txtDisplay.Text);
                    break;
                case "/":
                    total2 = total1 / double.Parse(txtDisplay.Text);
                    break;
                case "*":
                    total2 = total1 * double.Parse(txtDisplay.Text);
                    break;
            }
            
            txtDisplay.Text = total2.ToString();
            total1 = 0;
        }

        bool plusButtonClicked = false;
        bool minusButtonClicked = false;
        bool divideButtonClicked = false;
        bool multiplyButtonClicked = false;

        private void btnMinus_Click(object sender, EventArgs e)
        {
            total1 = total1 + double.Parse(txtDisplay.Text);
            txtDisplay.Clear();
            theOperator = "-";
            plusButtonClicked = false;
            minusButtonClicked = true;
            divideButtonClicked = false;
            multiplyButtonClicked = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            total1 = total1 + double.Parse(txtDisplay.Text);
            txtDisplay.Clear();
            theOperator = "/";
            plusButtonClicked = false;
            minusButtonClicked = false;
            divideButtonClicked = true;
            multiplyButtonClicked = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            total1 = total1 + double.Parse(txtDisplay.Text);
            txtDisplay.Clear();
            theOperator = "*";
            plusButtonClicked = false;
            minusButtonClicked = false;
            divideButtonClicked = false;
            multiplyButtonClicked = true;
        }
    }
}
