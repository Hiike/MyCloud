using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using DropNet;
using DropNet.Models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DropNetClient _client;
        List<UserLogin> listLogin;
        List<Item> listItem;
        MetaData metaData;
        String path;
//        LiveLoginResult authResult = await authClient.LoginAsync(new List<String>() { "wl.signin", "wl.basic", "wl.skydrive" });

        public MainWindow()
        {
            InitializeComponent();
            _client = new DropNetClient("gthmyk9qe4hh3sn", "rpoe69bag92239g");
            listLogin = new List<UserLogin>();
            listItem = new List<Item>();
        }

        private void btn_CoDB(object sender, RoutedEventArgs e)
        {
            try
            {
                _client.GetToken();
                var url = _client.BuildAuthorizeUrl();
                ConnectWB.Navigate(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Please relaunch the program");
            }
        }

        private void ConnectWB_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Uri.AbsolutePath == "/1/oauth/authorize_submit")
            {
                try
                {
                    var accessToken = _client.GetAccessToken();
                    path = "/";
                    metaData = _client.GetMetaData(path);
                    if (check1.IsChecked == true)
                    {
                        listLogin.Add(accessToken);
                    }
                    foreach (MetaData data in metaData.Contents)
                    {
                        Item item = new Item()
                        {
                            Name = data.Name,
                            Bytes = data.Bytes,
                            Modified = data.Modified,
                            Path = data.Path,
                            Is_Dir = data.Is_Dir,
                            Is_Deleted = data.Is_Deleted,
                            Size = data.Size,
                            Root = data.Root,
                            Icon = "C:/Users/Hiike/Documents/Visual Studio 2010/Projects/MyCloud/Image/"
                            + ((data.Icon.Contains("folder") == true) ? "Folder.png" : "File.png"),
                            Extension = data.Extension,
                            Revision = data.Revision
                        };
                        listItem.Add(item);
                    }
                    itemList.ItemsSource = listItem;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void item_isSelected(object sender, MouseButtonEventArgs e)
        {
            TextBlock selected = (TextBlock)sender;
            if ((String)((Item)itemList.SelectedItem).Name == (String)selected.Text)
            {
                Item sItem = (Item)itemList.SelectedItem;
                if (sItem.Is_Dir == true)
                {
                    path = sItem.Path;
                    metaData = _client.GetMetaData(path);
                    try
                    {
                        listItem.Clear();
                        foreach (MetaData data in metaData.Contents)
                        {
                            Item item = new Item()
                            {
                                Name = data.Name,
                                Bytes = data.Bytes,
                                Modified = data.Modified,
                                Path = data.Path,
                                Is_Dir = data.Is_Dir,
                                Is_Deleted = data.Is_Deleted,
                                Size = data.Size,
                                Root = data.Root,
                                Icon = "C:/Users/Hiike/Documents/Visual Studio 2010/Projects/MyCloud/Image/"
                            + ((data.Icon.Contains("folder") == true) ? "Folder.png" : "File.png"),
                                Extension = data.Extension,
                                Revision = data.Revision
                            };
                            listItem.Add(item);
                        }
                        itemList.ItemsSource = null;
                        itemList.ItemsSource = listItem;
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    var fileBytes = _client.GetFile(sItem.Path);
                    String dbpath = "C:/Users/Hiike/Documents/Dropbox/";
                    File.WriteAllBytes(dbpath + sItem.Name, fileBytes);
                    System.Diagnostics.Process.Start(dbpath + sItem.Name);
                }
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (path != "/")
            {
                path = path.Remove(path.LastIndexOf('/'));
                MessageBox.Show(path);
                if (path == "")
                    path = "/";

                metaData = _client.GetMetaData(path);
                try
                {
                    listItem.Clear();
                    foreach (MetaData data in metaData.Contents)
                    {
                        Item item = new Item()
                        {
                            Name = data.Name,
                            Bytes = data.Bytes,
                            Modified = data.Modified,
                            Path = data.Path,
                            Is_Dir = data.Is_Dir,
                            Is_Deleted = data.Is_Deleted,
                            Size = data.Size,
                            Root = data.Root,
                            Icon = "C:/Users/Hiike/Documents/Visual Studio 2010/Projects/MyCloud/Image/"
                            + ((data.Icon.Contains("folder") == true) ? "Folder.png" : "File.png"),
                            Extension = data.Extension,
                            Revision = data.Revision
                        };
                        listItem.Add(item);
                    }
                    itemList.ItemsSource = null;
                    itemList.ItemsSource = listItem;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ConnectOD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
