﻿namespace Laba_6_OOP
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Circle = new System.Windows.Forms.Button();
            this.Button_Square = new System.Windows.Forms.Button();
            this.Button_Rectangular = new System.Windows.Forms.Button();
            this.change_color_button = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.resize_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1267, 591);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(884, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(959, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Button_Circle
            // 
            this.Button_Circle.Location = new System.Drawing.Point(39, 32);
            this.Button_Circle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Circle.Name = "Button_Circle";
            this.Button_Circle.Size = new System.Drawing.Size(113, 28);
            this.Button_Circle.TabIndex = 5;
            this.Button_Circle.Text = "Круг";
            this.Button_Circle.UseVisualStyleBackColor = true;
            this.Button_Circle.Click += new System.EventHandler(this.Button_Circle_Click);
            // 
            // Button_Square
            // 
            this.Button_Square.Location = new System.Drawing.Point(160, 32);
            this.Button_Square.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Square.Name = "Button_Square";
            this.Button_Square.Size = new System.Drawing.Size(119, 28);
            this.Button_Square.TabIndex = 6;
            this.Button_Square.Text = "Квадрат";
            this.Button_Square.UseVisualStyleBackColor = true;
            this.Button_Square.Click += new System.EventHandler(this.Button_Square_Click);
            // 
            // Button_Rectangular
            // 
            this.Button_Rectangular.Location = new System.Drawing.Point(287, 32);
            this.Button_Rectangular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Rectangular.Name = "Button_Rectangular";
            this.Button_Rectangular.Size = new System.Drawing.Size(119, 28);
            this.Button_Rectangular.TabIndex = 7;
            this.Button_Rectangular.Text = "Треугольник";
            this.Button_Rectangular.UseVisualStyleBackColor = true;
            this.Button_Rectangular.Click += new System.EventHandler(this.Button_Rectangular_Click_1);
            // 
            // change_color_button
            // 
            this.change_color_button.Location = new System.Drawing.Point(497, 15);
            this.change_color_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.change_color_button.Name = "change_color_button";
            this.change_color_button.Size = new System.Drawing.Size(127, 66);
            this.change_color_button.TabIndex = 8;
            this.change_color_button.Text = "Изменить цвет объекта";
            this.change_color_button.UseVisualStyleBackColor = true;
            this.change_color_button.Click += new System.EventHandler(this.change_color_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Изменить размер объекта";
            // 
            // resize_box
            // 
            this.resize_box.Location = new System.Drawing.Point(671, 57);
            this.resize_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resize_box.Name = "resize_box";
            this.resize_box.Size = new System.Drawing.Size(132, 22);
            this.resize_box.TabIndex = 10;
            this.resize_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resize_box_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.resize_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.change_color_button);
            this.Controls.Add(this.Button_Rectangular);
            this.Controls.Add(this.Button_Square);
            this.Controls.Add(this.Button_Circle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Circle;
        private System.Windows.Forms.Button Button_Square;
        private System.Windows.Forms.Button Button_Rectangular;
        private System.Windows.Forms.Button change_color_button;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resize_box;
    }
}

