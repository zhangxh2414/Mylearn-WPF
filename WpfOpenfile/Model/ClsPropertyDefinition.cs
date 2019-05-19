using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.Windows.Forms;

namespace WpfOpenfile.Model
{
    /// <summary>
    /// 作者：张晓恒
    /// INotifyPropertyChanged包含在 System.ComponentModel程序集中;
    /// 该类用于定义可能会用于绑定的普通属性或依赖属性；
    /// 该类同样需要继承于INotifyPropertyChanged或者用户自定义的继承于INotifyPropertyChanged的子类；
    /// </summary>
    class ClsPropertyDefinition :clsNotifyobject,INotifyPropertyChanged
    {
        private string _basePropertyName;
        //项目基本信息属性名称
        public string BasePropertyName
        {
            get { return _basePropertyName; }
            set
            {
                if (_basePropertyName!=value)
                {
                    _basePropertyName = value;
                    RaisePropertyChanged("BasePropertyName");
                }
            }       
        }

        private string _basePropertyValue;
        //项目基本信息属性值
        public string BasePropertyValue
        {
            get { return _basePropertyValue; }
            set
            {
                if(_basePropertyValue!= value)
                {
                    _basePropertyValue = value;
                    RaisePropertyChanged("BasePropertyValue");
                }
            }
        }

        private string _filePathName;
        //文件路径
        public string FilepathName
        {
            get { return _filePathName; }
            set
            {
                if (_filePathName != value)
                {
                    _filePathName = value;
                    RaisePropertyChanged("FilepathName");
                }
            }
        }

        //读取ifc属性
        public  static IEnumerable<ClsPropertyDefinition> GetifcProperties(string ifcfileName)
        {

            if (ifcfileName.ToString() == string.Empty)
            {
                yield break;
            }
            else
            {
                var Model = IfcStore.Open(ifcfileName);
                var allSites = Model.Instances.OfType<IIfcSite>();
                if (allSites.Count() == 0)
                {
                    yield break;
                }
                IIfcSite theSite = allSites.First();//get site

                var properties = theSite.IsDefinedBy
                    .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                    .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                    .OfType<IIfcPropertySingleValue>();
                foreach (var property in properties)
                {
                    yield return new ClsPropertyDefinition
                    {
                        BasePropertyName = property.Name,
                        BasePropertyValue = property.NominalValue.ToString(),
                    };
                }
            }
        }

        //打开IFC路径
        public static ClsPropertyDefinition GetFileName()
        {
            string str;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "选择IFC模型";
            dlg.FileName = "IFC Files";
            dlg.Filter = "IFC文件|*.ifc";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                str = dlg.FileName;
            }
            return new ClsPropertyDefinition { FilepathName = dlg.FileName, };
        }
           
    }
}
