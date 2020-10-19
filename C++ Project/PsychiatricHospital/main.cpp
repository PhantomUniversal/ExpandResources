#include <iostream>
#include <string>
#include <conio.h>
#include "PsychiatricHospital.h"


using namespace std;


char Menu()
{
	cout << "1.환자등록" << endl;
	cout << "2.요금수납" << endl;
	cout << "3.환자전체보기" << endl;
	cout << "4.환자검색" << endl;
	cout << "5.진료예약" << endl;
	cout << "6.요금수납" << endl;
	cout << "7.병실확인" << endl;
	cout << "0.프로그램종료" << endl;
	return _getch();
}


void main()
{
	bool choice = true;
	PsychiatricHospital Pr;
	while (choice)
	{
		switch (Menu())
		{
		case '1':
			Pr.PatientRegistration();
			break;
		case '2':
			break;
		case '3':
			Pr.AllPatients();
			break;
		case '4':
			break;
		case '5':
			break;
		case '6':
			break;
		case '7':
			break;
		case '0':
			choice = false;
			break;
		}
	}
}
