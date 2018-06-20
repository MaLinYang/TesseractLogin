using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace TesseractLogin
{
    internal class Program
    {

        /// <summary>
        /// 验证码
        /// </summary>
        static string _checkCode = string.Empty;

        public static void Main(string[] args)
        {

            //Bitmap bitmap = new Bitmap("D:\\eda8888\\789126534Code.jpg");

            ////解析验证码 
            //using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            //{
            //    using (var entity = engine.Process(bitmap))
            //    {
            //        _checkCode = entity.GetText();
            //    }
            //}

           WebUser user = new WebUser();
            Console.ReadKey();
        }
    }
}
