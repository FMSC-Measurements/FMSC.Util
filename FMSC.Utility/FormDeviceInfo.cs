using System;
//using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FMSC.Utility
{
    public partial class FormDeviceInfo : Form
    {
        public FormDeviceInfo()
        {
            InitializeComponent();
        }

        private void FormDeviceInfo_Load(object sender, EventArgs e)
        {
            MobileDeviceInfo DeviceInfo = new MobileDeviceInfo();
            string DeviceInfoString = "Manufacturer:\t" + DeviceInfo.platformManufacturer + "\r\n";
            DeviceInfoString += "Model:\t\t" + DeviceInfo.deviceModel + "\r\n";
            DeviceInfoString += "Identification:\t" + DeviceInfo.serialNumber + "\r\n";
            DeviceInfoString += "Win CE Version:\t" + DeviceInfo.OSVersion + "\r\n";
            DeviceInfoString += "Platform Type:\t" + DeviceInfo.betterPlatformType + "\r\n";
            DeviceInfoString += "Owner Name:\t" + DeviceInfo.userName + "\r\n";
            DeviceInfoString += "Device Name:\t" + DeviceInfo.machineName + "\r\n";
            DeviceInfoString += "Device Description:\t" + DeviceInfo.machineDescription + "\r\n";

            textBoxDeviceInfo.Text = DeviceInfoString;
        }
    }
}