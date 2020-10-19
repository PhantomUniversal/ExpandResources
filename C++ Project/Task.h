#pragma once
#include "Patient.h"
#include <iostream>

using namespace std;
class Task
{
private:
	Patient* patient = NULL;
public:
	Task(Patient* pPatient = NULL);
public:
	
};

//void title();
void gotoxy(int x, int y);
void task();
void addPatient();
void viewPatient();
void deletePatient();
void searchPatient();
void editPatient();
void checkRoom();
void clearScreen();
void assignRoom();