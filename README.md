# 📡 UDP 통신 예제 (WPF, .NET Framework 4.7.2)

이 프로젝트는 C# WPF 환경에서 구현한 **UDP 단방향 통신 예제**입니다.  
**서버 → 클라이언트 구조**로 설계되어 있으며, 기본에 충실하게 간단하게 작성하였습니다.

---

## 🧾 개요

- 📤 **UdpServerExample**: 사용자가 입력한 메시지를 지정된 포트(IP: `127.0.0.1`, Port: `9000`)로 전송
- 📥 **UdpClientExample**: 해당 포트에서 메시지를 수신하고 화면에 출력

각 프로젝트는 독립적으로 실행 가능하며,  
서버와 클라이언트는 동시에 실행하여 전송/수신을 확인할 수 있습니다.

---

## 📦 프로젝트 구성

| 폴더명 | 설명 |
|--------|------|
| [`UdpServerExample`](./UdpServerExample) | UDP 메시지를 전송하는 WPF 서버 예제 |
| [`UdpClientExample`](./UdpClientExample) | UDP 메시지를 수신하는 WPF 클라이언트 예제 |

---

## 🧪 실행 방법

1. Visual Studio로 이 솔루션을 엽니다.
2. `UdpClientExample` 프로젝트를 실행 → 포트 `9000`에서 수신 대기
3. `UdpServerExample` 프로젝트를 실행 → 메시지 입력 후 "전송" 버튼 클릭
4. 클라이언트가 메시지를 수신하여 UI에 표시됨

> ✅ 서버와 클라이언트는 동시에 실행되어야 합니다.

---

## 🎯 주요 기능

- `UdpClient` 클래스 활용한 메시지 전송 및 수신
- `ListBox`를 활용한 실시간 로그 출력
- `MessageBox` 대신 UI 기반 로그 처리

---

## 🔧 기술 스택

- C# / WPF (XAML)
- .NET Framework 4.7.2
- System.Net.Sockets (UdpClient)
- Visual Studio 2022

---

## 📚 프로젝트별 README

| 프로젝트 | 문서 |
|----------|------|
| 서버 | [`UdpServerExample/README.md`](./UdpServerExample/README.md) |
| 클라이언트 | [`UdpClientExample/README.md`](./UdpClientExample/README.md) |

---

## 🧑‍💻 마무리

이 예제는 네트워크 통신의 기본 개념을 직접 구현하며 학습하기 위한 실습용 프로젝트입니다.  
UDP 통신 흐름, WPF를 활용한 UI 구성, 그리고 단방향 메시지 흐름을 정리했습니다.

실제 프로젝트에선 양방향 통신, 에러 처리, 포트 설정 등 다양한 확장 요소가 존재하지만,  
이번 예제는 **기본기에 집중하며 작고 명확한 구조로 설계**하는 데 중점을 두었습니다.