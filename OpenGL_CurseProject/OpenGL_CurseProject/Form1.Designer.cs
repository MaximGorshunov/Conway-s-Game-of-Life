namespace OpenGL_CurseProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.comboBoxView = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.comboBoxPresets = new System.Windows.Forms.ComboBox();
            this.comboBoxCreatures = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RenderTimer
            // 
            this.RenderTimer.Interval = 25;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(21, 65);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(1269, 724);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // comboBoxView
            // 
            this.comboBoxView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Items.AddRange(new object[] {
            "Default View",
            "View from the ground",
            "View from above",
            "View from right side",
            "View from left side"});
            this.comboBoxView.Location = new System.Drawing.Point(21, 27);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(121, 21);
            this.comboBoxView.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(586, 25);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(586, 25);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 3;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Visible = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // comboBoxPresets
            // 
            this.comboBoxPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPresets.FormattingEnabled = true;
            this.comboBoxPresets.Items.AddRange(new object[] {
            "-none-",
            "Глайдер",
            "Баржа",
            "Кос. Корабль"});
            this.comboBoxPresets.Location = new System.Drawing.Point(158, 27);
            this.comboBoxPresets.Name = "comboBoxPresets";
            this.comboBoxPresets.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPresets.TabIndex = 4;
            this.comboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.comboBoxPresets_SelectedIndexChanged);
            // 
            // comboBoxCreatures
            // 
            this.comboBoxCreatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCreatures.FormattingEnabled = true;
            this.comboBoxCreatures.Items.AddRange(new object[] {
            "Сфера",
            "Гриб",
            "Елка",
            "Человек"});
            this.comboBoxCreatures.Location = new System.Drawing.Point(295, 27);
            this.comboBoxCreatures.Name = "comboBoxCreatures";
            this.comboBoxCreatures.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCreatures.TabIndex = 5;
            this.comboBoxCreatures.SelectedIndexChanged += new System.EventHandler(this.comboBoxCreatures_SelectedIndexChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(863, 27);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(13, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "0";
            // 
            // labelTimeText
            // 
            this.labelTimeText.AutoSize = true;
            this.labelTimeText.Location = new System.Drawing.Point(814, 27);
            this.labelTimeText.Name = "labelTimeText";
            this.labelTimeText.Size = new System.Drawing.Size(43, 13);
            this.labelTimeText.TabIndex = 7;
            this.labelTimeText.Text = "Время:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(814, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Население:";
            // 
            // labelPopulation
            // 
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Location = new System.Drawing.Point(886, 40);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Size = new System.Drawing.Size(13, 13);
            this.labelPopulation.TabIndex = 9;
            this.labelPopulation.Text = "0";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(667, 25);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 10;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Visible = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Вид камеры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Пресеты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Существо";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 801);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelPopulation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTimeText);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.comboBoxCreatures);
            this.Controls.Add(this.comboBoxPresets);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxView);
            this.Controls.Add(this.AnT);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Gorshunov";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnT_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer RenderTimer;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.ComboBox comboBoxView;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.ComboBox comboBoxPresets;
        private System.Windows.Forms.ComboBox comboBoxCreatures;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTimeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPopulation;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

