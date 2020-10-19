#include "Task.h"
#include "Depression.h"
#include "Insomnia.h"
#include "Patient.h"
#include "Mentalunease.h"
#include "Schizophrenia.h"
#include <iostream>
#include <map>
#include <windows.h>
#include <Conio.h>

#define WIDTH	80
#define HEIGHT	25

#define DAY_COUNT 100000
multimap<string, Patient*> patientMap;
typedef multimap<string, Patient*>::iterator patientIt;


void gotoxy(int x, int y)
{
	COORD pos = { x,y };
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);
}

void task() {



	gotoxy((WIDTH - 65) / 2, 1);
	cout << "===============================================================" << endl;
	gotoxy((WIDTH - 22) / 2, 2);
	cout << "비트 정신병원 프로그램" << endl;
	gotoxy((WIDTH - 65) / 2, 3);
	cout << "===============================================================" << endl;

	int sel;


	gotoxy((WIDTH - 36) / 2, 5); cout << "┌──────────────────────────────────┐" << endl;
	gotoxy(20, 6); cout << "  │                                  │" << endl;
	gotoxy(20, 7); cout << "  │         1. 환자 접수             │" << endl;
	gotoxy(20, 8); cout << "  │                                  │" << endl;
	gotoxy(20, 9); cout << "  │         2. 환자 모두 보기        │" << endl;
	gotoxy(20, 10); cout << "  │                                  │" << endl;
	gotoxy(20, 11); cout << "  │         3. 환자 검색             │" << endl;
	gotoxy(20, 12); cout << "  │                                  │" << endl;
	gotoxy(20, 13); cout << "  │         4. 환자 정보 수정        │" << endl;
	gotoxy(20, 14); cout << "  │                                  │" << endl;
	gotoxy(20, 15); cout << "  │         5. 환자 삭제             │" << endl;
	gotoxy(20, 16); cout << "  │                                  │" << endl;
	gotoxy(20, 17); cout << "  │         6. 환자 입실             │" << endl;
	gotoxy(20, 18); cout << "  │                                  │" << endl;
	gotoxy(20, 19); cout << "  │         7. 병동 상황 보기        │" << endl;
	gotoxy(20, 20); cout << "  │                                  │" << endl;
	gotoxy(20, 21); cout << "  │         8. 프로그램 종료         │" << endl;
	gotoxy(20, 22); cout << "  │                                  │" << endl;
	gotoxy(20, 23); cout << "  └──────────────────────────────────┘" << endl;

	gotoxy(21, 24); cout << "  <<원하시는 업무를 입력하세요>> : ";
	
	gotoxy(56, 24); cin >> sel;
	cout << endl;
	system("cls");

	switch (sel) {
	case 1:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 접수>>>>>>> " << endl << endl;
		addPatient();
		break;
	case 2:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 모두 보기 >>>>>>>> " << endl << endl;
		viewPatient();
		break;
	case 3:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 정보 검색>>>>>>>> " << endl << endl;
		searchPatient();
		break;

	case 4:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 정보 수정>>>>>>>> " << endl << endl;
		editPatient();
		break;
	case 5:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 퇴원 >>>>>>>> " << endl << endl;
		deletePatient();
		break;
	case 6:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 입원 >>>>>>> " << endl << endl;
		assignRoom();
		break;
	case 7:
		gotoxy((WIDTH - 30) / 2, 1);
		cout << " <<<<<<<환자 병동 상황 >>>>>>> " << endl << endl;
		checkRoom();
		break;
	case 8:
		exit(0);
	}
}

void addPatient() {
	int sel;
	string name;
	int age;
	string ID_NUM;
	string symptom;

	cout << "================================================================================" << endl;
	cout << endl;
	cout << "이름 (메뉴로 가기 = 0 입력) >> ";
	cin >> name;
	if (name == "0") { system("cls"); return; }
	cout << "나이 >> ";
	cin >> age;
	cout << "주민등록번호 >> ";
	cin >> ID_NUM;
	cout << "증상 >> ";
	getchar(); getline(cin, symptom);
	cout << "병명 진단 : 1. 우울증 , 2. 불면증, 3. 조현병, 4. 정서불안>> ";
	cin >> sel;
	cout << "정상 접수되었습니다." << endl << endl;
	cout << endl;

	if (sel == 1) {
		Depression* dep = new Depression(name, age, ID_NUM, symptom);
		dep->checkSymptom();
		dep->seeDr();
		dep->Drug();
		patientMap.insert(make_pair("우울증", dep));
	}
	else if (sel == 2) {
		Insomnia* insom = new Insomnia(name, age, ID_NUM, symptom);
		insom->checkSymptom();
		insom->seeDr();
		insom->Drug();
		patientMap.insert(make_pair("불면증", insom));
	}
	else if (sel == 3) {
		Schizophrenia* schiz = new Schizophrenia(name, age, ID_NUM, symptom);
		schiz->checkSymptom();
		schiz->seeDr();
		schiz->Drug();
		patientMap.insert(make_pair("조현병", schiz));
	}
	else if (sel == 4) {
		Mentalunease* mental = new Mentalunease(name, age, ID_NUM, symptom);
		mental->checkSymptom();
		mental->seeDr();
		mental->Drug();
		patientMap.insert(make_pair("정서불안", mental));
	}

	clearScreen();
}

