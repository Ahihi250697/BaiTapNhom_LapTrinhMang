using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        /// <summary>
        /// khai bao
        /// </summary>

        Socket _client;
        IPEndPoint _ip;
        string clientName = "";

        /// <summary>
        /// gửi tin nhắn
        /// </summary>
        private void btn_send_Click(object sender, EventArgs e)
        {
            Send();
        }

        /// <summary>
        /// kết nối server
        /// + chờ nhận tin nhắn
        /// </summary>
        void Connect()
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

            try
            {
                _client.Connect(_ip);
            }
            catch
            {
                MessageBox.Show("Khong the ket noi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread _listen = new Thread(Receive);
            _listen.IsBackground = true;
            _listen.Start();

        }
        /// <summary>
        /// gửi tin nhắn
        /// </summary>
        void Send()
        {
            if (clientName == "") { Set_name(); }

            var _text = input_chat.Text;
            if (_text != string.Empty)
            {
                string _mess = clientName + ":" + _text;
                _client.Send(Encoding.ASCII.GetBytes(_mess));
                Add_message(_mess);
            }
        }
        /// <summary>
        /// nhận tin nhắn
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] _data = new byte[1024 * 100];
                    var _size = _client.Receive(_data);

                    var _message = Encoding.UTF8.GetString(_data, 0, _size);

                    var _Q = Get_name(_message);

                    if (_Q == "Question")
                    {
                        time_status.Text = "Playing...";
                    }
                    else if (_Q == "Endgame")
                    {
                        time_status.Text = "Waiting new Q";
                    }
                    else if (_Q == "List winner")
                    {
                        test_textbox.Clear();
                        test_textbox.AppendText(_message);
                        _message = "";
                    }
                    Add_message(_message);
                }

            }
            catch
            {
                Disconnect();
            }
        }

        /// <summary>
        /// thêm vào chat box
        /// </summary>
        void Add_message(string _s)
        {
            // all_chat_view.Items.Add(new ListViewItem() { Text = _s });
            // test_textbox.Text += _s + System.Environment.NewLine;
            all_chat_view.AppendText(_s + System.Environment.NewLine);
            input_chat.Clear();
        }
        /// <summary>
        /// ngắt kết nối
        /// </summary>
        void Disconnect()
        {
            _client.Close();
        }
        /// <summary>
        /// ngắt kết nối do tác động bên ngoài
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        /// <summary>
        /// đặt tên nếu
        /// + không nhập tên vào ô name
        /// + random tên
        /// </summary>
        void Set_name()
        {
            var _has_name = name_box.Text;
            if (_has_name != string.Empty)
            {
                clientName = _has_name;
            }
            else
            {
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                clientName = new String(stringChars);

            }
            this.Text = clientName;
        }

        /// <summary>
        /// cuộn xuống cuối box nhưng có vẻ ko cần thiết 😄😄😄
        /// </summary>
        private void all_chat_view_TextChanged(object sender, EventArgs e)
        {
            // all_chat_view.SelectionStart = all_chat_view.Text.Length;
            // all_chat_view.ScrollToCaret();
        }
        /// <summary>
        /// lấy câu hỏi
        /// </summary>
        string Get_name(string _s)
        {
            var _q = _s.Split(':')[0];
            return _q;
        }
    }
}
