# DontHiddenPlayButton


ScoreSaber のリーダーボード画面でプレイボタンが消える (押せなくなる) 問題を抑止する MOD です。プレイボタンの状態設定を Harmony で置き換えます。

## 機能

- `ScoreSaberLeaderboardView.SetPlayButtonState` を Harmony の Prefix で置き換える
- 元の処理を実行せず、内部の `_playButton` の `interactable` に渡された状態をそのまま設定する
- これにより ScoreSaber 側のボタン非表示処理を回避し、プレイボタンを押せる状態に保つ
- WIP 譜面 (`levelID` が `" WIP"` で終わる譜面) ではプレイボタンを無効のままにする
- 譜面選択イベント (`BSEvents.levelSelected`) で選択中の譜面が WIP かどうかを追跡する
- プラグイン無効化時に Harmony パッチを解除する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.16.1 |
| 依存 MOD | BSIPA 4.1.3 以降 / ScoreSaber 3.1.0 以降 / BS Utils 1.10.0 以降 |

## インストール

1. Beat Saber を 1.16.1 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/DontHiddenPlayButton/releases) から `DontHiddenPlayButton-0.0.2-bs1.16.1.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## ビルド

```powershell
git clone https://github.com/denpadokei/DontHiddenPlayButton.git
cd DontHiddenPlayButton
dotnet build .\DontHiddenPlayButton\DontHiddenPlayButton.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。


> GitHub Actions によるビルドは未設定です。manifest の対象バージョン (1.16.1) に対応する ScoreSaber が BeatMods に存在せず、CI で参照アセンブリを解決できないため。

## ライセンス

MIT License (`LICENSE`)
