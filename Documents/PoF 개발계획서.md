PoF 개발계획서
=============

Club GG Team KAN
----------------
## 구성원
- DSM2016 나성식
- DSM2017 안병관
- DSM2018 김동휘

# 개요
- 2D 플랫포머 액션 RPG.
- Hallow Knight에서 아이디어 착안.
- 스토리의 참신함으로 시장성 확보.
- 좀비 고양이가 사람을 공격하는 컨셉.

# 요구분석

## 기능적 요구
- 플레이어블 캐릭터를 상하좌우로 이동할 수 있고, 점프 할 수 있다.
- 플레이어블 캐릭터는 공격할 수 있으며, 공격이 적에게 적중할 경우 적의 HP가 일정량 소모된다.
- 적의 HP가 일정량 이하일 때, 플레이어가 특수 커맨드를 사용하면 그 적을 좀비화한다.
- 좀비화된 적은 플레이어블 캐릭터를 따라다니다가 적을 만날 경우 다가가 자폭한다.
- 보스는 좀비화시킬 수 없다.
- 게임은 여러 챕터로 구성되어 있으며, 각 챕터에 있는 최종보스를 클리어하면 챕터를 넘어간다.
- 플레이어블 캐릭터가 적에게 닿거나 공격받을 경우, 플레이어의 HP가 일정량 감소한다.
- 플레이어블 캐릭터의 HP가 0이 될 경우, 게임 오버된다.
- 게임 오버될 경우 게임 오버된 챕터의 처음부터 재시작할 수 있다.
- 게임을 종료할 때 진척 상황이 저장되고, 이는 게임을 시작할 때 저장된 진척 상황부터 시작할 수 있게 한다.

## 비기능적 요구
- 게임패드를 사용하기 좋은 입력을 사용한다.
- 60FPS를 목표로 한다.
- 게임 내부의 언어는 영어로 한다.
- 스팀을 통해 퍼블리싱한다.

## 특징 및 장단점, 전제 조건
- 특징: 독특한 스토리라인
- 장점: 화려한 액션과 타격감, 캐릭터 디자인
- 단점: 개발 시간 부족
- 전제 조건: 학업에 지장이 가지 않는 한도 내에서 하루 1시간 이상 개발

# 개발 툴 및 사용자 실행 환경

## 개발 툴
Unity 2017

## 사용자 실행 환경
DirectX 11 지원 PC(게임패드 권장)

# 개발 내용

## 프로젝트 범위
- 플레이어블 캐릭터 이동 & 공격 & 피격
- 적 캐릭터 이동 & 공격 & 피격
- 적 좀비화
- 레벨 디자인
- 챕터 이동
- 게임 Save & Load

## 기능 설명
Unity 내부 기능으로 모두 구현 가능

# 프로토타이핑 모델
- 시스템의 일부 혹은 시스템의 모형이 될 만한 것을 만들고, 피드백을 받아 반복하는 모델
- 게임 개발에 가장 많이 사용하는 개발 모델
- 프로토타입을 보고 개발 기간을 단축해버리는 성향이 단점
- 프로토타입에 만족하지 않고 꾸준히 개선하는 작업이 필요

# 역할 분담

## 나성식
* 플레이어 이동, 콤보 공격, 피격, 게임 오버
* 보스전 로직
* 튜토리얼 제작

## 안병관
* 아트
* 오프닝, 엔딩 동영상
* 적 이동, 콤보 공격, 피격, 좀비화
* 오디오 긁어오기

## 김동휘
* 기획
* 레벨 디자인
* 씬 이동
* 플레이어 hp, 적 hp
* Save & Load