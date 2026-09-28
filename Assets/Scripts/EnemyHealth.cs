using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;

    EnemyAI enemyAI;
    EnemyMovement enemyMovement;
    EnemyAnimation enemyAnimation;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        enemyAI = GetComponent<EnemyAI>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void OnDamaged(int scoreValue)
    {
        enemyAI.StopAI();

        capsuleCollider.enabled = false;

        enemyAnimation.PlayDeathVisuals();
        enemyMovement.AddKnockbackForce(Vector2.up * 5f);

        GameManager.instance.score += scoreValue;
        UIManager.instance.UpdateScore(GameManager.instance.score);

        Invoke(nameof(DeActive), 5f);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}