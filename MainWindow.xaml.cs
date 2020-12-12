using System.Windows;
using _40402601.Business_Layer;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _40402601
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MessageInput r;
        private Lists l;
 
        public MainWindow()
        {
            InitializeComponent();

            MessageInput read = new MessageInput();
            r = read;
            NextBtn_Click(null, null);
        }

        public MainWindow(Sms sms, MessageInput read, Lists list)
        {
            InitializeComponent();

            HeaderTxt.Text = sms.ID;
            SenderTxt.Text = sms.Sender;
            BodyTxt.Text = sms.Abbreviation(sms.MessageBody).Replace("\\n", "\n");

            SubjectTxt.Visibility = Visibility.Collapsed;

            r = read;
            if (list != null)
                l = list;

            var json = new JavaScriptSerializer().Serialize(sms);
            sms.WriteToJSON(json);
        }

        public MainWindow(Tweet tweet, MessageInput read, Lists list)
        {
            InitializeComponent();

            HeaderTxt.Text = tweet.ID;
            SenderTxt.Text = tweet.Sender;
            BodyTxt.Text = tweet.Abbreviation(tweet.MessageBody).Replace("\\n", "\n");

            SubjectTxt.Visibility = Visibility.Collapsed;

            r = read;
            if (list != null)
                l = list;

            var json = new JavaScriptSerializer().Serialize(tweet);
            tweet.WriteToJSON(json);
        }

        public MainWindow(Email email, MessageInput read, Lists list)
        {
            InitializeComponent();
            //Check for SIR email, add in text boxes prgrammitacally, maybe remove checks from read method
            HeaderTxt.Text = email.ID;
            SenderTxt.Text = email.Sender;
            SubjectTxt.Text = email.Subject;
            BodyTxt.Text = email.MessageBody.Replace("\\n", "\n");
            BodyTxt.Text = email.CheckUrls(BodyTxt.Text);

            SubjectTxt.Visibility = Visibility.Visible;

            r = read;
            if (list != null)
                l = list;

            var json = new JavaScriptSerializer().Serialize(email);
            email.WriteToJSON(json);
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            if (!r.Read(this))
                if(l != null)
                {
                    Dictionary<string, int> hash_dict = new Dictionary<string, int>();

                    Tweet tweet = new Tweet();
                    tweet.Trending(l, hash_dict);

                    l.Show();
                    Close();
                }
        }
    }
}
