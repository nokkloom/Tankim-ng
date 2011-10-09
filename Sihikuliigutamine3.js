var itemTexture : Texture2D;    

function OnGUI () {
    GUI.depth = 0;
    GUI.DrawTexture (Rect (Input.mousePosition.x - (itemTexture.width / 2),
                           Input.mousePosition.y - (itemTexture.height / 2),
                           itemTexture.width,
                           itemTexture.height), 
                     itemTexture);
}

var crosshair : GUITexture ;

function Start (){

crosshair=GameObject.FindWithTag("Sihik").GUITexture;
}

function Update () {
	if(crosshair)
	{
		var hit : RaycastHit;
		if(Physics.Raycast(transform.position,transform.forward,hit))
			crosshair.transform.position=camera.main.WorldToViewportPoint(hit.point);
		else
			crosshair.transform.position=camera.main.WorldToViewportPoint(transform.position+transform.forward*1000);
	}
			
}