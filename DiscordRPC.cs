using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        void Initialze()
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
			Initialze();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			client.Dispose();
        }
    }
}
