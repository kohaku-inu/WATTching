using UnityEngine;

// Sends the player back to their desk when the supervisor reprimands them.
public class ReturnToDeskOnReprimand : MonoBehaviour
{
    [SerializeField] private SuspicionMeter suspicion;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Transform deskSpawnPoint;

    private void OnEnable() => suspicion.Reprimanded += SendPlayerToDesk;
    private void OnDisable() => suspicion.Reprimanded -= SendPlayerToDesk;

    private void SendPlayerToDesk(int reprimandCount) => player.Teleport(deskSpawnPoint.position);
}
