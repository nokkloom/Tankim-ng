var rotationSpeed = 90.0;
var tiltSpeed = 45.0;
var minTilt = -70;
var maxTilt = 10;

var tiltableGun : Transform;
//var triggerButton = "Fire1";

private var turretTurn = 0.0;
private var gunTilt = 0.0;
private var destroyed = false;

//Enable or disable user controls
/*function SetEnableUserInput(enableInput)
{
	if(!destroyed)
		enabled = enableInput;
}

//no more shooting when destroyed;
function Detonate()
{
	destroyed = true;
	enabled = false;
}*/

function Update () {
if(GameObject.FindWithTag("Test-kere")){
	//Disable Raycasts for collider in parent object, so we don't shoot ourselves
	for(c in transform.root.GetComponentsInChildren(Collider))
		c.gameObject.layer=2;

	//Cast ray into mouse direction
	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	var hit : RaycastHit;
	var targetPoint : Vector3;
	if (Physics.Raycast(ray,hit,10000.0))
		targetPoint = hit.point;
	else
		targetPoint = ray.GetPoint(1000);
	
	//Enable raycasts again
	for(c in transform.root.GetComponentsInChildren(Collider))
		c.gameObject.layer=0;

	//rotate turret
	dir = targetPoint-transform.position;
	angleToTarget = Mathf.Abs(90 - Vector3.Angle(dir,transform.right));
	transform.localRotation.eulerAngles.y += Mathf.Clamp(rotationSpeed * Time.deltaTime * Mathf.Sign(Vector3.Dot(Vector3.Cross(transform.forward,dir),Vector3.up)),-angleToTarget,angleToTarget);
	
	//tilt gun
	dir = targetPoint - tiltableGun.position;
	angleToTarget = Mathf.Abs(90 - Vector3.Angle(dir,tiltableGun.up));
	tiltableGun.localRotation.eulerAngles.x += Mathf.Clamp(tiltSpeed * Time.deltaTime * Mathf.Sign(Vector3.Dot(Vector3.Cross(tiltableGun.forward,dir),tiltableGun.right)),-angleToTarget,angleToTarget);
	
	//limit gun tilt by margins
	if(tiltableGun.localRotation.eulerAngles.x > 180 && tiltableGun.localRotation.eulerAngles.x < Mathf.Repeat(minTilt,360))
		tiltableGun.localRotation.eulerAngles.x = minTilt;
	if(tiltableGun.localRotation.eulerAngles.x < 180 && tiltableGun.localRotation.eulerAngles.x > Mathf.Repeat(maxTilt,360))
		tiltableGun.localRotation.eulerAngles.x = maxTilt;
	
	//fire at will
	//if(Input.GetButton(triggerButton))
		//BroadcastMessage("Fire",null,SendMessageOptions.DontRequireReceiver);
		}
}
