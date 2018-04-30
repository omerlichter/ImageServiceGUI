using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ImageServiceGUI.controls
{
    class ModelSettingsPage : IModelSettingsPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string outputDirectory;
        private string sourceName;
        private string logName;
        private int thumbnailSize;

        public string OutputDirectory {
            set {
                this.outputDirectory = value;
                this.NotifyPropertyChanged("OutputDirectory");
            }
            get { return this.outputDirectory; }
        }
        public string SourceName {
            set {
                this.sourceName = value;
                this.NotifyPropertyChanged("SourceName");
            }
            get { return this.sourceName; }
        }
        public string LogName {
            set {
                this.logName = value;
                this.NotifyPropertyChanged("LogName");
            }
            get { return this.logName; }
        }
        public int ThumbnailSize {
            set {
                this.thumbnailSize = value;
                this.NotifyPropertyChanged("ThumbnailSize");
            }
            get { return this.thumbnailSize; }
        }

        public void NotifyPropertyChanged(string propName) {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public bool GetSettingsFromService()
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
                TcpClient client = new TcpClient();
                client.Connect(ep);

                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Send data to server
                    writer.Write("bla");

                    // Get result from server
                    int result = reader.ReadInt32();
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
