# RigidBody2DExtention.cs
using UnityEngine;
## class RigidBody2D
### [Methods]
#### void MoveAndSlide(float xAxis, float yAxis, LayerMask colLayer, float moveSpeed = 2.5f, float accelerate = 0.008f, float decelerate = 0.0016f)
RigidBody2D 模式需为 Kinematic 在鸟瞰视角的游戏中进行八向移动，请放在FixedUpdate里使用
```
RigidBody2D rig;
float xAxis = Input.GetAxisRaw("Horizontal");
float yAxis = Input.GetAxisRaw("Vertical");
LayerMask colLayer = 0;

// 使用默认值移动
rig.MoveAndSlide(xAxis, yAxis, colLayer);

// 或使用自定义值移动
rig.MoveAndSlide(xAxis, yAxis, colLayer, 5, 0.01f, 0.005f);
```
#### void MoveAndSlide(LayerMask colLayer, float moveSpeed = 2.5f, float accelerate = 0.008f, float decelerate = 0.0016f)
MoveAndSlide 的简化版，默认监听 Input.GetAxisRaw("Horizontal") 和 Input.GetAxisRaw("Vertical");
```
RigidBody2D rig;
LayerMask colLayer = 0;

// 使用默认值移动
rig.MoveAndSlide(colLayer);

// 或使用自定义值移动
rig.MoveAndSlide(colLayer, 5, 0.01f, 0.005f);

```

#### void MoveInPlatform(float xAxis, LayerMask groundLayer, float moveSpeed = 2.5f, float accelerate = 0.008f, float decelerate = 0.0032f)
平台跳跃类游戏的左右移动(会检测碰撞的图层)，前提是该 RigidBody2D 有包含 Collider2D
```
RigidBody2D rig;
float xAxis = Input.GetAxisRaw("Horizontal");
LayerMask colLayer = 0;
rig.MoveInPlatform(xAxis, colLayer);
```

#### void MoveInPlatform(LayerMask groundLayer, float moveSpeed = 2.5f, float accelerate = 0.008f, float decelerate = 0.0032f)
MoveInPlatform 的简化版，默认监听 Input.GetAxisRaw("Horizontal")
```
RigidBody2D rig;
LayerMask colLayer = 0;

// 默认速度
rig.MoveInPlatform(colLayer);

// 自定义速度
rig.MoveInPlatform(colLayer, 3f, 0.009f, 0.001f);
```

#### void Jump(float jumpAxis, LayerMask groundLayer, float jumpSpeed = 14f, float gravity = -20f, float fallMultiplier = 5f, float lowJumpMultiplier = 2.5f)
平台跳跃类游戏的跳跃，跳跃键按得越长，跳的越高，自动检测落地
```
RigidBody2D rig;
LayerMask colLayer = 0;
float jumpAxis = Input.GetAxisRaw("Jump");

// 默认速度
rig.Jump(jumpAxis, colLayer);

// 自定义速度
rig.Jump(jumpAxis, colLayer, 9f, -18f, 5f, 2.5f);
```

#### bool IsOnWall(Vector2 moveDirection, LayerMask layer)
对目标方向进行碰撞检测，前提是该 RigidBody2D 有包含 Collider2D
(注: 碰撞距离请在 RigidBody2DExtention.cs 文件内，修改 colSensitivity 的数值)
```
RigidBody2D rig;
float xAxis = Input.GetAxisRaw("Horizontal");
float yAxis = Input.GetAxisRaw("Vertical");
Vector2 moveDirection = new Vector2(xAxis, yAxis);
LayerMask colLayer = 0;
bool isOnWall = rig.IsOnWall(moveDirection, colLayer);
```

#

