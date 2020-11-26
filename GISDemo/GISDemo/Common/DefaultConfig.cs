using AlarmCenter.Core;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ICSharpCode.Core;
using System.Configuration;
using System.Web.Configuration;
using System.Windows;
using AlarmCenter.DataCenter;
using CefSharp.Wpf;
using System.Data;
using Newtonsoft.Json;
using ExpressionEvaluation;
using System.Diagnostics;

namespace CEFDemo
{
    public class DefaultConfig
    {
        // 获取界面路径
        public static string GetLoacalIP(string PageName)
        {
            Properties properties = PropertyService.Get("AlarmCenter.Browser.Config", new Properties());
            var ConfigPort = properties.Get("Port", "");
            var ConfigIp = properties.Get("LocalIP", "");
            if (string.IsNullOrWhiteSpace(ConfigPort) || string.IsNullOrWhiteSpace(ConfigIp))
            {
                throw new Exception("无效的IP和端口请检测配置文件是否正确");
            }
            return "http://" + ConfigIp + ":" + ConfigPort + "/Views/" + PageName;
        }

        // 初始化
        public static void CEFInit()
        {
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings();
               
                settings.RemoteDebuggingPort = 9011;// 使用一个未被占用的端口
                settings.CefCommandLineArgs.Add("enable-media-stream", "1");
                settings.CachePath = System.Windows.Forms.Application.StartupPath + "\\Cache"; //设置缓存 设置为null时浏览器不会生成缓存文件
                Cef.Initialize(settings);
                Cef.EnableHighDPISupport();
            }
        }

        public static void ShutDownExit()
        {
            Application.Current.Exit += Current_Exit;
        }

        private static void Current_Exit(object sender, ExitEventArgs e)
        {
            Cef.Shutdown();
        }
    }

    /// <summary>
    /// cef菜单事件 屏蔽右键菜单
    /// </summary>
    internal class MenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //清除上下文菜单
            model.Clear();
        }


        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            // throw new NotImplementedException();
            return false;
        }


        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //    throw new NotImplementedException();
        }


        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
            //  throw new NotImplementedException();
        }
    }

    public class Cmd
    {

        public string command { get; set; }

        // 传递组态页面值进行控制 如：EP1
        public void CommandExecute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                try
                {
                    AlarmCenter.GWWPFControls.GWControlStatic.ExecuteClickCmd(command, false);
                }
                catch (Exception ee)
                {
                    AlarmCenter.DataCenter.DataCenter.WriteLogFile(ee.ToString());
                }
            }));
        }

        // 传递四个参数值进行控制 equip_no main_instruction minor_instruction value
        public void SceneSwitch(int equipnm, string cmd1, string cmd2, string cmd3)
        {
            try
            {
                AlarmCenter.DataCenter.DataCenter.proxy.SetParm(equipnm, cmd1, cmd2, cmd3, DataCenter.UserNm);
            }
            catch (Exception ee)
            {
                AlarmCenter.DataCenter.DataCenter.WriteLogFile(ee.ToString());
            }
        }

        // 传递设备号和设置号进行控制 equip_no set_no
        public void SceneSwitch2(int equipnm, int setno)
        {
            try
            {
                AlarmCenter.DataCenter.DataCenter.proxy.SetParm1(equipnm, setno, DataCenter.UserNm);
            }
            catch (Exception ee)
            {
                AlarmCenter.DataCenter.DataCenter.WriteLogFile(ee.ToString());
            }
        }
    }

    // 用户信息 可注册到前端页面
    public class UserInfo
    {
        public string UserName
        {
            get { return DataCenter.UserNm; }
        }

        public string UserPwd
        {
            get { return DataCenter.UserPWD; }
        }
    }
}

