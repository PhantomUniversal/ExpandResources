#pragma once
#include "Patient.h"
class Schizophrenia :
    public Patient
{
public:
	Schizophrenia(string name, int age, string ID_NUM, string symptom);
public:
	virtual void checkSymptom();
	virtual void Drug();
	string checkSex(string sex);
	virtual void seeDr();
};