# CameraExtention.cs
using UnityEngine;
## class Camera
### [Methods]
#### void FollowTarget(Vector3 targetPos, float smmothDeltaTime)
相机跟随目标，需要在 Update() 或 FixedUpdate() 内使用
```
Camera cam = Camera.main;
GameObject player;

// 在FixedUpdate()里使用
cam.FollowTarget(player.transform.position, 2 * Time.FixedDeltaTime);

// 在Update()里使用
cam.FollowTarget(player.transform.position, 2 * Time.DeltaTime);
```

#### void ScrollFieldOfView(string axisOfMouseScrollWheel, float sensitivity = 0, float min = 80, float max = 130)
可在 Perspective 模式的相机使用， 一般情况下，使用鼠标滚轮，axis的名字请在Unity/Edit/Project Setting/InputManager查看，默认为"Mouse ScrollWheel"(有空格)
```
Camera cam = Camera.main;

// 使用默认缩放限制，可在 FixedUpdate() 或 Update() 使用
cam.ScrollFieldOfView("Mouse ScrollWheel");

// 使用自定义缩放限制 min 是最近距离 max 是最远距离
cam.ScrollFieldOfView("Mouse ScrollWheel", 50, 150);
```

#### void ScrollOrthographicSize(string axisOfMouseScrollWheel, float sensitivity = 0, float min = 8, float max = 16)
可在 Orthogrphic 模式的相机使用，一般情况下，使用鼠标滚轮，axis的名字请在Unity/Edit/Project Setting/InputManager查看，默认为"Mouse ScrollWheel"(有空格)
```
Camera cam = Camera.main;

// 使用默认缩放限制，可在 FixedUpdate() 或 Update() 使用
cam.ScrollOrthographicSize("Mouse ScrollWheel");

// 使用自定义缩放限制 min 是最近距离 max 是最远距离
cam.ScrollOrthographicSize("Mouse ScrollWheel", 5, 20);
```

#### void ClickMoveCamera(KeyCode mousePressKey, float sensitivity = 0.5f)
按住某键时，拖动鼠标，即可平移相机
```
Camera cam = Camera.main;
cam.ClickMoveCamera(KeyCode.Mouse0);
```

#

# TileMapExtention.cs
using UnityEngine.Tilemaps;
## class TileMap
### [Methods]
#### string[,] ToStringArray(BoundsInt bounds) 
将 Tilemap 转换为 string[,] 二维数组, string 为 每个Tile的name，空的Tile则为string.empty  
该方法的作用主要是：序列化编辑器里的 Tile 数据，用于通过代码读取并绘制 Tilemap
```
Tilemap groundMap;
string[,] mapStringArr = groundMap.ToStringArray();
```

---
# CloneExtention.cs
## class T
### [Methods]
#### T CreateDeepClone()
创建任何一个引用类型的深复制对象，类型需要 [System.Serializable] 特性  
注: 遍历使用时，可能会有BUG
```
[System.Serializable]
class Player {
    string playerName = "Jeff"
    int age = 28;
}

Player jeff = new Player();

// 这样引用会导致jeff的名字变化，因为它们的内存位置一样
Player dave = jeff;
dave.playerName = "Dave"; // jeff.playerName == dave

// 正确用法
Player dave = jeff.CreateDeepClone();
dave.playerName = "Dave"; // jeff.playerName == jeff
```
# ArrayExtention.cs
## class T[]
### [Methods]
#### T[] Shuffle(Random random = null)
将 T[] 的顺序随机打乱后返回 T[]
```
int[] arr = new int[]{1, 2, 3, 4, 5};
arr = arr.Shuffle(); // {4, 1, 2, 5, 3} 这是随机的
```
#### bool TryGetEmptySlotIndex<T>(out int index)
(仅适用于引用类型)判断数组内是否有空值，有则返回索引位置，无则返回-1
```
class Player {}
Player arr = new Player[3];
arr[0] = new Player();
arr[1] = null;
arr[2] = new Player();

int emptyIndex;
bool hasEmpty = arr.TryGetEmptySlotIndex(out emptyIndex); // hasEmpty == true; emptyIndex == 1;
```