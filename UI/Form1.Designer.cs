namespace UI
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
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            label4 = new Label();
            cmbCurso = new ComboBox();
            label5 = new Label();
            txtPromedio = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtIdEstudiante = new TextBox();
            label8 = new Label();
            txtNuevoNombre = new TextBox();
            label9 = new Label();
            txtNuevoPromedio = new TextBox();
            label10 = new Label();
            cmbNuevoCurso = new ComboBox();
            btnModificarEstudiante = new Button();
            btnCargarEstudiante = new Button();
            btnAgregarLista = new Button();
            btnConfirmarLista = new Button();
            label11 = new Label();
            label12 = new Label();
            txtEliminarEstudiante = new TextBox();
            btnEliminarEstudiante = new Button();
            dgvEstudiantes = new DataGridView();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(23, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(241, 23);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 1;
            label1.Text = "Registro de Estudiantes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 36);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 91);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 3;
            label3.Text = "Fecha de Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(23, 109);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(241, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 146);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Curso:";
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(25, 164);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(239, 23);
            cmbCurso.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 198);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 7;
            label5.Text = "Promedio:";
            // 
            // txtPromedio
            // 
            txtPromedio.Location = new Point(25, 216);
            txtPromedio.Name = "txtPromedio";
            txtPromedio.Size = new Size(239, 23);
            txtPromedio.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(361, 9);
            label6.Name = "label6";
            label6.Size = new Size(156, 15);
            label6.TabIndex = 9;
            label6.Text = "Modificación de Estudiantes";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(375, 36);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 10;
            label7.Text = "ID del Estudiante:";
            // 
            // txtIdEstudiante
            // 
            txtIdEstudiante.Location = new Point(375, 56);
            txtIdEstudiante.Name = "txtIdEstudiante";
            txtIdEstudiante.Size = new Size(239, 23);
            txtIdEstudiante.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(375, 91);
            label8.Name = "label8";
            label8.Size = new Size(92, 15);
            label8.TabIndex = 12;
            label8.Text = "Nuevo Nombre:";
            // 
            // txtNuevoNombre
            // 
            txtNuevoNombre.Location = new Point(375, 112);
            txtNuevoNombre.Name = "txtNuevoNombre";
            txtNuevoNombre.Size = new Size(239, 23);
            txtNuevoNombre.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(373, 146);
            label9.Name = "label9";
            label9.Size = new Size(100, 15);
            label9.TabIndex = 14;
            label9.Text = "Nuevo Promedio:";
            // 
            // txtNuevoPromedio
            // 
            txtNuevoPromedio.Location = new Point(373, 164);
            txtNuevoPromedio.Name = "txtNuevoPromedio";
            txtNuevoPromedio.Size = new Size(241, 23);
            txtNuevoPromedio.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(373, 198);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 16;
            label10.Text = "Nuevo Curso:";
            // 
            // cmbNuevoCurso
            // 
            cmbNuevoCurso.FormattingEnabled = true;
            cmbNuevoCurso.Location = new Point(375, 216);
            cmbNuevoCurso.Name = "cmbNuevoCurso";
            cmbNuevoCurso.Size = new Size(239, 23);
            cmbNuevoCurso.TabIndex = 17;
            // 
            // btnModificarEstudiante
            // 
            btnModificarEstudiante.Location = new Point(377, 248);
            btnModificarEstudiante.Name = "btnModificarEstudiante";
            btnModificarEstudiante.Size = new Size(198, 23);
            btnModificarEstudiante.TabIndex = 18;
            btnModificarEstudiante.Text = "Modificar Estudiante";
            btnModificarEstudiante.UseVisualStyleBackColor = true;
            btnModificarEstudiante.Click += btnModificarEstudiante_Click_1;
            // 
            // btnCargarEstudiante
            // 
            btnCargarEstudiante.Location = new Point(45, 248);
            btnCargarEstudiante.Name = "btnCargarEstudiante";
            btnCargarEstudiante.Size = new Size(198, 23);
            btnCargarEstudiante.TabIndex = 19;
            btnCargarEstudiante.Text = "Cargar un Estudiante";
            btnCargarEstudiante.UseVisualStyleBackColor = true;
            btnCargarEstudiante.Click += btnCargarEstudiante_Click_1;
            // 
            // btnAgregarLista
            // 
            btnAgregarLista.Location = new Point(45, 277);
            btnAgregarLista.Name = "btnAgregarLista";
            btnAgregarLista.Size = new Size(198, 23);
            btnAgregarLista.TabIndex = 20;
            btnAgregarLista.Text = "Agregar a la lista";
            btnAgregarLista.UseVisualStyleBackColor = true;
            btnAgregarLista.Click += btnAgregarLista_Click_1;
            // 
            // btnConfirmarLista
            // 
            btnConfirmarLista.Location = new Point(47, 306);
            btnConfirmarLista.Name = "btnConfirmarLista";
            btnConfirmarLista.Size = new Size(198, 23);
            btnConfirmarLista.TabIndex = 21;
            btnConfirmarLista.Text = "Confirmar Lista";
            btnConfirmarLista.UseVisualStyleBackColor = true;
            btnConfirmarLista.Click += btnConfirmarLista_Click_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 339);
            label11.Name = "label11";
            label11.Size = new Size(148, 15);
            label11.TabIndex = 22;
            label11.Text = "Eliminación de Estudiantes";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 368);
            label12.Name = "label12";
            label12.Size = new Size(98, 15);
            label12.TabIndex = 23;
            label12.Text = "ID del Estudiante:";
            // 
            // txtEliminarEstudiante
            // 
            txtEliminarEstudiante.Location = new Point(25, 386);
            txtEliminarEstudiante.Name = "txtEliminarEstudiante";
            txtEliminarEstudiante.Size = new Size(239, 23);
            txtEliminarEstudiante.TabIndex = 24;
            // 
            // btnEliminarEstudiante
            // 
            btnEliminarEstudiante.Location = new Point(45, 415);
            btnEliminarEstudiante.Name = "btnEliminarEstudiante";
            btnEliminarEstudiante.Size = new Size(198, 23);
            btnEliminarEstudiante.TabIndex = 25;
            btnEliminarEstudiante.Text = "Eliminar Estudiante";
            btnEliminarEstudiante.UseVisualStyleBackColor = true;
            btnEliminarEstudiante.Click += btnEliminarEstudiante_Click_1;
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.Location = new Point(375, 324);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.Size = new Size(413, 181);
            dgvEstudiantes.TabIndex = 26;
            dgvEstudiantes.CellClick += dgvEstudiantes_CellClick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(375, 306);
            label13.Name = "label13";
            label13.Size = new Size(133, 15);
            label13.TabIndex = 27;
            label13.Text = "Consulta de Estudiantes";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(label13);
            Controls.Add(dgvEstudiantes);
            Controls.Add(btnEliminarEstudiante);
            Controls.Add(txtEliminarEstudiante);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(btnConfirmarLista);
            Controls.Add(btnAgregarLista);
            Controls.Add(btnCargarEstudiante);
            Controls.Add(btnModificarEstudiante);
            Controls.Add(cmbNuevoCurso);
            Controls.Add(label10);
            Controls.Add(txtNuevoPromedio);
            Controls.Add(label9);
            Controls.Add(txtNuevoNombre);
            Controls.Add(label8);
            Controls.Add(txtIdEstudiante);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtPromedio);
            Controls.Add(label5);
            Controls.Add(cmbCurso);
            Controls.Add(label4);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpFechaNacimiento;
        private Label label4;
        private ComboBox cmbCurso;
        private Label label5;
        private TextBox txtPromedio;
        private Label label6;
        private Label label7;
        private TextBox txtIdEstudiante;
        private Label label8;
        private TextBox txtNuevoNombre;
        private Label label9;
        private TextBox txtNuevoPromedio;
        private Label label10;
        private ComboBox cmbNuevoCurso;
        private Button btnModificarEstudiante;
        private Button btnCargarEstudiante;
        private Button btnAgregarLista;
        private Button btnConfirmarLista;
        private Label label11;
        private Label label12;
        private TextBox txtEliminarEstudiante;
        private Button btnEliminarEstudiante;
        private DataGridView dgvEstudiantes;
        private Label label13;
    }
}
