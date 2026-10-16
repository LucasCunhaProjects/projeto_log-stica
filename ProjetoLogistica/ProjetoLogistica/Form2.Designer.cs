namespace ProjetoLogistica
{
    partial class Form2
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
            this.btn_Entrar = new System.Windows.Forms.Button();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Senha = new System.Windows.Forms.Label();
            this.txt_Login = new System.Windows.Forms.TextBox();
            this.txt_Senha = new System.Windows.Forms.TextBox();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.btn_Encerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Entrar
            // 
            this.btn_Entrar.Location = new System.Drawing.Point(354, 271);
            this.btn_Entrar.Name = "btn_Entrar";
            this.btn_Entrar.Size = new System.Drawing.Size(98, 31);
            this.btn_Entrar.TabIndex = 0;
            this.btn_Entrar.Text = "Entrar";
            this.btn_Entrar.UseVisualStyleBackColor = true;
            this.btn_Entrar.Click += new System.EventHandler(this.btn_Entrar_Click);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(238, 176);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(50, 18);
            this.lbl_Email.TabIndex = 1;
            this.lbl_Email.Text = "E-mail";
            // 
            // lbl_Senha
            // 
            this.lbl_Senha.AutoSize = true;
            this.lbl_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Senha.Location = new System.Drawing.Point(238, 223);
            this.lbl_Senha.Name = "lbl_Senha";
            this.lbl_Senha.Size = new System.Drawing.Size(50, 18);
            this.lbl_Senha.TabIndex = 2;
            this.lbl_Senha.Text = "Senha";
            // 
            // txt_Login
            // 
            this.txt_Login.Location = new System.Drawing.Point(294, 174);
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(252, 20);
            this.txt_Login.TabIndex = 3;
            // 
            // txt_Senha
            // 
            this.txt_Senha.Location = new System.Drawing.Point(294, 221);
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(252, 20);
            this.txt_Senha.TabIndex = 4;
            this.txt_Senha.UseSystemPasswordChar = true;
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.Location = new System.Drawing.Point(241, 369);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(98, 31);
            this.btn_Cadastrar.TabIndex = 5;
            this.btn_Cadastrar.Text = "Cadastre-se";
            this.btn_Cadastrar.UseVisualStyleBackColor = true;
            this.btn_Cadastrar.Click += new System.EventHandler(this.btn_Cadastrar_Click);
            // 
            // btn_Encerrar
            // 
            this.btn_Encerrar.Location = new System.Drawing.Point(690, 407);
            this.btn_Encerrar.Name = "btn_Encerrar";
            this.btn_Encerrar.Size = new System.Drawing.Size(98, 31);
            this.btn_Encerrar.TabIndex = 6;
            this.btn_Encerrar.Text = "Encerrar";
            this.btn_Encerrar.UseVisualStyleBackColor = true;
            this.btn_Encerrar.Click += new System.EventHandler(this.btn_Encerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "SISTEMA DE VIAGENS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gestão de Rotas e Frotas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Não possui cadastro?";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Encerrar);
            this.Controls.Add(this.btn_Cadastrar);
            this.Controls.Add(this.txt_Senha);
            this.Controls.Add(this.txt_Login);
            this.Controls.Add(this.lbl_Senha);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.btn_Entrar);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Entrar;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Senha;
        private System.Windows.Forms.TextBox txt_Login;
        private System.Windows.Forms.TextBox txt_Senha;
        private System.Windows.Forms.Button btn_Cadastrar;
        private System.Windows.Forms.Button btn_Encerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}