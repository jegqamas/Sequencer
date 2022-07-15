// This file is part of Sequencer
// A program that allows to create your own numbers sequence by adjusting the properties of an element of your own.
// 
// Copyright © Alaa I.Hadid 2017
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.If not, see<http://www.gnu.org/licenses/>.
// 
// Author email: mailto:ahdsoftwares@hotmail.com
//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sequencer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Element> elements_in_field = new List<Element>();
        int stageNumber;
        // Start the show
        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
            // Add the element 0
            AddNewElement("Element0");
            // Write about it
            WriteEvent("The show started with one element 'Element0'.", "Element0");
            // Clock one stage
            NextStage();
            // Write a review
            WriteReview();
        }
        private void ClearAll()
        {
            elements_in_field.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listView1.Items.Clear();
            textBox_current_stage.Text = "";
            textBox_total_elements_count.Text = "";
            stageNumber = 0;
            richTextBox1.Text = "";
        }
        private int GetY(int X)
        {
            /* 
By Alaa Ibrahim Hadid at 2 June 2017
------------------------------------
--------------------+---------------------------------------------+-------------------+-------------------+
The double sequence | The pattern of the science of torus anatomy | The power of 9 !! | Comments and notes|
--------------------+---------------------------------------------+-------------------+-------------------+
1                   | 1                                           | -0                | Nothing happened here
--------------------+---------------------------------------------+-------------------+-------------------
2                   | 2                                           | -0                | Nothing happened here
--------------------+---------------------------------------------+-------------------+-------------------
4                   | 4                                           | -0                | Nothing happened here
--------------------+---------------------------------------------+-------------------+-------------------
8                   | 8                                           | -0                | Nothing happened here
--------------------+---------------------------------------------+-------------------+-------------------
16                  | 7                                           | -9=7              | We toke 9 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
32                  | 5                                           | -27=5             | We toke 9x3=27 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
64                  | 1                                           | -63=1             | We toke 9x7=63 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
128                 | 2                                           | -126=2            | We toke 9x14=126 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
256                 | 4                                           | -252=4            | We toke 9x28=504 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
512                 | 8                                           | -504=8            | We toke 9x56=504 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
1024                | 7                                           | -1017=7           | We toke 9x113=1017 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
2048                | 5                                           | -2043=5           | We toke 9x227=2043 from the total number
--------------------+---------------------------------------------+-------------------+-------------------
X                   | Y                                           | X-Z=Y             | We toke Z= 9 x G from the total number
--------------------+---------------------------------------------+-------------------+-------------------
As we see:

Y = X - Z 
while
Y: is the number of pattern "The pattern of the science of torus anatomy" related to X
X: is an integer number that it is a power of 2 (1,2,4,8,16,32...etc)

we have Z = G x 9
while
G: this is the magic number, using this number and multiply it with 9, we get Y !!

Then ...
Y = X - (G x 9)           [1]

But still, we don't know Y and G. We can guess Y that is a sequence of 1,2,4,8,7,5,1,2,...etc
But for a given number X, we cannot guess Y in that simple, as well as guessing G.
We know that there is a way we can get Y, for example:
for 16: 1+6=7
for 32: 3+2=5
....

So, as long as the number is a multiply of 2 (2,4,8,16,32...etc): 
We can always find out the number of "The pattern of the science of torus anatomy" for that number by using these 2 ways:

Using adding:
for 16: 1+6=7
for 32: 3+2=5
for 512: 5+1+2=8
.....

OR using this formula:
Y = X - (G x 9)
While:
Y: is the number of pattern "The pattern of the science of torus anatomy" related to X
X: is an integer number and a power of 2  (1,2,4,8,16,32,64,128,256...etc) (Xn = Xn-1 x 2)
G: this is the magic number, using this number and multiply it with 9, we get Y !!

It is all about finding G, the question, where does G come from ??
Okay, we can get away this by simply: finding the closed number to X that is a multiply of 9 and smaller than X.
Example: 
for X=16, the closed numbers that are a multiples of 9 are: 1x9=9 or 2x9=18, 9 is the best since it is smaller than X then G = 1
for X=128, the closed numbers that are a multiples of 9 are: 9x14=126 or 9x15=1035, 126 is the best since it is smaller than X then G = 14
Then, we can say 
G = floor(X / 9); floor is the largest integer less than or equal to the specified decimal number.

Thus,let's use formula [1]:
Y = X - (G x 9)

+-------------------------+
|Y = X - (floor(X/9) x 9) |
+-------------------------+

Thus,

X = Y + (floor(X/9) x 9)

This means, for any givin integer number X, and that it is a power of 2 (1,2,4,8,16,32...etc),(Xn = Xn-1 x 2): X MUST be equal to a number of the pattern "The pattern of the science of torus anatomy"
plus the a result of multiplying the number 9 with the closed number (smaller than X) that is resulting from deviding the number X with 9 and follow this formula "Xn = Yn + (floor(Xn/9) x 9)"
             */
            // return Y = X - (floor(X/9) x 9)
            return (X - ((int)Math.Floor((double)(X / 9)) * 9));
        }
        private void AddNewElement(string name)
        {
            // 1 create the element with the properties specified
            Element ele = new Element();
            ele.Name = name;
            ele.CanProduce = true;
            ele.CurrentStage = 0;
            ele.HowMuchItProduceInAStage = (int)numericUpDown_how_many_can_breed.Value;
            ele.MaxStages = (int)numericUpDown_how_much_it_can_live.Value;
            ele.ProductionsAbilityCount = (int)numericUpDown_production_count.Value;
            ele.TeenStage = (int)numericUpDown_stage_of_breed.Value;
            // 2 add it !
            elements_in_field.Add(ele);
        }
        private void NextStage()
        {
            stageNumber++;
            // Advance the stage counter of all elements
            for (int i = 0; i < elements_in_field.Count; i++)
            {
                elements_in_field[i].CurrentStage++;
                // Does it die ?
                if ((elements_in_field[i].MaxStages > 0) && elements_in_field[i].CurrentStage == elements_in_field[i].MaxStages)
                {
                    // It dies !! 
                    // Remove it from the field
                    WriteEvent("The element '" + elements_in_field[i].Name + "' dies. The cause of death: it reaches the stage of death, at stage " + elements_in_field[i].MaxStages, elements_in_field[i].Name);
                    elements_in_field.RemoveAt(i);
                    i--;
                }
                // Can it breed ! (if it dies at a stage, it cannot breed at that stage)
                else if (elements_in_field[i].CurrentStage >= elements_in_field[i].TeenStage)
                {
                    if (elements_in_field[i].CanProduce)
                    {
                        // It can breed !!
                        // Create new element
                        if (elements_in_field[i].ProductionsAbilityCount > 0)
                        {
                            if (elements_in_field[i].ProductionsCount <= elements_in_field[i].ProductionsAbilityCount)
                            {
                                for (int c = 0; c < elements_in_field[i].HowMuchItProduceInAStage; c++)
                                {
                                    AddNewElement(elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "]");
                                    WriteEvent("A new healthy element has born: " + elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "] son of '" + elements_in_field[i].Name + "'", elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "]");
                                }
                                elements_in_field[i].ProductionsCount++;
                            }
                            else
                            {
                                WriteEvent("'" + elements_in_field[i].Name + "' wants to have a child but it can't, it has exceeded the maximum count of production.", elements_in_field[i].Name);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < elements_in_field[i].HowMuchItProduceInAStage; c++)
                            {
                                AddNewElement(elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "]");
                                WriteEvent("A new healthy element has born: " + elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "] son of '" + elements_in_field[i].Name + "'", elements_in_field[i].Name + " [ChildElement" + elements_in_field[i].ProductionsCount + "]");
                            }
                            elements_in_field[i].ProductionsCount++;
                        }
                    }
                    else
                    {
                        WriteEvent("'" + elements_in_field[i].Name + "' is at the age of production but it cannot produce !!?", elements_in_field[i].Name);
                    }
                }
                else
                {
                    WriteEvent("'" + elements_in_field[i].Name + "' survived the stage, it lives to see another stage ...", elements_in_field[i].Name);
                }
            }
            // Add the fields elements count
            listBox1.Items.Add(elements_in_field.Count);
            listBox2.Items.Add(GetY(elements_in_field.Count));

            textBox_current_stage.Text = stageNumber.ToString();
            textBox_total_elements_count.Text = elements_in_field.Count.ToString();
        }
        private void WriteEvent(string text, string itemName)
        {
            ListViewItem it = new ListViewItem();
            it.Text = stageNumber.ToString();
            it.SubItems.Add(itemName);
            it.SubItems.Add(text);

            listView1.Items.Add(it);
        }
        private void WriteReview()
        {
            string text = "";
            text += "In order an element (can be a living being, a cell, a structure ...etc) to follow this sequence, it MUST have these properties:\n";
            // Live time
            if (numericUpDown_how_much_it_can_live.Value != 0)
                text += "1. The element must live for " + numericUpDown_how_much_it_can_live.Value + " stage(s) at least (it appears for " + numericUpDown_how_much_it_can_live.Value + " stage(s)), then it is disappeared in the next stage.\n";
            else
                text += "1. The element does not have a limit for it's live.\n";
            // Stage of teenage
            string nn = numericUpDown_stage_of_breed.Value.ToString();
            switch (numericUpDown_stage_of_breed.Value)
            {
                case 1: nn += "st"; break;
                case 2: nn += "nd"; break;
                case 3: nn += "rd"; break;
                default: nn += "th"; break;
            }
            text += "2. The element must start producing (giving a birth, engender ...etc) at the " + nn + " stage of it's live time.\n";
            // How many times it can produce
            if (numericUpDown_production_count.Value == 0)
                text += "3. The element should be able to produce (giving a birth, engender ...etc) as long as it is alive.\n";
            else
                text += "3. The element should be able to produce (giving a birth, engender ...etc) " + numericUpDown_production_count.Value + " time(s) as long as it is alive.\n";
            // Production count in live time.
            if (numericUpDown_how_many_can_breed.Value != 0)
                text += "4. When that element reaches a stage of production (giving a birth, engender ...etc), it will add " + numericUpDown_how_many_can_breed.Value + " element(s) in that stage (the stage when that element is alive and can produce).\n";
            else
                text += "4. This element produce no element (the sequence will end up in 0,0,0,...etc or 1,1,1...etc).\n";

            richTextBox1.Text = text;
        }
        // Next stage
        private void button2_Click(object sender, EventArgs e)
        {
            NextStage();
        }
        // Clear all
        private void button3_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        // Fibonnaci
        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown_how_much_it_can_live.Value = 0;// Immortal
            numericUpDown_how_many_can_breed.Value = 1;// It can have one child at a time
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_stage_of_breed.Value = 3;// Start breeding at the 3rd stage 
        }
        // Stick to 2
        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown_how_much_it_can_live.Value = 3;// 3 stages only
            numericUpDown_how_many_can_breed.Value = 1;// It can have one child at a time
            numericUpDown_production_count.Value = 1;// One child only
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Doubles
        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown_how_much_it_can_live.Value = 0;// Immortal
            numericUpDown_how_many_can_breed.Value = 1;// It can have one child at a time
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Power of 3
        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_how_many_can_breed.Value = 2;// It can have 2 children at a time
            numericUpDown_how_much_it_can_live.Value = 0;// Immortal
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Power of 4
        private void button8_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_how_many_can_breed.Value = 3;// It can have 3 children at a time
            numericUpDown_how_much_it_can_live.Value = 0;// Immortal
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Power of 5
        private void button9_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_how_many_can_breed.Value = 4;// It can have 4 children at a time
            numericUpDown_how_much_it_can_live.Value = 0;// Immortal
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Start with multiplying with 4, then continue with power of 3
        private void button10_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 1;// 1 time only
            numericUpDown_how_many_can_breed.Value = 3;// It can have 3 children at a time
            numericUpDown_how_much_it_can_live.Value = 3;// live for 3 stages
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Start with multiplying with 5, then continue with power of 4
        private void button11_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 1;// 1 time only
            numericUpDown_how_many_can_breed.Value = 4;// It can have 4 children at a time
            numericUpDown_how_much_it_can_live.Value = 3;// live for 3 stages
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Start with multiplying with 3, then continue with power of 2
        private void button12_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 2;// 2 times 
            numericUpDown_how_many_can_breed.Value = 2;// It can have 2 children at a time
            numericUpDown_how_much_it_can_live.Value = 3;// live for 3 stages
            numericUpDown_stage_of_breed.Value = 2;// Start breeding at the 2nd stage 
        }
        // Strange 1
        private void button13_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// 2 times 
            numericUpDown_how_many_can_breed.Value = 1;// It can have 2 children at a time
            numericUpDown_how_much_it_can_live.Value = 0;// live for 3 stages
            numericUpDown_stage_of_breed.Value = 4;// Start breeding at the 2nd stage 
        }
        // Strange 2
        private void button14_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_how_many_can_breed.Value = 1;// It can have 1 child at a time
            numericUpDown_how_much_it_can_live.Value = 5;// live for 5 stages
            numericUpDown_stage_of_breed.Value = 4;// Start breeding at the 4th stage 
        }
        // Strange 3
        private void button15_Click(object sender, EventArgs e)
        {
            numericUpDown_production_count.Value = 0;// Unstoppable
            numericUpDown_how_many_can_breed.Value = 1;// It can have 1 child at a time
            numericUpDown_how_much_it_can_live.Value = 4;// live for 5 stages
            numericUpDown_stage_of_breed.Value = 3;// Start breeding at the 4th stage 
        }
        // Load properties from file
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open the properties from a file";
            op.Filter = "Text file|*.txt;";
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(op.FileName);
                if (lines.Length < 4)
                {
                    MessageBox.Show("Error loading the file: the file length is smaller than expected '4'");
                    return;
                }
                int val = 0;
                if (int.TryParse(lines[0], out val))
                    numericUpDown_production_count.Value = val;
                else
                    numericUpDown_production_count.Value = 0;

                val = 0;
                if (int.TryParse(lines[1], out val))
                    numericUpDown_how_many_can_breed.Value = val;
                else
                    numericUpDown_how_many_can_breed.Value = 0;

                val = 0;
                if (int.TryParse(lines[2], out val))
                    numericUpDown_how_much_it_can_live.Value = val;
                else
                    numericUpDown_how_much_it_can_live.Value = 0;

                val = 0;
                if (int.TryParse(lines[3], out val))
                    numericUpDown_stage_of_breed.Value = val;
                else
                    numericUpDown_stage_of_breed.Value = 0;
            }
        }
        // Save properties into file
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "Save the properties into a file";
            sav.Filter = "Text file|*.txt;";
            if (sav.ShowDialog(this) == DialogResult.OK)
            {

                string[] lines = {
                numericUpDown_production_count.Value.ToString(),
                numericUpDown_how_many_can_breed.Value.ToString(),
                numericUpDown_how_much_it_can_live.Value.ToString(),
                numericUpDown_stage_of_breed.Value.ToString(),
                };

                System.IO.File.WriteAllLines(sav.FileName, lines);
            }
        }
        // Save the sequence
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "Save the sequence into a file";
            sav.Filter = "Text file (all sequence saved in one line)|*.txt;|Text file (each number of the sequence in a line)|*.txt;";
            if (sav.ShowDialog(this) == DialogResult.OK)
            {
                if (sav.FilterIndex == 1)
                {
                    string txt = "";
                    foreach (int item in listBox1.Items)
                        txt += item + ",";
                    System.IO.File.WriteAllText(sav.FileName, txt);
                }
                else
                {
                    string[] lines = new string[listBox1.Items.Count];
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        lines[i] = listBox1.Items[i].ToString();
                    System.IO.File.WriteAllLines(sav.FileName, lines);
                }
            }
        }
        // Save the Number of the pattern of the science of torus anatomy sequence
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "Save the 'Number of the pattern of the science of torus anatomy' into a file";
            sav.Filter = "Text file (all numbers will be saved in one line)|*.txt;|Text file (each number in a line)|*.txt;";
            if (sav.ShowDialog(this) == DialogResult.OK)
            {
                if (sav.FilterIndex == 1)
                {
                    string txt = "";
                    foreach (int item in listBox2.Items)
                        txt += item + ",";
                    System.IO.File.WriteAllText(sav.FileName, txt);
                }
                else
                {
                    string[] lines = new string[listBox2.Items.Count];
                    for (int i = 0; i < listBox2.Items.Count; i++)
                        lines[i] = listBox2.Items[i].ToString();
                    System.IO.File.WriteAllLines(sav.FileName, lines);
                }
            }
        }
        // About
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Sequencer" +
      "\n A program that allows to create your own numbers sequence by adjusting the properties of an element of your own." +
       "\n" +
       "\n Copyright © Alaa I.Hadid 2017" +
       "\n" +
      "\n This program is free software: you can redistribute it and/or modify" +
       "\n it under the terms of the GNU General Public License as published by" +
      "\n the Free Software Foundation, either version 3 of the License, or" +
      "\n(at your option) any later version." +
      "\n" +
      "\n This program is distributed in the hope that it will be useful," +
      "\n but WITHOUT ANY WARRANTY; without even the implied warranty of" +
     "\n MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the" +
     "\n GNU General Public License for more details." +
      "\n" +
     "\n You should have received a copy of the GNU General Public License" +
      "\n along with this program.If not, see<http://www.gnu.org/licenses/>." +
     "\n" +
     "\n Author email: mailto:ahdsoftwares@hotmail.com");
        }
    }
}
