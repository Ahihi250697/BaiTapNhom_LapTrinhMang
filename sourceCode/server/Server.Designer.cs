
namespace server
{
    partial class Server
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
            this.btn_send = new System.Windows.Forms.Button();
            this.input_chat = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.time_end_show = new System.Windows.Forms.TextBox();
            this.time_end = new System.Windows.Forms.Timer(this.components);
            this.all_chat_view = new System.Windows.Forms.TextBox();
            this.winner_board = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(216, 338);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(119, 100);
            this.btn_send.TabIndex = 7;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // input_chat
            // 
            this.input_chat.Location = new System.Drawing.Point(13, 338);
            this.input_chat.Multiline = true;
            this.input_chat.Name = "input_chat";
            this.input_chat.Size = new System.Drawing.Size(197, 100);
            this.input_chat.TabIndex = 5;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(341, 338);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(105, 100);
            this.btn_start.TabIndex = 8;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // time_end_show
            // 
            this.time_end_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_end_show.Location = new System.Drawing.Point(267, 299);
            this.time_end_show.Name = "time_end_show";
            this.time_end_show.Size = new System.Drawing.Size(179, 23);
            this.time_end_show.TabIndex = 9;
            this.time_end_show.Text = "00:10:00";
            this.time_end_show.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_end_show.TextChanged += new System.EventHandler(this.time_end_show_TextChanged);
            // 
            // time_end
            // 
            this.time_end.Interval = 10;
            this.time_end.Tick += new System.EventHandler(this.time_end_Tick);
            // 
            // all_chat_view
            // 
            this.all_chat_view.Location = new System.Drawing.Point(13, 13);
            this.all_chat_view.Multiline = true;
            this.all_chat_view.Name = "all_chat_view";
            this.all_chat_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.all_chat_view.Size = new System.Drawing.Size(249, 309);
            this.all_chat_view.TabIndex = 10;
            this.all_chat_view.TextChanged += new System.EventHandler(this.all_chat_view_TextChanged);
            // 
            // winner_board
            // 
            this.winner_board.Location = new System.Drawing.Point(268, 13);
            this.winner_board.Multiline = true;
            this.winner_board.Name = "winner_board";
            this.winner_board.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.winner_board.Size = new System.Drawing.Size(179, 280);
            this.winner_board.TabIndex = 11;
            // 
            // Server
            // 
            this.AcceptButton = this.btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.winner_board);
            this.Controls.Add(this.all_chat_view);
            this.Controls.Add(this.time_end_show);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.input_chat);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox input_chat;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox time_end_show;
        private System.Windows.Forms.Timer time_end;
        private System.Windows.Forms.TextBox all_chat_view;
        private System.Windows.Forms.TextBox winner_board;
    }
}

