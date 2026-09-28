using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    internal int nextMove;

    EnemyAnimation enemyAnimation;
    Rigidbody2D rigid;

    bool isDead = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    void Start()
    {
        // 첫 생각 시작
        Invoke(nameof(Think), 3f);
    }

    void FixedUpdate()
    {
        if (isDead) { return; }

        // 낭떠러지 감지 (Platform Check)
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.1f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, Color.green);

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }

    void Think()
    {
        if (isDead) { return; }

        // -1: 왼쪽, 0: 정지, 1: 오른쪽
        nextMove = Random.Range(-1, 2);

        // 애니메이션 및 시각 효과 업데이트
        enemyAnimation.UpdateWalkingAnimation(nextMove);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke(nameof(Think), nextThinkTime);
    }

    void Turn()
    {
        if (isDead) { return; }

        nextMove *= -1;
        enemyAnimation.UpdateWalkingAnimation(nextMove);

        CancelInvoke(nameof(Think));
        Invoke(nameof(Think), 4f);
    }

    public void StopAI()
    {
        isDead = true;
        CancelInvoke();
        nextMove = 0;
    }
}