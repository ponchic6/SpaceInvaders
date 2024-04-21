using System.Collections;
using UnityEngine;

public class EnemyCoroutineMover : MonoBehaviour
{
    public void StartMoveCoroutine(float delay)
    {
        StartCoroutine(MoveCoroutine(delay));
    }

    private IEnumerator MoveCoroutine(float delay)
    {   
        Vector3 direction = Vector3.right;
        
        yield return new WaitForSeconds(delay);
        
        while (true)
        {
            int i = 10;
            
            while (i != 0)
            {   
                yield return new WaitForSeconds(1);
                transform.position += direction * 30;
                i--;
            }

            transform.position += Vector3.down * 30;
            direction = -direction;
        }
    }
}