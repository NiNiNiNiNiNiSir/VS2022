using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Common;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; this.DoNotify(); }
        }



        //输入ctor后双击tab 快速生成构造函数
        public LoginViewModel()
        {
            this.CloseWindowCommand = new CommandBase();//初始化
            //匿名委托  o是参数
            this.CloseWindowCommand.DoExecute = new Action<object>((o) => 
            {
                //执行内容在这个里面
                (o as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });  //关闭按钮一直可用，不做判断


            this.LoginCommand = new CommandBase();//实例化登录按钮命令
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });  


        }


        //登录逻辑
        private void DoLogin(object o)
        {
            this.ErrorMessage = " ";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名!";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码!";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码!";
                return;
            }
            if(LoginModel.ValidationCode.ToLower()!="etu4")
            {
                this.ErrorMessage = "验证码输入不正确!";
                return;
            }
        }




    }
}
