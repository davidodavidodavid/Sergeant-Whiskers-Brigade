using UnityEngine;

public class DetonatorDan : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float chaseRange = 1.5f;
    [SerializeField] private float detonateRange = 0.5f;
    [SerializeField] private float chaseDirection = 0;
    [SerializeField] private float jumpCooldown = 2;
    private float cooldown;

    private void Update(){
        if(chaseDirection == 0) CheckForPlayerInRange();
        UpdateAnimator();
    }

    private void CheckForPlayerInRange(){
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        foreach(GameObject player in players){
            if(Vector2.Distance(player.transform.position, transform.position) <= chaseRange){
                chaseDirection = player.transform.position.x < transform.position.x ? -1 : 1;
                cooldown = jumpCooldown;
            }
        }
    }

    private void UpdateAnimator(){
        animator.SetBool("isChasing", !(chaseDirection == 0));
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detonateRange);
    }
}