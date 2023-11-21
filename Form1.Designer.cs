namespace KaliInjecteur
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtPID = new TextBox();
            txtDLLPath = new TextBox();
            tableProcess = new ListBox();
            actualiser = new Button();
            parcourir = new Button();
            injecter = new Button();
            enregistrer = new Button();
            charger = new Button();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 192, 255);
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 13);
            label1.TabIndex = 0;
            label1.Text = "Processus";
            // 
            // txtPID
            // 
            txtPID.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPID.ForeColor = Color.Black;
            txtPID.Location = new Point(73, 12);
            txtPID.Name = "txtPID";
            txtPID.Size = new Size(100, 20);
            txtPID.TabIndex = 2;
            txtPID.Text = "GTA5";
            // 
            // txtDLLPath
            // 
            txtDLLPath.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtDLLPath.Location = new Point(11, 191);
            txtDLLPath.Name = "txtDLLPath";
            txtDLLPath.PlaceholderText = "Chemin de la DLL";
            txtDLLPath.Size = new Size(161, 20);
            txtDLLPath.TabIndex = 3;
            // 
            // tableProcess
            // 
            tableProcess.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            tableProcess.FormattingEnabled = true;
            tableProcess.Location = new Point(12, 38);
            tableProcess.Name = "tableProcess";
            tableProcess.Size = new Size(250, 147);
            tableProcess.TabIndex = 4;
            tableProcess.SelectedIndexChanged += tableProcess_SelectedIndexChanged;
            // 
            // actualiser
            // 
            actualiser.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            actualiser.Location = new Point(179, 10);
            actualiser.Name = "actualiser";
            actualiser.Size = new Size(75, 23);
            actualiser.TabIndex = 5;
            actualiser.Text = "Actualiser";
            actualiser.UseVisualStyleBackColor = true;
            actualiser.Click += actualiser_Click;
            // 
            // parcourir
            // 
            parcourir.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            parcourir.Location = new Point(179, 189);
            parcourir.Name = "parcourir";
            parcourir.Size = new Size(75, 23);
            parcourir.TabIndex = 6;
            parcourir.Text = "Parcourir";
            parcourir.UseVisualStyleBackColor = true;
            parcourir.Click += parcourir_Click;
            // 
            // injecter
            // 
            injecter.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            injecter.Location = new Point(179, 245);
            injecter.Name = "injecter";
            injecter.Size = new Size(75, 23);
            injecter.TabIndex = 7;
            injecter.Text = "Injecter";
            injecter.UseVisualStyleBackColor = true;
            injecter.Click += injecter_Click;
            // 
            // enregistrer
            // 
            enregistrer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            enregistrer.Location = new Point(11, 274);
            enregistrer.Name = "enregistrer";
            enregistrer.Size = new Size(75, 23);
            enregistrer.TabIndex = 8;
            enregistrer.Text = "Enregistrer";
            enregistrer.UseVisualStyleBackColor = true;
            enregistrer.Click += enregistrer_Click;
            // 
            // charger
            // 
            charger.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            charger.Location = new Point(179, 274);
            charger.Name = "charger";
            charger.Size = new Size(75, 23);
            charger.TabIndex = 9;
            charger.Text = "Charger";
            charger.UseVisualStyleBackColor = true;
            charger.Click += charger_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.FromArgb(255, 192, 255);
            checkBox1.Location = new Point(10, 218);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(178, 17);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "attendre le processus pendant : ";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(179, 216);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(41, 23);
            numericUpDown1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 192, 255);
            label2.Location = new Point(226, 219);
            label2.Name = "label2";
            label2.Size = new Size(20, 13);
            label2.TabIndex = 12;
            label2.Text = "ms";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(266, 309);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(charger);
            Controls.Add(enregistrer);
            Controls.Add(injecter);
            Controls.Add(parcourir);
            Controls.Add(actualiser);
            Controls.Add(tableProcess);
            Controls.Add(txtDLLPath);
            Controls.Add(txtPID);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "InjecteurKali";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPID;
        private TextBox txtDLLPath;
        private ListBox tableProcess;
        private Button actualiser;
        private Button parcourir;
        private Button injecter;
        private Button enregistrer;
        private Button charger;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private Label label2;
    }
}