void viewPatient() {
	multimap<string, Patient*> ::iterator Pit;
	int sel;
	cout << "1 .전체 병동 환자 보기 / 2 .병동 별로 환자 보기 입력 >>";
	cin >> sel;
	if (sel == 1) {
		for (Pit = patientMap.begin(); Pit != patientMap.end(); ++Pit) {

			Patient* patient = Pit->second;
			cout << Pit->first << "\n";

			cout << "이름 : " << patient->Name << endl;
			cout << "나이 : " << patient->Age << endl;
			cout << "성별 : " << patient->sex << endl;
			cout << "비용 : " << patient->money << endl;
			cout << "증상 : " << patient->symptom << endl;
			cout << "호실 : " << patient->roomNum << endl;
			cout << "---------------------------------" << endl;

		}
		cout << endl;
		clearScreen();
	}if (sel == 2) {
	FIRST:
		string ill;
		cout << "검색할 병동을 입력하세요(메뉴로 가기 = 0 입력) >>";

		cin >> ill;
		cout << endl << endl;
		if (ill == "0") { system("cls"); return; }
		pair<patientIt, patientIt> result = patientMap.equal_range(ill);

		if (result.first == result.second) {
			cout << "그런 병동은 없습니다, 다시 입력해 주세요." << endl;
			goto FIRST;
		}
		else {
			
			for (Pit = patientMap.begin(); Pit != patientMap.end(); ++Pit) {
				if (Pit->first == ill) {
					Patient* patient = Pit->second;
					cout << Pit->first << "\n";

					cout << "이름 : " << patient->Name << endl;
					cout << "나이 : " << patient->Age << endl;
					cout << "성별 : " << patient->sex << endl;
					cout << "비용 : " << patient->money << endl;
					cout << "증상 : " << patient->symptom << endl;
					cout << "호실 : " << patient->roomNum << endl;
					cout << "---------------------------------" << endl;
				}
			}
			cout << endl;
			clearScreen();
		}
		
		
	}
}

void deletePatient() {
FIRST:
	string ill;
	cout << "삭제할 환자의 병명을 입력하세요(메뉴로 가기 = 0 입력) >>";

	cin >> ill;
	if (ill == "0") { system("cls"); return; }
	pair<patientIt, patientIt> result = patientMap.equal_range(ill);

	if (result.first == result.second) {
		cout << "그런 병명은 없습니다, 다시 입력해 주세요." << endl;
		goto FIRST;
	}
	else {
		string name;
		cout << "삭제할 환자의 이름을 입력하세요 >>";
		cin >> name;
		cout << endl;
		for (patientIt it = result.first; it != result.second; it++) {

			if (it->second->Name == name) {
				cout << name << "님의 정보를 삭제했습니다." << endl << endl;
				patientMap.erase(it);
				break;
			}
		}
	}
	clearScreen();
}

