using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web;
using Grpc.Core;
using System.IO;
using System.Net;

namespace WindowsFormsAppConvertor
{
    public partial class Form1 : Form
    {
        int selectedIndex = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Stuart's Encoding Software Copyright 2021";            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && comboBox1.SelectedItem != null) // notice the combobox selection is checked, if its null no selection has been made
            {
                string toencode = textBox1.Text;
                textBox2.Text = "";     //empty text box so no confusing info

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("URL");
                        var url = System.Net.WebUtility.UrlEncode(toencode);
                        textBox2.Text = url;
                        break;
                    case 1:
                        Console.WriteLine("HTML");
                        var html = WebUtility.HtmlEncode(toencode);
                        textBox2.Text = html;
                        break;
                    case 2:
                        Console.WriteLine("Base64");
                        var plainTextBytes = Encoding.UTF8.GetBytes(toencode);
                        string encodedText = Convert.ToBase64String(plainTextBytes);
                        textBox2.Text = encodedText;
                        break;
                    case 3:
                        Console.WriteLine("Hex");
                        byte[] hex = Encoding.Default.GetBytes(toencode);
                        var hexString = BitConverter.ToString(hex);
                        hexString = hexString.Replace("-", "");
                        textBox2.Text = hexString;
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                
                
            }

            else { MessageBox.Show("Please enter a sequence to encode or check your method"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            Console.WriteLine(selectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            selectedIndex = comboBox1.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            Console.WriteLine(selectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                string todecode = textBox3.Text;
                textBox4.Text = "";     //empty text box so no confusing info

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("URL");
                        var url = System.Net.WebUtility.UrlDecode(todecode);
                        textBox4.Text = url;
                        break;
                    case 1:
                        Console.WriteLine("HTML");
                        var html = WebUtility.HtmlDecode(todecode);
                        textBox4.Text = html;
                        break;
                    case 2:
                        Console.WriteLine("Base64");
                        break;
                    case 3:
                        Console.WriteLine("Hex");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }


            }

            else { MessageBox.Show("Please enter a sequence to decode or check your method"); }
        }//end of button

        private void button5_Click(object sender, EventArgs e)
        {
            string url = "https://coronavirus.data.gov.uk/";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(new StreamReader(WebRequest.Create(url).GetResponse()
                                             .GetResponseStream()));
            
            string first = doc.DocumentNode.SelectNodes("//*[@id=\"main-content\"]/div/div/div[2]/div/div/div[1]/p[1]")[0].InnerText;
            string second = doc.DocumentNode.SelectNodes("//*[@id=\"main-content\"]/div/div/div[2]/div/div/div[1]/p[2]")[0].InnerText;
            textBox5.Text = first;
            textBox6.Text = second;
        }
    }//end of class

}//end of file
