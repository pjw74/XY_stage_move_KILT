namespace XY_stage_move
{
    partial class Form1
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
            this.stg_con = new System.Windows.Forms.Button();
            this.stg_dis = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sv_on = new System.Windows.Forms.Button();
            this.sv_off = new System.Windows.Forms.Button();
            this.origin = new System.Windows.Forms.Button();
            this.jog_move = new System.Windows.Forms.Button();
            this.MOTOR_SPEED = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.error_1 = new System.Windows.Forms.Button();
            this.x_array = new System.Windows.Forms.NumericUpDown();
            this.y_array = new System.Windows.Forms.NumericUpDown();
            this.pitch_val_x = new System.Windows.Forms.NumericUpDown();
            this.mtr_spd = new System.Windows.Forms.NumericUpDown();
            this.spd_set = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.y_up = new System.Windows.Forms.Button();
            this.y_down = new System.Windows.Forms.Button();
            this.x_left = new System.Windows.Forms.Button();
            this.x_right = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.str_pt_x = new System.Windows.Forms.NumericUpDown();
            this.str_pt_y = new System.Windows.Forms.NumericUpDown();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Baud_Combox = new System.Windows.Forms.ComboBox();
            this.Port_Combox = new System.Windows.Forms.ComboBox();
            this.Close_btn = new System.Windows.Forms.Button();
            this.Open_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button_shutter_close = new System.Windows.Forms.Button();
            this.button_shutter_open = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.exposure_time = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pitch_val_y = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.image_up = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.delay_time = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lb_x_position = new System.Windows.Forms.Label();
            this.lb_y_position = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.posi_chk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.x_array)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_array)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtr_spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposure_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_y)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delay_time)).BeginInit();
            this.SuspendLayout();
            // 
            // stg_con
            // 
            this.stg_con.Location = new System.Drawing.Point(28, 22);
            this.stg_con.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stg_con.Name = "stg_con";
            this.stg_con.Size = new System.Drawing.Size(140, 28);
            this.stg_con.TabIndex = 0;
            this.stg_con.Text = "STAGE CONNECT";
            this.stg_con.UseVisualStyleBackColor = true;
            this.stg_con.Click += new System.EventHandler(this.stg_con_Click);
            // 
            // stg_dis
            // 
            this.stg_dis.Location = new System.Drawing.Point(170, 22);
            this.stg_dis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stg_dis.Name = "stg_dis";
            this.stg_dis.Size = new System.Drawing.Size(161, 28);
            this.stg_dis.TabIndex = 1;
            this.stg_dis.Text = "STAGE DISCONNECT";
            this.stg_dis.UseVisualStyleBackColor = true;
            this.stg_dis.Click += new System.EventHandler(this.stg_dis_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 172);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 29);
            this.textBox1.TabIndex = 2;
            // 
            // sv_on
            // 
            this.sv_on.Location = new System.Drawing.Point(17, 29);
            this.sv_on.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sv_on.Name = "sv_on";
            this.sv_on.Size = new System.Drawing.Size(88, 29);
            this.sv_on.TabIndex = 3;
            this.sv_on.Text = "SERVO ON";
            this.sv_on.UseVisualStyleBackColor = true;
            this.sv_on.Click += new System.EventHandler(this.sv_on_Click);
            // 
            // sv_off
            // 
            this.sv_off.Location = new System.Drawing.Point(17, 69);
            this.sv_off.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sv_off.Name = "sv_off";
            this.sv_off.Size = new System.Drawing.Size(88, 29);
            this.sv_off.TabIndex = 4;
            this.sv_off.Text = "SERVO OFF";
            this.sv_off.UseVisualStyleBackColor = true;
            this.sv_off.Click += new System.EventHandler(this.sv_off_Click);
            // 
            // origin
            // 
            this.origin.BackColor = System.Drawing.Color.Blue;
            this.origin.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.origin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.origin.Location = new System.Drawing.Point(170, 66);
            this.origin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(161, 28);
            this.origin.TabIndex = 6;
            this.origin.Text = "ORIGIN MOVE";
            this.origin.UseVisualStyleBackColor = false;
            this.origin.Click += new System.EventHandler(this.origin_Click);
            // 
            // jog_move
            // 
            this.jog_move.BackColor = System.Drawing.Color.Red;
            this.jog_move.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.jog_move.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.jog_move.Location = new System.Drawing.Point(470, 199);
            this.jog_move.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.jog_move.Name = "jog_move";
            this.jog_move.Size = new System.Drawing.Size(162, 36);
            this.jog_move.TabIndex = 7;
            this.jog_move.Text = "START";
            this.jog_move.UseVisualStyleBackColor = false;
            this.jog_move.Click += new System.EventHandler(this.jog_move_Click);
            // 
            // MOTOR_SPEED
            // 
            this.MOTOR_SPEED.AutoSize = true;
            this.MOTOR_SPEED.Location = new System.Drawing.Point(16, 48);
            this.MOTOR_SPEED.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MOTOR_SPEED.Name = "MOTOR_SPEED";
            this.MOTOR_SPEED.Size = new System.Drawing.Size(94, 12);
            this.MOTOR_SPEED.TabIndex = 8;
            this.MOTOR_SPEED.Text = "MOTOR SPEED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "PITCH X-AXIS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "ARRAY (X x Y)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            // 
            // error_1
            // 
            this.error_1.Location = new System.Drawing.Point(111, 68);
            this.error_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.error_1.Name = "error_1";
            this.error_1.Size = new System.Drawing.Size(105, 29);
            this.error_1.TabIndex = 13;
            this.error_1.Text = "ERROR RESET";
            this.error_1.UseVisualStyleBackColor = true;
            this.error_1.Click += new System.EventHandler(this.button1_Click);
            // 
            // x_array
            // 
            this.x_array.Location = new System.Drawing.Point(155, 207);
            this.x_array.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.x_array.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.x_array.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.x_array.Name = "x_array";
            this.x_array.Size = new System.Drawing.Size(45, 21);
            this.x_array.TabIndex = 23;
            this.x_array.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // y_array
            // 
            this.y_array.Location = new System.Drawing.Point(224, 207);
            this.y_array.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.y_array.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.y_array.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.y_array.Name = "y_array";
            this.y_array.Size = new System.Drawing.Size(45, 21);
            this.y_array.TabIndex = 24;
            this.y_array.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pitch_val_x
            // 
            this.pitch_val_x.DecimalPlaces = 3;
            this.pitch_val_x.Location = new System.Drawing.Point(155, 147);
            this.pitch_val_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pitch_val_x.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.pitch_val_x.Name = "pitch_val_x";
            this.pitch_val_x.Size = new System.Drawing.Size(94, 21);
            this.pitch_val_x.TabIndex = 21;
            // 
            // mtr_spd
            // 
            this.mtr_spd.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.mtr_spd.Location = new System.Drawing.Point(155, 46);
            this.mtr_spd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mtr_spd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mtr_spd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mtr_spd.Name = "mtr_spd";
            this.mtr_spd.Size = new System.Drawing.Size(94, 21);
            this.mtr_spd.TabIndex = 18;
            this.mtr_spd.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // spd_set
            // 
            this.spd_set.Location = new System.Drawing.Point(111, 29);
            this.spd_set.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.spd_set.Name = "spd_set";
            this.spd_set.Size = new System.Drawing.Size(105, 27);
            this.spd_set.TabIndex = 19;
            this.spd_set.Text = "SPEED SET";
            this.spd_set.UseVisualStyleBackColor = true;
            this.spd_set.Click += new System.EventHandler(this.spd_set_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "Y-AXIS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "X-AXIS";
            // 
            // y_up
            // 
            this.y_up.Location = new System.Drawing.Point(94, 53);
            this.y_up.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.y_up.Name = "y_up";
            this.y_up.Size = new System.Drawing.Size(75, 25);
            this.y_up.TabIndex = 23;
            this.y_up.Text = "UP";
            this.y_up.UseVisualStyleBackColor = true;
            this.y_up.Click += new System.EventHandler(this.y_up_Click);
            // 
            // y_down
            // 
            this.y_down.Location = new System.Drawing.Point(177, 53);
            this.y_down.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.y_down.Name = "y_down";
            this.y_down.Size = new System.Drawing.Size(79, 25);
            this.y_down.TabIndex = 24;
            this.y_down.Text = "DOWN";
            this.y_down.UseVisualStyleBackColor = true;
            this.y_down.Click += new System.EventHandler(this.y_down_Click);
            // 
            // x_left
            // 
            this.x_left.Location = new System.Drawing.Point(94, 86);
            this.x_left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.x_left.Name = "x_left";
            this.x_left.Size = new System.Drawing.Size(75, 25);
            this.x_left.TabIndex = 25;
            this.x_left.Text = "LEFT";
            this.x_left.UseVisualStyleBackColor = true;
            this.x_left.Click += new System.EventHandler(this.x_left_Click);
            // 
            // x_right
            // 
            this.x_right.Location = new System.Drawing.Point(177, 86);
            this.x_right.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.x_right.Name = "x_right";
            this.x_right.Size = new System.Drawing.Size(79, 25);
            this.x_right.TabIndex = 26;
            this.x_right.Text = "RIGHT";
            this.x_right.UseVisualStyleBackColor = true;
            this.x_right.Click += new System.EventHandler(this.x_right_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "START  POINT(X)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "START  POINT(Y)";
            // 
            // str_pt_x
            // 
            this.str_pt_x.DecimalPlaces = 3;
            this.str_pt_x.Location = new System.Drawing.Point(155, 83);
            this.str_pt_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.str_pt_x.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.str_pt_x.Name = "str_pt_x";
            this.str_pt_x.Size = new System.Drawing.Size(94, 21);
            this.str_pt_x.TabIndex = 19;
            // 
            // str_pt_y
            // 
            this.str_pt_y.DecimalPlaces = 3;
            this.str_pt_y.Location = new System.Drawing.Point(155, 109);
            this.str_pt_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.str_pt_y.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.str_pt_y.Name = "str_pt_y";
            this.str_pt_y.Size = new System.Drawing.Size(94, 21);
            this.str_pt_y.TabIndex = 20;
            // 
            // Baud_Combox
            // 
            this.Baud_Combox.FormattingEnabled = true;
            this.Baud_Combox.Items.AddRange(new object[] {
            "9600"});
            this.Baud_Combox.Location = new System.Drawing.Point(155, 333);
            this.Baud_Combox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baud_Combox.Name = "Baud_Combox";
            this.Baud_Combox.Size = new System.Drawing.Size(95, 20);
            this.Baud_Combox.TabIndex = 36;
            this.Baud_Combox.Text = "9600";
            // 
            // Port_Combox
            // 
            this.Port_Combox.FormattingEnabled = true;
            this.Port_Combox.Location = new System.Drawing.Point(29, 80);
            this.Port_Combox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port_Combox.Name = "Port_Combox";
            this.Port_Combox.Size = new System.Drawing.Size(95, 20);
            this.Port_Combox.TabIndex = 17;
            // 
            // Close_btn
            // 
            this.Close_btn.Location = new System.Drawing.Point(170, 111);
            this.Close_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(161, 29);
            this.Close_btn.TabIndex = 34;
            this.Close_btn.Text = "SHUTTER DISCONNECT";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // Open_btn
            // 
            this.Open_btn.Location = new System.Drawing.Point(28, 111);
            this.Open_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_btn.Name = "Open_btn";
            this.Open_btn.Size = new System.Drawing.Size(140, 29);
            this.Open_btn.TabIndex = 33;
            this.Open_btn.Text = "SHUTTER CONNECT";
            this.Open_btn.UseVisualStyleBackColor = true;
            this.Open_btn.Click += new System.EventHandler(this.Open_btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "SHUTTER BAUD RATE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "Shutter COM Port";
            // 
            // button_shutter_close
            // 
            this.button_shutter_close.Location = new System.Drawing.Point(106, 138);
            this.button_shutter_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_shutter_close.Name = "button_shutter_close";
            this.button_shutter_close.Size = new System.Drawing.Size(61, 51);
            this.button_shutter_close.TabIndex = 39;
            this.button_shutter_close.Text = "CLOSE";
            this.button_shutter_close.UseVisualStyleBackColor = true;
            this.button_shutter_close.Click += new System.EventHandler(this.button_shutter_close_Click);
            // 
            // button_shutter_open
            // 
            this.button_shutter_open.Location = new System.Drawing.Point(39, 138);
            this.button_shutter_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_shutter_open.Name = "button_shutter_open";
            this.button_shutter_open.Size = new System.Drawing.Size(61, 51);
            this.button_shutter_open.TabIndex = 38;
            this.button_shutter_open.Text = "OPEN";
            this.button_shutter_open.UseVisualStyleBackColor = true;
            this.button_shutter_open.Click += new System.EventHandler(this.button_shutter_open_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 51);
            this.button1.TabIndex = 40;
            this.button1.Text = "ONE SHOT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "EXPOSURE TIME";
            // 
            // exposure_time
            // 
            this.exposure_time.DecimalPlaces = 1;
            this.exposure_time.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.exposure_time.Location = new System.Drawing.Point(155, 307);
            this.exposure_time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exposure_time.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.exposure_time.Name = "exposure_time";
            this.exposure_time.Size = new System.Drawing.Size(94, 21);
            this.exposure_time.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "PITCH Y-AXIS";
            // 
            // pitch_val_y
            // 
            this.pitch_val_y.DecimalPlaces = 3;
            this.pitch_val_y.Location = new System.Drawing.Point(155, 172);
            this.pitch_val_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pitch_val_y.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.pitch_val_y.Name = "pitch_val_y";
            this.pitch_val_y.Size = new System.Drawing.Size(94, 21);
            this.pitch_val_y.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(252, 113);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 12);
            this.label15.TabIndex = 46;
            this.label15.Text = "(LIMIT 300mm)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(252, 87);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 12);
            this.label16.TabIndex = 47;
            this.label16.Text = "(LIMIT 300mm)";
            // 
            // image_up
            // 
            this.image_up.Location = new System.Drawing.Point(92, 67);
            this.image_up.Name = "image_up";
            this.image_up.Size = new System.Drawing.Size(128, 28);
            this.image_up.TabIndex = 48;
            this.image_up.Text = "LOAD IMAGE";
            this.image_up.UseVisualStyleBackColor = true;
            this.image_up.Click += new System.EventHandler(this.image_up_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.stg_dis);
            this.groupBox1.Controls.Add(this.origin);
            this.groupBox1.Controls.Add(this.Close_btn);
            this.groupBox1.Controls.Add(this.stg_con);
            this.groupBox1.Controls.Add(this.Open_btn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Port_Combox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(29, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 216);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Connection Setting";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "Connection State";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spd_set);
            this.groupBox2.Controls.Add(this.sv_on);
            this.groupBox2.Controls.Add(this.sv_off);
            this.groupBox2.Controls.Add(this.error_1);
            this.groupBox2.Location = new System.Drawing.Point(707, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 118);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller Option";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.y_up);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.y_down);
            this.groupBox3.Controls.Add(this.x_left);
            this.groupBox3.Controls.Add(this.x_right);
            this.groupBox3.Controls.Add(this.button_shutter_open);
            this.groupBox3.Controls.Add(this.button_shutter_close);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(400, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 225);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(43, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 15);
            this.label20.TabIndex = 54;
            this.label20.Text = "* Stage";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(41, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 15);
            this.label19.TabIndex = 53;
            this.label19.Text = "* Shutter";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.image_up);
            this.groupBox4.Location = new System.Drawing.Point(400, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 118);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3. Image Setting";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(24, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(256, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "Array Size와 Image 개수는 일치해야 함.\r\n";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.delay_time);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.MOTOR_SPEED);
            this.groupBox5.Controls.Add(this.x_array);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.y_array);
            this.groupBox5.Controls.Add(this.pitch_val_x);
            this.groupBox5.Controls.Add(this.mtr_spd);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.Baud_Combox);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.str_pt_x);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.pitch_val_y);
            this.groupBox5.Controls.Add(this.str_pt_y);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.exposure_time);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(29, 262);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(364, 366);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "2. Parameter Setting";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(251, 50);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 12);
            this.label25.TabIndex = 59;
            this.label25.Text = "(LIMIT 1~1000)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(251, 243);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 12);
            this.label23.TabIndex = 58;
            this.label23.Text = "(sec)";
            // 
            // delay_time
            // 
            this.delay_time.DecimalPlaces = 1;
            this.delay_time.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.delay_time.Location = new System.Drawing.Point(155, 236);
            this.delay_time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delay_time.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.delay_time.Name = "delay_time";
            this.delay_time.Size = new System.Drawing.Size(94, 21);
            this.delay_time.TabIndex = 25;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 239);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 12);
            this.label24.TabIndex = 57;
            this.label24.Text = "DELAY TIME";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.Location = new System.Drawing.Point(15, 278);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 15);
            this.label22.TabIndex = 55;
            this.label22.Text = "* Shutter";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(15, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 15);
            this.label21.TabIndex = 55;
            this.label21.Text = "* Stage";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(251, 314);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 12);
            this.label14.TabIndex = 50;
            this.label14.Text = "(sec)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(252, 174);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 12);
            this.label12.TabIndex = 49;
            this.label12.Text = "(mm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "(mm)";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(851, 550);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(87, 34);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "4. Job Start";
            this.groupBox6.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(470, 155);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "START POINT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(438, 262);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 12);
            this.label26.TabIndex = 105;
            this.label26.Text = "X Position";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(438, 283);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(62, 12);
            this.label27.TabIndex = 103;
            this.label27.Text = "Y Position";
            // 
            // lb_x_position
            // 
            this.lb_x_position.AutoSize = true;
            this.lb_x_position.Location = new System.Drawing.Point(506, 264);
            this.lb_x_position.Name = "lb_x_position";
            this.lb_x_position.Size = new System.Drawing.Size(57, 12);
            this.lb_x_position.TabIndex = 104;
            this.lb_x_position.Text = "  000.000 ";
            this.lb_x_position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_y_position
            // 
            this.lb_y_position.AutoSize = true;
            this.lb_y_position.Location = new System.Drawing.Point(506, 285);
            this.lb_y_position.Name = "lb_y_position";
            this.lb_y_position.Size = new System.Drawing.Size(57, 12);
            this.lb_y_position.TabIndex = 106;
            this.lb_y_position.Text = "  000.000 ";
            this.lb_y_position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(561, 264);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(27, 12);
            this.label28.TabIndex = 107;
            this.label28.Text = "mm";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(561, 285);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 12);
            this.label29.TabIndex = 108;
            this.label29.Text = "mm";
            // 
            // posi_chk
            // 
            this.posi_chk.Location = new System.Drawing.Point(599, 269);
            this.posi_chk.Name = "posi_chk";
            this.posi_chk.Size = new System.Drawing.Size(88, 25);
            this.posi_chk.TabIndex = 109;
            this.posi_chk.Text = "Position";
            this.posi_chk.Click += new System.EventHandler(this.posi_chk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 644);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.jog_move);
            this.Controls.Add(this.lb_x_position);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lb_y_position);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.posi_chk);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파면프린트(KILT) Y_Down";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.x_array)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_array)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtr_spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.str_pt_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposure_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitch_val_y)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delay_time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stg_con;
        private System.Windows.Forms.Button stg_dis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sv_on;
        private System.Windows.Forms.Button sv_off;
        private System.Windows.Forms.Button origin;
        private System.Windows.Forms.Button jog_move;
        private System.Windows.Forms.Label MOTOR_SPEED;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button error_1;
        private System.Windows.Forms.NumericUpDown x_array;
        private System.Windows.Forms.NumericUpDown y_array;
        private System.Windows.Forms.NumericUpDown pitch_val_x;
        private System.Windows.Forms.NumericUpDown mtr_spd;
        private System.Windows.Forms.Button spd_set;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button y_up;
        private System.Windows.Forms.Button y_down;
        private System.Windows.Forms.Button x_left;
        private System.Windows.Forms.Button x_right;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown str_pt_x;
        private System.Windows.Forms.NumericUpDown str_pt_y;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox Baud_Combox;
        private System.Windows.Forms.ComboBox Port_Combox;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Button Open_btn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_shutter_close;
        private System.Windows.Forms.Button button_shutter_open;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown exposure_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pitch_val_y;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button image_up;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown delay_time;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lb_x_position;
        private System.Windows.Forms.Label lb_y_position;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button posi_chk;
    }
}

