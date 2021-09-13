using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.IO.Ports;

using OpenCvSharp;
using OpenCvSharp.Extensions;

using System.Text.RegularExpressions;
using System.IO;



namespace XY_stage_move
{
    public partial class Form1 : Form
    {
        Socket sock;
        byte dummy = 0xff;
        byte stx = 0x02;
        byte etx = 0x03;
        byte[] bytes = new byte[1024];
        byte ACK = 0x06;
        byte nak = 0x15;
        byte rst = 0x12;

        string spd_str = "0000";
        string ltn_stra1 = "00000.0000";
        string ltn_stra2 = "00000.0000";

        static Mat[] mats = new Mat[1000];

        static int count = 0;

        string open_sut = "3,0,0\n";
        string close_sut = "1,0,0\n";

        int W = System.Windows.Forms.SystemInformation.VirtualScreen.Width; //X:-1080 Width: 3000
        //6014
        int H = System.Windows.Forms.SystemInformation.VirtualScreen.Height;//Y:-854 Height: 1934
        //2400
        //
        int W_2 = System.Windows.Forms.SystemInformation.VirtualScreen.X;
        int H_2 = System.Windows.Forms.SystemInformation.VirtualScreen.Y;

        int W_1 = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;//1920
        int H_1 = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;//1080

        int a = System.Windows.Forms.SystemInformation.MonitorCount;

        //System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width
        //int W_3 = System.Windows.Forms.SystemInformation.pr.X;
        //int H_3 = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Y;


        byte flag_ok = 0x30;
        byte flag_error = 0x31;  //send 부분에 else if로 검사 후 처리
        byte flag_fail = 0x32;

        string x_position, y_position;

        string status = "";

        string ltn_stra5 = "    0.000 ";//일의 자리 수일 때         

        char[] x_pos = new char[10];
        char[] y_pos = new char[10];

        double x_start_point;
        double y_start_point;

        double x_stage_point;
        double y_stage_point;

        double x_pitch_size;
        double y_pitch_size;

        byte[] x_stage_position = new byte[10];
        byte[] y_stage_position = new byte[10];

        double y_complete;
        decimal x_complete;

        double[] long_point = new double[4];
        double[] short_point = new double[2];



        public Form1()
        {
            InitializeComponent();

            string[] PortNames = SerialPort.GetPortNames();  // 포트 검색.

            foreach (string portnumber in PortNames)
            {
                Port_Combox.Items.Add(portnumber);          // 검색한 포트를 콤보박스에 입력. 
            }

            //mat = Cv2.ImRead("C:\\image_sample\\4k_3.jpg");
            // mat_even_down = Cv2.ImRead("C:\\image_sample\\4k_1.jpg");
            //mat_odd_down = Cv2.ImRead("C:\\image_sample\\4k_2.jpg");
            //mat_even = Cv2.ImRead("C:\\image_sample\\4k_2.jpg");
            //mat_odd = Cv2.ImRead("C:\\image_sample\\4k_1.jpg");
        }







        public void Form1_Load(object sender, EventArgs e)
        {

            //Cv2.NamedWindow("test", WindowMode.FreeRatio);
            //Cv2.MoveWindow("test", W_1, 0);
            //Cv2.SetWindowProperty("test", WindowProperty.Fullscreen, 1);

            //Mat mat_test = new Mat();
            //mat_test = Cv2.ImRead("C:\\image_sample\\4k_2.jpg");
            //Cv2.ImShow("test", mat_test);
            //Cv2.WaitKey(1000);

        }


        private void stg_con_Click(object sender, EventArgs e)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("192.168.1.203");//인자값 : 서버측 IP         
            IPEndPoint endPoint = new IPEndPoint(ip, 20000);//인자값 : IPAddress,포트번호
            sock.Connect(endPoint);
            textBox1.Text = ("Stage Connected");

            if (sock.Connected == true)
            {
                stg_con.Enabled = false;
            }

        }

        private void stg_dis_Click(object sender, EventArgs e)
        {
            sock.Close();
            textBox1.Text = ("disconnected");

            stg_con.Enabled = true;

            sock.Dispose();
        }

