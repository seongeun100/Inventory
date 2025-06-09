# 📦 Inventory (Unity)

Uinity 기반의 인벤토리 구현 예제입니다.


## ✅ 주요 기능

- 인벤토리 슬롯 UI (아이템 표시 + 장착 표시)
- 클릭 기반 장착/해제 기능 (장착하면 UI 표시 자동 업데이트)
- 장비 스탯 자동 계산 (장비 효과 합산)
- 텍스트, 아이콘 등 UI 요소를 사용한 실시간 연동


## 📁 프로젝트 구조

- `Scenes/`: 메인 씬
- `Scripts/Art`: 아이콘, 배경, 캐릭터 이미지 등
- `Scripts/Resources`: CharacterData, ItemData 등 데이터
- `Scripts/Manager`: GameManager, UIManager 등 매니저 클래스
- `Scripts/UI`: UIInventory, UIMainMenu 등 UI 클래스
- `Prefabs/`: UI 프리팹


## ▶️ 실행 방법
1. Unity 2022.3 LTS 이상 버전으로 프로젝트 열기
2. MainScene 실행하면 게임이 시작됩니다

## 🛠 사용한 기술 및 패키지
- Unity 2D URP
- TextMeshPro
- ScriptableObject
