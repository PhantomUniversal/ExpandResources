#include "Patient.h"
#include "Depression.h"
#include "Insomnia.h"
#include "Mentalunease.h"
#include "Task.h"
#include "Schizophrenia.h"
#include <iostream>
#include <string>
#include <map>
#include <windows.h>
#include <Conio.h>
#include <windows.h>
#include <mmsystem.h>
#pragma comment(lib,"winmm.lib")


using namespace std;


void main() {
	PlaySound(TEXT("a.wav"), NULL, SND_ASYNC | SND_LOOP);


	system("mode CON COLS=80 LINES=30");
	system("color 3f");
	string id;
	string pw;
	string id2 = "bitcamp";
	string pw2 = "0000";


	gotoxy(5, 3); cout << "┌─────────────────────────────────────────────────────────────────┐ " << endl;
	gotoxy(5, 4); cout << "│                                                                 │ " << endl;
	gotoxy(5, 5); cout << "│                              ┏━━━━┓                             │ " << endl;
	gotoxy(5, 6); cout << "│                              ┃    ┃                             │ " << endl;
	gotoxy(5, 7); cout << "│                          ┏━━━┛    ┗━━━┓                         │ " << endl;
	gotoxy(5, 8); cout << "│                          ┃            ┃                         │ " << endl;
	gotoxy(5, 9); cout << "│                          ┗━━━┓    ┏━━━┛                         │ " << endl;
	gotoxy(5, 10); cout << "│                              ┃    ┃                             │ " << endl;
	gotoxy(5, 11); cout << "│                              ┗━━━━┛                             │ " << endl;
	gotoxy(5, 12); cout << "│                                                                 │ " << endl;
	gotoxy(5, 13); cout << "│                                                                 │ " << endl;
	gotoxy(5, 14); cout << "│                                                                 │ " << endl;
	gotoxy(5, 15); cout << "│                                                                 │ " << endl;
	gotoxy(5, 16); cout << "│                                                                 │ " << endl;
	gotoxy(5, 17); cout << "│                       ┌──────────────────┐                      │" << endl;
	gotoxy(5, 18); cout << "│             Username: │                  │                      │" << endl;
	gotoxy(5, 19); cout << "│                       └──────────────────┘                      │" << endl;
	gotoxy(5, 20); cout << "│                       ┌──────────────────┐                      │" << endl;
	gotoxy(5, 21); cout << "│             Password: │                  │                      │" << endl;
	gotoxy(5, 22); cout << "│                       └──────────────────┘                      │" << endl;
	gotoxy(5, 23); cout << "│                                                                 │ " << endl;
	gotoxy(5, 24); cout << "└─────────────────────────────────────────────────────────────────┘ " << endl;

login:
	gotoxy(32, 18); cin >> id;
	gotoxy(32, 21); cin >> pw;

	if (id != id2 || pw != pw2) {

		gotoxy(30, 16); cout << "아이디 비밀번호 오류";
		gotoxy(32, 18); cout << "             ";
		gotoxy(32, 21); cout << "             ";
		goto login;
	}
	else {
		system("cls");
		while (1) {
		Task:task();
		}
		cout << endl; cout << endl; cout << endl; cout << endl;
		system("cls");
	}

}

