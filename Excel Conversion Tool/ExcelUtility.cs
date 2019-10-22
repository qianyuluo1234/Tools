using System.Collections;
using System.Collections.Generic;
using Excel;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Reflection;
using System;

public class ExcelUtility
{

	/// <summary>
	/// 表格数据集合
	/// </summary>
	private DataSet mResultSet;

    public string FileName { get; private set; }

    static StringBuilder PathBuider { set; get; } = new StringBuilder();
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="excelFile">Excel file.</param>
    public ExcelUtility (string excelFile)
	{
		FileStream mStream = File.Open (excelFile, FileMode.Open, FileAccess.Read);
        FileName = Path.GetFileNameWithoutExtension(mStream.Name);

        IExcelDataReader mExcelReader = Path.GetExtension(mStream.Name) == ".xls"
            ? ExcelReaderFactory.CreateBinaryReader(mStream)
            : ExcelReaderFactory.CreateOpenXmlReader(mStream); 
		mResultSet = mExcelReader.AsDataSet ();
	}
			
	/// <summary>
	/// 转换为实体类列表
	/// </summary>
	public List<T> ConvertToList<T> ()
	{
		//判断Excel文件中是否存在数据表
		if (mResultSet.Tables.Count < 1)
			return null;
		//默认读取第一个数据表
		DataTable mSheet = mResultSet.Tables [0];
			
		//判断数据表内是否存在数据
		if (mSheet.Rows.Count < 1)
			return null;

		//读取数据表行数和列数
		int rowCount = mSheet.Rows.Count;
		int colCount = mSheet.Columns.Count;
				
		//准备一个列表以保存全部数据
		List<T> list = new List<T> ();
				
		//读取数据
		for (int i=1; i<rowCount; i++) 
		{
			//创建实例
			Type t = typeof(T);
			ConstructorInfo ct = t.GetConstructor (System.Type.EmptyTypes);
			T target = (T)ct.Invoke (null);
			for (int j=0; j<colCount; j++) 
			{
				//读取第1行数据作为表头字段
				string field = mSheet.Rows [0] [j].ToString ();
				object value = mSheet.Rows [i] [j];
				//设置属性值
				SetTargetProperty (target, field, value);
			}
					
			//添加至列表
			list.Add (target);
		}
				
		return list;
	}

	/// <summary>
	/// 转换为Json
	/// </summary>
	/// <param name="jsonPath">Json文件路径</param>
	/// <param name="Header">表头行数</param>
	public bool ConvertToJson (string jsonPath, Encoding encoding)
	{
        if (!ConvertReady(out DataTable mSheet)) return false;

        //读取数据表行数和列数
        int rowCount = mSheet.Rows.Count;
		int colCount = mSheet.Columns.Count;

		//准备一个列表存储整个表的数据
		List<Dictionary<string, object>> table = new List<Dictionary<string, object>> ();

		//读取数据
		for (int i = 1; i < rowCount; i++) {
			//准备一个字典存储每一行的数据
			Dictionary<string, object> row = new Dictionary<string, object> ();
			for (int j = 0; j < colCount; j++) {
				//读取第1行数据作为表头字段
				string field = mSheet.Rows [0] [j].ToString ();
				//Key-Value对应
				row [field] = mSheet.Rows [i] [j];
			}

			//添加到表数据中
			table.Add (row);
		}

		//生成Json字符串
		string json = JsonConvert.SerializeObject (table, Newtonsoft.Json.Formatting.Indented);
		//写入文件
		using (FileStream fileStream=new FileStream(BuildPath(jsonPath, ".json", FileName), FileMode.Create,FileAccess.Write)) 
        {
			using (TextWriter textWriter = new StreamWriter(fileStream, encoding)) 
            {
				textWriter.Write (json);
			}
		}
        return true;
	}

