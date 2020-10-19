#pragma once
#include "Patient.h"
class Insomnia : public Patient
{
public:
	Insomnia(string name, int age, string ID_NUM, string symptom);
public:
	virtual void checkSymptom();
	virtual void Drug();
	string checkSex(string sex);
	virtual void seeDr();
};
