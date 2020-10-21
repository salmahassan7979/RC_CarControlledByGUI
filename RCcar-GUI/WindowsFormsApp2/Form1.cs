using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SerialPort port = null;
        public Form1()
        {
            InitializeComponent();
            refreshCom();
            label1.Text = "Disconnected";
            label1.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshCom();
        }
        private void refreshCom()
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }
        private void Connect()
        {
            port = new SerialPort(comboBox1.SelectedItem.ToString());
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                        }
            }catch(Exception ex) { }
           

        }
        private void Disconnect()
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    label1.Text = "Disconnected";
                    label1.ForeColor = Color.Red;
                }
            }catch(Exception ex)
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                port.Write("U");
            }catch(Exception ex) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                port.Write("L");
            }
            catch (Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                port.Write("D");
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                port.Write("R");
            }
            catch (Exception ex) { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text =  trackBar1.Value.ToString();
           
        }

      
        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                port.Write(trackBar1.Value.ToString());
            }catch(Exception ex) { }
        }
    }
    }

