# 게임개발 숙련주차 개인과제
---

이번 개인과제는 강의를 들으면서 만들었던 프로젝트와 곂치는 부분이 많았기에

강의를 듣던 중에 작성했던 프로젝트를 베이스로 하여 조금 덧붙혀서 만들었습니다.

이하는 필수 구현사항에 대한 설명입니다. 

---

## 필수요구사항 1, 2, 3 ,5

강의 내용과 같습니다.

---

## 필수 요구사항 4 : 점프대 만들기

![image](https://github.com/hayoungbin/3DTest/assets/167050593/8d2b32c7-ad3c-4aa3-8f74-5eb452c1a25b)

기본 3D 오브젝트에 텍스트를 추가하여 만든 오브젝트에

이하의 간단한 스크립트를 추가하여 점프패드와 충돌할 시 높이 점프하도록 만들었습니다.

```cs
<C#>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * 500, ForceMode.Impulse);
    }
}
```

![image](https://github.com/hayoungbin/3DTest/assets/167050593/66a8b014-934b-4b05-9b4f-7990d46a8187)

닿으면 위와 같이 높이 점프합니다.

---

## 필수 요구사항 6 : 아이템 사용, 선택 요구사항 1 : 추가UI, 선택 요구사항 5 : 다양한 아이템 구현

우선, 필수 요구사항 6을 위해 선택요구사항 5의 추가적인 아이템 구현을 먼저 하기로 했습니다.

![image](https://github.com/hayoungbin/3DTest/assets/167050593/9f4adb0b-9957-4a49-9d44-117db2546275)

새로운 아이템인 사과입니다.

![image](https://github.com/hayoungbin/3DTest/assets/167050593/89c6b511-79d1-40e9-a80c-0bf40bd347a6)

강의자료에 달리 아이콘이 없길래 기본 원형 스프라이트를 윈도우 기본 편집기로 수정해서 만들었습니다.

![image](https://github.com/hayoungbin/3DTest/assets/167050593/a4804d73-2522-4c79-9384-6509072ac8d9)

사과를 사용할 경우 10초동안 이동속도가 10 증가하며, 화면 아래에 버프 아이콘이 생깁니다.

아래와같은 스크립트를 사용했습니다.

인스펙터창에 등록할 버프 아이콘
```cs
<C#>
    [Header("SpeedBuff")]
    [SerializeField] private GameObject BuffIcon;
    [SerializeField] private TextMeshProUGUI VelueText;
```

이동속도 버프를 활성화하는 스크립트
```cs
<C#>
 PlayerCondition.cs

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
```

---

추가로 위의 구현사항을 구현함에 있어서 약간의 시행착오가 있었습니다.

처음에 코루틴을 UIInventory.cs에 작성했었는데,

UIInventory.cs가 등록된 인벤토리창 UI가 비활성화될 때 이 곳에 작성된 코루틴이 같이 비활성화되는 문제가 있었습니다.

그래서 결과적으로 해당 코루틴을 PlayerCondition.cs로 넘기는 것으로 간단히 해결하였는데,

이로 인해 해당 코루틴이 등록된 오브젝트가 비활성화 될 때 코루틴이 중단된다는 것을 알게되었고,

아이템의 사용을 결정하는 기능과 아이템의 효과를 정의하는 기능을 다른 스크립트에 분리해두게 된 이유를 알게 되었습니다.

---

이상입니다.
