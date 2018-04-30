using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ImageServiceGUI.controls
{
    class VMSettingsPage : IVMSettingsPage
    {
        private IModelSettingsPage model;
        public event PropertyChangedEventHandler PropertyChanged;

        public string VM_OutputDirectory
        {
            get { return this.model.OutputDirectory; }
        }

        public string VM_SourceName
        {
            get { return this.model.SourceName; }
        }

        public string VM_LogName
        {
            get { return this.model.LogName; }
        }

        public int VM_ThumbnailSize
        {
            get { return this.model.ThumbnailSize; }
        }

        public VMSettingsPage(IModelSettingsPage model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            model.GetSettingsFromService();

        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
