using System;
using System.IO;
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


namespace server
{
    public partial class Server : Form
    {

        /// <summary>
        /// var
        /// </summary>
        /// 
        Socket _server;
        IPEndPoint _ip;
        List<Socket> _clients;
        List<string> winnerLists = new List<string>();
        int timeToTest = 0, isStart = -1;
        string fileData = "./data.json";
        string[] QArrays, Question;
        string result;
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            LoadQuestions();
            Connect();
        }
        /// <summary>
        /// ngắt kết nối do tác động bên ngoài
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }
        /// <summary>
        /// gửi tin nhắn
        /// </summary>
        private void btn_send_Click(object sender, EventArgs e)
        {

            var _text = "Server:" + input_chat.Text;
            foreach (Socket item in _clients)
            {
                Send(item, _text);
            }
            Add_message(_text);
        }
        
        public void LoadQuestions()
        {
            string text = System.IO.File.ReadAllText(fileData);
            QArrays = text.Split('|');
        }
        
        /// <summary>
        /// kết nối
        /// + Accept()
        /// + chờ nhận tin nhắn
        /// </summary>
        void Connect()
        {
            _clients = new List<Socket>();
            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ip = new IPEndPoint(IPAddress.Any, 12345);

            _server.Bind(_ip);

            Thread _listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        _server.Listen(100);
                        Socket _client = _server.Accept();
                        _clients.Add(_client);

                        Thread _receive = new Thread(Receive);
                        _receive.IsBackground = true;
                        _receive.Start(_client);
                    }
                }
                catch
                {
                    _ip = new IPEndPoint(IPAddress.Any, 80);
                    _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

            });
            _listen.IsBackground = true;
            _listen.Start();
        }
        /// <summary>
        /// gửi tin nhắn
        /// </summary>
        void Send(Socket _c, string _text)
        {
            if (_text != string.Empty)
            {
                var ae = Encoding.ASCII.GetBytes(_text);
               // Encoding.Convert(Encoding.UTF8, Encoding.Unicode, ae);
                _c.Send(ae);
               // _c.Send(Encoding.UTF8.GetString(_text));
                
            }
        }
        /// <summary>
        /// nhận tin nhắn
        /// </summary>
        void Receive(object _obj)
        {
            Socket _client = _obj as Socket;
            try
            {
                while (true)
                {
                    byte[] _data = new byte[1024 * 10];
                    var _size = _client.Receive(_data);
                    string _message = Encoding.ASCII.GetString(_data, 0, _size);

                    if (isStart == 1)
                    {

                        var _m = Get_message(_message).ToUpper();

                        if (_m == result)
                        {
                            Add_message("Correct Answer");
                            string _winner_name = Get_name(_message);
                            Add_message(_winner_name);
                            Add_winner(_winner_name);
                        }
                    }
                    else
                    {
                        Add_message(_message);
                        foreach (Socket item in _clients)
                        {
                            if (item != _client)
                            {
                                Send(item, _message);
                            }

                        }
                    }
                }
            }
            catch
            {
                _clients.Remove(_client);
                _client.Close();
            }
        }
        /// <summary>
        /// thêm tin nhắn vào chatbox
        /// </summary>
        void Add_message(string _s)
        {
            //all_chat_view.Items.Add(new ListViewItem() { Text = _s });
            //all_chat_view.Text += _s + System.Environment.NewLine;
            all_chat_view.AppendText(_s + System.Environment.NewLine);
            input_chat.Clear();
        }
        /// <summary>
        /// thêm người trả lời đúng vào danh sách
        /// </summary>
        /// <param name="_s"></param>
        void Add_winner(string _s)
        {
            var _flag = 0;
            if (winnerLists.Count == 0)
            {
                winnerLists.Add(_s);
            }
            else
            {
                for (var i = 0; i < winnerLists.Count; i++)
                {
                    if (winnerLists[i] == _s)
                    {
                        break;
                    }
                    else
                    {
                        if (i == winnerLists.Count - 1)
                        {
                            _flag = 1;
                        }
                    }
                }
            }
            if (_flag == 1)
            {
                winnerLists.Add(_s);
            }
            Add_message(winnerLists.Count.ToString());
            Update_winner();
        }
        /// <summary>
        /// xóa danh sách những người trả lời đúng
        /// </summary>
        void Clear_winner()
        {
            winner_board.Clear();
        }
        /// <summary>
        /// cập nhật danh sách người trả lời đúng
        /// </summary>
        void Update_winner()
        {
            Clear_winner();
            string _board = "List winner:";
            foreach (string item in winnerLists)
            {
                this.winner_board.AppendText(item + System.Environment.NewLine);
                _board += "\r\n";
                _board += item;
            }

            foreach (Socket item in _clients)
            {
                Send(item, _board);
            }
        }

        /// <summary>
        /// lấy tên người dùng
        /// </summary>
        string Get_name(string _s)
        {
            var _client_name = "";
            var _has_name = _s.Split(':')[0];
            if (_has_name != string.Empty)
            {
                _client_name = _has_name;
            }

            return _client_name;
        }
        /// <summary>
        /// lấy phần tin nhắn
        /// </summary>
        string Get_message(string _s)
        {
            var _client_message = _s.Split(':')[1].TrimStart();
            return _client_message;
        }
        /// <summary>
        /// hủy kết nối
        /// </summary>
        void Disconnect()
        {
            _server.Close();
        }
        /// <summary>
        /// bắt đầu câu hỏi
        /// </summary
        private void btn_start_Click(object sender, EventArgs e)
        {
            isStart = 1;
            timeToTest = 10 * 60;
            Enable_something(isStart);
            winnerLists.Clear();
            Clear_winner();

            var _index = new Random().Next(QArrays.Length);
            Question = QArrays[_index].Split(',');
           
            var _Question = Question[0];
            var _Answer = Question[1].Split('-');
            result = Question[2].Trim();

            foreach (Socket _item in _clients)
            {
                Send(_item, _Question);
                foreach (string _answer in _Answer) {
                    Send(_item, _answer+"\r\n");
                }
            }
            Add_message(Question[0]);
            Add_message(Question[1]);
        }
        /// <summary>
        /// khóa nút start
        /// </summary>
        void Enable_something(int _i)
        {
            if (_i == 1)
            {
                this.btn_start.Enabled = false;
                this.time_end.Enabled = true;
            }
            else
            {
                this.btn_start.Enabled = true;
                this.time_end.Enabled = false;
            }
        }

        /// <summary>
        /// thời gian trả lời
        /// </summary>
        private void time_end_Tick(object sender, EventArgs e)
        {
            if (timeToTest > 0)
            {
                timeToTest--;
                var _mins = timeToTest / 60;
                var _secs = timeToTest - (_mins * 60);

                time_end_show.Text = string.Format("{0}:{1}", _mins.ToString().PadLeft(2, '0'), _secs.ToString().PadLeft(2, '0'));
            }
            else
            {
                isStart = -1;
                this.time_end.Stop();
                foreach (Socket item in _clients)
                {
                    Send(item, "Endgame");
                }

                Enable_something(isStart);
            }
        }

        /// <summary>
        /// cuộn xuống cuối box nhưng có vẻ ko cần thiết 😄😄😄
        /// </summary>
        private void all_chat_view_TextChanged(object sender, EventArgs e)
        {
            //all_chat_view.SelectionStart = all_chat_view.Text.Length;
            //all_chat_view.ScrollToCaret();
        }

        private void time_end_show_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
