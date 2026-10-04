using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Coroutine stopCoroutine;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInParent<Player>() == null)
        {
            return;
        }

        // 玩家重新碰到鸟，取消“停止动画”的倒计时
        if (stopCoroutine != null)
        {
            StopCoroutine(stopCoroutine);
            stopCoroutine = null;
        }

        // 开始播放鸟的动作
        animator.SetBool("IsTrigger", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInParent<Player>() == null)
        {
            return;
        }

        // 玩家离开后，开始等待 3 秒
        if (stopCoroutine != null)
        {
            StopCoroutine(stopCoroutine);
        }

        stopCoroutine = StartCoroutine(StopAnimationAfterThreeSeconds());
    }

    private IEnumerator StopAnimationAfterThreeSeconds()
    {
        yield return new WaitForSeconds(3f);

        // 3 秒后停止鸟的动作
        animator.SetBool("IsTrigger", false);

        stopCoroutine = null;
    }
}