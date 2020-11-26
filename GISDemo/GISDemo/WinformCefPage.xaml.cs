using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlarmCenter.Core;
using AlarmCenter.GWWpfCustomControlLibrary;
using CefSharp;
using System.Windows.Interop;
using AlarmCenter.DataCenter;
using System.Xml;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace CEFDemo
{
    public partial class WinformCefPage
    {
        private string Url;
        private string strData;
        bool isfirst = true;
        public WinformCefPage()
        {
            DefaultConfig.CEFInit();
            InitializeComponent();
            //DefaultConfig.ShutDownExit();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            // 注册userinfo用户信息给前端界面，前端界面会自动生成一个userinfo全局变量
            browser.RegisterJsObject("userinfo", new UserInfo() { }, new BindingOptions { CamelCaseJavascriptNames = false });
            // 注册bindcmd控制命令给前端界面，前端界面会自动生成一个bindcmd全局变量
            browser.RegisterJsObject("bindcmd", new Cmd() { }, new BindingOptions { CamelCaseJavascriptNames = false });
            browser.FrameLoadEnd += browser_FrameLoadEnd;
            try
            {
                //绝对路径，如引用外部地址
                Url = "https://www.baidu.com/";
                browser.Load(Url);

                //web相对路径 GetLoacalIP动态获取web站点的IP、端口和路径地址，默认返回http://localhost:8088/Views/Url
                //browser.Load(DefaultConfig.GetLoacalIP(Url));
            }
            catch (Exception e)
            {
                DataCenter.WriteLogFile(e.ToString());
            }
        }

        void browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //网页加载完成触发 即首次打开界面会触发此方法，后续不会触发
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    if (browser.CanExecuteJavascriptInMainFrame)
                    {
                        if (isfirst)
                        {
                            // 后端调用前端getControlInfo方法，并传参，参数可根据场景自定义
                            browser.ExecuteScriptAsync($"getControlInfo('{strData}')");
                            isfirst = false;
                        }
                    }
                }
                catch (Exception ee)
                {
                    DataCenter.WriteLogFile(ee.ToString());
                }
            }));
        }

        public override void Dispose()
        {
            browser.Dispose();
        }

        public override void DoAttach(string plStr)
        {
            if (plStr != "" && plStr != null)
            {
                strData = plStr.Substring(1);
                // 触发方式为触发控制后，会触发此方法，后端调用前端getControlInfo方法，并传参
                if (browser.CanExecuteJavascriptInMainFrame)
                {
                    browser.ExecuteScriptAsync($"getControlInfo('{strData}')");
                }
            }
            base.DoAttach(plStr);
        }
    }
}
