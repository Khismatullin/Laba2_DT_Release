namespace Laba2_DT_Release
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_evaluationProbability = new System.Windows.Forms.TextBox();
            this.textBox_risk = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxNameVertex = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.dataGridViewProbEvents = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCostOfLosses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxFAL = new System.Windows.Forms.RichTextBox();
            this.richTextBoxProbabilityFunction = new System.Windows.Forms.RichTextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1237, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ресурс \"Сервер\" (ОС \"Отказ сервера\")";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1665, 32);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(71, 29);
            this.toolStripDropDownButton1.Text = "Файл";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(182, 30);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(182, 30);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1180, 744);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Оценка вероятности реализации ОС";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1180, 777);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Стоимость потери от реализации ОС";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1180, 808);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Риск от реализации ОС";
            // 
            // textBox_evaluationProbability
            // 
            this.textBox_evaluationProbability.Location = new System.Drawing.Point(1526, 740);
            this.textBox_evaluationProbability.Name = "textBox_evaluationProbability";
            this.textBox_evaluationProbability.Size = new System.Drawing.Size(100, 26);
            this.textBox_evaluationProbability.TabIndex = 18;
            this.textBox_evaluationProbability.Text = "0";
            // 
            // textBox_risk
            // 
            this.textBox_risk.Location = new System.Drawing.Point(1526, 807);
            this.textBox_risk.Name = "textBox_risk";
            this.textBox_risk.Size = new System.Drawing.Size(100, 26);
            this.textBox_risk.TabIndex = 19;
            this.textBox_risk.Text = "0";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(993, 787);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(160, 43);
            this.button_exit.TabIndex = 20;
            this.button_exit.Text = "Выход (ESC)";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1141, 743);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textBoxNameVertex
            // 
            this.textBoxNameVertex.Location = new System.Drawing.Point(12, 804);
            this.textBoxNameVertex.Name = "textBoxNameVertex";
            this.textBoxNameVertex.Size = new System.Drawing.Size(408, 26);
            this.textBoxNameVertex.TabIndex = 1;
            this.textBoxNameVertex.Text = "НовоеИмя";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 781);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Имя добавляемого события";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(806, 787);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(181, 43);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // dataGridViewProbEvents
            // 
            this.dataGridViewProbEvents.AllowUserToAddRows = false;
            this.dataGridViewProbEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProbEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewProbEvents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProbEvents.ColumnHeadersHeight = 22;
            this.dataGridViewProbEvents.Location = new System.Drawing.Point(1184, 89);
            this.dataGridViewProbEvents.Name = "dataGridViewProbEvents";
            this.dataGridViewProbEvents.RowHeadersWidth = 48;
            this.dataGridViewProbEvents.RowTemplate.Height = 28;
            this.dataGridViewProbEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProbEvents.Size = new System.Drawing.Size(442, 309);
            this.dataGridViewProbEvents.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1179, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Вероятности реализации инициирующих событий";
            // 
            // textBoxCostOfLosses
            // 
            this.textBoxCostOfLosses.Location = new System.Drawing.Point(1526, 775);
            this.textBoxCostOfLosses.Name = "textBoxCostOfLosses";
            this.textBoxCostOfLosses.Size = new System.Drawing.Size(100, 26);
            this.textBoxCostOfLosses.TabIndex = 36;
            this.textBoxCostOfLosses.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1179, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Функция алгебры логики";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1178, 602);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "Вероятностная функция";
            // 
            // richTextBoxFAL
            // 
            this.richTextBoxFAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxFAL.Location = new System.Drawing.Point(1182, 483);
            this.richTextBoxFAL.Name = "richTextBoxFAL";
            this.richTextBoxFAL.Size = new System.Drawing.Size(443, 106);
            this.richTextBoxFAL.TabIndex = 41;
            this.richTextBoxFAL.Text = "";
            // 
            // richTextBoxProbabilityFunction
            // 
            this.richTextBoxProbabilityFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxProbabilityFunction.Location = new System.Drawing.Point(1183, 625);
            this.richTextBoxProbabilityFunction.Name = "richTextBoxProbabilityFunction";
            this.richTextBoxProbabilityFunction.Size = new System.Drawing.Size(442, 109);
            this.richTextBoxProbabilityFunction.TabIndex = 42;
            this.richTextBoxProbabilityFunction.Text = "";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(1182, 404);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(151, 43);
            this.buttonCalculate.TabIndex = 43;
            this.buttonCalculate.Text = "Вычислить";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 843);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.richTextBoxProbabilityFunction);
            this.Controls.Add(this.richTextBoxFAL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCostOfLosses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewProbEvents);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxNameVertex);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.textBox_risk);
            this.Controls.Add(this.textBox_evaluationProbability);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1678, 871);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЛР №2 \"Логико-вероятностный метод\" Хисматуллин А. И. ПРО-409";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProbEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_evaluationProbability;
        private System.Windows.Forms.TextBox textBox_risk;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxNameVertex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridView dataGridViewProbEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCostOfLosses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richTextBoxFAL;
        private System.Windows.Forms.RichTextBox richTextBoxProbabilityFunction;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