        public static byte[] Combine(byte[] first, byte[] second) //byte 결합하는 함수에 관한 부분
        {
            return first.Concat(second).ToArray();
        }

        public byte lrc_cal(byte[] data)  //명령어 LRC 계산하는 부분
        {

            //byte XOR 연산
            byte lrc = dummy;
            for (int n = 0; n < data.Length; n++)
            {
                lrc = (byte)(lrc ^ data[n]);
            }
            if (lrc == 0)
            {
                lrc = etx;
            }
            return lrc;
        }

        public byte[] servo_on(string channel)
        {
            byte[] command = Encoding.UTF8.GetBytes("DB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("1");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);


            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] info_check(string channel)
        {
            byte[] make_msg = Encoding.UTF8.GetBytes("AD");

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] servo_off(string channel)
        {
            byte[] command = Encoding.UTF8.GetBytes("DB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("0");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);


            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] jog_start(string channel, string axis, string pm)
        {
            byte[] command = Encoding.UTF8.GetBytes("BE");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] axis_type = Encoding.UTF8.GetBytes(axis);
            byte[] direc_type = Encoding.UTF8.GetBytes(pm);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, axis_type);
            make_msg = Combine(make_msg, direc_type);
            make_msg = Combine(make_msg, motion_type);


            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        private void send2controller(byte[] msg)
        {
            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };
            msg = Combine(header, msg);
            if (sock.Available > 0) // here we clean up the current queue
            {
                sock.Receive(bytes);
            }
            sock.Send(msg);
            while (sock.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }
            sock.Receive(bytes); // after receiving the data, we should check the LRC if possible
            string status = Encoding.UTF8.GetString(bytes);


            sock.Send(ack);
            msg.Initialize();

        }

