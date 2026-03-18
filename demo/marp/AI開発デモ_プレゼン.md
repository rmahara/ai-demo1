---
marp: true
theme: default
paginate: true
size: 16:9
style: |
  @import url('https://fonts.googleapis.com/css2?family=Noto+Sans+JP:wght@400;700;900&display=swap');
  section {
    font-family: 'Noto Sans JP', 'Meiryo', sans-serif;
    background: linear-gradient(135deg, #0f0c29, #302b63, #24243e);
    color: #e0e0e0;
    font-size: 28px;
    line-height: 1.5;
  }
  section h1 {
    color: #00d2ff;
    font-size: 64px;
    font-weight: 900;
    text-shadow: 0 0 20px rgba(0, 210, 255, 0.3);
  }
  section h2 {
    color: #00d2ff;
    font-size: 44px;
    font-weight: 700;
    border-bottom: 3px solid rgba(0, 210, 255, 0.4);
    padding-bottom: 10px;
    margin-bottom: 24px;
  }
  section h3 {
    color: #a0c4ff;
    font-size: 36px;
    font-weight: 700;
  }
  section strong {
    color: #ffd700;
  }
  section em {
    color: #ff6b6b;
    font-style: normal;
  }
  section a {
    color: #69dbff;
  }
  section li {
    margin-bottom: 8px;
  }
  section code {
    background: rgba(0, 210, 255, 0.15);
    color: #69dbff;
    padding: 2px 8px;
    border-radius: 4px;
    font-size: 0.9em;
  }
  section.title {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-align: center;
    background: linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%);
  }
  section.title h1 {
    font-size: 72px;
    margin-bottom: 0;
  }
  section.title h3 {
    font-size: 32px;
    color: #a0c4ff;
    margin-top: 8px;
  }
  section.title p {
    font-size: 24px;
    color: #999;
    margin-top: 24px;
  }
  section.section-break {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-align: center;
    background: linear-gradient(135deg, #1a1a2e, #16213e, #0f3460);
  }
  section.section-break h2 {
    font-size: 56px;
    border-bottom: none;
    color: #00d2ff;
  }
  section.section-break p {
    font-size: 28px;
    color: #a0c4ff;
  }
  section.highlight-box {
    background: linear-gradient(135deg, #0d1b2a, #1b2838, #162447);
  }
  section.closing {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-align: center;
    background: linear-gradient(135deg, #0f0c29, #302b63, #24243e);
  }
  section.closing h2 {
    border-bottom: none;
    font-size: 52px;
  }
  section.huge {
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    background: linear-gradient(135deg, #0f0c29, #302b63, #24243e);
  }
  section.huge h1 {
    font-size: 150px !important;
    letter-spacing: 20px !important;
    text-shadow: 0 0 60px rgba(0, 210, 255, 0.8) !important;
    margin: 0 !important;
    color: #00d2ff !important;
  }
  .timeline {
    font-size: 26px;
  }
  .timeline li {
    margin-bottom: 12px;
  }
  .two-column {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 40px;
    align-items: start;
  }
  .card {
    background: rgba(255,255,255,0.05);
    border: 1px solid rgba(0, 210, 255, 0.2);
    border-radius: 12px;
    padding: 24px;
  }
  .accent {
    color: #ff6b6b;
    font-weight: 700;
  }
  .kpi {
    font-size: 80px;
    font-weight: 900;
    color: #ffd700;
    text-align: center;
  }
  .kpi-label {
    font-size: 24px;
    text-align: center;
    color: #a0c4ff;
  }
  section table {
    width: 100% !important;
    border-collapse: collapse !important;
    font-size: 24px !important;
    margin-top: 8px !important;
  }
  section table th {
    background: rgba(0, 210, 255, 0.2) !important;
    color: #00d2ff !important;
    font-weight: 700 !important;
    padding: 8px 16px !important;
    border: none !important;
    border-bottom: 2px solid rgba(0, 210, 255, 0.4) !important;
  }
  section table td {
    color: #ffffff !important;
    padding: 6px 16px !important;
    border: none !important;
    border-bottom: 1px solid rgba(255, 255, 255, 0.15) !important;
    background: transparent !important;
  }
  section table tr {
    background: transparent !important;
  }
  section table th:first-child,
  section table td:first-child {
    text-align: center !important;
    width: 50px !important;
  }
  section table th:last-child,
  section table td:last-child {
    text-align: center !important;
    width: 70px !important;
  }
---

<!-- _class: title -->

# AI駆動開発の実践

### 生コン出荷管理システム開発デモ
### ～ Claude Codeを活用した超並列開発手法 ～

**発表者**: 産業ソリューション部　馬原

---

## 自己紹介

**馬原（まはら）** / 産業ソリューション部

- **主な業務**
  - 生コン工場・協同組合向けシステムの開発・保守
  - 要件定義から運用まで担当
- **働き方の変化**
  - 昨年度：プロジェクト過渡期でPSC残業時間1位…
  - 今年度：AI活用と落ち着きを取り戻し、定時退社を実現！
- **趣味・現状**
  - 筋トレ（ベンチプレス100kg）→ 怪我で休養中😭
  - 暇になった時間で **帰宅後に毎日3時間以上AI漬け**
  - 難しい理論より「実践」。AIの利用・開発経験は **1000時間超**

---

## アジェンダ（40分想定）

| # | 内容 | 時間 |
|:-:|:--|:-:|
| 1 | 当部でのAI活用事例と裏話 | 5分 |
| 2 | 「AIと開発する」とは？（概念説明） | 3分 |
| 3 | 絶対にやるべきこと | 5分 |
| 4 | デモアプリ紹介と課題 | 2分 |
| 5 | **ライブデモ：並列タスク同時実行** | 15分 |
| 6 | 結果検証・動作確認 | 5分 |
| 7 | 質疑応答（Q&A） | 5分 |

---

<!-- _class: section-break -->

## 01
AI活用事例と予算化への道

---

## 当部でのAI活用 ～ 予算化への歩み

**背景**: まずは個人でAIサービスを契約。「実績・事例」を作るため行動開始。

<div class="timeline">

- **2025/10～** AI勉強会を実施。Excel＋Markdownハイブリッド運用、Gemini CLI利用許可
- **2026/01～** **Antigravity** を用いた開発の導入
- **2026/02～** **Claude Code** を用いた開発の導入
- **2026/03～** CodeRabbitによるコードレビューを個人で検証開始
- **2026/04～** 🎉 中村部長のおかげで **無事予算化！** Azure DevOps等との連携へ

</div>

---

<!-- _class: section-break -->

## 02
「AIと開発する」とは？

---

## 従来 vs AI駆動開発

<div class="two-column">
<div class="card">

### 😐 従来の開発
- 開発者がコードを書く
- わからないことをチャットAIに **「質問」** する
- AIは **ツール** の一つ

</div>
<div class="card">

### 🚀 AI駆動開発
- AI自身がプロジェクトに入り、コードを **読んで理解**
- 人間は **「指示」** を出す
- AIが自律的に **設計・実装・テスト**
- 人間は **「レビューア」「ディレクター」** へ進化

</div>
</div>

---

<!-- _class: section-break -->

## 03
AI活用で生き残るための条件

---

<!-- _class: title -->

# AI活用で一番大事なことは？

---

<!-- _class: huge -->

# 評価！！

---

## AI活用で生き残る人材・組織の条件

### 🧠 これからの時代に強くなる人

- プロンプトの背後にある **「技術、アーキテクチャ」** を深く理解している人
- **一番大事なのは「コードを評価できるか」**
  - AIの出力を理解できないなら使わないほうが良い

### ⚡ 開発スピードの真実と対策

<div class="kpi">1.1倍</div>
<div class="kpi-label">コーディング単体のスピード向上は平均でこの程度</div>

- AIを使って逆にハマることもある → **「リトライは何回まで」** のルールが重要

---

## 絶対にやるべき準備 ①

### 📝 仕様書のMarkdown化

- **実践事例**: 7名チームで約2ヶ月、AIとの壁打ち＆Markdown仕様書作成を実践
- **究極の壁打ち相手**: アバウトな指示でもAIが仕様の漏れを逆質問 → 具体化サイクル確立
- **強み**: 独自規約・フォーマットに完全準拠した仕様書一式を生成可能

### ⚠️ 課題

- **課題①（スキル依存）**: 「AIが書いたから分からない」はNG → **自分の出力へコンバート**
- **課題②（客先フォーマット）**: 客先Excel必須でも **まずMarkdownで作成・レビュー** → 最後にExcel転記。AIエージェントにそのまま読ませられるメリット絶大

---

## 絶対にやるべき準備 ②～④

### 🔀 2. Gitへの完全移行

- Subversionは卒業
- Gitは難易度が高いからこそ、AI開発の **前提** として早急にメンバーに慣れさせる

### 🎯 3. まずは「自分たちで評価できる内容」から始める

- いきなり新規開発に投入せず、**数年以上運用してきたプロジェクト**の仕様作成・改修・調査・保守から
- **要件定義や提案書の作成** など、正しさを自分の目で判断できる領域が鉄則

---

## Amazon AI-DLC の活用

### 🚀 4. プロジェクトの「初動」でAI-DLCを活用する

- プログラムにAIを使っても速度向上は **約10%程度**
- Amazonは **一番のボトルネックは客先や部署間の連携** にあると着目
- キックオフ等でAI-DLCを活用 → **「2倍～10倍」のパラダイムシフト**

### 💡 個人的な見解

- 提案書・仕様作成・コーディングなど広く活用できるが、評価しきれない部分もある
- **まずは初動（キックオフ・要件整理）で使うのがベスト**
- 今後、自分のプロジェクトでも積極的に取り入れたい

---

## 🌎 どの工程が楽になるか「ビジョンを広げる」

### 🏆 インプットと「すぐ検証する」フットワーク
- YouTube、Note、Qiita、AIハッカソンの入賞作品などから最先端の情報をキャッチする。
- 「AIで自社のどの作業・工程を楽にできるか？」というビジョンを広げることが最重要。
- すごい事例を見つけたら、**「じゃあ自分たちのシステムにもいいとこだけ取り入れてみよう」とすぐ検証に動くフットワークの軽さ** が鍵。

### 💡 発想の具体例：Markdown仕様書の「超・横展開」
- 仕様書をMarkdownで作っておけば、**次のフェーズの作業が一気に楽になる**。
- **設計フェーズ**：客先への基本設計レビュー資料作成をAIで自動生成（完成度6割）。
- **導入フェーズ**：部署ごとに異なる6種類の担当者向け説明資料も、仕様書を読ませるだけで、**わずか30分で「完成度8割」のベース資料が一気に完成！** 画像を貼るだけで終わる。

---

<!-- _class: section-break -->

## 08
デモ：AIが作った説明会資料

---

## 📄 実物デモ：Markdown仕様書から爆速生成
**「1文字も変更していない、AIの完全な成果物」** をお見せします。

---

<style scoped>
table { font-size: 21px !important; }
table th:first-child, table td:first-child { width: 18% !important; text-align: left !important; }
table th:nth-child(2), table td:nth-child(2) { width: 12% !important; text-align: left !important; }
table th:nth-child(3), table td:nth-child(3) { width: 35% !important; text-align: left !important; }
table th:last-child, table td:last-child { width: 35% !important; text-align: left !important; }
li { margin-bottom: 2px; }
</style>

## 主要なAI開発ツールのコストと利用イメージ

| ツール | 価格（月額） | 制限・利用スタイル | 特徴・強み |
|:---|:---|:---|:---|
| **Claude Pro** | $20 | 一定利用で制限がかかるが、**約5時間ごとにリフレッシュ** | **論理的思考・単体コーディング能力が現状最強** |
| **Cursor** | $20 | 月500回まで高速応答、上限到達以降は**低速モードで無制限** | **AIエディタの覇権**。ファイル横断のコード生成・補完が非常に快適 |
| **Google AI Pro** | ￥3,190 | Gemini Advanced利用。極端な高負荷利用時のみ制限あり | **コスパのバケモノ**。12TB容量やGCP枠など付帯サービスが凄まじい |
| **GitHub Copilot**| $10～$19 | エディタ予測補完・基本チャット機能は**基本無制限の定額制** | **王道の補完ツール**。タイピングの予測で手書きの負担を劇的短縮 |
| **生成AI(API利用)** | **従量課金** | 送受信した**トークン量に応じた完全従量制（使った分だけ）** | アプリ組み込みや独自の連携ツール開発など、柔軟な使い方 |

---

## おすすめのAI環境プラン


<div class="two-column">
<div class="card">

### 💰 コスパ最強セット
#### 月額 約6,000円

- **Claude**（ネイティブ最強）
- **Google AI Pro**
  - 12TB Drive
  - GCP $10 × 6
  - NotebookLM
  - Veo, Flow... 等

</div>
<div class="card">

### 🏆 メインエンジニア推奨
#### 月額 約20,000円

- **Claude Code Maxプラン**（$100）
- ＋ **Google AI Pro**
- やる気を出させるための投資
- 本部メインエンジニアに推奨

</div>
</div>

---

<!-- _class: section-break -->

## 04
デモアプリ紹介

---

## デモアプリ「生コンAI出荷管理システム」

### 🏭 対象業務
生コン工場の受注 〜 出荷管理・配車計画・請求処理

### 🛠 技術スタック

- **ASP.NET Core MVC** (C#) / **EF Core** + SQLite
- **Bootstrap 5** + Chart.js / ClosedXML.Report

### 📋 現在の状態（デモ開始時）

- メニュー画面と基本データ追加機能は動く
- テストコードなし、ドキュメントなし、セキュリティ未対策
- *あえて「荒削り」な状態からスタート*

---

<!-- _class: section-break -->

## 05
ライブデモ

---

## ライブデモのシナリオ

これからターミナルを立ち上げ、以下の **3タスクをAIに同時並行で** 依頼します。

<div class="two-column">
<div>

### 🔧 Task A：バックエンド
数量データの **ValueObject化**
（業務ルールのカプセル化）

### 🎨 Task B：UI/フロント
システム全体への
**ダークモード** 切り替え機能

</div>
<div>

### 🌤 Task C：外部API連携
天気予報APIを活用した
**ウィジェット作成**

### ⏱ 並列実行
3つのターミナルで
**同時にAIが自律開発**

</div>
</div>

---

<!-- _class: section-break -->

## ⚡ ライブデモ実況

*スライドを閉じ、3分割されたターミナルとWebアプリの画面を投影*

---

<!-- _class: section-break -->

## 06
結果の振り返り

---

## 結果の振り返り

### 🧠 コード読解力
バックエンドの複雑なドメイン設計（ValueObject）を
自律的に理解し**リファクタリング**できた

### 🎯 全体への影響範囲把握
Bootstrap等のUI仕様を読み解き、
既存レイアウトを**壊さずに**ダークモードを適用

### 🌐 外部仕様の自己解決
初見の天気予報APIの仕様をAIが**自力で解読**し、
見事なウィジェットを完成

---

<style scoped>
h2 { margin-bottom: 10px; padding-bottom: 5px; }
h3 { margin-bottom: 5px; margin-top: 15px; font-size: 30px; }
li { margin-bottom: 4px; font-size: 22px; line-height: 1.3; }
</style>

## まとめ

### 🔀 1. GitとCI/CDの導入
- まだGitを使っていないグループはぜひ使い始めましょう！
- 環境の問題などもありますが、導入時は **CI/CDも一緒に経験する** と良いです。

### 🎯 2. 「評価可能」な領域からAIを活用
- 評価可能な仕様書・提案書作成、または **運用中の既存プロジェクト** から活用開始！
- 「マイナーツールでレガシーだから」「システムを熟知してないと…」は関係なし！
- 1日かかる難解なバグ調査も、AIなら **5分** で特定・修正・コミットまで完了。
- ※新規開発の場合は、開発を深く理解した **「AIマスター」** がいると勝ち。

### 💰 3. 迷ったら「Claude」
- 迷ったら **Claude** のMaxプラン。障害対策として **2つのAIサービス** 契約を推奨。

---

<!-- _class: closing -->

## メッセージ：AI時代を楽しむ

### 🏆 デベロッパーがトップになれる時代

天才な助手が依頼した内容を代わりにやってくれる。
**我々がトッププレイヤーになれる可能性が開かれた。**

### ⚡ 今をトップスピードで楽しむ

数年後には「誰でもできる」状態に変わるかもしれない。
だからこそ、**今先行して楽しむ** ことが大事。

---

<!-- _class: title -->

# ありがとうございました

### 🎤 質疑応答（Q&A）

**家族や恋人、友達に誇らしく仕事をしましょう！**
