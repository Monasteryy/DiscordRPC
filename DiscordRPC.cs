using System;
using System.IO;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace Discord_RPC_WPF
{
    public partial class DiscordRPC : Form
    {
        public DiscordRPC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DiscordRPC_Load(object sender, EventArgs e)
        {

        }

        public DiscordRpcClient client;
        
        void Initialize()
		{
			/*
	Create a Discord client
	NOTE: 	If you are using Unity3D, you must use the full constructor and define
			 the pipe connection.
	*/
			client = new DiscordRpcClient(ClientID_TexBox.Text);

			//Set the logger
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				//Details = "Example Project",
				State = State_TextBox.Text,
				Assets = new Assets()
				{
					LargeImageKey = "mymaya",
					//LargeImageText = "Lachee's Discord IPC Library",
					SmallImageKey = "bunny"
				}
			});
		}

        private void button1_Click(object sender, EventArgs e)
        {
			Initialize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			client.Dispose();
        }
        
        /*public static class ClientIdManager
        {
            private static string filePath = Path.Combine(Application.StartupPath, "clientid.txt");

            public static void SaveClientId(string clientId)
            {
                File.WriteAllText(filePath, clientId);
            }

            public static string LoadClientId()
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
                return string.Empty;
            }
        }
        */
        
    }
}
