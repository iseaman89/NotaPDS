using System.Collections.ObjectModel;
using BAPDS.Model;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace BAPDS.View;

public partial class ChatPage : ContentPage
{
    public ProjectDB Project { get; set; }
    public ObservableCollection<ChatMessage> MessagesCollection { get; set; }
    public Dictionary<string, ChatMessage> ChatDictionary { get; set; }
    private int index = 0;

    private IFirebaseConfig _config = new FirebaseConfig
    {
        AuthSecret = "1sbCn04JQ7vckC9lg8caux4dI8xFUyiAGIAPmhSz",
        BasePath = "https://bapds-48d75-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    private IFirebaseClient _client;

    public ChatPage(ProjectDB project)
    {
        InitializeComponent();

        Project = project;
        MessagesCollection = new ObservableCollection<ChatMessage>();
        _client = new FireSharp.FirebaseClient(_config);
        //GetChat();
        BindingContext = this;
    }
    private void GetChat()
    {
        var response = _client.Get(@"ChatDB");
        ChatDictionary
           = JsonConvert.DeserializeObject<Dictionary<string, ChatMessage>>(response.Body.ToString());

        if (ChatDictionary.ContainsKey(Project.FullNumber))
        {
            foreach (var messages in ChatDictionary)
            {
                MessagesCollection.Add(messages.Value);
            }
        }
    }

    void SendBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        ChatMessage chatMessage = new ChatMessage {
            Date = DateTime.Now.Date.Hour.ToString(),
            Sender = "User",
            Text = ChatEntry.Text
        };
        _client.Set<ChatMessage>("ChatDB/" + Project.FullNumber + "/" + index++ + "/", chatMessage);
        ChatEntry.Text = string.Empty;
        MessagesCollection.Add(chatMessage);
    }
}
