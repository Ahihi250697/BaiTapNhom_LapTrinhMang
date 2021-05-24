
namespace client
{
    partial class Client
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
            this.input_chat = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.name_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.test_textbox = new System.Windows.Forms.TextBox();
            this.all_chat_view = new System.Windows.Forms.TextBox();
            this.time_status = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // input_chat
            // 
            this.input_chat.Location = new System.Drawing.Point(13, 338);
            this.input_chat.Multiline = true;
            this.input_chat.Name = "input_chat";
            this.input_chat.Size = new System.Drawing.Size(279, 100);
            this.input_chat.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(298, 338);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(179, 100);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // name_box
            // 
            this.name_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_box.Location = new System.Drawing.Point(298, 301);
            this.name_box.Name = "name_box";
            this.name_box.Size = new System.Drawing.Size(179, 23);
            this.name_box.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "name:";
            // 
            // test_textbox
            // 
            this.test_textbox.Location = new System.Drawing.Point(298, 42);
            this.test_textbox.Multiline = true;
            this.test_textbox.Name = "test_textbox";
            this.test_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.test_textbox.Size = new System.Drawing.Size(179, 240);
            this.test_textbox.TabIndex = 7;
            // 
            // all_chat_view
            // 
            this.all_chat_view.Location = new System.Drawing.Point(13, 13);
            this.all_chat_view.Multiline = true;
            this.all_chat_view.Name = "all_chat_view";
            this.all_chat_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.all_chat_view.Size = new System.Drawing.Size(279, 311);
            this.all_chat_view.TabIndex = 8;
            this.all_chat_view.TextChanged += new System.EventHandler(this.all_chat_view_TextChanged);
            // 
            // time_status
            // 
            this.time_status.Enabled = false;
            this.time_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_status.Location = new System.Drawing.Point(300, 13);
            this.time_status.Name = "time_status";
            this.time_status.Size = new System.Drawing.Size(179, 23);
            this.time_status.TabIndex = 10;
            this.time_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Client
            // 
            this.AcceptButton = this.btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 450);
            this.Controls.Add(this.time_status);
            this.Controls.Add(this.all_chat_view);
            this.Controls.Add(this.test_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_box);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.input_chat);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox input_chat;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox name_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox test_textbox;
        private System.Windows.Forms.TextBox all_chat_view;
        private System.Windows.Forms.TextBox time_status;
    }
}

