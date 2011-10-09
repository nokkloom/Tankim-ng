using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
public class UDPConnectionGUI : MonoBehaviour {
private UdpClient server;
private UdpClient client;
private IPEndPoint receivePoint;
private string port = "6767";
private int listenPort = 25001;
private string ip = "0.0.0.0";
//private bool useNAT=false;
private string ip_broadcast = "255.255.255.255";
private bool youServer = false;
private bool connected = false;
private string server_name = "";
private int clear_list = 0;
public void Update() 
	{
		if(clear_list++>200)
			{
				server_name = "";
				clear_list = 0;
			}
		}
		
public void Start() 
		{
			Debug.Log("Start");
			LoadClient();
		}
		
public void LoadClient() 
		{
			client = new UdpClient(System.Convert.ToInt32(port));
			receivePoint = new IPEndPoint(IPAddress.Parse(ip),System.Convert.ToInt32(port));
			Thread startClient = new Thread(new ThreadStart(start_client));
			startClient.Start();
		}
		
public void start_client()
		{
			bool continueLoop =true;
			try
			{
				while(continueLoop)
					{
						byte[] recData = client.Receive(ref receivePoint);
						System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
						server_name = encode.GetString(recData);
						if(connected)
							{
								server_name = "";
								client.Close();
								break;
								}
							}
						}
						catch {}
							}
							
public void start_server() 
		{
			try
			{
				while(true)
					{
						System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
						byte[] sendData = encode.GetBytes(Network.player.ipAddress.ToString());
						server.Send(sendData,sendData.Length,ip_broadcast,System.Convert.ToInt32(port));
						Thread.Sleep(100);
					}
				} 
			catch {}
			}
			void OnGUI() {
				if(!youServer)
					{
						if(GUI.Button(new Rect(10,10,100,30),"Start Server"))
							{
								youServer = true;
								Network.InitializeServer(32, listenPort);
//Network.InitializeServer(32, listenPort,useNAT);
								string ipaddress = Network.player.ipAddress.ToString();
								ip = ipaddress;
								client.Close();
								server = new UdpClient(System.Convert.ToInt32(port));
								receivePoint = new IPEndPoint(IPAddress.Parse(ipaddress),System.Convert.ToInt32(port));
								Thread startServer = new Thread(new ThreadStart(start_server));
								startServer.Start();
							}
						if(server_name!="")
							{
								if(GUI.Button(new Rect(20,100,200,50),server_name))
							{
						connected = true;
						Network.Connect(server_name, listenPort);
							}
						}
					}
				else
					{
						if(GUI.Button(new Rect(10,10,100,30),"Disconnect"))
							{
								Network.Disconnect();
								youServer = false;
								server.Close();
								LoadClient();
							}
						}
					}
				}