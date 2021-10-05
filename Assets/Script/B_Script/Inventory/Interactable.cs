using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;

    bool hasInterated = false;

    public virtual void Interact ()
    {
        Debug.Log("Interacing with " + transform.name);
    }

    void Update (){
        if(isFocus && !hasInterated)
        {

            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if (distance <= radius){

                Interact();
                hasInterated = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform){
        isFocus = true;
        player = playerTransform;
        hasInterated = false;
    }

    public void OnDefocused(){
        isFocus = false;
        player = null;
        hasInterated = false;
    }

    void OnDrawGizmosSelected (){
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
