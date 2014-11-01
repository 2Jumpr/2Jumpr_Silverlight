using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _2Jumpr.Resources;

namespace _2Jumpr
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("his count:" + (App.HistroyList ?? new List<Model.JumperModel>()).Count);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(textBox1.Text));
                
                if (App.HistroyList == null)
                    App.HistroyList = new List<Model.JumperModel>();
                else
                    App.HistroyList.Add(
                            new Model.JumperModel()
                            {
                                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                                Path = textBox1.Text
                            }
                        );
            }
            catch
            {
                MessageBox.Show(AppResources.MsgBoxContent, AppResources.MsgBoxTitle, MessageBoxButton.OK);
            }
        }

        private async void textBox1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                try
                {
                    var isSuccess = await Windows.System.Launcher.LaunchUriAsync(new Uri(textBox1.Text));
                    
                    if (App.HistroyList == null)
                        App.HistroyList = new List<Model.JumperModel>();
                    else
                        App.HistroyList.Add(
                                new Model.JumperModel()
                                {
                                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                                    Path = textBox1.Text
                                }
                            );
                }
                catch
                {
                    MessageBox.Show(AppResources.MsgBoxContent, AppResources.MsgBoxTitle, MessageBoxButton.OK);
                }
            }
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}