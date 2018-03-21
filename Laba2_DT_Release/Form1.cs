using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2_DT_Release
{
    public partial class Form1 : Form
    {
        //RectText, Rect
        Dictionary<string, Rectangle> listRect = new Dictionary<string, Rectangle>();
        Dictionary<string, string> listArcs = new Dictionary<string, string>();

        //selected vertices
        bool IsSelected1 = false;
        bool IsSelected2 = false;

        //show if user hold mouse
        bool InArea = false;

        //for move rect
        int deltaX = 0;
        int deltaY = 0;

        //for know selected rect
        string selectedRect = "";

        //delete selected rect
        bool IsDelete = false;

        //was event MouseMove or not
        bool IsMouseMoveIsClicked = false;

        //temp storage for deleted rectangle
        Rectangle delRect = new Rectangle();

        //2 vertices for connect
        Dictionary<string, Rectangle> verticesForConnect = new Dictionary<string, Rectangle>();

        //format of string for alignment text in rect
        StringFormat sf = new StringFormat();

        string[] eventX;

        //passed vertices
        Dictionary<string, bool> markEvents = new Dictionary<string, bool>();

        bool onlyOneTime = false;

        //passed branches from "И"
        Dictionary<string, bool> markBranches = new Dictionary<string, bool>();

        //for delete fails chains
        bool[] failEventX;

        //ending events
        string[] endingEvents;

        //probability ending event
        Dictionary<string, double> probEndingEvents = new Dictionary<string, double>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //handler of keys (need set propreties Form.KeyPreview as "true")
            this.KeyDown += new KeyEventHandler(hotKeys);

            //format of string for alignment text in rect
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        private void hotKeys(object sender, KeyEventArgs e)
        {
            //exit button (ESC)
            if (e.KeyCode.ToString() == "Escape")
                Application.Exit();

            //open file button (Ctrl + O)
            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
                загрузитьToolStripMenuItem_Click(sender, e);

            //save file button (Ctrl + S)
            if (e.Control && e.KeyCode == Keys.S)
                сохранитьToolStripMenuItem_Click(sender, e);

            //delete selected rect (delete)
            if (e.KeyCode == Keys.Delete && IsDelete == true)
            {
                listRect.Remove(selectedRect);
                listBox_dangerous_states.Items.Remove(selectedRect);

                //remove arc by key (1 arc, because it my bug with selected structes of data)
                listArcs.Remove(selectedRect);

                //remove arcs by value (several arcs)
                int counter = 0;

                //save size before he not resize
                int end = listArcs.Count;

                while (counter != end)
                {
                    foreach (var arc in listArcs)
                    {
                        if (arc.Value == selectedRect)
                        {
                            listArcs.Remove(arc.Key);
                            break;
                        }
                    }
                    counter++;
                }

                IsDelete = false;
                pictureBox1.Invalidate();
            }
        }

        //for toolStrip need in contextMenu choose "DropDownButton" and set property "DisplayStyle" = Text
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete all rect, arcs and other
            listRect.Clear();
            listArcs.Clear();
            probEndingEvents.Clear();
            listBox_dangerous_states.Items.Clear();
            dataGridViewProbEvents.ColumnCount = 2;
            dataGridViewProbEvents.Columns[0].HeaderText = String.Format("Инициирующее событие");
            dataGridViewProbEvents.Columns[1].HeaderText = String.Format("Вероятность");

            string file = "";
            pictureBox1.Invalidate();

            //use "using" for dispose this resource when he will not need
            using (var of = new OpenFileDialog())
            {
                //set directory by default
                of.InitialDirectory = "D:\\MyYandexDisk\\YandexDisk\\4 course\\Теория принятий решений";

                //set type of files
                of.Filter = "txt files (*.txt) | *.txt";

                //choose file (path will save in property "FileName")
                if (of.ShowDialog() != DialogResult.OK)
                    of.FileName = "D:\\MyYandexDisk\\YandexDisk\\4 course\\Теория принятий решений\\laba2_input.txt";           //if not choose file

                //extract from file data
                file = File.ReadAllText(of.FileName);

                //renew pointer
                int i = 0;

                listRect.Clear();
                listArcs.Clear();

                string vertex;
                Rectangle uploadRect = new Rectangle();

                //upload rect-s
                while (file[i] != '\r' || file[i + 1] != '\n')
                {
                    //X
                    vertex = "";
                    while (file[i] != ' ')
                    {
                        vertex += file[i].ToString();
                        i++;
                    }
                    i++;
                    uploadRect.X = Convert.ToInt32(vertex);

                    //Y
                    vertex = "";
                    while (file[i] != ' ')
                    {
                        vertex += file[i].ToString();
                        i++;
                    }
                    i++;
                    uploadRect.Y = Convert.ToInt32(vertex);

                    //Width
                    vertex = "";
                    while (file[i] != ' ')
                    {
                        vertex += file[i].ToString();
                        i++;
                    }
                    i++;
                    uploadRect.Width = Convert.ToInt32(vertex);

                    //Height
                    vertex = "";
                    while (file[i] != ' ')
                    {
                        vertex += file[i].ToString();
                        i++;
                    }
                    i++;
                    uploadRect.Height = Convert.ToInt32(vertex);

                    //text of rect
                    vertex = "";
                    while (file[i] != '\r')
                    {
                        vertex += file[i].ToString();
                        i++;
                    }
                    i += 2;

                    //save fully rect
                    listRect.Add(vertex, uploadRect);
                }
                i += 2;

                //upload arcs
                while (file[i] != '\r' || file[i + 1] != '\n')
                {
                    string vertex1 = "";
                    string vertex2 = "";

                    //text of first rect
                    while (file[i] != ' ' || file[i + 1] != '-' || file[i + 2] != ' ')
                    {
                        vertex1 += file[i].ToString();
                        i++;
                    }
                    i += 3;

                    //text of second rect
                    while (file[i] != '\r')
                    {
                        vertex2 += file[i].ToString();
                        i++;
                    }
                    i += 2;
                    
                    //save fully arc
                    listArcs.Add(vertex2, vertex1);
                }
                i += 2;

                //index for dataGridViews with prob.init.events and losses
                int x = 0;

                //probability of init. events
                while (file[i] != '\r' || file[i + 1] != '\n')
                {
                    string vert = "";
                    string prob = "";

                    //text of init. event
                    while (file[i] != ' ' || file[i + 1] != '-' || file[i + 2] != ' ')
                    {
                        vert += file[i].ToString();
                        i++;
                    }
                    i += 3;

                    //probability of init. event
                    while (file[i] != '\r')
                    {
                        prob += file[i].ToString();
                        i++;
                    }
                    i += 2;

                    //save probabilty init.events
                    dataGridViewProbEvents.RowCount += 1;
                    dataGridViewProbEvents[0, x].Value = vert;
                    dataGridViewProbEvents[1, x].Value = prob;
                    dataGridViewProbEvents.Rows[x].HeaderCell.Value = String.Format("{0}", x + 1);

                    //for next init.event
                    x++;
                }
                i += 2;

                //cost of losses danger state (1 number)
                textBoxCostOfLosses.Text = "";
                while (file[i] != '\r' || file[i + 1] != '\n')
                {
                    textBoxCostOfLosses.Text += file[i].ToString();
                    i++;
                }

                //draw vertices

                //transform pictBox in Bitmap and then in Graphics
                Bitmap pictBoxBM = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics pictBoxBM_G = Graphics.FromImage(pictBoxBM);

                //for best image
                pictBoxBM_G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                //create figure on Graphics
                Pen penBlack = new Pen(Color.Black);

                foreach (var rect in listRect)
                {
                    if ((rect.Key[0] == 'И' && Char.IsDigit(rect.Key[1])) || (rect.Key[0] == 'И' && rect.Key[1] == 'Л' && rect.Key[2] == 'И' && Char.IsDigit(rect.Key[3])))
                    {
                        pictBoxBM_G.DrawEllipse(penBlack, rect.Value);
                    }
                    else
                    {
                        pictBoxBM_G.DrawRectangle(penBlack, rect.Value);
                    }

                    //text in rect
                    pictBoxBM_G.DrawString(rect.Key, new Font("Helvetica", 8, FontStyle.Regular), Brushes.Black, rect.Value, sf);

                    //add in list
                    if ((rect.Key[0] != 'И' && !Char.IsDigit(rect.Key[1])) && (rect.Key[0] != 'И' && rect.Key[1] != 'Л' && rect.Key[2] != 'И' && !Char.IsDigit(rect.Key[3])))
                    {
                        listBox_dangerous_states.Items.Add(rect.Value);
                    }

                    //draw arcs
                    foreach (var arc in listArcs)
                        pictBoxBM_G.DrawLine(penBlack, listRect[arc.Value].X + listRect[arc.Value].Width / 2, listRect[arc.Value].Y + listRect[arc.Value].Height, listRect[arc.Key].X + listRect[arc.Key].Width / 2, listRect[arc.Key].Y);

                    //need for render image
                    pictureBox1.CreateGraphics().DrawImageUnscaled(pictBoxBM, 0, 0);
                    pictureBox1.Invalidate();
                }
            }
        }

        //for toolStrip need in contextMenu choose "DropDownButton" and set property "DisplayStyle" = Text
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = "";

            //use "using" for dispose this resource when he will not need
            using (var sf = new SaveFileDialog())
            {
                //set directory by default
                sf.InitialDirectory = "D:\\MyYandexDisk\\YandexDisk\\4 course\\Теория принятий решений";

                //set type of files
                sf.Filter = "txt files (*.txt) | *.txt";

                //choose file (path will save in property "FileName")
                if (sf.ShowDialog() != DialogResult.OK)
                    sf.FileName = "D:\\MyYandexDisk\\YandexDisk\\4 course\\Теория принятий решений\\laba2_output";           //if not choose file

                //import vertices
                foreach (var item in listRect)
                {
                    file += item.Value.X + " " + item.Value.Y + " " + item.Value.Width + " " + item.Value.Height + " " + item.Key + "\r\n";
                }

                //separator
                file += "\r\n";

                //import arcs
                foreach (var arc in listArcs)
                {
                    file += arc.Value;
                    file += " - " + arc.Key + "\r\n";
                }

                //separator
                file += "\r\n";

                //probability init.events
                for (int i = 0; i < dataGridViewProbEvents.RowCount; i++)
                    file += dataGridViewProbEvents[0, i].Value + " - " + dataGridViewProbEvents[1, i].Value + "\r\n";

                //separator
                file += "\r\n";

                //cost of losses danger state (1 number)
                file += textBoxCostOfLosses.Text + "\r\n";

                File.WriteAllText(sf.FileName, file);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRender_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //delete all rect, arcs and other
            listRect.Clear();
            listArcs.Clear();
            listBox_dangerous_states.Items.Clear();

            //update
            pictureBox1.Invalidate();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            int index = listBox_dangerous_states.SelectedIndex;

            //delete by index
            listBox_dangerous_states.Items.RemoveAt(index);

            //insert by index
            listBox_dangerous_states.Items.Insert(index, textBoxEditState.Text);

            textBoxEditState.Text = "";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var rect in listRect)
            {
                //check on enter in exist rect
                if ((e.X > rect.Value.X) && (e.X < rect.Value.X + rect.Value.Width))
                {
                    if ((e.Y > rect.Value.Y) && (e.Y < rect.Value.Y + rect.Value.Height))
                    {
                        InArea = true;
                        deltaX = e.X - rect.Value.X;
                        deltaY = e.Y - rect.Value.Y;

                        //save key of selected rect
                        selectedRect = rect.Key;
                    }
                }
            }

            if (InArea == false || e.Button == MouseButtons.Right)
            {
                //add vertex
                if (e.Button == MouseButtons.Left)
                {
                    //transform pictBox in Bitmap and then in Graphics
                    Bitmap pictBoxBM = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics pictBoxBM_G = Graphics.FromImage(pictBoxBM);

                    //for best image
                    pictBoxBM_G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    //create figure on Graphics
                    Pen penBlack = new Pen(Color.Black);
                    Rectangle rectangle;

                    //need if draw not exist rect after his moving
                    pictureBox1.Invalidate();

                    if ((textBoxNameVertex.Text[0] == 'И' && Char.IsDigit(textBoxNameVertex.Text[1])) || (textBoxNameVertex.Text[0] == 'И' && textBoxNameVertex.Text[1] == 'Л' && textBoxNameVertex.Text[2] == 'И' && Char.IsDigit(textBoxNameVertex.Text[3])))
                    {
                        if ((textBoxNameVertex.Text[0] == 'И' && Char.IsDigit(textBoxNameVertex.Text[1])))
                        {
                            rectangle = new Rectangle(e.X - 10, e.Y - 10, textBoxNameVertex.Text.Length * 20, textBoxNameVertex.Text.Length * 20);
                            pictBoxBM_G.DrawEllipse(penBlack, rectangle);
                        }
                        else
                        {
                            rectangle = new Rectangle(e.X - 10, e.Y - 10, textBoxNameVertex.Text.Length * 12, textBoxNameVertex.Text.Length * 12);
                            pictBoxBM_G.DrawEllipse(penBlack, rectangle);
                        }
                    }
                    else
                    {
                        rectangle = new Rectangle(e.X - 10, e.Y - 10, 80, 40);
                        pictBoxBM_G.DrawRectangle(penBlack, rectangle);
                    }

                    //text in rect
                    pictBoxBM_G.DrawString(textBoxNameVertex.Text, new Font("Helvetica", 8, FontStyle.Regular), Brushes.Black, rectangle, sf);
                    
                    if (!listRect.Keys.Contains(textBoxNameVertex.Text))
                    {                        
                        listRect.Add(textBoxNameVertex.Text, rectangle);

                        //add in list
                        if ((textBoxNameVertex.Text[0] != 'И' || !Char.IsDigit(textBoxNameVertex.Text[1])) && (textBoxNameVertex.Text[0] != 'И' || textBoxNameVertex.Text[1] != 'Л' || textBoxNameVertex.Text[2] != 'И' || !Char.IsDigit(textBoxNameVertex.Text[3])))
                        {
                            listBox_dangerous_states.Items.Add(textBoxNameVertex.Text);
                        }
                    }
                    else
                    {
                        pictureBox1.Invalidate();
                        MessageBox.Show("Вершина с таким именем уже добавлена", "Предупреждение!");
                        pictureBox1.Invalidate();
                    }
                   
                    //need for render image
                    pictureBox1.CreateGraphics().DrawImageUnscaled(pictBoxBM, 0, 0);
                }
                else
                {
                    //select 1 vertex
                    if (IsSelected1 == false && IsSelected2 == false)
                    {
                        foreach (var item in listRect)
                        {
                            //check on enter mouse click in every rect-s
                            if ((e.X > item.Value.X) && (e.X < item.Value.X + item.Value.Width))
                            {
                                if ((e.Y > item.Value.Y) && (e.Y < item.Value.Y + item.Value.Height))
                                {
                                    IsSelected1 = true;
                                    verticesForConnect.Add(item.Key, item.Value);
                                    break;
                                }
                            }
                        }
                    }
                    else if (IsSelected1 == true)
                    {
                        //select 2 vertex
                        foreach (var item in listRect)
                        {
                            //check on enter mouse click in every rect-s
                            if ((e.X > item.Value.X) && (e.X < item.Value.X + item.Value.Width))
                            {
                                if ((e.Y > item.Value.Y) && (e.Y < item.Value.Y + item.Value.Height))
                                {
                                    IsSelected2 = true;

                                    //check on distint rect
                                    if (verticesForConnect.First().Key != item.Key)
                                    {
                                        verticesForConnect.Add(item.Key, item.Value);
                                    }
                                    break;
                                }
                            }
                        }

                        //connect two vertices

                        //check on distint rect
                        if (verticesForConnect.Count != 2)
                        {
                            MessageBox.Show("Данная вершина выбрана дважды", "Предупреждение!");
                        }
                        else
                        {
                            //transform pictBox in Bitmap and then in Graphics
                            Bitmap pictBoxBM = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            Graphics pictBoxBM_G = Graphics.FromImage(pictBoxBM);

                            //for best image
                            pictBoxBM_G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                            //correct visialization line
                            try
                            {
                                if (verticesForConnect.First().Value.Y < verticesForConnect.Last().Value.Y)
                                {
                                    listArcs.Add(verticesForConnect.Last().Key, verticesForConnect.First().Key);

                                    //connect vertices on Graphics (as usual using program)
                                    pictBoxBM_G.DrawLine(Pens.Black, verticesForConnect.First().Value.X + verticesForConnect.First().Value.Width / 2, verticesForConnect.First().Value.Y + verticesForConnect.First().Value.Height, verticesForConnect.Last().Value.X + verticesForConnect.Last().Value.Width / 2, verticesForConnect.Last().Value.Y);
                                }
                                else
                                {
                                    listArcs.Add(verticesForConnect.First().Key, verticesForConnect.Last().Key);

                                    //connect vertices on Graphics (not as usual using program)
                                    pictBoxBM_G.DrawLine(Pens.Black, verticesForConnect.First().Value.X + verticesForConnect.First().Value.Width / 2, verticesForConnect.First().Value.Y, verticesForConnect.Last().Value.X + verticesForConnect.Last().Value.Width / 2, verticesForConnect.Last().Value.Y + verticesForConnect.Last().Value.Height);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Некоррекное построение дерева", "Предупреждение!");
                            }

                            IsSelected1 = false;
                            IsSelected2 = false;
                            verticesForConnect.Clear();

                            //need for render image
                            pictureBox1.CreateGraphics().DrawImageUnscaled(pictBoxBM, 0, 0);
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //when ponter of mouse move in pictureBox(that is MouseMove) and hold(clicked) mouse
            if (InArea)
            {
                //was event MouseMove and IsClicked
                IsMouseMoveIsClicked = true;

                Rectangle selRect = listRect[selectedRect];

                //preparation for update parameters of rect
                int W = selRect.Width;
                int H = selRect.Height;
                listRect.Remove(selectedRect);

                //renew rect
                Rectangle newRect = new Rectangle(e.X - deltaX, e.Y - deltaY, W, H);

                //move rect smoothly (don't putting edge of rect)
                listRect.Add(selectedRect, newRect);

                //recalculate arcs
                int counter = 0;
                while (counter != listArcs.Count)
                {
                    foreach (var arc in listArcs)
                    {
                        if (arc.Key == selectedRect)
                        {
                            //preparation for update parameters of rect

                            //save second rect
                            string rect2 = arc.Value;

                            //delete old rect
                            listArcs.Remove(arc.Key);

                            //add new arc
                            listArcs.Add(selectedRect, rect2);

                            break;
                        }

                        if (arc.Value == selectedRect)
                        {
                            //preparation for update parameters of rect

                            //save first rect
                            string rect1 = arc.Key;

                            //delete old rect
                            listArcs.Remove(arc.Key);

                            //add new arc
                            listArcs.Add(rect1, selectedRect);

                            break;
                        }
                    }
                    counter++;
                }

                //clear image and run event Paint()
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //mark rect, which will delete
            if (IsMouseMoveIsClicked == false && InArea == true && e.Button == MouseButtons.Left)
            {
                //mark
                if (IsDelete == false)
                {
                    IsDelete = true;                    

                    delRect = listRect[selectedRect];
                }
                else
                {
                    IsDelete = false;
                }

                //update image
                pictureBox1.Invalidate();
            }

            InArea = false;
            IsMouseMoveIsClicked = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //for best image
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            foreach (var rect in listRect)
            {
                if ((rect.Key[0] == 'И' && Char.IsDigit(rect.Key[1])) || (rect.Key[0] == 'И' && rect.Key[1] == 'Л' && rect.Key[2] == 'И' && Char.IsDigit(rect.Key[3])))
                {
                    if (IsDelete == true && rect.Value == delRect)
                    {
                        e.Graphics.DrawEllipse(Pens.Red, rect.Value);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(Pens.Black, rect.Value);

                    }
                }
                else
                {
                    if (IsDelete == true && rect.Value == delRect)
                    {
                        e.Graphics.DrawRectangle(Pens.Red, rect.Value);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, rect.Value);
                    }
                }
                e.Graphics.DrawString(rect.Key, new Font("Helvetica", 8, FontStyle.Regular), Brushes.Black, rect.Value, sf);
            }

            //draw arcs
            foreach (var arc in listArcs)
                e.Graphics.DrawLine(Pens.Black, listRect[arc.Value].X + listRect[arc.Value].Width / 2, listRect[arc.Value].Y + listRect[arc.Value].Height, listRect[arc.Key].X + listRect[arc.Key].Width / 2, listRect[arc.Key].Y);

            //create logical tree
            
            //key of rect with minimal Y for root rect
            int minY = pictureBox1.Height;
            string keyRootRect = "";

            //found root of tree
            foreach (var rect in listRect)
            {
                if (rect.Value.Y < minY)
                {
                    minY = rect.Value.Y;
                    keyRootRect = rect.Key;
                }
            }

            //event "X"
            eventX = new string[listRect.Count + listArcs.Count];

            for (int i = 0; i < listRect.Count + listArcs.Count; i++)
                eventX[i] = "";

            failEventX = new bool[listRect.Count + listArcs.Count];

            endingEvents = new string[0];

            //found linking rect-s
            
            for (int c = 0; c < listRect.Count + listArcs.Count; c++)
            {
                FoundNextRect(c, keyRootRect);
                onlyOneTime = false;
                markEvents.Clear();
                markBranches.Clear();
            }

            //delete fails (not fully)
            for (int i = 0; i < listRect.Count + listArcs.Count; i++)
            {
                if (failEventX[i] == true)
                    eventX[i] = "";
            }

            //add ending event with probability previously clear old values
            listBox_initEvents.Items.Clear();
            for (int i = 0; i < endingEvents.Length; i++)
            {
                probEndingEvents.Add(endingEvents[i], 0.0);
                listBox_initEvents.Items.Add(endingEvents[i]);
            }

            //if(probEndingEvents.Count != 0)
            //    ;

            


            //textBoxFAL.Text = ;
        }

        //recursively found links with rect-s
        private void FoundNextRect(int c, string firstRect)
        {
            foreach (var secondRect in listArcs)
            {
                if (firstRect == secondRect.Value)
                {
                    //down
                    FoundNextRect(c, secondRect.Key);

                    //put
                    bool endEvent = true;
                    foreach (var ar in listArcs)
                    {
                        if (ar.Value == secondRect.Key)
                        {
                            endEvent = false;
                            break;
                        }
                    }

                    //save and exit from branch
                    if (endEvent == true && !markEvents.Keys.Contains(secondRect.Key) && onlyOneTime == false && !eventX.Contains(eventX[c] + secondRect.Key + " - "))
                    {                       
                        onlyOneTime = true;
                        eventX[c] += secondRect.Key + " - ";
                        markEvents.Add(secondRect.Key, true);

                        //save ending event if not add
                        if (!endingEvents.Contains(secondRect.Key))
                        {
                            Array.Resize(ref endingEvents, endingEvents.Length + 1);
                            endingEvents[endingEvents.Length - 1] = secondRect.Key;
                        }
                        break;
                    }
                    
                    //up
                    if ((firstRect[0] == 'И' && Char.IsDigit(firstRect[1])))
                    {
                        //for distinct branches "И"
                        markBranches.Add(secondRect.Key, true);

                        int countBranches = 1;

                        //all ways from "И"
                        foreach (var a in listArcs)
                        {
                            //down (by other branch) (not from come here)
                            if (a.Value == firstRect && a.Key != secondRect.Key && !markBranches.Keys.Contains(a.Key))
                            {
                                countBranches++;

                                //for "И"
                                onlyOneTime = false;

                                FoundNextRect(c, a.Key);

                                //put
                                bool endEvent2 = true;
                                foreach (var ar in listArcs)
                                {
                                    if (ar.Value == a.Key)
                                    {
                                        endEvent2 = false;
                                        break;
                                    }
                                }

                                //save (previously check on lower rect, check on two distinct rect, check on distinct arcs)
                                if (endEvent2 == true && !markEvents.Keys.Contains(secondRect.Key) && !eventX.Contains(eventX[c] + secondRect.Key + " - "))
                                {
                                    eventX[c] += secondRect.Key + " - ";
                                    markEvents.Add(secondRect.Key, true);
                                }

                                int times = 0;
                                for (int i = 2; i < eventX[c].Length; i++)
                                {
                                    if (eventX[c][i] == ' ' && eventX[c][i - 1] == '-' && eventX[c][i - 2] == ' ')
                                        times++;
                                }

                                if (countBranches != times)
                                {
                                    failEventX[c] = true;
                                }
                                else
                                {
                                    failEventX[c] = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}