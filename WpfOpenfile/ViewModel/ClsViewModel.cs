using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using WpfOpenfile.Model;


namespace WpfOpenfile.ViewModle
{
    class ClsViewModel:clsNotifyobject
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                RaisePropertyChanged("FilePath");
            }
        }
        
        /// <summary>
        /// 列表类数据
        /// </summary>
        private ObservableCollection<ClsPropertyDefinition> _dataList;
        public ObservableCollection<ClsPropertyDefinition> DataList
        {
            get { return _dataList; }
            set
            {
                if (_dataList != value)
                {
                    _dataList = value;
                    SetAndNotifyIfChanged("DataList", ref _dataList, value);
                }
            }
        }

        //“打开”命定
        private ClsMyCommds _CmdOpen;
        public ClsMyCommds CmdOpen
        {
            get
            {
                if(_CmdOpen == null)
                {
                    _CmdOpen = new ClsMyCommds(new Action<object>
                    (
                         o =>
                         {
                            var clsproperty= ClsPropertyDefinition.GetFileName();
                             FilePath = clsproperty.FilepathName;
                             DataList = new ObservableCollection<ClsPropertyDefinition>(ClsPropertyDefinition.GetifcProperties(FilePath));
                         }
                    ));
                }
                return _CmdOpen;
            }
        }

        //测试用
        //private ClsMyCommds _normalCommand;
        //public ClsMyCommds NormalCommand
        //{
        //    get
        //    {
        //        if (_normalCommand == null)
        //            _normalCommand = new ClsMyCommds(
        //                new Action<object>(
        //                    o => System.Windows.MessageBox.Show("这是个普通命令!")));
        //        return _normalCommand;
        //    }
        //}

    }
}
