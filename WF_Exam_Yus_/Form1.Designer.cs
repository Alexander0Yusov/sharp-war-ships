
namespace WF_Exam_Yus_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_head = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.button_create = new System.Windows.Forms.Button();
            this.button_check = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_replay = new System.Windows.Forms.Button();
            this.button_new_game = new System.Windows.Forms.Button();
            this.comboBox_level = new System.Windows.Forms.ComboBox();
            this.comboBox_orientation = new System.Windows.Forms.ComboBox();
            this.label_level = new System.Windows.Forms.Label();
            this.label_orientation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_time_lim = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_fields = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_time_limit = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labe_total_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_head
            // 
            this.label_head.AutoSize = true;
            this.label_head.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_head.Font = new System.Drawing.Font("Bookman Old Style", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_head.Location = new System.Drawing.Point(2, 9);
            this.label_head.MinimumSize = new System.Drawing.Size(857, 50);
            this.label_head.Name = "label_head";
            this.label_head.Size = new System.Drawing.Size(857, 50);
            this.label_head.TabIndex = 0;
            this.label_head.Text = "М о р с к о й   б о й";
            this.label_head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(98, 505);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(330, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar2.Location = new System.Drawing.Point(434, 504);
            this.progressBar2.MarqueeAnimationSpeed = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.RightToLeftLayout = true;
            this.progressBar2.Size = new System.Drawing.Size(330, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 2;
            // 
            // button_create
            // 
            this.button_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_create.Location = new System.Drawing.Point(98, 72);
            this.button_create.MinimumSize = new System.Drawing.Size(60, 20);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(80, 35);
            this.button_create.TabIndex = 3;
            this.button_create.Text = "Создать";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_check
            // 
            this.button_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_check.Location = new System.Drawing.Point(184, 72);
            this.button_check.MinimumSize = new System.Drawing.Size(60, 20);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(80, 35);
            this.button_check.TabIndex = 3;
            this.button_check.Text = "Готово";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(270, 72);
            this.button_start.MinimumSize = new System.Drawing.Size(60, 20);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(80, 35);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Начать";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_replay
            // 
            this.button_replay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_replay.Location = new System.Drawing.Point(653, 72);
            this.button_replay.MinimumSize = new System.Drawing.Size(60, 20);
            this.button_replay.Name = "button_replay";
            this.button_replay.Size = new System.Drawing.Size(110, 35);
            this.button_replay.TabIndex = 3;
            this.button_replay.Text = "Повторить";
            this.button_replay.UseVisualStyleBackColor = true;
            this.button_replay.Click += new System.EventHandler(this.button_replay_Click);
            // 
            // button_new_game
            // 
            this.button_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_new_game.Location = new System.Drawing.Point(547, 72);
            this.button_new_game.MinimumSize = new System.Drawing.Size(60, 20);
            this.button_new_game.Name = "button_new_game";
            this.button_new_game.Size = new System.Drawing.Size(100, 35);
            this.button_new_game.TabIndex = 3;
            this.button_new_game.Text = "Новая игра";
            this.button_new_game.UseVisualStyleBackColor = true;
            this.button_new_game.Click += new System.EventHandler(this.button_new_game_Click);
            // 
            // comboBox_level
            // 
            this.comboBox_level.FormattingEnabled = true;
            this.comboBox_level.Location = new System.Drawing.Point(356, 86);
            this.comboBox_level.Name = "comboBox_level";
            this.comboBox_level.Size = new System.Drawing.Size(90, 21);
            this.comboBox_level.TabIndex = 4;
            // 
            // comboBox_orientation
            // 
            this.comboBox_orientation.FormattingEnabled = true;
            this.comboBox_orientation.Location = new System.Drawing.Point(451, 86);
            this.comboBox_orientation.Name = "comboBox_orientation";
            this.comboBox_orientation.Size = new System.Drawing.Size(90, 21);
            this.comboBox_orientation.TabIndex = 4;
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Location = new System.Drawing.Point(353, 70);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(69, 13);
            this.label_level.TabIndex = 5;
            this.label_level.Text = "Сложность :";
            // 
            // label_orientation
            // 
            this.label_orientation.AutoSize = true;
            this.label_orientation.Location = new System.Drawing.Point(448, 70);
            this.label_orientation.Name = "label_orientation";
            this.label_orientation.Size = new System.Drawing.Size(74, 13);
            this.label_orientation.TabIndex = 5;
            this.label_orientation.Text = "Ориентация :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(95, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Прогресс игрока :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(431, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Прогресс врага :";
            // 
            // label_time_lim
            // 
            this.label_time_lim.AutoSize = true;
            this.label_time_lim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time_lim.Location = new System.Drawing.Point(95, 116);
            this.label_time_lim.Name = "label_time_lim";
            this.label_time_lim.Size = new System.Drawing.Size(120, 17);
            this.label_time_lim.TabIndex = 5;
            this.label_time_lim.Text = "Лимит для хода :";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time.Location = new System.Drawing.Point(534, 116);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(178, 17);
            this.label_time.TabIndex = 5;
            this.label_time.Text = "Продолжительность боя :";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_status.Location = new System.Drawing.Point(387, 116);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(93, 17);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "Удачи в бою!";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(769, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 456);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(2, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 456);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panel_fields
            // 
            this.panel_fields.Location = new System.Drawing.Point(98, 136);
            this.panel_fields.Name = "panel_fields";
            this.panel_fields.Size = new System.Drawing.Size(665, 330);
            this.panel_fields.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_time_limit
            // 
            this.label_time_limit.AutoSize = true;
            this.label_time_limit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time_limit.Location = new System.Drawing.Point(218, 116);
            this.label_time_limit.Name = "label_time_limit";
            this.label_time_limit.Size = new System.Drawing.Size(24, 17);
            this.label_time_limit.TabIndex = 9;
            this.label_time_limit.Text = "00";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labe_total_time
            // 
            this.labe_total_time.AutoSize = true;
            this.labe_total_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labe_total_time.Location = new System.Drawing.Point(718, 116);
            this.labe_total_time.Name = "labe_total_time";
            this.labe_total_time.Size = new System.Drawing.Size(44, 17);
            this.labe_total_time.TabIndex = 10;
            this.labe_total_time.Text = "00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 539);
            this.Controls.Add(this.labe_total_time);
            this.Controls.Add(this.label_time_limit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel_fields);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_orientation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_time_lim);
            this.Controls.Add(this.label_level);
            this.Controls.Add(this.comboBox_orientation);
            this.Controls.Add(this.comboBox_level);
            this.Controls.Add(this.button_new_game);
            this.Controls.Add(this.button_replay);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_check);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_head);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_head;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_replay;
        private System.Windows.Forms.Button button_new_game;
        private System.Windows.Forms.ComboBox comboBox_level;
        private System.Windows.Forms.ComboBox comboBox_orientation;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label_orientation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_time_lim;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_fields;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_time_limit;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labe_total_time;
    }
}

