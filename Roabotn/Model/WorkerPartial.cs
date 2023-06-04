using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Roabotn.Model;

namespace Roabotn.Model
{
    public partial class Worker
    {
        public ImageSource ImagePath { get {
                byte[] image = null;
                if (Image == null)
                {
                    image = File.ReadAllBytes($"..\\..\\Assets\\Images\\no_foto.png");
                }
                else
                {
                   image = File.ReadAllBytes($"..\\..\\Assets\\Images\\{Image}");
                   
                }
                return new
                       ImageSourceConverter().ConvertFrom(image) as ImageSource;

            }
        }
        
    }
}
