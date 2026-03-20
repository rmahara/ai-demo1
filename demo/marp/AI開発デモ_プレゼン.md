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
    margin-top: -30px;
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

<style scoped>
p { margin-bottom: 8px; }
li { margin-bottom: 6px; }
ul ul { margin-top: 2px; margin-bottom: 6px; }
ul ul li { font-size: 25px; margin-bottom: 2px; }
</style>

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
  - ジムやめて暇すぎて **毎日3時間以上AIで遊ぶ、休日は10時間以上** ※課金 月額1万超
  - 難しいAI理論は苦手＆興味なし！ AIの利用・開発経験は **1000時間超**

---

## アジェンダ（50分想定）

| # | 内容 | 時間 |
|:-:|:--|:-:|
| 1 | 当部でのAI活用事例と裏話 | 3分 |
| 2 | 「AIと開発する」とは？（概念説明） | 2分 |
| 3 | 絶対にやるべきこと | 15分 |
| 4 | デモアプリ紹介とシナリオ | 3分 |
| 5 | **デモ：並列タスク同時実行開始** | 2分 |
| 6 | デモ待機中：主要な生成AIサービスの紹介 | 10分 |
| 7 | 結果検証・まとめ | 5分 |
| 8 | 質疑応答（Q&A） | 5分 |

---

<!-- _class: section-break -->

## 01
AI活用事例と予算化への道

---

## 当部でのAI活用 ～ 予算化への歩み

**背景**: まずは個人でAIサービスを契約。「実績・事例」を作るため行動開始。

<div class="timeline">

- **2025/8** 部長に、AI勉強会を企画・承認
- **2025/10～** AI勉強会を実施。Excel＋Markdownハイブリッド運用、Gemini CLI利用許可
- **2026/01～** **Antigravity** を用いた開発の導入
- **2026/02～** **Claude Code** を用いた開発の導入
- **2026/03～** CodeRabbitによるコードレビューを個人で検証開始
- **2026/04～** 🎉 中村部長のおかげで **希望通り予算化！** 
  - 実運用を進めつつ、部内ルールの整備や汎用フレームワークの選定・作成へ

</div>

---

<!-- _class: section-break -->

## 02
「AIと開発する」とは？

---

