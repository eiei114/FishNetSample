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
- クライアントの入力を受け取る
- クライアントの入力をサーバーに送信する
- サーバーから受け取ったデータを表示する
###### Modelの役割
- ゲームのロジックを管理する
- ゲームのすべてのパラメーターを保持するクラスを持つ
- パラメーターに変更を加えるメソッドを持つ
###### Presenterの役割
- クライアントの入力を受け取りModelの変更を行う
- サーバーから受け取ったデータを元にViewの変更を行う
###### Networkの役割
- サーバーとの接続を行う
- サーバー上にあるViewに公開すべきデータを複製し仮想Modelを生成する
##### ゲームフロー
![GameFlow](https://user-images.githubusercontent.com/60887155/189492680-ccbbff0d-82ee-4d73-9a3d-d78e5bdf05bf.png)

## UserInputGUI
- ユーザーがクライアント端末に直接アクションを起こすブロック
## ObserverUI
- `UserInputGUI`からのアクションに対する表示の更新(ボタンを押すと表示UIが変わる)
- `UserInputGUI`からのアクションによる情報を`GameLogic`まで流す
- `GameLogic`から公開されてる情報からオブジェクトの位置情報や状態を画面上で表す(制限時間の更新、プレイヤーオブジェクトの位置)
## Network
- Client-Server間の情報を仲介するブロック
## GameLogic
- `UserInputGUI`からの通知などを受け取りゲームの情報を更新する
## LoadMap

1. ローカルホスト上で動くようにする
2. 専用サーバー上にデプロイする
3. ランダムマッチメイキングの実装