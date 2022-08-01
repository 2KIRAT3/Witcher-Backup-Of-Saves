using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Witcher_Backup_Of_Saves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Icon = Properties.Resources.icon;
            pictureBox2.Image = Properties.Resources.witcher_icon;
        }
        
        public string path_to_folder_mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
       
        Point mouse_down_pont = Point.Empty;

        string path_to_backup_folder = "";

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down_pont = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down_pont = Point.Empty;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down_pont.IsEmpty)
                return;
            Location = new Point(Location.X + (e.X - mouse_down_pont.X), Location.Y + (e.Y - mouse_down_pont.Y));
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down_pont = new Point(e.X, e.Y);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down_pont = Point.Empty;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down_pont.IsEmpty)
                return;
            Location = new Point(Location.X + (e.X - mouse_down_pont.X), Location.Y + (e.Y - mouse_down_pont.Y));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        string get_path_to_backup_folder() 
        {
            string path = path_to_folder_mydocuments + @"\Witcher_Backup";
            if (!(Directory.Exists(path)))
                Directory.CreateDirectory(path);
            return path;
        }

        void open_backup_folder() 
        {
            Process.Start("explorer.exe", path_to_backup_folder);
        }

        string get_path_to_save_directory()
        {
            string path_to_directory_steam_cloud_witcher2 = "";
            if (checkBox1_steam_cloud.Checked)
            {
                string[] directories_steam_cloud = Directory.GetDirectories(@"C:\Program Files (x86)\Steam\userdata");
                foreach (string directory_steam_cloud in directories_steam_cloud) 
                {
                    if (Directory.Exists($"{directory_steam_cloud}\\20920")) // folder witcher 2
                        path_to_directory_steam_cloud_witcher2 = $"{directory_steam_cloud}\\20920\\remote";

                }
                return path_to_directory_steam_cloud_witcher2;
            }
            else 
            {
                if (Directory.Exists(path_to_folder_mydocuments + @"\Witcher 2"))
                {
                    path_to_directory_steam_cloud_witcher2 = path_to_folder_mydocuments + @"\Witcher 2\gamesaves"; ;
                }
                else
                {
                    MessageBox.Show($"{path_to_folder_mydocuments}\\Witcher 2\n Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    path_to_directory_steam_cloud_witcher2 = "";
                }
                return path_to_directory_steam_cloud_witcher2;
            }
        }

        string[] get_path_last_save()
        {
            FileInfo[] all_files = new DirectoryInfo(get_path_to_save_directory()).GetFiles();  
 
            FileInfo last_file = all_files[0];  
 
            foreach (FileInfo file in all_files)  
                if (file.CreationTime > last_file.CreationTime && file.Name.Contains(".sav"))
                    last_file = file;
            string last_file_screenshot = last_file.FullName.Remove(last_file.FullName.Length-4) + "_640x360.bmp";
            string[] array_files = { last_file.FullName, last_file_screenshot };
            return array_files;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            open_backup_folder();
            //get_last_save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "https://github.com/2KIRAT3/Witcher-Backup-Of-Saves";
            proc.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 60000; // 60000 ms = 1 min
            label3.Text = $"{trackBar1.Value.ToString()} min";
            label3.Location = trackBar1.Value < 10 ? new Point(278, 88) : new Point(274, 88);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (string file_path in get_path_last_save())
            {
                textBox1.Text += $"Copy: {file_path} {DateTime.Now}\r\n";
                if (file_path.EndsWith(".bmp"))
                {
                   if(pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    File.Copy(file_path, get_path_to_backup_folder() + "\\Screenshot.bmp", true);
                    pictureBox1.Image = Image.FromFile(get_path_to_backup_folder() + "\\Screenshot.bmp");
                }
                else
                    File.Copy(file_path, get_path_to_backup_folder() + "\\BackUp_Save.sav", true);
            }
        }

        async private void Form1_Load(object sender, EventArgs e)
        {
            button2.Lato_Font_Button();
            label1.Witcher_Font_Label();
            label2.Lato_Font_Label();
            label3.Lato_Font_Label();
            label4.Lato_Font_Label();
            textBox1.Lato_Font_Textbox();
            checkBox1_steam_cloud.Lato_Font_CheckBox();
            linkLabel1.Lato_Font_Label();
            path_to_backup_folder = get_path_to_backup_folder();
            for (Opacity = 0.0; Opacity < 1; Opacity+=0.01)
                await Task.Delay(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}