<style scoped>
ul ul li { font-size: 24px; margin-bottom: 2px; color: #d0d0d0; }
li { margin-bottom: 8px; }
ul { margin-bottom: 8px; }
</style>

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
- **部分的な自動補完ではなく
「開発の全工程」を一任**
- **AIに自律してやらせること**
  - 要件定義・設計書作成の協働
  - コーディング
  - コードレビュー、テスト
  - ソース管理、リリース準備
- 人間は **「ディレクター」** へ

</div>
</div>

---

<!-- _class: section-break -->

## 03
AI活用で生き残るための条件

---

## 2026年エンジニアの強者の条件

### 🏆 「技術の根幹」と「業務知識」を知る力
- 表面的なプロンプトではなく **「技術の仕組み、フレームワーク、インフラ等の根本知識」** と、対象となる **「業務知識」** こそが重要。

### 🗣️ やりたいことを的確に伝える「言語化能力」
- 変わらず、自分の意図を正確にAI（や人間）に伝える **「コミュニケーション能力」** と **「言語化能力」** を持つ人が、AIを最も上手くコントロールできる。

---

<!-- _class: title -->

# AI活用で一番大事なことは？

---

<!-- _class: huge -->

# 評価！！

---

<style scoped>
li { font-size: 26px; margin-bottom: 4px; }
.kpi { font-size: 60px; line-height: 1.1; margin-top: -10px; }
.kpi-label { font-size: 20px; margin-bottom: 12px; }
</style>

## なぜ「評価」が最重要なのか？

### 🎯 自分なりの「評価基準」を持てるか
- 要件を満たしているか？（Yes / No）
- 「今回は10点満点中8点だから良しとしよう」と品質を判定できるか

※ AIの出力を理解できず、**点数すらつけられないのであれば使うべきではない**。

### ⚡ AIを活用した開発スピードの真実と「品質の罠」

<div class="kpi">約 10%</div>
<div class="kpi-label">Google統計：生産性向上はせいぜいこの程度</div>

- AI任せで品質調査を怠ると、ドツボにハマり **かえって工数オーバー** に陥る。
- **対策（ルール）**：「自分が確実に評価できる領域に絞る」「リトライは何回までと決める」

---

## 絶対にやるべき準備 ①-1：仕様書のMarkdown化

### 🤖 AIと協働で仕様書を作成する「2つの目標」
- ドキュメントを **「プロジェクトで完全に統一したフォーマット」** にする。
  - 「チームでどんな仕様書が分かりやすいか」を考え抜くことが重要。
- **「転記や多重管理の削減」**。似た資料を複数作らないように、開発フローで真に必要な設計書・テスト資料に合わせて出力させる。

### 🛠️ 目標を実現するために自作したツール「document foundry」
- 開発言語、DB、連携機能、設計手法など **約1万行のルール** をAIに事前学習。
- これにより、メンバー全員が **チームのルールに完全に合った仕様書一式** が出力可能になる。

---

## 絶対にやるべき準備 ①-2：ツール概要

### 🛠️ ファイルを1つ読ませて、大雑把な要件を伝えるだけ
- AIに初期ファイル（プロジェクトルール）を読み込ませる。
- 次に「各種マスタに承認機能を作りたい」などの大雑把な要件を手短に伝える。

### 🔄 AIの「逆質問」に答えて具体化する
- AIから「～～の処理はこの認識であってますか？」「ステータス遷移は？」「否認されたらどの状態にするか？申請状態を保持したままステータスだけ変更か、ロックは解除するか？」など、人間が漏らしがちな仕様の穴を、次々と逆質問してくる。
- 人間は **「これらの質問にただ正確に答えるだけ」** で設計書が完成していく。

---

## 絶対にやるべき準備 ①-3：時間配分と人間の責任

### ⏳ 「時間配分」の劇的変化
- 仕様書の作成は **従来の半分の時間で高品質** に！
- 浮いた時間で、**チームレビューの時間をこれまでの2倍** にする余裕が生まれた。

### 📝 AIのせいにしない「人間の責任」
- 🚨 事前の意識づけ：**「AIが書いた文章で、細部は分かりません」という人が続出**。
- 生成された成果物を **完全に「自分のもの」にする責任（評価）** を持つ。
  
⚠️ 内容の確認漏れは **「AIとは無関係のヒューマンエラー」** 
 品質を担保するため、AI時代であっても **人間のダブルチェック** がに重要。

---

<style scoped>
li { font-size: 26px; }
h3 { margin-top: 15px; margin-bottom: 5px; font-size: 32px; }
</style>

## 絶対にやるべき準備 ①-4：チームで感じた利点1

### 💡 レビュー充実による「属人化の軽減」
- 全員でレビューし合うため **「その機能は担当外なので分かりません」という状態が軽減した** 。
- レビュー用に「曖昧点、保留事項、お客様確認事項」などをまとめてと、AIに伝達するだけで、レビュー資料を即座に作成してくれる。

### 🌱 未経験者への「タスク委譲」と「成長の機会」
- 外注SEや仕様作成未経験のPGでも、AI補助によって **「80点の成果物」** が完成する。
- ツール無しなら多大な説明コストがかかり「依頼すらしなかった業務」を任せられる。
- 担当者自身も **「自力で正解に近い成果物を作り上げる成功体験」** を積むことができる。

---

## 絶対にやるべき準備 ①-5：チームで感じた利点2

### 🔄 仕様変更時の「一貫した自動修正」
- レビュー後の指摘・仕様変更箇所を、AIに伝達するだけで逆質問が始まり、影響範囲となる各資料を **一貫して漏れなく自動修正** してくれる。

### 🤖 最大の恩恵：「AIエージェントへの直結」
- 仕様書がテキスト形式であるため、**AIエージェントが直接読み取って「即座に自動コーディング」へ移行できる** 強烈なメリットに繋がる。

---

## 絶対にやるべき準備 ②～④

### 🔀 2. Gitへの完全移行

- Subversionは卒業
- Gitは難易度が高いからこそ、AI開発の **前提** として早急にメンバーに慣れさせる

### 🎯 3. 「自分たちで評価できる内容」から経験を積む

- いきなり新規開発に投入せず、**数年以上運用してきたプロジェクト**の仕様作成・改修・調査・保守で経験を積む
- **要件定義や提案書の作成** など、正しさを自分の目で判断できる領域が鉄則

---

## Amazon AI-DLC の活用

### 🚀 4. プロジェクトの「初動」でAI-DLCを活用する

- プログラムにAIを使っても速度向上は **約10%程度**
- Amazonは **一番のボトルネックは客先や部署間の連携品質** にあると着目
- キックオフ等でAI-DLCを活用 → **「2倍～10倍」のパラダイムシフト**

### 💡 個人的な見解

- 提案書・仕様作成・コーディングなど広く活用できるが、規模が大きすぎてコントロールできない部分もありそう
- **まずは初動（キックオフ・要件整理）で使うのがベスト**
- 今後、自分のプロジェクトでも積極的に取り入れたい

---

<style scoped>
li { font-size: 26px; }
h3 { margin-top: 15px; margin-bottom: 5px; font-size: 32px; }
</style>

## 🌎 どの工程が楽になるか「ビジョンを広げる」

### 🏆 インプットと「すぐ検証する」フットワーク
- YouTube、Note、Qiita、AIハッカソンの入賞作品などから最先端の情報をキャッチする。
- 「AIで自社のどの作業・工程を楽にできるか？」というビジョンを広げることが最重要。
- すごい事例を見つけたら、**「じゃあ自分たちのシステムにもいいとこだけ取り入れてみよう」とすぐ検証に動くフットワークの軽さ** が鍵。

### 💡 発想の具体例：Markdown仕様書の「その先へ…横展開」
- 仕様書をMarkdownで作っておけば、**次のフェーズの作業が一気に楽になる**。
- **設計フェーズ**：客先への基本設計レビュー資料作成をAIで自動生成（完成度6割）。
- **導入フェーズ**：部署ごとに異なる6種類の担当者向け説明資料も、仕様書を読ませるだけで、**わずか30分で「完成度7割」のベース資料が一気に完成！** あとは画像を貼るだけで終わる。

---

<!-- _class: section-break -->

## ミニデモ
AIが作った説明会資料

---

## 📄 実物デモ：Markdown仕様書から爆速生成
**「1文字も変更していない、AIの成果物」** をお見せします。

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
Claude Code 実演デモ

---

## ライブデモのシナリオ

これからターミナルを立ち上げ、以下の **3~4タスクをAIに同時並行で** 依頼します。

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
主要な生成AIサービスの紹介

---

<style scoped>
table { font-size: 18px !important; margin-top: -10px !important; }
table th, table td { padding: 4px 8px !important; line-height: 1.3 !important; }
table th:first-child, table td:first-child { width: 17% !important; text-align: left !important; }
table th:nth-child(2), table td:nth-child(2) { width: 10% !important; text-align: left !important; }
table th:nth-child(3), table td:nth-child(3) { width: 36% !important; text-align: left !important; }
table th:last-child, table td:last-child { width: 37% !important; text-align: left !important; }
li { margin-bottom: 2px; }
</style>

## 主要なAI開発ツールのコストと利用イメージ

| ツール | 価格 | 制限・利用スタイル | 特徴・強み |
|:---|:---|:---|:---|
| **Claude Pro** | $20 | 激しく使うと**30分〜1時間で制限到達**<br>約5時間で回復。別途ウィークリー枠制限あり | **論理的思考・単体コーディング能力が現状最強** |
| **Cursor** | $20 | 月額$20枠まで高速応答、上限到達以降は**低速モードで無制限** | **AIエディタの覇権**。<br>※対抗馬：WindSurf, Kiro, Antigravity |
| **Google AI Pro** | ￥3,000 | 2026年3月に**利用制限が厳格化**（従来の1/30へ大幅縮小） | Gemini 3 Flashモデルはほぼ無制限。<br>Google One（2TB）等の**豊富な付帯特典が魅力**。 |
| **GitHub Copilot**| $10～$19 | Agent機能の拡充により、GitHubとの連携が段階的に強化中。リクエスト数制限あり、リクエストを節約するスキルが必要 | GitHubでのTeam一括契約など**経理的な導入ハードルは低い**が、単体のコーディング性能は他に見劣りするとの声も。 |
| **中国系AI** | **格安** | **セキュリティを自身で担保できる「個人利用」に最適**。<br>企業コンプライアンス上、業務利用は要確認。 | Zhipu等の最新モデル（GLM-5など）が**月額$3程度**で利用できるなど、驚異的な価格破壊が強み。 |

---

<style scoped>
.card { padding: 25px; }
li { font-size: 23px; line-height: 1.4; }
p { font-size: 24px; margin-bottom: 5px; line-height: 1.4; }
h3 { margin-top: 5px; margin-bottom: 15px; font-size: 30px; }
</style>

## おすすめのAI環境プラン

<div class="two-column">
<div class="card">

### 💰 コスパセット2選

**① Claude Pro & Google AI Pro**（約6,000円）
- 普段の小さい作業は「Gemini Flash」
- 大規模で重要な作業時は「Claude Code」

**② Claude Pro & Cursor Pro**（約6,000円）
- メインはClaude、制限時にCursorへ切替

</div>
<div class="card">

### 🏆 メインプレイヤー向け

**① Claude Pro & Cursor Pro+**（約12,000円）
- より上位のCursorプランを活用する

**② Claude Max5 ＋ 補助AI**（約,20,000円）
- 圧倒的パフォーマンスの「Maxプラン」主軸
- 補助として$20のAIをペアで持つ最強の布陣

</div>
</div>

---

<!-- _class: section-break -->

## 07
結果の振り返り

---

## 結果の振り返り

### 🧠 コード読解力
バックエンドの複雑なドメイン設計思想（ValueObject）を
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
- 環境の問題などもありますが、導入時は **CI/CDも一緒に経験する** となお良い。

### 🎯 2. 「評価可能」な領域からAIを活用
- 評価可能な仕様書・提案書作成、または **運用中の既存プロジェクト** から活用開始！
- 「マイナーツールでレガシーだから」「システムを熟知してないと…」は関係なし、評価できるかどうか。
- 1日かかる難解なバグ調査も、AIなら **5分** で特定・修正・コミットまで完了。
- 新規開発プロジェクトの場合、開発を深く理解した **「AIマスター」** がいると勝率あがる。

### 💰 3. 迷ったら「Claude」
- 迷ったら **Claude** のMaxプラン。障害対策として **2つ目のAIサービス** 契約を推奨。

---

<!-- _class: closing -->

## メッセージ：AI時代を楽しむ

### 🏆 デベロッパーがトップになれる時代

天才な助手が依頼した内容を代わりにやってくれる。
**我々がトッププレイヤーになれる可能性が開かれた。**

### ⚡ 今をトップスピードで楽しむ

数年後には「誰でもできる（コモディティ化）」に変わるかもしれない。
だからこそ、**今を楽しむ** ことが大事。

---

<!-- _class: title -->

# おわり

### 🎤 質疑応答（Q&A）

**家族や知人に誇らしく仕事をしましょう！**
