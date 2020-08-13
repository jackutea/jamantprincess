# Demo 仅支持Unity
### 移动演示(鸟瞰视图类游戏)
```
using UnityEngine;
using JackUtil;

public class Actor : MonoBehaviour {

    public RigidBody2D rig; // 绑定一个 RigidBody2D 模式为 Kinematic, 必须配上 Collider2D 才可使用
    public LayerMask colLayer; // 声明碰撞哪个层

    void FixedUpdate() {

        // 一行代码实现移动
        rig.MoveAndSlide(colLayer);

        // 或者可以自定义速度
        // rig.MoveAndSlide(colLayer, 5, 0.01f, 0.005f);

        // 如果 axis 的名称有更改，请使用自定义的按键判断
        // float xAxis = Input.GetAxisRaw("Horizontal");
        // float yAxis = Input.GetAxisRaw("Vertical");
        // rig.MoveAndSlide(xAxis, yAxis, colLayer);

    }
}
```

### 移动演示(平台跳跃类游戏)
```
using UnityEngine;
using JackUtil;

public class Actor : MonoBehaviour {

    public RigidBody2D rig; // 绑定一个 RigidBody2D 模式为 Kinematic, 必须配上 Collider2D 才可使用
    public LayerMask colLayer; // 声明碰撞哪个层

    void FixedUpdate() {

        // 一行代码实现移动(默认速度)
        rig.MoveInPlatform(colLayer);

        // 或者自定义速度
        // rig.MoveInPlatform(colLayer, 3f, 0.009f, 0.001f);

    }
}
```

### 跳跃演示(平台跳跃类游戏)
```
using UnityEngine;
using JackUtil;

public class Actor : MonoBehaviour {

    public RigidBody2D rig; // 绑定一个 RigidBody2D 模式为 Kinematic, 必须配上 Collider2D 才可使用
    public LayerMask colLayer; // 声明碰撞哪个层

    void FixedUpdate() {

        // 一行代码实现跳跃(默认速度)
        rig.Jump(colLayer);

        // 自定义速度
        // rig.Jump(colLayer, 9f, -18f, 5f, 2.5f);

    }
}
```

### 相机演示
```
using UnityEngine;
using JackUtil;

public class Actor : MonoBehaviour {

    Camera cam;

    void Start() {

        cam = Camera.main;

    }

    void FixedUpdate() {

        // 一行代码实现相机跟随
        cam.FollowTarget(transform.position, 2 * Time.FixedDeltaTime);

        // 一行代码实现视野缩放
        cam.ScrollFieldOfView("Mouse ScrollWheel"); // Perspective 模式
        // cam.ScrollOrthographicSize("Mouse ScrollWheel"); // Orthographic 模式, 调整的是Y轴

        // 也可自定义最近和最远距离
        // cam.ScrollFieldOfView("Mouse ScrollWheel", 50, 150); // Perspective 模式
        // cam.ScrollOrthographicSize("Mouse ScrollWheel", 5, 20); // Orthographic 模式

        // 一行代码实现按住某键平移相机
        cam.ClickMoveCamera(KeyCode.Mouse0);

    }
}
```