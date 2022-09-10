# FishNetSample

## OverView

FishNetを利用し"Client-Serverモデル/専用サーバー型"を実現するためのサンプル

## Library

- [UniRx](https://github.com/neuecc/UniRx)
- [UniTask](https://github.com/Cysharp/UniTask)
- [FishNet](https://github.com/FirstGearGames/FishNet)
## Figure
![Client-Server](https://user-images.githubusercontent.com/60887155/189012203-ecee4a32-1ab0-4b19-9aa6-85a484d51032.png)

## Architecture

### NetworkModel
#### Client-Server型/専用サーバー型を採用
##### 利点
- クライアントとサーバー間のみの接続状況を意識するだけでよい
- サーバーの負荷分散を適切に行ったり、スペックを上げることでスケールすることができる
- サーバー内でゲームロジックを完結するので安定したプレイ環境を得られる
- サーバー内でゲームロジックを完結するのでチート耐性がある。(クライアント側でチートを行われることが多い)

##### 欠点
- サーバー内でゲームロジックを完結するので処理コストが上がる

#### Unityインゲーム実装
##### 前提条件
<details>
<summary>ネットワークの処理とゲームロジック部分は独立させる</summary>
  <ul>
    <li> ネットワークライブラリのアップデート、差し替え、修正が容易になる</li>
    <li>ロジック、ネットワーク、クライアントでそれぞれのバグ修正、機能追加が容易になる</li>
    <li>作業分担の切り分けが容易になる</li>
  </ul>
</details>

##### 全体クラス図

![NetworkImple](https://user-images.githubusercontent.com/60887155/189012791-4cf8239a-7306-4d82-ac20-48b1c8e7471a.png)

###### Viewの役割
###### Modelの役割
###### Presenterの役割
###### Networkの役割

##### ゲームフロー
![GameFlow](https://user-images.githubusercontent.com/60887155/189492680-ccbbff0d-82ee-4d73-9a3d-d78e5bdf05bf.png)


## LoadMap
