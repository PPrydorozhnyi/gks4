using laba1.simplex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        enum Sign : int { MoreThan = 1, LessThan = -1 };
        private double[,] table;
        private int amountOfRoots;
        private int amountOfRestriction;
        private List<int> importantIndexesOfRoots;
        private double function = 0;
        private double[] result;
        private List<TextBox> boxesList;
        private List<ComboBox> comboBoxes;
        private List<TextBox> textBoxesforB;
        private double[] functionsX;
        private List<int> indexesOfEquel;

        public Form1()
        {
            InitializeComponent();
            outputBox.Hide();
            acceptTable.Hide();
            importantIndexesOfRoots = new List<int>();
            inputAmountOfRoots.SelectedIndex = 1;
            inputAmountOfRestrictions.SelectedIndex = 1;
            boxesList = new List<TextBox>();
            comboBoxes = new List<ComboBox>();
            textBoxesforB = new List<TextBox>();
            indexesOfEquel = new List<int>();
           
        }

        private void acceptParemetrs_Click(object sender, EventArgs e)
        {
            amountOfRoots = Convert.ToInt32(inputAmountOfRoots.SelectedItem);
            amountOfRestriction = Convert.ToInt32(inputAmountOfRestrictions.SelectedItem);
            CreateTable();
        }

        private void CreateTable()
        {
            HideStartFields();
            
            for (int j = 0; j < amountOfRestriction + 1; ++j)
            {
                for (int i = 0; i < amountOfRoots + 2; ++i)
                {
                    if (i < amountOfRoots)
                    {
                        TextBox textBox = new TextBox()
                        { Name = i.ToString(), Location = new Point(2 + 40 * i, 3 + 30*j), Width = 40, Height = 30 };
                        this.Controls.Add(textBox);
                        boxesList.Add(textBox);
                    }
                    else if(i == amountOfRoots)
                    {
                        ComboBox comboBox = new ComboBox()
                        {
                            Name = i.ToString(),
                            Location = new Point(2 + 40 * i, 3 + 30 * j),
                            Width = 40,
                            Height = 30,
                        };
                        if (j != amountOfRestriction)
                        {
                            comboBox.Items.AddRange(new string[] { "≤", "≥", "=" });
                        }
                        else
                        {
                            comboBox.Items.AddRange(new string[] { "max", "min"});
                        }
                        comboBox.SelectedIndex = 0;
                        this.Controls.Add(comboBox);
                        comboBoxes.Add(comboBox);
                    }
                    else if(j != amountOfRestriction)
                    {
                        TextBox textBox = new TextBox()
                        { Name = i.ToString(), Location = new Point(2 + 40 * i, 3 + 30 * j), Width = 40, Height = 30 };
                        this.Controls.Add(textBox);
                        textBoxesforB.Add(textBox);
                    }
                }
            }

        }

        private void HideStartFields()
        {
            inputAmountOfRestrictions.Hide();
            inputAmountOfRoots.Hide();
            acceptParemetrs.Hide();
            roots.Hide();

            acceptTable.Show();
        }

        private void Process()
        {
            ParseData();
            Calculate();
            ShowResult();
        }

        private void ParseData()
        {
            table = new double[amountOfRestriction + 1, amountOfRoots + 1];
            functionsX = new double[amountOfRoots + 1];
            string text;
            //add b to the table
            for (int i = 0; i < amountOfRestriction; ++i)
            {
                text = textBoxesforB.ElementAt(i).Text;
                table[i, 0] = String.IsNullOrWhiteSpace(text) ? 0 : Convert.ToDouble(text);
            }
            //add b = 0 for the function row
            table[amountOfRestriction, 0] = 0;
            //add x to the table

            for (int i = 0, j = 1, k = 0; i < boxesList.Count; ++i, ++j)
            {
                text = boxesList.ElementAt(i).Text;
                table[k, j] = String.IsNullOrWhiteSpace(text) ? 0 : Convert.ToDouble(text);
                if(k == amountOfRestriction)
                {
                    functionsX[j] = table[k, j];
                }
                if (j == amountOfRoots)
                {
                    ++k;
                    j = 0;
                }
            }
            //invert signs
            for(int i = 0; i < comboBoxes.Count; ++i)
            {
                if (comboBoxes.ElementAt(i).Text.Equals("≥"))
                {
                    for(int j = 0; j < amountOfRoots + 1; ++j)
                    {
                        table[i, j] *= (-1);
                    }
                }
                else if (comboBoxes.ElementAt(i).Text.Equals("max"))
                {
                    for (int j = 0; j < amountOfRoots + 1; ++j)
                    {
                        table[i, j] *= (-1);
                    }
                }
            }
            //check equels

            double[,] tablePequels;

            for(int i = 0; i < comboBoxes.Count; ++i)
            {
                if (comboBoxes.ElementAt(i).Text.Equals("="))
                {
                    indexesOfEquel.Add(i);
                }
            }
            if (indexesOfEquel.Count != 0)
            {
                amountOfRestriction += indexesOfEquel.Count; 
                tablePequels = new double[amountOfRoots + 1, amountOfRestriction + 1];
                //add old to new
                for(int i = indexesOfEquel.Count, n = 0; i < amountOfRestriction + 1; ++i, ++n)
                {
                    for(int j = 0; j < amountOfRoots + 1; ++j)
                    {
                        tablePequels[i, j] = table[n, j];
                    }
                }
                //add reverse old to new
                for(int i = 0; i < indexesOfEquel.Count; ++i)
                {
                    for (int j = 0; j < amountOfRoots + 1; ++j)
                    {
                        tablePequels[i, j] = table[indexesOfEquel.ElementAt(i), j] * (-1);
                    }
                }
                table = tablePequels;
            }
            

        }

        private void Calculate()
        {
            function = 0;
            result = new double[amountOfRoots];
            Simplex S = new Simplex(table);
            S.Calculate(result);
            for (int i = 0; i < amountOfRoots; ++i)
            {
                //indexes of function
                if(functionsX[i+1] != 0)
                {
                    importantIndexesOfRoots.Add(i);
                    function += functionsX[i+1] * result[i];
                }
            }

        }

        private void ShowResult()
        {
            outputBox.Show();
            outputBox.AppendText("F(x) = " + function + "\n");
            foreach(int element in importantIndexesOfRoots)
            {
                outputBox.AppendText("x[" + (element+1) + "] = " + result[element] + "\n");
            }
            //for(int i = 0; i < result.Length; ++i)
            //{
            //    outputBox.AppendText("" + result[i] + "\n");
            //}
            //outputBox.AppendText("----------------");
            //for (int i = 1; i < functionsX.Length; ++i)
            //{
            //    outputBox.AppendText("" + functionsX[i] + "\n");
            //}

        }

        private void acceptTable_Click(object sender, EventArgs e)
        {
            Process();
        }
    }
}
