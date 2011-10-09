// Your player transform
var Player : Transform;
var Player2 : Transform;

// This function will be called when network is loaded
function OnNetworkLoadedLevel ()
{		
	// Instantiate object to the network in the position of Spawn
	Network.Instantiate(Player, transform.position, transform.rotation, 0);
}
function TekitaTank ()
{		
	// Instantiate object to the network in the position of Spawn
	Network.Instantiate(Player2, transform.position, transform.rotation, 0);
}

// this function will be called when player is disconnected
function OnPlayerDisconnected (player : NetworkPlayer)
{
	// Removing player from network and scene
	Debug.Log("Server destroying player");
	Network.RemoveRPCs(player, 0);
	Network.DestroyPlayerObjects(player);
}