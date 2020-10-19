#include "Schizophrenia.h"
#include "Task.h"


Schizophrenia::Schizophrenia(string name, int age, string ID_NUM, string symptom) {
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
void Schizophrenia::seeDr() {
	cout << this->Name << "님 반갑습니다. 조현병센터 Dr.Jason 입니다." << endl
		<< "조현병 때문에 많이 힘드시죠?" << endl << "입원절차는 데스크 직원에게 받으시면 되고," << endl;
	
}
void Schizophrenia::checkSymptom() {
	cout << "조현병 환자 진료실 입니다." << endl << endl;

}

void Schizophrenia::Drug() {
	cout << "약은 쿠에타핀 1정, 뉴프람 2정 식후 30분에 드시면 됩니다." << endl << endl;
}

string Schizophrenia::checkSex(string sex) {
	auto it = sex.find("-1");
	if (it != string::npos) {
		return "남자";
	}
	else
		return "여자";
}