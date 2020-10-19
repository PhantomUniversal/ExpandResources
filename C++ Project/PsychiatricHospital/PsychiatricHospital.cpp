#include "PsychiatricHospital.h"
#include <iostream>

#include <map>

using namespace std;



void PsychiatricHospital::PatientRegistration()
{

	int k;

	cout << "이름 : " << endl;
	cin >> name;

	cout << "나이 : " << endl;
	cin >> age;

	puts("주민번호 : ");
	puts("예)999999-1111111");
	for (k = 0; k < 14; k++)
	{
		cin >> rrn[k];
	}
	rrn[14] = { };
	if (rrn[7] == '1')
		cout << "성별 : 남" << endl;
	else if (rrn[7] == '2')
		cout << "성별 : 여" << endl;
	else if (rrn[7] == '3')
		cout << "성별 : 남" << endl;
	else if (rrn[7] == '4')
		cout << "성별 : 여" << endl;
	else
		cout << "누구세여?" << endl;

	cout << "핸드폰번호 : " << endl;
	cin >> pn;

	cout << "병실 : " << endl;
	cin >> ward;

}

void PsychiatricHospital::AllPatients()
{
	
	cout << "이름 : " << this->name << endl;
	cout << "나이 : " << this->age << endl;
	cout << "주민등록번호 : " << this->rrn << endl;
	cout << "핸드폰번호 : " <<this->pn << endl;
	cout << "병실 : " << this->ward << endl;
	
	
	cout << endl << endl;
}

void PsychiatricHospital::CareerReservation()
{
	
}