void searchPatient() {
FIRST:
	string ill;
	cout << "찾으실 환자의 병명을 입력하세요 (메뉴로 가기 = 0 입력) >>";

	cin >> ill;
	if (ill == "0") { system("cls"); return; }                       //multimap<string, Patient*>::iterator
	pair<patientIt, patientIt> result = patientMap.equal_range(ill); //반복자 한 쌍 시작과 끝을 가리킴
	//key 값에 해당하는 원소의 범위를 pair 객체로 반환
	//pair 객체의 first는 key 값에 해당하는 원소의 첫번째 반복자
	//pair 객체의 second는 key 값에 해당하는 원소의 마지막 원소의 "다음" 반복자 반환 

	if (result.first == result.second) { // first~second(마지막 다음요소) 까지 찾는 중 (같아지면 없다는것)	
		cout << "그런 병명은 없습니다, 다시 입력해 주세요." << endl;
		goto FIRST;
	}
	else {
		string name;
		cout << "찾으실 환자의 이름을 입력하세요 >>";
		cin >> name;
		cout << endl;
		for (patientIt it = result.first; it != result.second; it++) {
			//multimap<string, Patient*>::iterator it = result.first;

			if (it->second->Name == name) {//it 의 발류값인 Patient 객체의 멤버변수 Name == name 이 되면
				Patient* patient = it->second;
				cout << it->first << "\n";
				cout << "이름 : " << patient->Name << endl;
				cout << "나이 : " << patient->Age << endl;
				cout << "성별 : " << patient->sex << endl;
				cout << "비용 : " << patient->money << endl;
				cout << "증상 : " << patient->symptom << endl << "---------------------------------" << endl;
				break;
			}
		}
	}
	clearScreen();
}
void editPatient() {
	int sel;
	string name;
	int age;
	string ID_NUM;
	string symptom;
	int money;
FIRST:
	string ill;
	cout << "찾으실 환자의 병명을 입력하세요 (메뉴로 가기 = 0 입력) >>";

	cin >> ill;
	if (ill == "0") { system("cls"); return; }
	pair<patientIt, patientIt> result = patientMap.equal_range(ill);

	if (result.first == result.second) {
		cout << "그런 병명은 없습니다, 다시 입력해 주세요." << endl;
		goto FIRST;
	}
	else {
		string name;
		cout << "찾으실 환자의 이름을 입력하세요 >>";
		cin >> name;
		cout << endl;
		for (patientIt it = result.first; it != result.second; it++) {

			if (it->second->Name == name) {
				Patient* patient = it->second;
				cout << it->first << "\n";

				cout << "이름 : " << patient->Name << endl;
				cout << "나이 : " << patient->Age << endl;
				cout << "성별 : " << patient->sex << endl;
				cout << "비용 : " << patient->money << endl;
				cout << "증상 : " << patient->symptom << endl << "---------------------------------" << endl;

				cout << " << 수정할 정보를 입력하세요 >>" << endl;;
				cout << "이름 >> ";
				cin >> name;
				cout << "나이 >>";
				cin >> age;
				cout << "비용 >>";
				cin >> money;
				patient->Name = name;
				patient->Age = age;
				patient->money = money;
				cout << endl << endl;
				cout << "수정 완료 되었습니다." << endl << endl;
				break;
			}
		}
	}
	clearScreen();
}

