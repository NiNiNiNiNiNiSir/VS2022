using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Common
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return DoCanExecute?.Invoke(parameter) == true;
        }

        public void Execute(object parameter)
        {
            DoExecute?.Invoke(parameter); //?.是如果不为空   DoExecute如果不为空则执行Invoke(parameter)
        }

        public Action<object> DoExecute { get; set; }  //Action是类库内置委托

        public Func<object,bool> DoCanExecute { get; set; } //Func是类库内置委托
    }
}
