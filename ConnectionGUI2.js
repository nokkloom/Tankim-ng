var remoteIP = "127.0.0.1";
var remotePort = 25000;
var listenPort = 25000;
var useNAT = false;
var yourIP = "";
var yourPort = "";
var tankid : Transform[];
var tekitaja : GameObject;
var olemas = false;
function Awake() {
if (FindObjectOfType(MasterServerGUI))
this.enabled = false;
if(FindObjectOfType(UDPConnectionGUI))
this.enabled = false;
}

function OnGUI () {
if (Network.peerType == NetworkPeerType.Disconnected)
{
// If not connected
if (GUI.Button (new Rect(10,10,100,30),"Connect"))
{
 useNAT = !Network.HavePublicAddress();
// Connecting to the server
Network.Connect(remoteIP, remotePort);
}
if (GUI.Button (new Rect(10,50,100,30),"Start Server"))
{
useNAT = !Network.HavePublicAddress();
// Creating server
Network.InitializeServer(32, listenPort,useNAT);
// Notify our objects that the level and the network is ready
for (var go : GameObject in FindObjectsOfType(GameObject))
{
go.SendMessage("OnNetworkLoadedLevel",
SendMessageOptions.DontRequireReceiver);
}
}
remoteIP = GUI.TextField(new Rect(120,10,100,20),remoteIP);
remotePort = parseInt(GUI.TextField(new
Rect(230,10,40,20),remotePort.ToString()));
}


// VAATA SIIA, SIIA SAAGU LINN
else
{
// If connected
// Getting your ip address and port
ipaddress = Network.player.ipAddress;
port = Network.player.port.ToString();
GUI.Label(new Rect(140,20,250,40),"IP Adress: "+ipaddress+":"+port);
if (GUI.Button (new Rect(10,10,100,50),"Disconnect"))
{
// Disconnect from the server
Network.Disconnect(200);
}
if (olemas==false)
{
if (GUI.Button (new Rect(10,60,100,50),"Tekita mind!!!:)"))
{
for (var go : GameObject in FindObjectsOfType(GameObject))

go.SendMessage("TekitaTank",SendMessageOptions.DontRequireReceiver);
olemas=true;
var _jalitaja : SmoothFollow = GetComponent("SmoothFollow");
_jalitaja.enabled = true;
var _juhtija : Juhtija;
_juhtija = gameObject.GetComponent("Juhtija");
_juhtija.enabled = true;
}

if (GUI.Button (new Rect(10,110,100,30),"CV-90"))
{/*
 useNAT = !Network.HavePublicAddress();
// Connecting to the server
Network.Connect(remoteIP, remotePort);
*/
//skript=tekitaja.GetComponent("Tekita");

var other : Tekita = tekitaja.gameObject.GetComponent(Tekita);
other.Player2=tankid[0];
//skript.Player=tankid[0];
}
if (GUI.Button (new Rect(10,160,100,30),"M1A1 Abrams"))
{/*
 useNAT = !Network.HavePublicAddress();
// Connecting to the server
Network.Connect(remoteIP, remotePort);
*/
//skript=tekitaja.GetComponent("Tekita");

var other2 : Tekita = tekitaja.gameObject.GetComponent(Tekita);
other2.Player2=tankid[1];
//skript.Player=tankid[0];
}
}
}
}


function OnConnectedToServer() {
// Notify our objects that the level and the network is ready
for (var go : GameObject in FindObjectsOfType(GameObject))
go.SendMessage("OnNetworkLoadedLevel",
SendMessageOptions.DontRequireReceiver);
}

function OnDisconnectedFromServer () {
if (this.enabled != false)
Application.LoadLevel(Application.loadedLevel);
else
{
var _NetworkLevelLoad : NetworkLevelLoad =
FindObjectOfType(NetworkLevelLoad);
_NetworkLevelLoad.OnDisconnectedFromServer();
}
}

function Kadus ()
{
olemas=false;
var _jalitaja : SmoothFollow = GetComponent("SmoothFollow");
_jalitaja.enabled = false;
var _juhtija : Juhtija;
_juhtija = gameObject.GetComponent("Juhtija");
_juhtija.enabled = false;
}