void checkRoom() {
	int room;
	string name;
	int day;

FIRST:
	string ill;
	cout << "찾으실 환자의 병동을 입력하세요 (메뉴로 가기 = 0 입력) >>";

	cin >> ill;
	if (ill == "0") { system("cls"); return; }
	pair<patientIt, patientIt> result = patientMap.equal_range(ill);

	if (result.first == result.second) {
		cout << "그런 병동은 없습니다, 다시 입력해 주세요." << endl;
		goto FIRST;
	}	
	else {
		gotoxy(5, 5); cout << "┏━━━━━━━━━┓━━━━━━━━━━━━━━━━━┓" << endl;
		gotoxy(5, 6); cout << "┃ ┏━━━━━┓ ┃                 ┃" << endl;
		gotoxy(5, 7); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(5, 8); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(5, 9); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(5, 10); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(5, 11); cout << "┃ ┗━━━━━┛ ┃                 ┃" << endl;
		gotoxy(5, 12); cout << "┗━━━━━━━━━┛━━━━━━━━━━━━━━━━━┛" << endl;


		gotoxy(38, 5); cout << "┏━━━━━━━━━┓━━━━━━━━━━━━━━━━━┓" << endl;
		gotoxy(38, 6); cout << "┃ ┏━━━━━┓ ┃                 ┃" << endl;
		gotoxy(38, 7); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(38, 8); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(38, 9); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(38, 10); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(38, 11); cout << "┃ ┗━━━━━┛ ┃                 ┃" << endl;
		gotoxy(38, 12); cout << "┗━━━━━━━━━┛━━━━━━━━━━━━━━━━━┛" << endl;

		gotoxy(5, 21); cout << "┏━━━━━━━━━┓━━━━━━━━━━━━━━━━━┓" << endl;
		gotoxy(5, 22); cout << "┃ ┏━━━━━┓ ┃                 ┃" << endl;
		gotoxy(5, 23); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(5, 24); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(5, 25); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(5, 26); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(5, 27); cout << "┃ ┗━━━━━┛ ┃                 ┃" << endl;
		gotoxy(5, 28); cout << "┗━━━━━━━━━┛━━━━━━━━━━━━━━━━━┛" << endl;

		gotoxy(38, 21); cout << "┏━━━━━━━━━┓━━━━━━━━━━━━━━━━━┓" << endl;
		gotoxy(38, 22); cout << "┃ ┏━━━━━┓ ┃                 ┃" << endl;
		gotoxy(38, 23); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(38, 24); cout << "┃ ┃━━━━━┃ ┃                 ┃" << endl;
		gotoxy(38, 25); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(38, 26); cout << "┃ ┃     ┃ ┃                 ┃" << endl;
		gotoxy(38, 27); cout << "┃ ┗━━━━━┛ ┃                 ┃" << endl;
		gotoxy(38, 28); cout << "┗━━━━━━━━━┛━━━━━━━━━━━━━━━━━┛" << endl;
		
		for (patientIt it = result.first; it != result.second; it++) {
			Patient* patient = it->second;

				if (it->second->roomNum == 101 || it->second->roomNum == 201 ||
					it->second->roomNum == 301 || it->second->roomNum == 401) {
					gotoxy(17, 7); cout << "이름 : " << patient->Name << endl;
					gotoxy(17, 8); cout << "나이 : " << patient->Age <<"세" << endl;
					gotoxy(17, 9); cout << "성별 : " << patient->sex << endl;
					gotoxy(17, 10); cout << "호실 : " << patient->roomNum <<"호"<< endl;
					gotoxy(17, 11); cout << "증상 : " << patient->symptom << endl;
					
				}
				else if (it->second->roomNum == 102 || it->second->roomNum == 202 ||
					it->second->roomNum == 302 || it->second->roomNum == 402) {
					gotoxy(49, 7); cout << "이름 : " << patient->Name << endl;
					gotoxy(49, 8); cout << "나이 : " << patient->Age <<"세"<< endl;
					gotoxy(49, 9); cout << "성별 : " << patient->sex << endl;
					gotoxy(49, 10); cout << "호실 : " << patient->roomNum <<"호" << endl;
					gotoxy(49, 11); cout << "증상 : " << patient->symptom << endl;
					
				}
				else if (it->second->roomNum == 103 || it->second->roomNum == 203 ||
					it->second->roomNum == 303 || it->second->roomNum == 403) {
					gotoxy(17, 23); cout << "이름 : " << patient->Name << endl;
					gotoxy(17, 24); cout << "나이 : " << patient->Age <<"세"<< endl;
					gotoxy(17, 25); cout << "성별 : " << patient->sex << endl;
					gotoxy(17, 26); cout << "호실 : " << patient->roomNum <<"호"<< endl;
					gotoxy(17, 27); cout << "증상 : " << patient->symptom << endl;
					
				}
				else if (it->second->roomNum == 104 || it->second->roomNum == 204 ||
					it->second->roomNum == 304 || it->second->roomNum == 404) {
					gotoxy(49, 23); cout << "이름 : " << patient->Name << endl;
					gotoxy(49, 24); cout << "나이 : " << patient->Age <<"세"<< endl;
					gotoxy(49, 25); cout << "성별 : " << patient->sex << endl;
					gotoxy(49, 26); cout << "호실 : " << patient->roomNum <<"호" << endl;
					gotoxy(49, 27); cout << "증상 : " << patient->symptom << endl;
				
				}
			
		}

		clearScreen();
	}
}

void assignRoom() {
	int room;
	string name;
	int day;

FIRST:
	string ill;
	cout << "찾으실 환자의 병동을 입력하세요, (메뉴로 가기 = 0 입력) >>";

	cin >> ill;
	pair<patientIt, patientIt> result = patientMap.equal_range(ill);
	if (ill == "0") { system("cls"); return; }
	if (result.first == result.second) {
		cout << "그런 병동은 없습니다, 다시 입력해 주세요." << endl;
		goto FIRST;
	}
	else {
		cout << "입원하실 환자의 이름을 입력하세요 >>";
		cin >> name;
		cout << endl;

		for (patientIt it = result.first; it != result.second; it++) {

			if (it->second->Name == name) {

				Patient* patient = it->second;
			REEDIT:
				cout << it->second->Name << "님 입원할 호실을 입력해 주세요 >>" << "\n";
				cin >> room;
				for (patientIt it = result.first; it != result.second; it++) {

					if (it->second->roomNum != room) {
						cout << name << "님 얼마나 입원하십니까? >> " << endl;
						cin >> day;
						patient->roomNum = room;
						patient->money = day * DAY_COUNT;
						cout << "비용 = " << patient->money << "납부 부탁 드립니다." << endl << endl;

						cout << patient->roomNum << "호\n" << patient->Name <<" 님"
							<< endl << patient->Age <<  "세" << endl << "증상 : "<< patient->symptom << endl;
						cout << "입실 완료 되었습니다." << endl << endl;
						break;
					}
					else {
						cout << room << "호는 다른 환자가 사용중입니다 다시 입력 부탁드립니다>> " << endl;
						goto REEDIT;
					}
				}
			}
		}
		clearScreen();
	}

}
void clearScreen() {
	getchar();
	getchar();
	system("cls");
}


