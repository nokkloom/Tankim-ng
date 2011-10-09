var target : Transform;
var distance : float = 10.0;
var height : float = 5.0;
var heightDamping : float = 2.0;
var rotationDamping : float = 3.0;
function LateUpdate () {
if(GameObject.FindWithTag("Test-kahur"))
{
if (!target)
target = GameObject.FindWithTag("Test-kahur").transform;
// Calculate the current rotation angles
var wantedRotationAngle : float = target.eulerAngles.y;
var wantedHeight : float = target.position.y + height;
var currentRotationAngle : float = transform.eulerAngles.y;
var currentHeight : float = transform.position.y;
// Damp the rotation around the y-axis
var dt : float = Time.deltaTime;
currentRotationAngle = Mathf.LerpAngle (currentRotationAngle,
wantedRotationAngle, rotationDamping * dt);
// Damp the height
currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * dt);
// Convert the angle into a rotation
var currentRotation : Quaternion = Quaternion.Euler (0, currentRotationAngle,
0);
// Set the position of the camera on the x-z plane to:
// distance meters behind the target
//transform.position = target.position;
var pos : Vector3 = target.position - currentRotation * Vector3.forward *
distance;
pos.y = currentHeight;
// Set the height of the camera
transform.position = pos;
// Always look at the target
transform.LookAt (target);
}
}