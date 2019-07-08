using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WinAPIS
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string path = open.FileName;
                byte[] imge = SaveImage(path);
                pictureBox1.Image = ShowImgByByte(imge);
                // Upfile(path);
                HttpUploadFile("http://localhost:9000/plr", path);

            }
        }


        public static void Upfile(string path)
        {
            using (var client = new HttpClient())
            {
                using (var multipartFormDataContent = new MultipartFormDataContent())
                {
                    multipartFormDataContent.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(path)), "myfile");
                    var requestUri = "http://localhost:9000/plr";
                    var html = client.PostAsync(requestUri, multipartFormDataContent).Result.Content.ReadAsStringAsync().Result;
                    MessageBox.Show(html.ToString());
                }
            }
        }


        /// <summary>
        /// 文件转二进制流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] SaveImage(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
            BinaryReader br = new BinaryReader(fs);
            byte[] imgBytesIn = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
            return imgBytesIn;
        }


        /// <summary>
        /// 二进制流转图片
        /// </summary>
        /// <param name="imgBytesIn"></param>
        public Bitmap ShowImgByByte(byte[] imgBytesIn)
        {
            MemoryStream ms = new MemoryStream(imgBytesIn);
            Bitmap bmp = new Bitmap(ms);
            return bmp;
        }

        private static void GetPage(string posturl = "http://localhost:9000/plr")//string account, string password, string mobile, string content
        {
            string result = "";
            //string postStrTpl = "account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true";

            UTF8Encoding encoding = new UTF8Encoding();

            //postStrTpl = string.Format(postStrTpl, account, password, mobile, content);
            //PostUrl = PostUrl + "?" + postStrTpl;
            byte[] postData = encoding.GetBytes(posturl);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(posturl);
            myRequest.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //myRequest.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
            myRequest.Headers["Accept-Charset"] = "utf-8";
            myRequest.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            myRequest.KeepAlive = true;
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";

            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑
            }
            else
            {
                //访问失败
                result = "访问失败";
            }

            MessageBox.Show(result);
        }


        /// <summary>
        /// post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <returns></returns>

        public static void HttpUploadFile(string url, string path)

        {

            // 设置参数

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            CookieContainer cookieContainer = new CookieContainer();

            request.CookieContainer = cookieContainer;

            request.AllowAutoRedirect = true;

            request.Method = "POST";

            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线

            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;

            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");

            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            int pos = path.LastIndexOf("\\");

            string fileName = path.Substring(pos + 1);
            //请求头部信息 

            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"myfile\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));

            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            byte[] bArr = new byte[fs.Length];

            fs.Read(bArr, 0, bArr.Length);

            fs.Close();
            Stream postStream = request.GetRequestStream();

            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);

            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            postStream.Write(bArr, 0, bArr.Length);

            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);

            postStream.Close();
            //发送请求并获取相应回应数据

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            //直到request.GetResponse()程序才开始向目标网页发送Post请求

            Stream instream = response.GetResponseStream();

            StreamReader sr = new StreamReader(instream, Encoding.UTF8);

            //返回结果网页（html）代码

            string content = sr.ReadToEnd();

            MessageBox.Show(content);

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Message f = new Message();
            f.Show();
            this.Hide();
        }

       
    }
}