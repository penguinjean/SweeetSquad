using UnityEngine;

public class ItemHp : MonoBehaviour, IItemEffect
{
    public int hpValue;

    public void ApplyEffect()
    {
        if (GameManager.instance.currentHealth < GameManager.instance.maxHealth) { GameManager.instance.currentHealth += hpValue; }
        else
        {
            // 캐릭터 재질 바꾸고

            // 3초동안 이속 1.5배
        }

        UIManager.instance.UpdateHp(GameManager.instance.currentHealth);
    }
}

