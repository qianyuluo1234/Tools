// 修改可参考 http://www.mamicode.com/info-detail-1846020.html
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Conversion_Tool
{
    public enum ConverMode
    {
        Single,
        Multiple
    }
    public enum FormatOption
    {
        JSON,
        XML,
        CVS
    }
    public enum ConvertStateCode
    {
        Success,
        Fail,
        NotFoundExcelFile
    }
    public partial class ExcelTool : Form
    {
        private ConverMode mode = ConverMode.Single;
        string[] codingOption = { "utf-8", "gb2312" };
        private string Coding { get; set; }
        private FormatOption Format { get; set; }
        private List<string> excelPathList = new List<string>();
        private string ExportPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExcelConvertExportFolder";

        public ExcelTool()
        {
            InitializeComponent();
            exportPathInputBox.Text = ExportPath;
            Coding = codingOption[0];
            Format = FormatOption.JSON;
        }

        private void singleToggle_CheckedChanged(object sender, EventArgs e)
        {
            excelListBox.Visible = false;
            countLabel.Visible = false;
            stateLabel.Text = "";
            importPathTextBox.Text = "";
            mode = ConverMode.Single;
            selectButton.Text = "选择文件";

        }

        private void multipleToggle_CheckedChanged(object sender, EventArgs e)
        {
            excelListBox.Visible = true;
            countLabel.Visible = true;
            stateLabel.Text = "";
            importPathTextBox.Text = "";
            mode = ConverMode.Multiple;
            selectButton.Text = "选择文件夹";
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            excelPathList.Clear();
            switch (mode) 
            {
                case ConverMode.Single:
                    SelectFile();
                    if(!string.IsNullOrEmpty(importPathTextBox.Text)&& File.Exists(importPathTextBox.Text))
                        excelPathList.Add(importPathTextBox.Text);
                    break;
                case ConverMode.Multiple:
                    SelectFolderBrowser(importPathTextBox);
                    if (!string.IsNullOrEmpty(importPathTextBox.Text)&&Directory.Exists(importPathTextBox.Text))
                        excelPathList.AddRange(GetAllExcelFile(importPathTextBox.Text));
                    for (int i = 0; i < excelPathList.Count; i++)
                    {
                        excelListBox.Items.Add(excelPathList[i]);
                    }
                    break;
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            SelectFolderBrowser(exportPathInputBox);
            ExportPath = exportPathInputBox.Text;
            stateLabel.Text = ExportPath;
        }
        void SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件|*.xls;*.xlsx";
            ofd.ShowDialog();
            importPathTextBox.Text = ofd.FileName;
        }

        void SelectFolderBrowser(TextBox textBox)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            textBox.Text = fbd.SelectedPath;
        }
        bool SingleConvert(string excelPath,string coding, FormatOption format)
        {
            ExcelUtility excel = new ExcelUtility(excelPath);
            Encoding encoding = Encoding.GetEncoding(coding);

            bool convertFlag = false;
            switch (format)
            {
                case FormatOption.JSON:
                    convertFlag = excel.ConvertToJson(ExportPath, encoding);
                    break;
                case FormatOption.XML:
                    convertFlag = excel.ConvertToXml(ExportPath);
                    break;
                case FormatOption.CVS:
                    convertFlag = excel.ConvertToCSV(ExportPath, encoding);
                    break;
                default:
                    break;
            }
            return convertFlag;
        }
        int[] MultipleConvert(string coding, FormatOption format)
        {
            int seccessCount = 0;
            int failCount = 0;
            for (int i = 0; i < excelPathList.Count; i++)
            {
                if (SingleConvert(excelPathList[i], coding, format))
                    seccessCount++;
                else
                    failCount++;
            }
            return new int[] { seccessCount, failCount };
        }

        private void utf8Toggle_CheckedChanged(object sender, EventArgs e)
        {
            Coding = codingOption[0];
        }

        private void gbToggle_CheckedChanged(object sender, EventArgs e)
        {
            Coding = codingOption[1];
        }

        private void jsonToggle_CheckedChanged(object sender, EventArgs e)
        {
            Format = FormatOption.JSON;
        }

        private void xmlToggle_CheckedChanged(object sender, EventArgs e)
        {
            Format = FormatOption.XML;

        }

        private void csvToggle_CheckedChanged(object sender, EventArgs e)
        {
            Format = FormatOption.CVS;
        }

        private void converButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);

            if (excelPathList.Count != 0)
            {
                if (excelPathList.Count > 1)
                {
                    int[] countArr = MultipleConvert(Coding, Format);
                    stateLabel.Text = string.Format("{0}: {2},{1}: {3}", ConvertStateCode.Success, ConvertStateCode.Fail, countArr[0], countArr[1]);
                }
                else
                {
                    stateLabel.Text = SingleConvert(excelPathList[0], Coding, Format) ? ConvertStateCode.Success.ToString() : ConvertStateCode.Fail.ToString();
                }
            }
            else
            {
                stateLabel.Text = ConvertStateCode.NotFoundExcelFile.ToString();
            }
        }
        public static string[] GetAllExcelFile(string path)
        {
            if (!Directory.Exists(path))
                return null;
            List<string> files = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                FileInfo[] fileInfos = dir.GetFiles();
                for (int i = 0; i < fileInfos.Length; i++)
                {
                    if (fileInfos[i].Extension == ".xlsx")
                        files.Add(fileInfos[i].FullName);
                }
            
                DirectoryInfo[] dirInfos = dir.GetDirectories();
                for (int i = 0; i < dirInfos.Length; i++)
                {
                    Console.WriteLine(dirInfos[i].FullName);
                    files.AddRange(GetAllExcelFile(dirInfos[i].FullName));
                }
            }
            catch{ }
            return files.ToArray();
        }

        private void openAssetMessageButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = ExportPath;
            p.Start();
        }
    }
}
