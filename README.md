# MarineWorks Employee Management System

> 마린전자 입사 첫 과제 프로젝트입니다.  
> C# WinForms 기반의 사내 직원 디렉토리 관리 시스템입니다.

---

## 프로젝트 구조

```
Employee_Directory/
├── Forms/          # UI 폼 (로그인, 메인, 직원, 계정, 비밀번호 변경)
├── Models/         # 데이터 모델 (Employee, NowUser, UserRole)
├── Services/       # 비즈니스 로직 (Auth, Employee, Account)
├── Repositories/   # DB 접근 계층
├── DB/             # DB 연결 서비스
├── Helpers/        # 유틸리티 (Logger)
└── Resources/      # 이미지, 아이콘 리소스
```

---

## 주요 기능

### 로그인
- 아이디 / 비밀번호 입력 후 로그인
- 권한(Admin / User)에 따라 기능 차등 제공

### 직원 목록 조회
- 전체 직원 정보를 표 형태로 표시
- 표시 항목: 부서 / 팀·사업소 / 파트 / 직위·직책 / 이름 / 내선번호 / 휴대번호 / 이메일

### 직원 검색
- 항목(컬럼) 선택 후 키워드 검색
- Enter 키 또는 검색 버튼으로 실행

### 직원 추가 / 수정 / 삭제 (Admin 전용)
- **추가**: 직원 정보 입력 폼을 통해 신규 등록
- **수정**: 목록에서 행 더블클릭 시 수정 폼 오픈
- **삭제**: 선택한 직원 삭제 (확인 메시지 포함)

### 계정 관리 (Admin 전용)
- 사용자 계정 목록 조회
- 신규 계정 추가 (User 권한으로 생성)
- 계정 삭제 (Admin 계정은 삭제 불가)

### 내 정보 (비밀번호 변경)
- 모든 권한의 사용자가 본인 비밀번호 변경 가능

### 로그아웃
- 로그아웃 시 로그인 화면으로 복귀

---

## 기술 스택

| 항목 | 내용 |
|------|------|
| 언어 | C# |
| 프레임워크 | .NET WinForms |
| DB | SQL Server |
| 아키텍처 | 3-Layer (Form → Service → Repository) |
| 로깅 | 자체 구현 Logger (Helpers/Logger.cs) |

---

## 권한 구조

| 기능 | Admin | User |
|------|:-----:|:----:|
| 직원 목록 조회 | ✅ | ✅ |
| 직원 검색 | ✅ | ✅ |
| 직원 추가·수정·삭제 | ✅ | ❌ |
| 계정 관리 | ✅ | ❌ |
| 비밀번호 변경 (본인) | ✅ | ✅ |

---

## 개발자

**ChangJunLee** — changjun.lee@marineworks.co.kr
