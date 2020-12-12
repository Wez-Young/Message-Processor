using _40402601.Business_Layer;
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
using System.Windows.Shapes;

namespace _40402601
{
    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInput : Window
    {
        private Lists li = new Lists();
        public UserInput()
        {
            InitializeComponent();
            NewHeaderTxt.Visibility = Visibility.Collapsed;
            SenderTxt.Visibility = Visibility.Collapsed;
            SubjectTxt.Visibility = Visibility.Collapsed;
            NewBodyTxt.Visibility = Visibility.Collapsed;
            IncidentTxt.Visibility = Visibility.Collapsed;
            Sort_CodeTxt.Visibility = Visibility.Collapsed;
            NewMessageBtn.Visibility = Visibility.Collapsed;
            FinishedBtn.Visibility = Visibility.Collapsed;
        }

        public UserInput(Lists l)
        {
            li = l;
            InitializeComponent();
            NewHeaderTxt.Visibility = Visibility.Collapsed;
            SenderTxt.Visibility = Visibility.Collapsed;
            SubjectTxt.Visibility = Visibility.Collapsed;
            NewBodyTxt.Visibility = Visibility.Collapsed;
            IncidentTxt.Visibility = Visibility.Collapsed;
            Sort_CodeTxt.Visibility = Visibility.Collapsed;
            NewMessageBtn.Visibility = Visibility.Collapsed;
            FinishedBtn.Visibility = Visibility.Collapsed;
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageInput mi = new MessageInput();
            bool check = mi.Sort(this, li, HeaderTxt.Text, BodyTxt.Text);
            //prints message if message fields are valid
            if (check)
            {
                //Chnage textbox visibilities depending on message type
                if (HeaderTxt.Text[0] == 'E')
                {
                    NewHeaderTxt.Visibility = Visibility.Visible;
                    SenderTxt.Visibility = Visibility.Visible;
                    SubjectTxt.Visibility = Visibility.Visible;
                    NewBodyTxt.Visibility = Visibility.Visible;
                    NewMessageBtn.Visibility = Visibility.Visible;
                    FinishedBtn.Visibility = Visibility.Visible;

                    if (IncidentTxt.Text != "" && Sort_CodeTxt.Text != "")
                    {
                        IncidentTxt.Visibility = Visibility.Visible;
                        Sort_CodeTxt.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    NewHeaderTxt.Visibility = Visibility.Visible;
                    SenderTxt.Visibility = Visibility.Visible;
                    NewBodyTxt.Visibility = Visibility.Visible;
                    NewMessageBtn.Visibility = Visibility.Visible;
                    NewBodyTxt.Margin = new Thickness(10, 68, 10, 79);
                    FinishedBtn.Visibility = Visibility.Visible;
                }
            }            
        }

        //Update instance of lists
        public void instance(Lists l)
        {
            li = l;
        }

        private void NewMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            UserInput ui = new UserInput(li);
            Close();
            ui.Show();
        }

        private void FinishedBtn_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> hash_dict = new Dictionary<string, int>();
            Tweet t = new Tweet();

            t.Trending(li, hash_dict);
            Close();
            li.Show();
            
        }
    }
}