	/// <summary>
	/// 转换为CSV
	/// </summary>
	public bool ConvertToCSV (string csvPath, Encoding encoding)
	{
        if (!ConvertReady(out DataTable mSheet)) return false;

		//读取数据表行数和列数
		int rowCount = mSheet.Rows.Count;
		int colCount = mSheet.Columns.Count;

		//创建一个StringBuilder存储数据
		StringBuilder stringBuilder = new StringBuilder ();

		//读取数据
		for (int i = 0; i < rowCount; i++) 
        {
			for (int j = 0; j < colCount; j++) 
            {
				//使用","分割每一个数值
				stringBuilder.Append (mSheet.Rows [i] [j] + ",");
			}
			//使用换行符分割每一行
			stringBuilder.Append ("\r\n");
		}

		//写入文件
		using (FileStream fileStream = new FileStream(BuildPath(csvPath, ".csv", FileName), FileMode.Create, FileAccess.Write)) {
			using (TextWriter textWriter = new StreamWriter(fileStream, encoding)) {
				textWriter.Write (stringBuilder.ToString ());
			}
		}
        return true;
	}

	/// <summary>
	/// 导出为Xml
	/// </summary>
	public bool ConvertToXml (string xmlPath)
	{
        if (!ConvertReady(out DataTable mSheet)) return false;
        
        //读取数据表行数和列数
        int rowCount = mSheet.Rows.Count;
        int colCount = mSheet.Columns.Count;
        //创建一个StringBuilder存储数据
        StringBuilder stringBuilder = new StringBuilder ();
		//创建Xml文件头
		stringBuilder.Append ("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
		stringBuilder.Append ("\r\n");
		//创建根节点
		stringBuilder.Append ("<Table>");
		stringBuilder.Append ("\r\n");
		//读取数据
		for (int i = 1; i < rowCount; i++) {
			//创建子节点
			stringBuilder.Append ("  <Row>");
			stringBuilder.Append ("\r\n");
			for (int j = 0; j < colCount; j++) {
				stringBuilder.Append ("   <" + mSheet.Rows [0] [j].ToString () + ">");
				stringBuilder.Append (mSheet.Rows [i] [j].ToString ());
				stringBuilder.Append ("</" + mSheet.Rows [0] [j].ToString () + ">");
				stringBuilder.Append ("\r\n");
			}
			//使用换行符分割每一行
			stringBuilder.Append ("  </Row>");
			stringBuilder.Append ("\r\n");
		}
		//闭合标签
		stringBuilder.Append ("</Table>");
		//写入文件
		using (FileStream fileStream = new FileStream(BuildPath(xmlPath,".xml",FileName), FileMode.Create, FileAccess.Write)) {
			using (TextWriter textWriter = new StreamWriter(fileStream,Encoding.GetEncoding("utf-8"))) {
				textWriter.Write (stringBuilder.ToString ());
			}
		}
        return true;
	}
    bool ConvertReady(out DataTable table)
    {
        //判断Excel文件中是否存在数据表
        table = null;
        if (mResultSet.Tables.Count < 1)
            return false;

        //默认读取第一个数据表
        table = mResultSet.Tables[0];

        //判断数据表内是否存在数据
        if (table.Rows.Count < 1)
            return false;

        return true;
    }

    static string BuildPath(string path, string extensionName, params string[] arg)
    {
        PathBuider.Clear();
        PathBuider.Append(path);
        if (arg != null && arg.Length > 0)
        {
            for (int i = 0; i < arg.Length; i++)
            {
                PathBuider.Append("\\");
                PathBuider.Append(arg[i]);
            }
        }
        PathBuider.Append(extensionName);
        return PathBuider.ToString();
    }
    /// <summary>
    /// 设置目标实例的属性
    /// </summary>
    private void SetTargetProperty (object target, string propertyName, object propertyValue)
	{
		//获取类型
		Type mType = target.GetType ();
		//获取属性集合
		PropertyInfo[] mPropertys = mType.GetProperties ();
		foreach (PropertyInfo property in mPropertys) {
			if (property.Name == propertyName) {
				property.SetValue (target, Convert.ChangeType (propertyValue, property.PropertyType), null);
			}
		}
	}
}

