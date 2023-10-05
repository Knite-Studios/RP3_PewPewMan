using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/CreatePlayerData")]

public class PlayerData : ScriptableObject
{
    public Player player;
}
[System.Serializable] //allow it to be seen in the inspector
public struct Player
{
    public int health;
    public int MaxHealth;
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

}
