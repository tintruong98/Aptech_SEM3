using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing;
using System.IO;
using ZXing.QrCode;
using System.Web;

namespace Lab2.Helpers
{
    [HtmlTargetElement("qrcode")]
    public class QRCodeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);
            var content = context.AllAttributes["content"].Value.ToString();
            content = HttpUtility.HtmlDecode(content);
            int height = int.Parse(context.AllAttributes["height"].Value.ToString());
            int width = int.Parse(context.AllAttributes["width"].Value.ToString());
            var barcode = new ZXing.BarcodeWriterPixelData
            {
                Format=ZXing.BarcodeFormat.QR_CODE,
                Options= new QrCodeEncodingOptions
                {
                    DisableECI=true,CharacterSet="UTF-8",Height=height,Width=width,Margin=0
                }
            };
            var pixelData = barcode.Write(content);
            using (var bitmap=new Bitmap(pixelData.Width,
                                        pixelData.Height,
                                        System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0,0,pixelData.Width,pixelData.Height),
                                                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0,
                                                bitmapData.Scan0,pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(memory,System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img";
                    output.Attributes.Clear();
                    output.Attributes.Add("width",width);
                    output.Attributes.Add("height",height);
                    output.Attributes.Add("src",String.Format("data:image/png;base64,{0}",Convert.ToBase64String(memory.ToArray())));
                }
            }
        }
    }
}
