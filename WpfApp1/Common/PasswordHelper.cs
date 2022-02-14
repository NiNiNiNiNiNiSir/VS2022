using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

/// <summary>
/// 这个类是密码框数据绑定功能
/// </summary>

namespace WpfApp1.Common
{
    public class PasswordHelper   //这个具体里面的没搞懂 
    {
        //使用附加的依赖属性实现密码的界面交互和类似绑定的功能


        //后台值变化时候，通知到控件上
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject d)//封装方法？
        {
            return d.GetValue(PasswordProperty).ToString();
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }


        //控件上变化时候通知后台
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttached)));
        //是这里又写了一遍Password，搞错了！！！会报错！！！
        public static bool GetAttach(DependencyObject d)//封装方法？
        {
            return (bool)d.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }






        static bool _isUpdating = false; //状态

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //后台值变化时候，通知到控件上
            PasswordBox password = d as PasswordBox; //这里不需要实例化 new关键字吗？
            password.PasswordChanged -= Password_PasswordChanged;
            if (!_isUpdating)
                password.Password = e.NewValue?.ToString();
            password.PasswordChanged += Password_PasswordChanged;
        }





        private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //控件上变化时候通知后台
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged += Password_PasswordChanged; //挂载到事件上
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _isUpdating = true;
            SetPassword(passwordBox, passwordBox.Password);
            _isUpdating = false;
        }
    }
}





//namespace WpfApp1.Common
//{

//    public class PasswordHelper
//    {
//        //防止附加属性值与控件属性值循环触发赋值< Password_PasswordChanged > < OnPropertyChanged >
//        private static bool _isUpdating = false;

//        //附加属性值变化后给推送给控件
//        public static readonly DependencyProperty PasswordProperty =
//            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(string), new
//                 PropertyChangedCallback(OnPropertyChanged)));
//        public static string GetPassword(DependencyObject d)
//        {
//            return d.GetValue(PasswordProperty).ToString();
//        }
//        public static void SetPassword(DependencyObject d, object value)
//        {
//            d.SetValue(PasswordProperty, value);
//        }
//        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            PasswordBox password = d as PasswordBox;
//            password.PasswordChanged -= Password_PasswordChanged;
//            if (_isUpdating)
//                password.Password = e.NewValue?.ToString();
//            password.PasswordChanged += Password_PasswordChanged;
//        }



//        public static readonly DependencyProperty AttachProperty =
//            DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(bool), new
//                 PropertyChangedCallback(OnAttached)));
//        public static bool GetAttach(DependencyObject d)
//        {
//            return (bool)d.GetValue(AttachProperty);
//        }
//        public static void SetAttach(DependencyObject d, object value)
//        {
//            d.SetValue(AttachProperty, value);
//        }
//        //控件的值变化后给推送给附加属性
//        private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            PasswordBox password = d as PasswordBox;
//            password.PasswordChanged += Password_PasswordChanged;
//        }
//        //控件的值变化后给推送给附加属性
//        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
//        {
//            PasswordBox passwordBox = sender as PasswordBox;
//            _isUpdating = true;
//            SetPassword(passwordBox, passwordBox.Password);
//            _isUpdating = false;
//        }
//    }
//}

