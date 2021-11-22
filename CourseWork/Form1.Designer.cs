
namespace CourseWork
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Хеш = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Номер = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Описание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Номер1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Проблема1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фио1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фио2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(402, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Хеш,
            this.Column1,
            this.Номер,
            this.Описание,
            this.Дата});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(524, 224);
            this.dataGridView1.TabIndex = 4;
            // 
            // Хеш
            // 
            this.Хеш.HeaderText = "Первичный хеш";
            this.Хеш.MinimumWidth = 8;
            this.Хеш.Name = "Хеш";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Хеш";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Номер
            // 
            this.Номер.HeaderText = "Номер телефона";
            this.Номер.MinimumWidth = 8;
            this.Номер.Name = "Номер";
            // 
            // Описание
            // 
            this.Описание.HeaderText = "Описание проблемы";
            this.Описание.MinimumWidth = 8;
            this.Описание.Name = "Описание";
            // 
            // Дата
            // 
            this.Дата.HeaderText = "Дата заявки";
            this.Дата.MinimumWidth = 8;
            this.Дата.Name = "Дата";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(-1, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Добавить заявку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(143, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 37);
            this.button4.TabIndex = 8;
            this.button4.Text = "Удалить заявку";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(295, 272);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 37);
            this.button5.TabIndex = 9;
            this.button5.Text = "Поиск заявки";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(430, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 37);
            this.button6.TabIndex = 10;
            this.button6.Text = "Назад ко всем заявкам";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Номер1,
            this.Проблема1,
            this.Фио1,
            this.Фио2,
            this.Дата1});
            this.dataGridView2.Location = new System.Drawing.Point(670, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.Size = new System.Drawing.Size(564, 224);
            this.dataGridView2.TabIndex = 11;
            // 
            // Номер1
            // 
            this.Номер1.HeaderText = "Дата заявки";
            this.Номер1.MinimumWidth = 8;
            this.Номер1.Name = "Номер1";
            // 
            // Проблема1
            // 
            this.Проблема1.HeaderText = "Описание проблемы";
            this.Проблема1.MinimumWidth = 8;
            this.Проблема1.Name = "Проблема1";
            // 
            // Фио1
            // 
            this.Фио1.HeaderText = "ФИО заказчика";
            this.Фио1.MinimumWidth = 8;
            this.Фио1.Name = "Фио1";
            // 
            // Фио2
            // 
            this.Фио2.HeaderText = "ФИО работника";
            this.Фио2.MinimumWidth = 8;
            this.Фио2.Name = "Фио2";
            // 
            // Дата1
            // 
            this.Дата1.HeaderText = "Номер телефона";
            this.Дата1.MinimumWidth = 8;
            this.Дата1.Name = "Дата1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(670, 272);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 49);
            this.button8.TabIndex = 13;
            this.button8.Text = "Добавить обработанную заявку";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(833, 272);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(92, 49);
            this.button9.TabIndex = 14;
            this.button9.Text = "Удалить обработанную заявку";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1001, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(92, 49);
            this.button10.TabIndex = 15;
            this.button10.Text = "Поиск по диапазону дат";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1142, 272);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(92, 49);
            this.button11.TabIndex = 16;
            this.button11.Text = "Назад ко всем обработанным заявкам";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(505, 401);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(92, 49);
            this.button12.TabIndex = 17;
            this.button12.Text = "Назад к выбору справочника";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(646, 401);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(92, 49);
            this.button13.TabIndex = 18;
            this.button13.Text = "Выйти и сохранить";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1265, 666);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Хеш;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер;
        private System.Windows.Forms.DataGridViewTextBoxColumn Описание;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Проблема1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фио1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фио2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата1;
    }
}

