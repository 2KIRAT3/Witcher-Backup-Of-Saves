using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Witcher_Backup_Of_Saves
{
    public static class Font_Ext
    {
        public static void Witcher_Font_Label(this Label label)
        {
            PrivateFontCollection witcher_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Thewitcher_font))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                witcher_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            label.Font = new Font(witcher_font.Families[0], label.Font.Size);
            label.UseCompatibleTextRendering = true;
        }
        public static void Lato_Font_Label(this Label label)
        {
            PrivateFontCollection lato_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Lato_Regular))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                lato_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            label.Font = new Font(lato_font.Families[0], label.Font.Size);
            label.UseCompatibleTextRendering = true;
        }
        public static void Lato_Font_CheckBox(this CheckBox check_box)
        {
            PrivateFontCollection lato_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Lato_Regular))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                lato_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            check_box.Font = new Font(lato_font.Families[0], check_box.Font.Size);
            check_box.UseCompatibleTextRendering = true;
        }
        public static void Witcher_Font_CheckBox(this CheckBox check_box)
        {
            PrivateFontCollection witcher_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Thewitcher_font))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                witcher_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            check_box.Font = new Font(witcher_font.Families[0], check_box.Font.Size);
            check_box.UseCompatibleTextRendering = true;
        }
        public static void Lato_Font_Button(this Button button)
        {
            PrivateFontCollection lato_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Lato_Regular))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                lato_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            button.Font = new Font(lato_font.Families[0], button.Font.Size);
            button.UseCompatibleTextRendering = true;
        }
        public static void Lato_Font_Textbox(this TextBox textBox)
        {
            PrivateFontCollection lato_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Lato_Regular))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                lato_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            textBox.Font = new Font(lato_font.Families[0], textBox.Font.Size);
        }
        public static void Witcher_Font_Button(this Button button)
        {
            PrivateFontCollection witcher_font = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.Thewitcher_font))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                witcher_font.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            button.Font = new Font(witcher_font.Families[0], button.Font.Size);
            button.UseCompatibleTextRendering = true;
        }
    }
}
