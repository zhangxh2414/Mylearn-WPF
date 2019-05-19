using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfOpenfile
{
    class clsNotifyobject : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 该作为用户自定义的基础类，继承于INotifyPropertyChanged，当ViewModel操作修改数据源时，向View发出“XXX属性发生改变了的通知，具体View中谁发生相应的改变，这里不关心”
        /// </summary>
        /// <param name="propertyName">已经发生更改的属性的名称</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SetAndNotifyIfChanged<T>(string propertyName, ref T oldValue, T newValue)
        {
            if (oldValue == null && newValue == null) return;
            if (oldValue != null && oldValue.Equals(newValue)) return;
            if (newValue != null && newValue.Equals(oldValue)) return;
            oldValue = newValue;
            RaisePropertyChanged(propertyName);
        }
    }
}
