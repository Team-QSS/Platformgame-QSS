## 코드 컨벤션

1. **카멜 표기법 잘 지키기**

   매우 사소하지만 지키지 않으면 화가납니다. 

   ````c#
   ex)private void SetJumpBar(GameObject jumpbar, SpriteRenderer jumpbarsprite)
   -> private void SetJumpBar(GameObject jumpBar, SpriteRenderer jumpBarSprite)
   ````

2. **private변수 앞에는 `_`로 시작한다.**

   `bool canMove = true;` -> `private bool _canMove = true;`

3. **변수 이름은 소문자로, 메서드와 클래스 이름은 대문자로 시작한다.**

4. **GetComponent로 가져올 변수는 `_(component type)`로 통일**

   ```c#
   ex)private Rigidbody2D _rigidbody2D;
   private Collider2D _col;
   -> private Rigidbody2D _rigidbody2D;
   private Collider2D _collider2D;
   ```

5. **private, public 변수 선언은 나누어 정리**

   ```c#
   private Transform _transform;
   public GameObject objectToFollow;
   private Transform _objectToFollowTransform;
   private float _followObjectY;
   public float moveSpeed = 3.0f;
   
   ->
   private Transform _transform;
   private Transform _objectToFollowTransform;
   private float _followObjectY;
   
   public GameObject objectToFollow;
   public float moveSpeed = 3.0f;
   ```

6. **if 문 이후 한 줄만 있는 코드도 스코프 쓰기**

   ```c#
   if (_canMove)
   	transform.Translate(_direction * (_mobSpeed * Time.deltaTime));
   ->
   if (_canMove)
   {
   	transform.Translate(_direction * (_mobSpeed * Time.deltaTime));
   }
   ```

나중에 명명규칙에 대해서는 더 얘기해 봐야함

### 컨벤션이라고 하기 애매한거

- 특정 오브젝트를 조정하는 스크립트의 이름은 오브젝트의 이름이 아닌 `(오브젝트 이름 )Ctrl.cs`
- 함수는 동사로 하기 `CantMove` -> `MakeCanNotMove()`

## 추가로 해야 할 것

MissileCtrl : 미사일이 최소 시작점 밑으로 내려가면 없어지도록 함 (중간만 나간 상태가 아닌 내려가면서 아예 보이지 않을때 없애도록) + 미사일이 랜덤 생성되게 함

게임 사이즈에 따라 카메라따라가기, 발판 생성 조작 

-> 카메라 따라갈때 캐릭터가 아래쪽에 있도록 해야할 듯

