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


各關卡數值表

| 關卡 | 時間 | 生成間隔 | 掉落速度 | 炸彈比例 | 蘋果 / 炸彈計分規則 |
| :--- | :--- | :--- | :--- | :--- | :--- |
| Level 1 | 前 10秒 | 0.85f 秒 | -0.065f | 30% | 蘋果 +100 / 炸彈分數減半 |
| Level 1 | 最後 10 秒 | 0.45f 秒 | -0.090f | 50% | 蘋果 +200 / 炸彈分數歸 0 |
| Level 2 | 前 10秒 | 0.60f 秒 | -0.090f | 50% | 蘋果 +100 / 炸彈分數減半 |
| Level 2 | 最後 10 秒 | 0.32f 秒 | -0.120f | 60% | 蘋果 +300 / 炸彈分數歸 0 |
| Level 3 | 前 10秒 | 0.38f 秒 | -0.120f | 60% | 蘋果 +100 / 炸彈分數減半 |
| Level 3 | 最後 10 秒 | 0.22f 秒 | -0.155f | 80% | 蘋果 +500 / 炸彈分數歸 0 |[cite: 2]




為什麼這樣設計 <br>
讓節奏一路變快、蘋果和炸彈變密、掉得更快，手腳要跟著快，不能慢慢等著接，提高操作刺激感。<br>
關卡之間做階梯銜接，不會突然斷掉，第一關快結束的速度跟炸彈比例，剛好接上第二關剛開始的感覺，第二關結束也剛好接上第三關開頭，玩起來比較順。<br>
最後 10 秒做成 高風險、高報酬的玩法，一但貪刀就會輸，炸彈比例拉高且碰到直接歸零，但蘋果加分提高到 +200 / +300 / +500，剩最後幾秒如果分數還差一點，玩家就得決定要不要冒險衝高分蘋果，還是穩穩閃炸彈保住分數，玩起來會緊張很多。<br>


所使用到的素材︰<br>
APPLE: https://sketchfab.com/3d-models/low-poly-apple-7656b9ae0d9542e4b28b817b0e7a2da4#download <br>
BOMB: https://sketchfab.com/3d-models/bomb-model-low-poly-8a77b3e7e1da4fa089ed06480885359a#download <br>
BUCKET https://sketchfab.com/3d-models/low-poly-bucket-739f1a6be838419993fbc79f79dda2ff#download<br>
炸彈音效: https://pixabay.com/sound-effects/film-special<br>
蘋果音效: https://pixabay.com/sound-effects/search/game/?pagi=2 <br>

關卡選擇BUTTON 及GAMESTART +BANNER 皆為AI 生成圖片<br>
