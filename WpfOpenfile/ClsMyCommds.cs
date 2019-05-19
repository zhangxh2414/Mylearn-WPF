using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfOpenfile
{
    class ClsMyCommds : ICommand
    {
        #region ICommand内部方法的实现
        public event EventHandler CanExecuteChanged
        {
            //Command检测到可能会影响到命令的可执行状态时触发RequerySuggested事件；
            add
            {
                CommandManager.RequerySuggested += value;

            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        //监听了该事件命令的对象调用 CanExecute(object parameter)方法检测命令是否可以执行，并将bool类型的返回值设置到绑定该控件的IsEnabled属性上
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
        #endregion
        #region ClsMyCommds用户自定义
        //构造函数中传入Action<object>和Func<object,bool>，让CanExecute执行Func<object,bool>，Execute执行Action<object>。
        private Func<object, bool> _canExecute;
        private Action<object> _execute;
        public ClsMyCommds(Action<object> execute):this(execute,null)
        {
        }

        public ClsMyCommds(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

    }
}
