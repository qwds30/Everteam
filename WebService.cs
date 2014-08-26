using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string recordsInDataBase() {
        OleDbConnection dbconn = new OleDbConnection("provider=Microsoft.Jet.OleDb.4.0;Data Source=G:\\项目\\DIS\\代码\\DIS\\App_Data\\DIS.mdb;");
        dbconn.Open();
        OleDbCommand dbcommand = new OleDbCommand("SELECT * FROM pimMemoTable", dbconn);
        OleDbDataReader dbReader = dbcommand.ExecuteReader();
        string contentInLabel = @"{""Memo"":[";
        if (dbReader != null)
        {
            while (dbReader.Read())
            { 
                contentInLabel += @"{""summary"":""";
                contentInLabel += dbReader["summary"].ToString();
                contentInLabel += @""",""details"":""";
                contentInLabel += dbReader["details"].ToString();
                contentInLabel += @""",""memoOrder"":""";
                contentInLabel += dbReader["memoOrder"].ToString();
                contentInLabel += @""",""createTime"":""";
                contentInLabel += dbReader["createTime"].ToString();
                contentInLabel += @""",""theme"":""";
                contentInLabel += dbReader["theme"].ToString();
                contentInLabel += @""",""remindTime"":""";
                contentInLabel += dbReader["remindTime"].ToString();
                contentInLabel += @""",""isHighlight"":""";
                contentInLabel += dbReader["isHighlight"].ToString();
                contentInLabel += @""",""isRemind"":""";
                contentInLabel += dbReader["isRemind"].ToString();
                contentInLabel += @"""},";
                

            }
            contentInLabel += @"{""summary"":""reserved"",""details"":""reserved"",""memoOrder"":""reserved"",""createTime"":""reserved"",""theme"":""reserved"",""remindTime"":""reserved"",""isHighlight"":""reserved"",""isRemind"":""reserved""}]}";

        }
        dbReader.Close();
        dbconn.Close();
        return contentInLabel;
    }
    [WebMethod]
    public void analysisJson(string jsonText)
    {
        System.IO.StringReader strReader = new System.IO.StringReader(jsonText);
        JsonReader reader = new JsonTextReader(strReader);
        string[] strAry = new string[5];
        for (int i = 0; i < 5; i++)
        {
            reader.Read();
            strAry[i] = "";
            strAry[i] += reader.Value;

        }

        OleDbConnection dbconn = new OleDbConnection("provider=Microsoft.Jet.OleDb.4.0;Data Source=G:\\项目\\DIS\\代码\\DIS\\App_Data\\DIS.mdb;");
        dbconn.Open();
        string idString;
        string contentString;
        idString = strAry[2];
        contentString = strAry[4];
        OleDbCommand dbcommand = new OleDbCommand("insert into [testTable] (id,content) values('" + idString + "','" + contentString + "');", dbconn);
        dbcommand.ExecuteNonQuery();
        dbconn.Close();


        OleDbConnection dbconn1 = new OleDbConnection("provider=Microsoft.Jet.OleDb.4.0;Data Source=G:\\项目\\DIS\\代码\\DIS\\App_Data\\DIS.mdb;");
        dbconn1.Open();
        OleDbCommand dbcommand1 = new OleDbCommand("insert into [testTable] (id,content) values('12','sifiei');", dbconn1);
        dbcommand1.ExecuteNonQuery();
        dbconn1.Close();
        
    }
    [WebMethod]
    public void sendMessage()
    {
        OleDbConnection dbconn = new OleDbConnection("provider=Microsoft.Jet.OleDb.4.0;Data Source=G:\\项目\\DIS\\代码\\DIS\\App_Data\\DIS.mdb;");
        dbconn.Open();
        OleDbCommand dbcommand = new OleDbCommand("insert into [pimMemoTable] (summary,details,memoOrder,createTime,theme,remindTime,isHighlight,isRemind) values('111','111','111','111','111','111','1','1');", dbconn);
        dbcommand.ExecuteNonQuery();
        dbconn.Close();
    }
    [WebMethod]
    public string HelloWorld()
    {
        return @"{""summary"":""reserved"",""details"":""reserved"",""memoOrder"":""reserved"",""createTime"":""reserved"",""theme"":""reserved"",""remindTime"":""reserved"",""isHighlight"":""reserved"",""isRemind"":""reserved""}";
    }
    [WebMethod]
    public void createMemo(string jsonText)
    {
        System.IO.StringReader strReader = new System.IO.StringReader(jsonText);
        JsonReader reader = new JsonTextReader(strReader);
        string[] strAry = new string[17];
        for (int i = 0; i < 17; i++)
        {
            reader.Read();
            strAry[i] = "";
            strAry[i] += reader.Value;

        }
        string summaryString = strAry[2];
        string detailsString = strAry[4];
        string memoOrderString = strAry[6];
        string createTimeString = strAry[8];
        string themeString = strAry[10];
        string remindTimeString = strAry[12];
        string isHighlightString = strAry[14];
        string isRemindString = strAry[16];
        OleDbConnection dbconn = new OleDbConnection("provider=Microsoft.Jet.OleDb.4.0;Data Source=G:\\项目\\DIS\\代码\\DIS\\App_Data\\DIS.mdb;");
        dbconn.Open();
        OleDbCommand dbcommand = new OleDbCommand("insert into [pimMemoTable] (summary,details,memoOrder,createTime,theme,remindTime,isHighlight,isRemind) values('"+strAry[2]+"','"+strAry[4]+"','"+strAry[6]+"','"+strAry[8]+"','"+strAry[10]+"','"+strAry[12]+"','"+strAry[14]+"','"+strAry[16]+"');", dbconn);
        dbcommand.ExecuteNonQuery();
        dbconn.Close();


    }
}