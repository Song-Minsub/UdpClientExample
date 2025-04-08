# 🛰️ UDP 수신기 (기본 예제)

WPF 환경에서 작성된 간단한 UDP 메시지 수신 예제입니다.  
UdpClient와 Task를 이용하여 비동기적으로 데이터를 수신하고,  
ListBox에 수신 메시지를 출력합니다.

---
## 🔄 업데이트 내역

- UDP 수신 로직을 async/await → Thread 기반으로 개선
- UI 업데이트는 Dispatcher.Invoke 사용
- 종료 시 안전하게 스레드 종료 (`Thread.Join`)

---

## ✅ 주요 기능

- 🛠️ UdpClient.ReceiveAsync() 기반 비동기 수신
- 🚀 Task.Run()으로 백그라운드 스레드 실행
- 🖥️ Dispatcher.Invoke()를 통한 UI 안전 갱신
- 📥 수신 메시지를 실시간 로그로 출력

---

## 🧰 개발 환경

- 💻 C#
- 🏗️ .NET Framework (예: 4.7.2)
- 🖼️ WPF (XAML)

---

## ▶️ 실행 방법

1. Visual Studio에서 새 프로젝트 열기
2. ▶️ "수신 시작" 버튼 클릭
3. 다른 프로그램에서 UDP 메시지를 127.0.0.1:9000 으로 전송
