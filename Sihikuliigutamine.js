var sihik : GUITexture ;

function Start (){
transform.DetachChildren();
//sihik=GUITexture.GameObject.FindWithTag("Sihik");
}

function Update () {
	if(sihik)
	{
		var hit : RaycastHit;
		if(Physics.Raycast(transform.position,transform.forward,hit))
			sihik.transform.position=camera.main.WorldToViewportPoint(hit.point);
		else
			sihik.transform.position=camera.main.WorldToViewportPoint(transform.position+transform.forward*1000);
	}
			
}