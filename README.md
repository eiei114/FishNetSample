# FishNetSample

## OverView

FishNetを利用し"Client-Serverモデル/専用サーバー型"を実現するためのサンプル

## Library

- [UniRx](https://github.com/neuecc/UniRx)
- [UniTask](https://github.com/Cysharp/UniTask)
- [FishNet](https://github.com/FirstGearGames/FishNet)
## Figure
![Client-Server](https://user-images.githubusercontent.com/60887155/189012203-ecee4a32-1ab0-4b19-9aa6-85a484d51032.png)
![NetworkImple](https://user-images.githubusercontent.com/60887155/189012791-4cf8239a-7306-4d82-ac20-48b1c8e7471a.png)

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
- ネットワークライブラリのアップデート、差し替え、修正がやりやすくなる
- ロジック、ネットワーク、クライアントでそれぞれのバグ修正、機能追加が容易になる
- 作業分担の切り分けが容易になる
</details>

## LoadMap
