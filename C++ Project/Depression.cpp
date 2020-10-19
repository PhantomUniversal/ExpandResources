#include "Depression.h"
#include "Task.h"






Depression::Depression(string name, int age, string ID_NUM, string symptom) {
	this->sex = checkSex(ID_NUM);
	this->Name = name;
	this->Age = age;
	this->ID_NUM = ID_NUM;
	this->symptom = symptom;
	gotoxy(7, 11); cout << "┏━━━━━━━━━━━━━━━┳━━━━━━━━━━━━━━━┳━━━━━━━━━━━━━━━┳━━━━━━━━━━━━━━━┓" << endl;
	gotoxy(7, 12); cout << "┃               ┃               ┃               ┃               ┃" << endl;
	gotoxy(7, 13); cout << "┣━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━┫" << endl;
	gotoxy(7, 14); cout << "┃               ┃               ┃               ┃               ┃" << endl;
	gotoxy(7, 15); cout << "┗━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━┛" << endl;
	gotoxy(14, 12); cout << "이름" << endl;
	gotoxy(13, 14); cout << this->Name << endl;
	gotoxy(30, 12); cout << "성별" << endl;
	gotoxy(30, 14); cout << this->sex << endl;
	gotoxy(46, 12); cout << "나이" << endl;
	gotoxy(47, 14); cout << this->Age << endl;
	gotoxy(62, 12); cout << "증상" << endl;
	gotoxy(61, 14); cout << this->symptom << endl;
	cout << endl;
	cout << endl;
	cout << "================================================================================" << endl;
}
void Depression::seeDr() {

	cout << this->Name << "님 반갑습니다. 우울증센터 Dr.Kim 입니다." << endl
		<< "우울증 때문에 많이 힘드시죠?" << endl
		<< "입원절차는 데스크 직원에게 받으시면 되고,"<<	endl;
	
}
void Depression::checkSymptom() {

	cout << "우울증 환자 진료실 입니다." << endl << endl;

}

void Depression::Drug() {
	cout << "약은 에스티랄로프람 1정, 플루옥세틴 2정 식후 30분에 드시면 됩니다." << endl << endl;
}

string Depression::checkSex(string sex){
	auto it = sex.find("-1");
	if (it != string::npos) {
		return "남자";
	}
	else
		return "여자";
}
