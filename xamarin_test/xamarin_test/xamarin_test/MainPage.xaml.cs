using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("타이틀에 표시될 내용", "메세지는 길어질 경우 2줄로 표시되고 기본이 1줄로 표시됨", "확  인");
            Console.WriteLine("콘솔에 내용 표시");
        }
    }
}
