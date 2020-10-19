#pragma once
#include <combaseapi.h>
#include <iostream>
#include <string>
using namespace std;


interface Patient {
	string Name;
	int Age;
	string ID_NUM;
	string symptom;
	string sex;
	int money = 0;
	int roomNum = 0;


	virtual void seeDr() = 0;
	virtual void checkSymptom() = 0;
	virtual void Drug() = 0;


};