using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tesseract;
using TesseractLogin.Tools;

namespace TesseractLogin
{
    /// <summary>
    /// 网站用户
    /// </summary>
    public class WebUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string _userName = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        private string _password = string.Empty;

        /// <summary>
        /// 验证码
        /// </summary>
        private string _checkCode = string.Empty;

        private HttpHelper _httpHelper = new HttpHelper();

        private char[] a_z;

        /// <summary>
        /// 构造函数
        /// </summary>
        public WebUser()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVW7XYZ,，￥$~!*&^%# -+/\"";
            a_z = chars.ToCharArray();       
            _userName = "281493779"; //初始化用户
            _password = "qwer1234"; //初始化密码
            Login();
        }

        /// <summary>
        /// 清除所有脚本
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            text = text.Replace(",", "");
            text = text.Replace("-", "");
            text = text.Replace("_", "");
            return text;
        }

        /// <summary>
        /// 查询字符有没有a-Z字符
        /// </summary>
        /// <param name="textCode"></param>
        /// <returns></returns>
        public bool Contains_a_Z(string textCode)
        {
            bool result = false;
            if (string.IsNullOrEmpty(textCode))
            {
                result = true;
            }
            else
            {
                var codes = textCode.ToCharArray();
                foreach (var item in codes)
                {
                    if (a_z.Contains(item))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            ////登录页
            //_httpHelper.SyncRequest("http://localhost:62269/Account/Login");

            ////获取验证码图片
            //var bitmap = _httpHelper.GetCheckCode("http://localhost:62269/Home/VCode");
            //System.Drawing.Image Source_image = (Image)bitmap;
            //var random = new Random();
            //var name_img = random.Next(0, int.MaxValue);
            //Source_image.Save("D:\\" + name_img + "_Code.jpg");
            ////Bitmap bitmap = new Bitmap("D:\\789126534Code.jpg");
            //UnCodebase uncode = new UnCodebase(bitmap);
            ////去图形边框
            //uncode.ClearPicBorder(1);
            ////灰度转换,逐点方式
            //uncode.GrayByPixels();
            ////图像二值化
            //uncode.ConvertToBinaryImage();

            //System.Drawing.Image image = (Image)uncode.bmpobj;

            ////解析验证码 
            //using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            //{
            //    using (var entity = engine.Process(uncode.bmpobj))
            //    {
            //        _checkCode = entity.GetText();
            //    }
            //}
            //_checkCode = _checkCode.Trim();
            //image.Save("D:\\" + InputText(_checkCode, _checkCode.Length) + "_Code.jpg");
            ////登录验证
            //_httpHelper.PostData = string.Format("Email={0}&Password={1}&VCode={2}",
            //    _userName, _password, _checkCode);
            //_httpHelper.SyncRequest("http://localhost:62269/Account/Login");
            //************************************************************************************************************//

            ////登录页
            //_httpHelper.SyncRequest("https://eastmoney-office.eastmoney.com/bd-cas/login?service=https://oa-eastmoney-office.eastmoney.com/login/Login.jsp?logintype=1");

            ////获取验证码图片
            //var bitmap = _httpHelper.GetCheckCode("https://eastmoney-office.eastmoney.com/bd-cas/captcha.htm");

            //System.Drawing.Image Source_image = (Image)bitmap;
            //var random = new Random();
            //var name_img = random.Next(0, int.MaxValue);
            //Source_image.Save("D:\\" + name_img + "_Code.jpg");
            ////Bitmap bitmap = new Bitmap("D:\\1415908407_Code.jpg");

            //UnCodebase uncode = new UnCodebase(bitmap);
            ////去图形边框
            //uncode.ClearPicBorder(1);
            ////灰度转换,逐点方式
            //uncode.GrayByPixels();
            ////图像二值化
            //uncode.ConvertToBinaryImage();
            ////扭曲图片校正
            //uncode.ReSetBitMap();

            ////解析验证码 
            //using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            //{
            //    using (var entity = engine.Process(uncode.bmpobj))
            //    {
            //        _checkCode = entity.GetText();
            //    }
            //}

            //System.Drawing.Image image = (Image)uncode.bmpobj;
            //image.Save("D:\\" + InputText(_checkCode, _checkCode.Length) + "_Code.jpg");

            //_checkCode = _checkCode.Trim();
            //_checkCode = _checkCode.Replace(" ", "");//这样替换下就可以了

            ////登录验证
            //_httpHelper.PostData = string.Format("username={0}&password={1}&captcha={2}",
            //    _userName, _password, _checkCode);
            //_httpHelper.SyncRequest("https://eastmoney-office.eastmoney.com/bd-cas/login");


            //#########################################################################//



            //登录页
            _httpHelper.SyncRequest(" http://wp18011601.eda8888.com/App/Login");

            //获取验证码图片
            var bitmap = _httpHelper.GetCheckCode("http://wp18011601.eda8888.com/App/Login/GetCodeImage?id=1");

            System.Drawing.Image Source_image = (Image)bitmap;
            var random = new Random();
            var name_img = random.Next(0, int.MaxValue);
            Source_image.Save("D:\\eda8888\\" + name_img + "_Code.jpg");
            //Bitmap bitmap = new Bitmap("D:\\617420430_Code.jpg");


            //解析验证码1 
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var entity = engine.Process(bitmap))
                {
                    _checkCode = entity.GetText();
                }
            }
            _checkCode = InputText(_checkCode, _checkCode.Length);

            UnCodebase uncode = new UnCodebase(bitmap);
            if (Contains_a_Z(_checkCode))
            {
                //去图形边框
                uncode.ClearPicBorder(1);
                //灰度转换,逐点方式
                uncode.GrayByPixels();

                //去掉噪点
                //uncode.ClearNoise(50, 1);
                //图像二值化
                uncode.ConvertToBinaryImage();
                //扭曲图片校正
                uncode.ReSetBitMap();

                //解析验证码2
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var entity = engine.Process(uncode.bmpobj))
                    {
                        _checkCode = entity.GetText();
                    }
                }
            }

            _checkCode = _checkCode.Trim();
            _checkCode = _checkCode.Replace(" ", "");//这样替换下就可以了
            _checkCode = InputText(_checkCode, _checkCode.Length);

            System.Drawing.Image image = (Image)uncode.bmpobj;
            image.Save("D:\\eda8888\\" + InputText(_checkCode, _checkCode.Length) + "_Code.jpg");


            //登录验证
            _httpHelper.PostData = string.Format("username={0}&password={1}&code={2}",
                _userName, _password, _checkCode);
            _httpHelper.SyncRequest("http://wp18011601.eda8888.com/App/Login");

        }
    }
}
