using Game.Player;
using UnityEngine;

public class Stair : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            playerMove.IsStair(true);
    }

}

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
            playerMove.IsStair(false);
    }
}
