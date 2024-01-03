using System;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;
using BarcodePrinter_API;
using BarcodePrinter_API.Comm;
using BarcodePrinter_API.Emulation.PPLB;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model;
using System.Collections.Generic;

namespace 移动家客WinApp.SerialPortLib
{
    internal class ArgonPPLB : IPrintBase
    {
        public ArgonPPLB(string USBDevicePath)
        {
            this.USBDevicePath = USBDevicePath;
        }

        private string USBDevicePath;

        private string Name = nameof(ArgonPPLB);
        private BarcodePrinter BarcodePrinter;
        private PPLB PPLBEmulation;

        private bool __createPrn()
        {
            bool isRight = true;
            IPrinterConnection fs = null;

            try
            {
                //create a connection.
                fs = new USBConnection(USBDevicePath);

                if (null == fs)
                    return false;
                //give a connection to the BarcodePrinter.AddConnection() method.
                BarcodePrinter = new BarcodePrinter();
                BarcodePrinter.AddConnection(fs);
                BarcodePrinter.Connection.Open(); // equal to fs.Open();
                PPLBEmulation = new PPLB();
                BarcodePrinter.AddEmulation(PPLBEmulation);
                return true;
            }

            //exception.
            catch (Exception ex)
            {
                ShowException.Show(this.Name, "__createPrn", ex);
            }
            finally
            {
                if ((false == isRight) && (null != fs))
                {
                    fs.Close();// equal to BarcodePrinter.Connection.Close();
                    fs = null;
                }
            }
            return isRight;
        }

        public void TerminalPrint(string areaname, string username, string manufactor, string model, string type, string Usually, string barCode, string num, DateTime time, string openport)
        {
            byte[] buf;
            Encoding encoder = Encoding.UTF8;

            if (false == __createPrn())
                return;

            try
            {
                PPLBEmulation.SetUtil.SetOrientation(true);//打印方向
                PPLBEmulation.SetUtil.SetHomePosition(0, 0);//原點位置
                PPLBEmulation.SetUtil.SetHardwareOption(PPLBMediaType.Direct_Thermal_Media, PPLBPrintMode.Tear_Off, 0);//硬件设定，包含：纸张的种类，打印后对标签纸的动作模式.
                PPLBEmulation.SetUtil.SetClearImageBuffer(); //清除图像缓冲区

                PPLBEmulation.TextUtil.PrintTextGraphic(300, 15, "宋体", 23, true, false, false, false, $"地区:{areaname}   发货部门:WH01  {username}", PPLBOrient.Clockwise_0_Degrees, 0);

                PPLBEmulation.TextUtil.PrintTextGraphic(300, 15 + 55, "宋体", 23, true, false, false, false, $"厂家:{manufactor}  型号:{model}  {type}", PPLBOrient.Clockwise_0_Degrees, 0);

                buf = encoder.GetBytes($"SN");
                PPLBEmulation.TextUtil.PrintText(300, 15 + 55 + 55, PPLBOrient.Clockwise_0_Degrees, PPLBFont.Font_3, 1, 1, false, buf);

                buf = encoder.GetBytes($"{barCode}");
                PPLBEmulation.BarcodeUtil.PrintOneDBarcode(300 + 65, 15 + 55 + 55, PPLBOrient.Clockwise_0_Degrees,
                    PPLBBarCodeType.Code_128_Auto_Mode, 2, 4, 120, false, buf);//一维条形码

                PPLBEmulation.TextUtil.PrintTextGraphic(300 + 65, 15 + 55 + 55 + 120 + 20, "宋体", 23, true, false, false, false, $"{barCode}", PPLBOrient.Clockwise_0_Degrees, 0);

                PPLBEmulation.TextUtil.PrintTextGraphic(300, 15 + 55 + 55 + 120 + 20 + 55, "宋体", 23, true, false, false, false, $"箱号:{num}", PPLBOrient.Clockwise_0_Degrees, 0);

                PPLBEmulation.TextUtil.PrintTextGraphic(300, 15 + 55 + 55 + 120 + 20 + 55 + 55, "宋体", 23, true, false, false, false, $"时间:{ time.ToString("yyyy/MM/dd")}", PPLBOrient.Clockwise_0_Degrees, 0);

                PPLBEmulation.SetUtil.SetPrintOut(1, 1);
                PPLBEmulation.IOUtil.PrintOut();
            }
            catch (Exception ex)
            {
                ShowException.Show(this.Name, "TerminalPrint", ex);
            }
            finally
            {
                BarcodePrinter.Connection.Close(); // equal to fs.Close();
            }
        }

        public void BoxsPrint(int i, string areaname, List<ModelGroup> list, int SortCount, string Num, string username, DateTime time, string openport)
        {
            if (false == __createPrn())
                return;

            try
            {
                PPLBEmulation.SetUtil.SetOrientation(true);//打印方向
                PPLBEmulation.SetUtil.SetHomePosition(0, 0);//原點位置
                PPLBEmulation.SetUtil.SetHardwareOption(PPLBMediaType.Direct_Thermal_Media, PPLBPrintMode.Tear_Off, 0);//硬件设定，包含：纸张的种类，打印后对标签纸的动作模式.
                PPLBEmulation.SetUtil.SetClearImageBuffer(); //清除图像缓冲区

                int y = 15 + 55 + 55 + 55;
                if (i == 0)
                {
                    PPLBEmulation.TextUtil.PrintTextGraphic(300, 15, "宋体", 33, true, false, false, false, $"地区:{areaname} 封箱人:{username}", PPLBOrient.Clockwise_0_Degrees, 0);

                    PPLBEmulation.TextUtil.PrintTextGraphic(300, 15 + 55, "宋体", 33, true, false, false, false, $"时间:{time.ToString("yyyy/MM/dd")}", PPLBOrient.Clockwise_0_Degrees, 0);

                    PPLBEmulation.TextUtil.PrintTextGraphic(300 + 390, 15 + 55, "宋体", 33, true, false, false, false, $"封箱数量:{SortCount}", PPLBOrient.Clockwise_0_Degrees, 0);

                    PPLBEmulation.TextUtil.PrintTextGraphic(300, 15 + 55 + 55, "宋体", 33, true, false, false, false, $"箱号:{Num}", PPLBOrient.Clockwise_0_Degrees, 0);
                }
                else
                {
                    y = 10;
                }

                //循环终端信息,取出厂家型号以及数量
                string ManufactorName = "";
                foreach (var item in list)
                {
                    if (ManufactorName != item.ManufactorName)
                    {
                        PPLBEmulation.TextUtil.PrintTextGraphic(300, y, "宋体", 33, true, false, false, false, $"{ item.ManufactorName }", PPLBOrient.Clockwise_0_Degrees, 0);
                    }

                    PPLBEmulation.TextUtil.PrintTextGraphic(300 + 270, y, "宋体", 33, true, false, false, false, $"{ item.TerminalModelName }", PPLBOrient.Clockwise_0_Degrees, 0);

                    PPLBEmulation.TextUtil.PrintTextGraphic(300 + 270 + 340, y, "宋体", 33, true, false, false, false, $"{ item.Count}", PPLBOrient.Clockwise_0_Degrees, 0);
                    ManufactorName = item.ManufactorName;
                    y += 55;
                }

                PPLBEmulation.SetUtil.SetPrintOut(1, 1);
                PPLBEmulation.IOUtil.PrintOut();
            }
            catch (Exception ex)
            {
                ShowException.Show(this.Name, "BoxsPrint", ex);
            }
            finally
            {
                BarcodePrinter.Connection.Close(); // equal to fs.Close();
            }
        }
    }
}