        private void send_position(byte[] msg) //좌표 수신
        {

            byte[] bytes = new byte[50];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock.Available > 0) // here we clean up the current queue
            {
                sock.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock.Send(msg);

            while (sock.Available == 0) // wait for the controller response
            {
                Thread.Sleep(100);
            }

            sock.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock.Send(msg);
            }
            else
            {
                sock.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            status.CopyTo(3, x_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 10);

            //int val = Convert.ToInt32(x_pos[8]);
            //x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            x_position = new string(x_pos);//비교를 위해 초기값 저장
            //x_position = Math.Abs(x_position);

            x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();

        }
            public byte[] move_zero(string channel) // 원점 이동 부분
        {
            byte[] command = Encoding.UTF8.GetBytes("BA");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] make_msg = Combine(command, channel_ba);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public byte[] error_reset(string channel)
        {
            byte[] make_msg = Encoding.UTF8.GetBytes("CG");
            byte lrc = lrc_cal(make_msg);
            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };
            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);
            return make_msg;
        }

        public byte[] speed(string channel, string spd)
        {
            byte[] command = Encoding.UTF8.GetBytes("CB");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] speed_set = Encoding.UTF8.GetBytes(spd);
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, speed_set);


            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }

        public double y_down_move(double previous_y)
        {
            double y_pitch_size = Convert.ToDouble(pitch_val_y.Value);
            double y_move_down = Convert.ToDouble(previous_y) + y_pitch_size;
            return y_move_down;
        }

        public double x_right_move(double previous_x)
        {
            double x_pitch_size = Convert.ToDouble(pitch_val_x.Value);
            double x_move_right = Convert.ToDouble(previous_x) + x_pitch_size;
            return x_move_right;
        }


        public double x_left_move(double previous_x)
        {
            double x_pitch_size = Convert.ToDouble(pitch_val_x.Value);
            double x_move_left = Convert.ToDouble(previous_x) - x_pitch_size;
            return x_move_left;
        }

        public byte[] move_axis(string channel, double x_axis_point, double y_axis_point)
        {

            byte[] command = Encoding.UTF8.GetBytes("BC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] motion_type = Encoding.UTF8.GetBytes("0");
            byte[] xy_type = Encoding.UTF8.GetBytes("1");


            decimal null_byte = 0;
            string null_st_fn = null_byte.ToString(ltn_stra2);

            decimal long_st1 = Convert.ToDecimal(x_axis_point);
            string long_st_fn = long_st1.ToString(ltn_stra2);

            decimal short_st1 = Convert.ToDecimal(y_axis_point);
            string short_st_fn = short_st1.ToString(ltn_stra2);


            byte[] xy_location1 = Encoding.UTF8.GetBytes(long_st_fn);
            byte[] xy_location_null = Encoding.UTF8.GetBytes(null_st_fn);

            byte[] xy_location2 = Encoding.UTF8.GetBytes(short_st_fn);
            byte[] xy_location_null2 = Encoding.UTF8.GetBytes(short_st_fn);

            byte[] xy_location_final = Combine(xy_location1, xy_location2);

            //byte[] xy_location_final = Combine(xy_location1, xy_location_null);
            //xy_location_final = Combine(xy_location_final, xy_location2);
            //xy_location_final = Combine(xy_location_final, xy_location_null2);






            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, motion_type);
            make_msg = Combine(make_msg, xy_type);
            make_msg = Combine(make_msg, xy_location_final);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }





        private void sv_on_Click(object sender, EventArgs e)
        {
            var comm = servo_on("0");
            send2controller(comm);
        }

        private void sv_off_Click(object sender, EventArgs e)
        {
            var comm = servo_off("0");
            send2controller(comm);
        }

        private void info_Click(object sender, EventArgs e)
        {
            var comm = info_check("0");
            send2controller(comm);
        }

        private void origin_Click(object sender, EventArgs e)
        {
            var comm = move_zero("0");
            send2controller(comm);
        }


        private void x_position_compare(byte[] msg) //좌표 수신
        {
            byte[] bytes = new byte[30];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock.Available > 0) // here we clean up the current queue
            {
                sock.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock.Send(msg);

            while (sock.Available == 0) // wait for the controller response
            {
                Thread.Sleep(10);
            }

            sock.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock.Send(msg);
            }
            else
            {
                sock.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            status.CopyTo(3, x_pos, 0, 10);
            //status.CopyTo(13, y_pos, 0, 10);

            //int val = Convert.ToInt32(x_pos[8]);
            //x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            //x_position = new string(x_pos);//비교를 위해 초기값 저장
            //x_position = Math.Abs(x_position);

            //x_position = x_position.Trim();


            x_position = new string(x_pos);//비교를 위해 초기값 저장
            x_position = x_position.Trim();

            //y_position = new string(y_pos);//비교를 위해 초기값 저장
            //y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();
        }



        private void y_position_compare(byte[] msg) //좌표 수신
        {
            byte[] bytes = new byte[30];

            byte[] ack = new byte[] { ACK };
            byte[] header = new byte[] { stx, dummy };

            msg = Combine(header, msg);

            if (sock.Available > 0) // here we clean up the current queue
            {
                sock.Receive(bytes);
                //sock1.Receive(bytes1);
            }

            sock.Send(msg);

            while (sock.Available == 0) // wait for the controller response
            {
                Thread.Sleep(10);
            }

            sock.Receive(bytes); // after receiving the data, we should check the LRC if possible

            if (bytes.Contains<byte>(nak) || bytes.Contains<byte>(rst) == true)
            {
                sock.Send(msg);
            }
            else
            {
                sock.Send(ack);
            }

            status = Encoding.UTF8.GetString(bytes);


            //status.CopyTo(3, x_pos, 0, 10);
            status.CopyTo(13, y_pos, 0, 10);

            //int val = Convert.ToInt32(x_pos[8]);
            //x_pos[8] = Convert.ToChar(48);//Convert.ToChar(val - 1);

            //x_position = new string(x_pos);//비교를 위해 초기값 저장
            //x_position = Math.Abs(x_position);

            //x_position = x_position.Trim();

            y_position = new string(y_pos);//비교를 위해 초기값 저장
            y_position = y_position.Trim();

            msg.Initialize();
            bytes.Initialize();
        }


        public byte[] posi_check_robot(string channel) //robot_position chk
        {
            byte[] command = Encoding.UTF8.GetBytes("AC");
            byte[] channel_ba = Encoding.UTF8.GetBytes(channel);
            byte[] data_type = Encoding.UTF8.GetBytes("2");
            byte[] make_msg = Combine(command, channel_ba);
            make_msg = Combine(make_msg, data_type);

            byte lrc = lrc_cal(make_msg);

            byte[] etx_ba = new byte[] { etx };
            byte[] lrc_ba = new byte[] { lrc };

            make_msg = Combine(make_msg, etx_ba);
            make_msg = Combine(make_msg, lrc_ba);

            return make_msg;
        }






        private async void jog_move_Click(object sender, EventArgs e)
        {
            decimal x_axis_pt_a1 = str_pt_x.Value;
            decimal y_axis_pt_a1 = str_pt_y.Value;

            string point_a1 = x_axis_pt_a1.ToString(ltn_stra1);
            double x_start_point = Convert.ToDouble(str_pt_x.Value);
            double x_stage_point = Convert.ToDouble(str_pt_x.Value);

            string point_a2 = y_axis_pt_a1.ToString(ltn_stra2);
            double y_start_point = Convert.ToDouble(str_pt_y.Value);
            double y_stage_point = Convert.ToDouble(str_pt_y.Value);

            double pitch_size = Convert.ToDouble(pitch_val_x.Value);
            double pitch_size2 = Convert.ToDouble(pitch_val_y.Value);

            string spd = mtr_spd.Value.ToString();

            int x_count = Convert.ToInt32(x_array.Value);
            int y_count = Convert.ToInt32(y_array.Value);

            int stage_del = Convert.ToInt32(delay_time.Value);

            

            stage_del = (stage_del * 1000) - 500;
           
            if (stage_del < 0)
            {
                stage_del = 0;
            }

            int end_count = y_count;

            string oneshot = "4," + exposure_time.Value.ToString() + ",0,\n";
            int shutt_del = Convert.ToInt32(exposure_time.Value);
            shutt_del = (shutt_del * 1000) + 1000;


            double y_limt = y_start_point + (pitch_size2 * (y_count - 1));
            double x_limt = x_start_point + (pitch_size * (x_count - 1));

            decimal speed_1 = mtr_spd.Value;
            string spd_1 = speed_1.ToString(spd_str);
            var comm_1 = speed("0", spd_1);
            send2controller(comm_1);


            if (y_limt > 300)//y 센서 거리 초과
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send2controller(comm);
                textBox1.Text = ("OVER Y-AXIS LIMIT");
            }

            else if (x_limt > 300)//x 센서 거리 초과
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send2controller(comm);
                textBox1.Text = ("OVER X-AXIS LIMIT");
            }


            else if (x_count == 1 && y_count == 1)// (x, y), (1,1) 스타트 포인트
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send2controller(comm);
                Thread.Sleep(4000);
                serialPort1.Write(oneshot);
                Thread.Sleep(shutt_del);
            }
            else if (x_count == 1)//x 가 1이고 y는 1이 아닐때
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send2controller(comm);
                Thread.Sleep(4000);
                serialPort1.Write(oneshot);
                Thread.Sleep(shutt_del);


                for (int m = 1; m < y_count + 1; m++)
                {


                    y_stage_point = y_down_move(y_stage_point);
                    comm = move_axis("0", x_stage_point, y_stage_point);
                    send2controller(comm);
                    Thread.Sleep(4000);
                    serialPort1.Write(oneshot);
                    Thread.Sleep(shutt_del);

                    if (m == y_count - 1)
                    {
                        comm = move_axis("0", x_start_point, y_start_point);
                        send2controller(comm);
                        break;
                    }

                }
            }
            else if (y_count == 1)//y가 1이고 x가 1이 아닐때
            {
                var comm = move_axis("0", x_stage_point, y_stage_point);
                send2controller(comm);
                Thread.Sleep(4000);
                serialPort1.Write(oneshot);
                Thread.Sleep(shutt_del);

                for (int m = 1; m < x_count + 1; m++)
                {
                    x_stage_point = x_right_move(x_stage_point);
                    comm = move_axis("0", x_stage_point, y_stage_point);
                    send2controller(comm);
                    Thread.Sleep(4000);
                    serialPort1.Write(oneshot);
                    Thread.Sleep(shutt_del);

                    if (m == x_count - 1)
                    {
                        comm = move_axis("0", x_start_point, y_start_point);
                        send2controller(comm);
                        break;
                    }

                }
            }
            else if (x_count > 1 && y_count > 1)
            {
                //(x, y) -> (n, m) 부분
                //100 mm/s

                //for (int i = 0; i < imageFileList_Load.Count(); i++)
                //{
                //Console.WriteLine("arr[" + i + "] : " + imageFileList_Load[i]);
                //mats[i] = Cv2.ImRead(imageFileList_Load[i]);
                //Cv2.ImShow("{ 0 }" + i, mats[i]);
                //Cv2.WaitKey(100);
                //}

                //var task1 = Task.Run(() =>
                //{

                //Thread.Sleep(stage_del);
                //});
                //await task1;
                //task1.Wait();

                /*
                var task1 = Task.Run(() =>
                {
                    
                });
                await task1;
                */

                Cv2.ImShow("test", mats[0]);
                Cv2.WaitKey(500);
                count++;

                var comm_posi_1 = posi_check_robot("0");
                x_position_compare(comm_posi_1);

                if (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                {
                    //serialPort1.Write(oneshot);
                    //Thread.Sleep(shutt_del);

                    var comm = move_axis("0", x_stage_point, y_stage_point);
                    send2controller(comm);
                }

                var task2 = Task.Run(() =>
                {
                    if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                    {
                        Thread.Sleep(stage_del);

                        serialPort1.Write(oneshot);
                        Thread.Sleep(shutt_del);
                    }
                    else
                    {
                        while (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                        {
                            var comm_posi_2 = posi_check_robot("0");
                            x_position_compare(comm_posi_2);

                            x_complete = Convert.ToDecimal(x_position);

                            if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                            {
                                Thread.Sleep(stage_del);

                                serialPort1.Write(oneshot);
                                Thread.Sleep(shutt_del);
                            }
                        }
                    }
                });
                await task2;

                //for (int count = 1; count == (x_count * y_count); count++)//image_count

                for (int i = 0; i < y_count; i++) //y가 1씩 증가할 때
                {


                    if (i % 2 == 0) //y카운트 짝수일 때
                    {
                        for (int m = 1; m < x_count; m++)//y카운트 홀수일 때
                        {
                            /*
                            var task_odd = Task.Run(() =>
                            {
                                Cv2.ImShow("test", mats[count]);
                                Cv2.WaitKey(shutt_del);
                                count++;
                            });
                            await task_odd;
                            */

                            var task_odd_1 = Task.Run(() =>
                            {
                                x_stage_point = x_right_move(x_stage_point);
                                var comm_2 = move_axis("0", x_stage_point, y_stage_point);
                                send2controller(comm_2);

                                //Thread.Sleep(stage_del);
                                //serialPort1.Write(oneshot);
                                //Thread.Sleep(shutt_del);

                            });
                            await task_odd_1;


                            var task_odd_2 = Task.Run(() =>
                            {

                                if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    Cv2.ImShow("test", mats[count]);
                                    Cv2.WaitKey(500);
                                    count++;

                                    Thread.Sleep(stage_del);

                                    serialPort1.Write(oneshot);
                                    Thread.Sleep(shutt_del);
                                }
                                else
                                {
                                    while (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                    {
                                        var comm_posi_2 = posi_check_robot("0");
                                        x_position_compare(comm_posi_2);

                                        x_complete = Convert.ToDecimal(x_position);

                                        if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                        {
                                            Cv2.ImShow("test", mats[count]);
                                            Cv2.WaitKey(500);
                                            count++;


                                            Thread.Sleep(stage_del);


                                            serialPort1.Write(oneshot);
                                            Thread.Sleep(shutt_del);
                                        }
                                    }
                                }
                            });
                            await task_odd_2;



                            if (m == x_count - 1)// && )
                            {
                                //Cv2.ImShow("test", mats[count]);
                                //Cv2.WaitKey(shutt_del);
                                //count++;


                                if (i == end_count - 1)
                                {
                                    break;
                                }

                                var task_odd_end = Task.Run(() =>
                                {
                                    y_stage_point = y_down_move(y_stage_point);
                                    var comm_down = move_axis("0", x_stage_point, y_stage_point);
                                    send2controller(comm_down);
                                    //Thread.Sleep(1000);
                                });
                                await task_odd_end;
                                //Thread.Sleep(stage_del);

                                var task_odd_3 = Task.Run(() =>
                                {
                                    /*
                                   // var comm_posi_2 = posi_check_robot("0");
                                   // y_position_compare(comm_posi_2);

                                    //y_complete = Convert.ToDouble(y_position);


                                    //if (y_complete == y_stage_point) // y축 좌표 비교 이동 완료
                                    //{
                                    //    Thread.Sleep(1000);

                                     //   Cv2.ImShow("test", mats[count]);
                                     //   Cv2.WaitKey(500);
                                        count++;

                                        serialPort1.Write(oneshot);
                                        Thread.Sleep(shutt_del);
                                    }
                                    else
                                    
                                    {
                                    */
                                    while (y_complete != y_stage_point) // y축 좌표 비교 이동 완료
                                    {
                                        var comm_posi_3 = posi_check_robot("0");
                                        y_position_compare(comm_posi_3);

                                        y_complete = Convert.ToDouble(y_position);

                                        if (y_complete == y_stage_point) // y축 좌표 비교 이동 완료
                                        {
                                            Thread.Sleep(1000);

                                            Cv2.ImShow("test", mats[count]);
                                            Cv2.WaitKey(500);
                                            count++;

                                            Thread.Sleep(stage_del);

                                            serialPort1.Write(oneshot);
                                            Thread.Sleep(shutt_del);
                                        }


                                    }
                                    //}
                                });
                                await task_odd_3;
                            }

                            
                        }
                        if (i == end_count - 1)
                        {
                            break;
                        }



                    }
                    else
                    {
                        //double tmp2 = m * i;

                        //if (tmp2 == (x_count - 1) * y_count)
                        //{
                        //    break;
                        //}
                        for (int r = 1; r < x_count; r++) //홀
                        {
                            //Cv2.ImShow("test", mats[count]);
                            //Cv2.WaitKey(shutt_del);
                            //count++;

                            //var task_even_1 = Task.Run(() =>
                            //{
                            x_stage_point = x_left_move(x_stage_point);
                            var comm_2 = move_axis("0", x_stage_point, y_stage_point);
                            send2controller(comm_2);
                            //});
                            //await task_even_1;

                            //Thread.Sleep(2000);
                            //Thread.Sleep(stage_del);

                            var task_even = Task.Run(() =>
                            {
                                if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                {
                                    Cv2.ImShow("test", mats[count]);
                                    Cv2.WaitKey(500);
                                    count++;

                                    Thread.Sleep(stage_del);

                                    serialPort1.Write(oneshot);
                                    Thread.Sleep(shutt_del);
                                }
                                else
                                {
                                    while (x_complete != Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                    {
                                        var comm_posi_2 = posi_check_robot("0");
                                        x_position_compare(comm_posi_2);

                                        x_complete = Convert.ToDecimal(x_position);

                                        if (x_complete == Convert.ToDecimal(x_stage_point)) // y축 좌표 비교 이동 완료
                                        {
                                            Cv2.ImShow("test", mats[count]);
                                            Cv2.WaitKey(500);
                                            count++;

                                            Thread.Sleep(stage_del);

                                            serialPort1.Write(oneshot);
                                            Thread.Sleep(shutt_del);
                                        }
                                    }
                                }
                            });
                            await task_even;



                            if (r == x_count - 1)// && )
                            {
                                //Cv2.ImShow("test", mats[count]);
                                //Cv2.WaitKey(500);
                                //count++;
                                if (i == end_count - 1)
                                {
                                    break;
                                }

                                var task_even_end = Task.Run(() =>
                                {
                                    y_stage_point = y_down_move(y_stage_point);
                                    var comm_4 = move_axis("0", x_stage_point, y_stage_point);
                                    send2controller(comm_4);
                                    //Thread.Sleep(1000);
                                });
                                await task_even_end;
                                //Thread.Sleep(stage_del);

                                var task_even_2 = Task.Run(() =>
                                {

                                    //if (y_complete == Convert.ToDecimal(y_stage_point)) // y축 좌표 비교 이동 완료
                                    //{
                                    //    serialPort1.Write(oneshot);
                                    //Thread.Sleep(shutt_del);
                                    //}
                                    //else
                                    //{
                                    while (y_complete != y_stage_point) // y축 좌표 비교 이동 완료
                                    {
                                        var comm_posi_2 = posi_check_robot("0");
                                        y_position_compare(comm_posi_2);

                                        y_complete = Convert.ToDouble(y_position);

                                        if (y_complete == y_stage_point) // y축 좌표 비교 이동 완료
                                        {
                                            Thread.Sleep(1000);

                                            Cv2.ImShow("test", mats[count]);
                                            Cv2.WaitKey(500);
                                            count++;

                                            Thread.Sleep(stage_del);

                                            serialPort1.Write(oneshot);
                                            Thread.Sleep(shutt_del);
                                        }                                        
                                    }
                                    //}
                                });
                                await task_even_2;
                            }
                            //double tmp1 = r * i;

                            //if (tmp1 == (x_count - 1) * y_count)
                            //{
                            //    break;
                            //}
                            
                        }
                        if (i == end_count - 1)
                        {
                            break;
                        }
                    }                   
                }

                var comm_3 = move_axis("0", x_start_point, y_start_point);
                send2controller(comm_3);

                serialPort1.Write(close_sut);
                Cv2.DestroyWindow("test");

                mats.Initialize();

                Array.Clear(mats, 0x0, mats.Length);

                x_start_point = 0;
                y_start_point = 0;
                count = 0;

                x_complete = 0;
                y_complete = 0;

                image_up.Enabled = true;

            }
        }







        private void button2_Click(object sender, EventArgs e)
        {
            
           

            decimal speed_1 = mtr_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm = speed("0", spd);
            send2controller(comm);

            //string spd = mtr_spd.Value.ToString();
            //var comm_1 = speed("0", spd);
            //send2controller(comm_1);


            double x_stage_point = Convert.ToDouble(str_pt_x.Value);
            double y_stage_point = Convert.ToDouble(str_pt_y.Value);

            var comm_1 = move_axis("0", x_stage_point, y_stage_point);
            send2controller(comm_1);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var comm = error_reset("0");
            send2controller(comm);
        }

        private void spd_set_Click(object sender, EventArgs e)
        {
            decimal speed_1 = mtr_spd.Value;
            string spd = speed_1.ToString(spd_str);
            var comm = speed("0", spd);
            send2controller(comm);
        }

        private void y_up_Click(object sender, EventArgs e)
        {
            decimal speed_1 = mtr_spd.Value;
            string spd_1 = speed_1.ToString(spd_str);
            var comm_1 = speed("0", spd_1);

            send2controller(comm_1);
            var comm = jog_start("0", "1", "0");
            send2controller(comm);
        }

        private void y_down_Click(object sender, EventArgs e)
        {
            decimal speed_1 = mtr_spd.Value;
            string spd_1 = speed_1.ToString(spd_str);
            var comm_1 = speed("0", spd_1);

            send2controller(comm_1);
            var comm = jog_start("0", "1", "1");
            send2controller(comm);
        }

        private void x_left_Click(object sender, EventArgs e)
        {
            decimal speed_1 = mtr_spd.Value;
            string spd_1 = speed_1.ToString(spd_str);
            var comm_1 = speed("0", spd_1);

            send2controller(comm_1);
            var comm = jog_start("0", "0", "0");
            send2controller(comm);
        }

        private void x_right_Click(object sender, EventArgs e)
        {

            decimal speed_1 = mtr_spd.Value;
            string spd_1 = speed_1.ToString(spd_str);
            var comm_1 = speed("0", spd_1);
            send2controller(comm_1);

            var comm = jog_start("0", "0", "1");
            send2controller(comm);
        }

        private void Open_btn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = Port_Combox.SelectedItem.ToString();                     //콤보 박스에서 선택.
                serialPort1.BaudRate = int.Parse(Baud_Combox.SelectedItem.ToString());          //콤보 박스에서 Baud Rate 선택.
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Open();
                serialPort1.WriteLine("abcd\r\n");                                                    // abcd\r\n Send
            }

            if (serialPort1.IsOpen == true)
            {
                Open_btn.Enabled = false;
                textBox1.Text = ("Shutter Connected");
            }


        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write("1,0,0\n");
                serialPort1.Close();

                Open_btn.Enabled = true;

            }
        }

        private void button_shutter_open_Click(object sender, EventArgs e)
        {
            string open_str = "3,0,0\n";
            serialPort1.Write(open_str);
        }

        private void button_shutter_close_Click(object sender, EventArgs e)
        {
            string close_str = "1,0,0\n";
            serialPort1.WriteLine(close_str);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string oneshot = "4," + exposure_time.Value.ToString() + ",0,\n";
            serialPort1.Write(oneshot);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cv2.DestroyWindow("test");
            //mat.Release();
            //mat_even.Release();
            //mat_even_down.Release();
            // mat_odd.Release();
            // mat_odd_down.Release();
        }
        public void SetText()
        {
            lb_x_position.Text = x_position;
            lb_y_position.Text = y_position;
        }

        private void posi_chk_Click(object sender, EventArgs e)
        {
            var comm = posi_check_robot("0");
            send_position(comm);
            // Compare_string(x_stage_point, y_stage_point);
            //Task.Run(() => SetText());
            this.Invoke(new Action(SetText));
        }

        private void image_up_Click(object sender, EventArgs e)
        {
            

            int x_count = Convert.ToInt32(x_array.Value);
            int y_count = Convert.ToInt32(y_array.Value);

            //List<string> imageFileList_Load = new List<string>();

            //string[] imageFileList_Load = new string[x_count * y_count];
            string[] imageFileList_Load_1 = new string[x_count * y_count];

            string directoryPath_1 = @"C:\\image_sample";

            List<string> imageFileList_1 = new List<string>();

            foreach (string fileName_1 in Directory.GetFiles(directoryPath_1))
            {
                if (Regex.IsMatch(fileName_1, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    imageFileList_1.Add(fileName_1);
                }
            }

            string[] imageFileList_Load = new string[imageFileList_1.Count()];


            if ((x_count * y_count) > imageFileList_1.Count())
            {
                //MessageBox.Show("Array와 Image 개수를 동일하게 해주세요.");
                int i = (x_count * y_count) - imageFileList_1.Count();

                MessageBox.Show("이미지 파일: " + "" + i + "개 추가해주세요.");
            }
            else
            {

                Image.GetImageFiles(@"C:\\image_sample", imageFileList_Load);

                for (int i = 0; i < imageFileList_Load.Count(); i++)
                {
                    mats[i] = Cv2.ImRead(imageFileList_Load[i]);

                    if (i == x_count * y_count)
                        break;
                }
                Cv2.NamedWindow("test", WindowMode.FreeRatio);
                Cv2.MoveWindow("test", W_1, 0);
                Cv2.SetWindowProperty("test", WindowProperty.Fullscreen, 1);
                image_up.Enabled = false;
            }


            //
            //for (int i = 0; i < imageFileList_Load.Count(); i++)
            //{
            //Console.WriteLine("arr[" + i + "] : " + imageFileList_Load[i]);
            //mats[i] = Cv2.ImRead(imageFileList_Load[i]);
            //Cv2.ImShow("{ 0 }" + i, mats[i]);
            //Cv2.WaitKey(100);


        }


    }




    public class Image
    {



        public static List<string> GetImageFiles(string directoryPath, string[] list)
        {

            List<string> imageFileList = new List<string>();

            foreach (string fileName in Directory.GetFiles(directoryPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    imageFileList.Add(fileName);
                }
            }
            imageFileList.CopyTo(list);

            return imageFileList;
        }


    }

}

