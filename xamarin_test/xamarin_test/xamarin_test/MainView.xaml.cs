using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Connectivity;


namespace xamarin_test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MainView()
        {
            //가비지 컬렉팅 문제인지 한번 로드 된 앱이 뒤로가기로 삭제되면 다음 오픈시 웹페이지가 로딩되지 않음
            // 메모리 부족 또는 이전 앱의 페이지가 WebView만 종료된 채로 다시 뜨는 문제일수도 있음.
            InitializeComponent();
            //var current = Connectivity.NetworkAccess;
            //DisplayAlert("check", current.ToString(), "확인");
            //Xam.Plugin.Connectivity 추가하여 접속여부를 확인하고자 했으나 처리되지 않음
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    //browser.Source = "https://mywebpage.com/";
            //    DisplayAlert("서버 접속 불가", "인터넷에 연결할 수 없습니다. 연결 상태를 확인해 주세요.", "확인");
            //    //System.Diagnostics.Process.GetCurrentProcess().Kill(); //앱 강제 종료 처리
            //}
            //else
            //{
            //    DisplayAlert("연결된 상태로 체크됨", CrossConnectivity.Current.IsConnected.ToString(), "확인");

            //}
        }
    }
}
