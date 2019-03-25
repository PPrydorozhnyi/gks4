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
        List<Label> labelsForTable;
        private List<double> yVector;

        public Form1()
        {
            InitializeComponent();
            outputBox.Hide();
            acceptTable.Enabled = false;
            importantIndexesOfRoots = new List<int>();
            inputAmountOfRoots.SelectedIndex = 1;
            inputAmountOfRestrictions.SelectedIndex = 1;
            boxesList = new List<TextBox>();
            comboBoxes = new List<ComboBox>();
            textBoxesforB = new List<TextBox>();
            indexesOfEquel = new List<int>();
            labelsForTable = new List<Label>();
            inputAmountOfRestrictions.DropDownStyle = ComboBoxStyle.DropDownList;
            inputAmountOfRoots.DropDownStyle = ComboBoxStyle.DropDownList;
            yVector = new List<double>();
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

            TextBox textBox;
            ComboBox comboBox;
            Label label;

            for (int i = 0; i < amountOfRoots + 2; ++i)
            {
                label = new Label()
                {
                    Name = i.ToString(),
                    Location = new Point(25 + 40 * i, 43),
                    ForeColor = Color.White,
                    AutoSize = true,
                };

                if(i == amountOfRoots)
                {
                    label.Text = "sign";
                } else if (amountOfRoots + 1 == i)
                {
                    label.Text = "B";
                } else
                {
                    label.Text = "X" + (i + 1);
                }

                labelsForTable.Add(label);
                this.Controls.Add(label);
            }

                for (int j = 0; j < amountOfRestriction + 1; ++j)
            {
                for (int i = 0; i < amountOfRoots + 2; ++i)
                {
                    if (i < amountOfRoots)
                    {
                        textBox = new TextBox()
                        { Name = i.ToString(), Location = new Point(12 + 40 * i, 63 + 30*j), Width = 40, Height = 30 };
                        this.Controls.Add(textBox);
                        boxesList.Add(textBox);
                    }
                    else if(i == amountOfRoots)
                    {
                        comboBox = new ComboBox()
                        {
                            Name = i.ToString(),
                            Location = new Point(12 + 40 * i, 63 + 30 * j),
                            Width = 40,
                            Height = 30,
                            DropDownStyle = ComboBoxStyle.DropDownList,
                          
                        };
                        if (j != amountOfRestriction)
                        {
                            comboBox.Items.AddRange(new string[] { "≤", "≥", "=" });
                        }
                        else
                        {
                            comboBox.Items.AddRange(new string[] { "max", "min"});
                            comboBox.Width = 50;
                        }
                        comboBox.SelectedIndex = 0;
                        this.Controls.Add(comboBox);
                        comboBoxes.Add(comboBox);
                    }
                    else if(j != amountOfRestriction)
                    {
                        textBox = new TextBox()
                        { Name = i.ToString(), Location = new Point(12 + 40 * i, 63 + 30 * j), Width = 40, Height = 30 };
                        this.Controls.Add(textBox);
                        textBoxesforB.Add(textBox);
                    }
                }
            }

        }

        private void HideStartFields()
        {
            inputAmountOfRestrictions.Enabled = false;
            inputAmountOfRoots.Enabled = false;
            acceptParemetrs.Enabled = false;

            acceptTable.Enabled = true;
        }

        private void DisableTable()
        {
            acceptTable.Enabled = false;
            foreach (ComboBox box in comboBoxes)
            {
                box.Enabled = false;
            }

            foreach (TextBox box in boxesList)
            {
                box.Enabled = false;
            }

            foreach (TextBox box in textBoxesforB)
            {
                box.Enabled = false;
            }
        }

        private void Process()
        {
            DisableTable();
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
            importantIndexesOfRoots.Clear();
            double[,] table_result;
            Simplex S = new Simplex(table);
            table_result = S.Calculate(result);
            yVector.Clear();
            for (int i = 0; i < amountOfRoots; ++i)
            {
                //indexes of function
                if(functionsX[i+1] != 0)
                {
                    importantIndexesOfRoots.Add(i);
                    function += functionsX[i+1] * result[i];
                }
            }

            for (int i = 1 + amountOfRoots; i < amountOfRoots + amountOfRestriction + 1; ++i)
            {
                yVector.Add(table_result[amountOfRestriction, i]);
            }

        }

        private void ShowResult()
        {
            outputBox.Clear();

            outputBox.Location = new Point(12, comboBoxes.ElementAt(comboBoxes.Count - 1).Location.Y + 40);
            outputBox.Show();
            outputBox.AppendText("F(x) = " + function + "\n");
            foreach(int element in importantIndexesOfRoots)
            {
                outputBox.AppendText("x" + (element+1) + " = " + result[element] + "\n");
            }

            for (int element = 0; element < yVector.Count; ++element)
            {
                if (element == 0)
                    outputBox.AppendText("Yopt = { " + yVector[element] + ", ");
                else if (element == yVector.Count - 1)
                    outputBox.AppendText(yVector[element] + " }\n");
                else
                    outputBox.AppendText(yVector[element] + ", ");
            }



        }

        private void acceptTable_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            outputBox.Hide();

            foreach (ComboBox box in comboBoxes)
            {
                this.Controls.Remove(box);
                box.Dispose();
            }

            foreach (TextBox box in boxesList)
            {
                this.Controls.Remove(box);
                box.Dispose();
            }

            foreach (TextBox box in textBoxesforB)
            {
                this.Controls.Remove(box);
                box.Dispose();
            }

            foreach (Label label in labelsForTable)
            {
                this.Controls.Remove(label);
                label.Dispose();
            }

            inputAmountOfRestrictions.Enabled = true;
            inputAmountOfRoots.Enabled = true;
            acceptParemetrs.Enabled = true;

        amountOfRoots = 0;
        amountOfRestriction = 0;
        importantIndexesOfRoots.Clear();
        function = 0;
        boxesList.Clear();
        comboBoxes.Clear();
        textBoxesforB.Clear();
        indexesOfEquel.Clear();
        labelsForTable.Clear();
        yVector.Clear();
    }
    }
}
