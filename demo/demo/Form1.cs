using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action();
        }

        // Main procedure 
        private void action()
        {


            // Local iconic variables 

            HObject ho_Image, ho_SymbolXLDs;

            // Local control variables 

            HTuple hv_DataCodeHandle = null, hv_ResultHandles = null;
            HTuple hv_DecodedDataStrings = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
            //读取图像
            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, "img.png");
            //创建二维码解码模型
            HOperatorSet.CreateDataCode2dModel("QR Code", new HTuple(), new HTuple(), out hv_DataCodeHandle);
            //解析二维码
            ho_SymbolXLDs.Dispose();
            HOperatorSet.FindDataCode2d(ho_Image, out ho_SymbolXLDs, hv_DataCodeHandle, new HTuple(),
                new HTuple(), out hv_ResultHandles, out hv_DecodedDataStrings);
            //清除模型
            HOperatorSet.ClearDataCode2dModel(hv_DataCodeHandle);


            //显示图像 hWindowControl1.HalconWindow为界面上那个窗口的句柄
            HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);

            //释放图像
            ho_Image.Dispose();
            ho_SymbolXLDs.Dispose();
            
            //弹出解码结果
            MessageBox.Show("解码结果："+ hv_DecodedDataStrings);

        }
    }
}
