using System;
using System.Windows.Forms;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Business.Service;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Output.Signin;

namespace 移动家客WinApp
{
    public partial class Signin : Form
    {
        private ISigninService _SigninService;

        public static UserInfoDto UserInfo { get; private set; }

        public Signin()
        {
            InitializeComponent();

            _SigninService = new SigninService();

            this.AcceptButton = button1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var uname = txtUserName.Text.Trim();
            var pwd = txtPassWord.Text.Trim();
            if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("请输入用户名和密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string imageCaptcha = string.Empty;
            try
            {
                imageCaptcha = await _SigninService.GetImageCaptcha();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(imageCaptcha))
            {
                MessageBox.Show("获取不到验证码,登录失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserAndTokenDto user = null;
            try
            {
                user = await _SigninService.Signin(uname, pwd, imageCaptcha);
                UserInfo = user?.data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConfigurationManagerHelpeor.AddUpdateAppSettings("UserName", txtUserName.Text.Trim());
            if (checkBox1.Checked)
            {
                ConfigurationManagerHelpeor.AddUpdateAppSettings("PassWord", txtPassWord.Text.Trim());
            }
            else
            {
                ConfigurationManagerHelpeor.AddUpdateAppSettings("PassWord", "");
            }

            MainForm newForm = new MainForm(this);
            this.Hide();
            newForm.Show();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            var UserName = ConfigurationManagerHelpeor.ReadSetting("UserName");
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                txtUserName.Text = UserName;
            }
            var PassWord = ConfigurationManagerHelpeor.ReadSetting("PassWord");
            if (!string.IsNullOrWhiteSpace(PassWord))
            {
                checkBox1.Checked = true;
                txtPassWord.Text = PassWord;
            }

            var BaseAddress = ConfigurationManagerHelpeor.ReadSetting("BaseAddress");
            if (string.IsNullOrWhiteSpace(BaseAddress))
            {
                MessageBox.Show($"缺少关键配置数据， 获取不到API地址，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //ConfigurationManagerHelpeor.AddUpdateAppSettings("BaseAddress", "http://119.96.226.157:9001/");
            }
        }

        private void Signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //3.为窗体添加SizeChanged事件，并在其方法Form1_SizeChanged中，调用类的自适应方法，完成自适应
        private void Signin_SizeChanged(object sender, EventArgs e)
        {
        }

        //窗口坐标和屏幕坐标也是可以相互转换的，　　
        private void Signin_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X; //相对form窗口的坐标，客户区坐标
            int y = e.Y;
            int x1 = Control.MousePosition.X;//相对显示器，屏幕的坐标
            int y1 = Control.MousePosition.Y;
        }
    }
}