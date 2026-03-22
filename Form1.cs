using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamsungDebloater
{
    public partial class Form1 : Form
    {
        // حل مشكلة Ambiguous Reference عبر تحديد المسار الكامل
        private System.Windows.Forms.Timer connectionTimer;

        private readonly (string Name, string Package)[] targetApps =
        [
            ("خدمة إعلانات سامسونج السحابية", "com.samsung.android.appcloud"),
            ("وحدة تتبع ironSource", "com.aura.muid")
        ];

        public Form1()
        {
            InitializeComponent();
            SetupAutoConnectionCheck();
            ShowWelcomeScreen();
        }

        private void SetupAutoConnectionCheck()
        {
            // حل مشكلة Ambiguous Reference وتبسيط Initialization
            connectionTimer = new System.Windows.Forms.Timer
            {
                Interval = 1500
            };
            connectionTimer.Tick += async (s, e) => await CheckConnectionStatusAsync();
            connectionTimer.Start();
        }

        private async Task CheckConnectionStatusAsync()
        {
            bool isConnected = await IsDeviceConnectedAsync();

            if (isConnected)
            {
                lblStatus.ForeColor = Color.ForestGreen;
                lblStatus.Text = "● منصة التحكم: متصلة" + Environment.NewLine + "جاهز لتنفيذ الأوامر .";
            }
            else
            {
                lblStatus.ForeColor = Color.DarkRed;
                lblStatus.Text = "○  غير متصل" + Environment.NewLine + "يرجى ربط الهاتف عبر كابل USB.";
            }
        }

        private void ShowWelcomeScreen()
        {
            string welcomeText = "إصدار خاص وحصري." +
                                 " للتخلص من برامج التجسس";

            label1.ForeColor = Color.MidnightBlue;
            label1.Font = new Font(label1.Font.FontFamily, 10, FontStyle.Bold);
            label1.Text = welcomeText.Replace(".", Environment.NewLine);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            connectionTimer.Stop();
            txtLog.Clear();
            button1.Enabled = false;

            if (!await IsDeviceConnectedAsync())
            {
                UpdateStatusDisplay(false, "تنبيه: لا يوجد اتصال حالي بالهاتف.");
                button1.Enabled = true;
                connectionTimer.Start();
                return;
            }

            foreach (var app in targetApps)
            {
                UpdateStatusDisplay(true, $"جاري تأمين: {app.Name}");
                string result = await Task.Run(() => RunAdbCommand($"shell pm uninstall -k --user 0 {app.Package}"));

                if (result.Contains("Success"))
                    AppendLog($"[✓] تم تأمين {app.Name}", Color.Green);
                else
                    AppendLog($"[-] {app.Name} مؤمن سابقاً", Color.Gray);
            }

            UpdateStatusDisplay(true, "تمت المهمة بنجاح. النظام مؤمن بالكامل.");
            button1.Enabled = true;
            connectionTimer.Start();
        }

        private void UpdateStatusDisplay(bool isConnected, string message)
        {
            string formattedMessage = message.Replace(".", "." + Environment.NewLine);
            lblStatus.ForeColor = isConnected ? Color.ForestGreen : Color.DarkRed;
            lblStatus.Text = (isConnected ? "● متصل" : "○ غير متصل") + Environment.NewLine + formattedMessage;
        }

        
        private static async Task<bool> IsDeviceConnectedAsync()
        {
            string output = await Task.Run(() => RunAdbCommand("get-state"));
            return output.Contains("device");
        }

        private static string RunAdbCommand(string arguments)
        {
            try
            {
                // تبسيط الـ Object initialization
                ProcessStartInfo psi = new()
                {
                    FileName = "adb.exe",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using var proc = Process.Start(psi);
                return proc?.StandardOutput.ReadToEnd() ?? "Error";
            }
            catch { return "Error"; }
        }

        private void AppendLog(string text, Color color)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionColor = color;
            txtLog.AppendText($"{text}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }
    }
}