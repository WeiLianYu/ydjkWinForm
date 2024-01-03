using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model;

namespace 移动家客WinApp.SerialPortLib
{
    public class TSCPrint : IPrintBase
    {
        public void TerminalPrint(string areaname, string username, string manufactor, string model, string type, string Usually, string barCode, string num, DateTime time, string openport)
        {
            //TSCSDK.comport TSCLIB_DLL = new driver();
            // 打开 打印机 端口.
            TSCLIB_DLL.openport(openport);
            // 设置标签 宽度、高度 等信息.
            // 宽 94mm  高 25mm
            // 速度为4
            // 字体浓度为8
            // 使用垂直間距感測器(gap sensor)
            // 两个标签之间的  间距为 3.5mm
            TSCLIB_DLL.setup("70", "40", "8", "8", "0", "3.5", "0");
            // 清除缓冲信息
            TSCLIB_DLL.clearbuffer();
            // 发送 TSPL 指令.
            // 设置 打印的方向.
            TSCLIB_DLL.sendcommand("DIRECTION 1");
            //TSCLIB_DLL.sendcommand("DIRECTION 1");
            // 打印文本信息.
            // 在 (176, 16) 的坐标上
            // 字体高度为34
            // 旋转的角度为 0 度
            // 2 表示 粗体.
            // 文字没有下划线.
            // 字体为 黑体.
            // 打印的内容为：title

            TSCLIB_DLL.windowsfont(80, 6, 22, 0, 2, 0, "宋体", $"地区:{areaname}   发货部门:WH01  {username}");

            TSCLIB_DLL.windowsfont(90, 50, 22, 0, 2, 0, "宋体", $"厂家:{manufactor}  型号:{model}  {type}");

            // 打印条码.
            // 在 (176, 66) 的坐标上
            // 以 Code39 的条码方式
            // 条码高度 130
            // 打印条码的同时，还打印条码0的文本信息.
            // 旋转的角度为 0 度
            // 条码 宽 窄 比例因子为 7:12
            // 条码内容为:barCode
            TSCLIB_DLL.windowsfont(80, 100, 22, 0, 2, 0, "宋体", "SN");

            TSCLIB_DLL.barcode("140", "80", "128", "80", "0", "0", "1", "1", barCode);
            //if (barCode.Length > 16)
            //{
            //    barCode = barCode.Substring(barCode.Length - 15);
            //}
            TSCLIB_DLL.windowsfont(80, 160, 22, 0, 2, 0, "宋体", $"{barCode}");
            TSCLIB_DLL.windowsfont(80, 200, 22, 0, 2, 0, "宋体", $"箱号:{ num}");
            TSCLIB_DLL.windowsfont(80, 240, 22, 0, 2, 0, "宋体", $"时间: { time.ToString("yyyy/MM/dd")}");
            TSCLIB_DLL.windowsfont(80, 280, 22, 0, 2, 0, "宋体", $"{Usually}");

            // 打印.
            TSCLIB_DLL.printlabel("1", "1");
            // 关闭 打印机 端口
            TSCLIB_DLL.closeport();
        }

        public void BoxsPrint(int i, string areaname, List<ModelGroup> list, int SortCount, string Num, string username, DateTime time, string openport)
        {
            //TSCSDK.comport TSCLIB_DLL = new driver();
            // 打开 打印机 端口.
            TSCLIB_DLL.openport(openport);
            // 设置标签 宽度、高度 等信息.
            // 宽 94mm  高 25mm
            // 速度为4
            // 字体浓度为8
            // 使用垂直間距感測器(gap sensor)
            // 两个标签之间的  间距为 3.5mm
            TSCLIB_DLL.setup("70", "40", "8", "8", "0", "3.5", "0");
            // 清除缓冲信息
            TSCLIB_DLL.clearbuffer();
            // 发送 TSPL 指令.
            // 设置 打印的方向.
            TSCLIB_DLL.sendcommand("DIRECTION 1");
            //TSCLIB_DLL.sendcommand("DIRECTION 1");
            // 打印文本信息.
            // 在 (176, 16) 的坐标上
            // 字体高度为34
            // 旋转的角度为 0 度
            // 2 表示 粗体.
            // 文字没有下划线.
            // 字体为 黑体.
            // 打印的内容为：title

            //TSCLIB_DLL.windowsfontunicode(50, 80, 8, 0, 2, 0, "Arial", "122343343");

            #region MyRegion

            // 打印条码.
            // 在 (176, 66) 的坐标上
            // 以 Code39 的条码方式
            // 条码高度 130
            // 打印条码的同时，还打印条码0的文本信息.
            // 旋转的角度为 0 度
            // 条码 宽 窄 比例因子为 7:12
            // 条码内容为:barCode
            // TSCLIB_DLL.windowsfont(160, 140, 22, 0, 2, 0, "宋体", "SN");

            //    //功能：繪製QRCODE二維條碼
            //    //語法：
            //    //QRCODE X, Y, ECC Level, cell width, mode, rotation, [model, mask,]"Data string”
            //    //參數說明
            //    //X QRCODE條碼左上角X座標
            //    //Y QRCODE條碼左上角Y座標
            //    //ECC level 錯誤糾正能力等級
            //    //L 7%
            //    //M 15%
            //    //Q 25%
            //    //H 30%
            //    //cell width    1~10
            //    //mode  自動生成編碼/手動生成編碼
            //    //A Auto
            //    //M Manual
            //    //rotation  順時針旋轉角度
            //    //0 不旋轉
            //    //90    順時針旋轉90度
            //    //180   順時針旋轉180度
            //    //270   順時針旋轉270度
            //    //model 條碼生成樣式
            //    //1 (預設), 原始版本
            //    //2 擴大版本
            //    //mask  範圍：0~8，預設7
            //    //Data string   條碼資料內容

            //TSCLIB_DLL.barcode("90", "110", "128", "45", "1", "0", "1", "1", barCode);

            #endregion MyRegion

            string command = "QRCODE 50,30,Q,8,A,0,M2,S7,\"" + Num + "\"";

            
            int y = 130;
            if (i == 0)
            {
                //生成二维码
                //TSCLIB_DLL.sendcommand(command);
                TSCLIB_DLL.windowsfont(60, 10, 30, 0, 2, 0, "宋体", $"地区:{areaname} 封箱人:{username}");
                TSCLIB_DLL.windowsfont(60, 50, 30, 0, 2, 0, "宋体", $"时间:{time.ToString("yyyy/MM/dd")}");

                TSCLIB_DLL.windowsfont(330, 50, 30, 0, 2, 0, "宋体", $"封箱数量:{SortCount}");
                TSCLIB_DLL.windowsfont(60, 90, 30, 0, 2, 0, "宋体", $"箱号:{ Num}");
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
                    TSCLIB_DLL.windowsfont(60, y, 30, 0, 2, 0, "宋体", $"{ item.ManufactorName }");
                }

                TSCLIB_DLL.windowsfont(250, y, 30, 0, 2, 0, "宋体", $"{ item.TerminalModelName }");
                TSCLIB_DLL.windowsfont(450, y, 30, 0, 2, 0, "宋体", $"{ item.Count}");
                ManufactorName = item.ManufactorName;
                y += 35;
            }

            // 打印.
            TSCLIB_DLL.printlabel("1", "1");
            // 关闭 打印机 端口
            TSCLIB_DLL.closeport();
        }
    }
}