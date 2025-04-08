# 🚀 UdpServerExample (UDP 메시지 전송 서버)

이 프로젝트는 WPF 기반의 UDP 서버 예제입니다.  
사용자가 입력한 메시지를 지정된 클라이언트로 전송합니다.

---

## 🧭 주요 기능

- TextBox로 메시지 입력
- "전송" 버튼 클릭 시 UdpClient를 통해 메시지 전송
- 로그는 ListBox에 실시간 출력
- 수신 대상은 127.0.0.1:9000 으로 하드코딩됨 (UdpClientExample와 연동)

---

## 💻 UI 구성

- **TextBox**: 전송할 메시지 입력
- **Button ("전송")**: 메시지를 즉시 클라이언트로 전송
- **ListBox**: 보낸 메시지 및 에러 로그 표시

---

## 📦 개발 환경

- C# (.NET Framework 4.7.2)
- WPF (XAML)
- `System.Net.Sockets` (UdpClient)

---

## 🔗 연동 대상

이 프로젝트는 다음 클라이언트와 함께 동작하도록 설계되었습니다:

🔹 [UdpBasicReceiver](../UdpClientExample)  
UDP 9000번 포트를 통해 서버로부터 메시지를 수신합니다.

---

## 🧪 사용 방법

1. Visual Studio에서 UdpServerExample 프로젝트 실행
2. 텍스트 입력 후 "전송" 버튼 클릭
3. 클라이언트가 실행 중이라면 메시지를 실시간으로 수신함

---
