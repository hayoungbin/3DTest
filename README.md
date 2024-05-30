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
