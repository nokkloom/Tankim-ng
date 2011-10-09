function OnGUI() {
GUI.Label(new Rect((Screen.width/2)-80,(Screen.height/2)-130,200,50),"vali ühenduse tüüp");
GUI.Label(new Rect((Screen.width-220),(Screen.height-30),220,30),"Tanki Mängu Mitmikmängu Demo");
if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/
2)-100,200,50),"Master Server Connection"))
{
Application.LoadLevel("MasterServer");
}
if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)-40,200,50),"Direct Connection"))
{
Application.LoadLevel("Ruum");
}
if(GUI.Button(new Rect((Screen.width/2)-100,(Screen.height/2)+20,200,50),"UDP Connection"))
{
Application.LoadLevel("UDPServer");
}
}