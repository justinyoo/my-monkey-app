# My Monkey App 🐵

원숭이 정보 관리 콘솔 애플리케이션입니다.

## 개요

이 애플리케이션은 다양한 원숭이 종류에 대한 정보를 제공하는 .NET 기반 콘솔 프로그램입니다. 각 원숭이마다 서식지, 개체 수, 상세 정보, 그리고 재미있는 ASCII 아트가 포함되어 있습니다.

## 기능

- **전체 원숭이 리스트 보기**: 모든 원숭이 종류를 목록으로 확인
- **원숭이 이름으로 검색**: 특정 원숭이의 상세 정보 조회
- **랜덤 원숭이 보기**: 임의의 원숭이 정보를 무작위로 표시
- **원숭이 통계 보기**: 총 개수, 지역별 분포 등의 통계 정보

## 기술 사양

- **플랫폼**: .NET 8.0
- **언어**: C# (Latest version)
- **아키텍처**: 콘솔 애플리케이션
- **문서화**: XML 주석 적용

## 프로젝트 구조

```
MyMonkeyApp/
├── Models/
│   └── Monkey.cs                  # 원숭이 데이터 모델
├── Services/
│   ├── MonkeyHelper.cs           # 원숭이 데이터 관리 서비스
│   └── ConsoleUI.cs              # 콘솔 사용자 인터페이스
├── Tests/
│   └── SimpleTests.cs            # 간단한 테스트 클래스
├── Program.cs                    # 메인 프로그램 진입점
└── MyMonkeyApp.csproj           # 프로젝트 파일
```

## 사용 방법

### 1. 빌드

```bash
cd MyMonkeyApp
dotnet build
```

### 2. 실행

```bash
dotnet run
```

### 3. 테스트 실행

```bash
dotnet run test
```

## 사용 예시

### 메인 메뉴

```
🐵 =============================================
    MY MONKEY APP - 원숭이 정보 시스템
🐵 =============================================

📋 메뉴를 선택하세요:
1. 모든 원숭이 리스트 보기
2. 원숭이 이름으로 검색
3. 랜덤 원숭이 보기
4. 원숭이 총 개수 보기
5. 종료
```

### 원숭이 정보 예시

```
🐵 Proboscis Monkey
================

📍 서식지: Borneo
👥 개체 수: 7,000마리
ℹ️  정보: Known for their distinctive large nose and reddish-brown fur...

ASCII 아트:
    .-""""""-.
   /          \
  |  O      O  |
  |      <     |
  |     ___    |
   \           /
    '-.......-'
```

## 포함된 원숭이 종류

1. **Proboscis Monkey** (코주부원숭이) - 보르네오
2. **Golden Snub-nosed Monkey** (금사자코원숭이) - 중국
3. **Japanese Macaque** (일본원숭이) - 일본
4. **Mandrill** (만드릴) - 중앙아프리카
5. **Howler Monkey** (호울러원숭이) - 중남미
6. **Capuchin Monkey** (카푸친원숭이) - 중남미
7. **Spider Monkey** (거미원숭이) - 중남미
8. **Vervet Monkey** (베르베트원숭이) - 아프리카

## 개발 정보

- **개발자**: My Monkey App Team
- **라이센스**: MIT License
- **언어**: 한국어 지원 (Unicode)
- **예외 처리**: 모든 주요 기능에 예외 처리 적용

## 라이센스

이 프로젝트는 MIT 라이센스 하에 제공됩니다.