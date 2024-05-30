using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    [Header("SpeedBuff")]
    [SerializeField] private GameObject BuffIcon;
    [SerializeField] private TextMeshProUGUI VelueText;

    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);


        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Eat(float amount)
    {
        stamina.Add(amount);
    }
    public void SpeedBuff(float speed)
    {
        StartCoroutine(SpeedUp(speed));
    }
    IEnumerator SpeedUp(float value)
    {
        CharacterManager.Instance.Player.controller.moveSpeed += value;
        BuffIcon.SetActive(true);
        VelueText.text = "+ " + value;
        Debug.Log("시작");
        yield return new WaitForSeconds(10);
        BuffIcon.SetActive(false);
        CharacterManager.Instance.Player.controller.moveSpeed -= value;
        VelueText.text = "+ " + 0;
        Debug.Log("끝");
    }

    private void Die()
    {
        Debug.Log("신다제!!!");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
