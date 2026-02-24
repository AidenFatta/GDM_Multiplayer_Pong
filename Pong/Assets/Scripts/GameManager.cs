using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    private NetworkVariable<int> leftScore = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    private NetworkVariable<int> rightScore = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    private NetworkVariable<int> winState = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server); // 0 = intialized, 1 =ongoing, 2= left wins, 3 = right wins
    private GameUI UI;
    public NetworkObject leftPaddle;
    public NetworkObject rightPaddle;

    private void Start()
    {
        UI = FindAnyObjectByType<GameUI>();
        
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        ulong hostID = NetworkManager.Singleton.LocalClientId;

        leftPaddle.ChangeOwnership(hostID);

        if (clientId != hostID)
        {
            rightPaddle.ChangeOwnership(clientId);
        }
    }

    public void RequestStart()
    {
        if (IsServer)
        {
            winState.Value = 1;
            leftScore.Value = 0;
            rightScore.Value = 0;
        }
    }

    public void IncrementLeftScore()
    {
        if (IsServer && winState.Value == 1)
        {
            leftScore.Value++;
            Debug.Log($"Left Score: {leftScore.Value}");
            CheckWinCondition();
        }
    }

    public int GetLeftScore()
    {
        return leftScore.Value;
    }

    public void IncrementRightScore()
    {
        if (IsServer && winState.Value == 1)
        {
            rightScore.Value++;
            Debug.Log($"Right Score: {rightScore.Value}");
            CheckWinCondition();
        }
    }

    public int GetRightScore()
    {
        return rightScore.Value;
    }

    void CheckWinCondition()
    {
        if (leftScore.Value >= 5)
        {
            Debug.Log("Left Player Wins!");
            winState.Value = 2;
        }
        else if (rightScore.Value >= 5)
        {
            Debug.Log("Right Player Wins!");
            winState.Value = 3;
        }
    }

    public int GetWinState()
    {
        return winState.Value;
    }
}
