/*
mentalunease 정서불안
depression 우울증
insomnia 불면증
schizophrenia 정신분열
*/

#pragma once
#include <iostream>
#include <string>

using namespace std;


class PsychiatricHospital
{

protected:
	string name; // 이름
	int age; // 나이
	char rrn[14];
	int nrr; //주민등록번호 : resident registration number
	string symptom; // 증상
	string pn; // 폰넘버v
	int ward; // 병실


public:
	void PatientRegistration(); // 환자등록
	//void PatientSearch(); // 환자검색
	void AllPatients(); // 환자전체보기
	//void PatientSearch(); // 환자검색
	void CareerReservation(); // 진로예약
	//void ChargeStorage(); // 요금수납
	//void CheckSickroom(); // 병실확인

};


