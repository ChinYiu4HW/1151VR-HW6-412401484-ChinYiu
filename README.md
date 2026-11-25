# 1151VR-HW6-412401484-ChinYiu



Youtube 連結︰<br>
https://youtu.be/IqAvxpD6HIA<br>

說明製作流程和相關操作 ︰<br>
用plane配合materail 拼出 3×3 九宮格舞台<br>
移動坐標以旗盤中間那格為基準，上下左右控制木盤<br>
載入 Apple + Bomb 的 3D 模型、掛上 Rigidbody 與 Collider、新增 Tag Apple, Bomb<br>
建立Apple + Bomb 的prefab + 建立Factory<br>
調整相機位置、Directional Light 產生陰影<br>
木盤碰到蘋果或炸彈會播音效 + 加分/ 扣分還有銷毀道具(消失)<br>
新增2個下一關 / 重玩一次按鈕並隱藏起來<br>
加入時間到就停產道具 + 依分數顯示 下一關或重玩一次的按鈕來切換關卡功能<br>
寫死3關的數值按關卡編號來辨識 + 剩餘時間 動態更新生成間隔、掉落速度、炸彈比例等等<br>
增加SceneChanger  把他public 萬用scripts 用來切換scene用<br>
增加GAME START scene 、關卡選擇scene + 關卡選擇BUTTON<br>
即時更新 UI 分數 + 倒數時間<br>
