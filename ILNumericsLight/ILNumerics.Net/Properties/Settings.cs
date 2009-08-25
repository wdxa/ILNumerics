#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Xml.Serialization;

namespace ILNumerics
{
    [XmlRoot("Settings", Namespace = "", IsNullable = false)]
    public class Settings
    {
        private static Settings configFile = ConstructSettings();
        public static Settings ConfigFile
        {
            get { return configFile; }
        }

        public static Settings ConstructSettings()
        {
            Settings newSettings;
            FileStream configFileStream = null;

            try
            {
                string appDir = (new DirectoryInfo(Assembly.GetExecutingAssembly().Location)).Parent.FullName;
                string configLoc = appDir + Path.DirectorySeparatorChar + "ILNumericsLight.dll.config";

                configFileStream = new FileStream(configLoc, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                newSettings = (Settings)serializer.Deserialize(configFileStream);

            } catch (Exception) {
                newSettings = new Settings();

            } finally {
                if (configFileStream != null)
                    configFileStream.Dispose();
            }

            return newSettings;
        }

        public Settings()
        {
            LAPACKLibrary = "ILManagedLapack";
            fftLibrary = "ILMKLFFT";
        }

        private string lapackLibrary, fftLibrary;

        [XmlElement("LAPACKLibrary")]
        public string LAPACKLibrary
        {
            get { return lapackLibrary; }
            set { lapackLibrary = value; }
        }

        [XmlElement("FFTLibrary")]
        public string FFTLibrary
        {
            get { return fftLibrary; }
            set { fftLibrary = value; }
        }

    }
}
