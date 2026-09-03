
#include <iostream>
#include <Windows.h>
#include "MainGame.h"


/*

Zasady do wprowadzenia:
KISS - trzymaj prostote debilu - se uprosc kod
SOLID - S - pojedyncza odpowiedzialnosc - utworz funkcje odpowiadajace za jakis kod


*/
int main()
{
	::SendMessage(::GetConsoleWindow(), WM_SYSKEYDOWN, VK_RETURN, 0x20000000);
	setlocale(LC_CTYPE, "polish");
	mainGame();
}

/*
* Zrobiæ poziomy trudnoœci.
* Zrobilem ale dokonczyc trzeba - secret difficulty, ¿ycia Tung Tunga zmienic na 1, itp.
*/

void mainGame()
{

	const int LOWER_RANGE = 1;
	int UPPER_RANGE = 100;
	char difficulty = 0;
	std::cout << "------------------------------------------\n";
	std::cout << "Podaj poziom trudnoœci:\n";
	std::cout << "£atwy: 1  (1 - 100)\n";
	std::cout << "Œredni: 2  (1 - 250)\n";
	std::cout << "Trudny: 3  (1 - 500)\n";
	std::cout << "------------------------------------------\n";
	std::cin >> difficulty;
	switch (difficulty)
	{
	case '1':
		UPPER_RANGE = 100;
		break;
	case '2':
		UPPER_RANGE = 250;
		break;
	case '3':
		UPPER_RANGE = 500;
		break;
	case 'T':
		UPPER_RANGE = 3;
		break;
	default:
		UPPER_RANGE = 12000000;
		break;
	}

	system("cls");

	srand(time(NULL));
	int randomNumber = rand() % (UPPER_RANGE - LOWER_RANGE + 1) + LOWER_RANGE;
	int numberFromUser;
	int yourAttempts = 0;
	const int maxLives = 10;
	int numbersUsed[maxLives + 1];
	std::string whatValue[maxLives + 1];
	int currentLives = maxLives;
	std::string moreOrLess;

	for (int i = 1; i < maxLives + 1; i++)
	{
		numbersUsed[i] = 0;
		whatValue[i] = " ";
	}

	do
	{
		if (currentLives < 1)
		{
			std::cout << "------------------------------------------\n";
			std::cout << "Przegra³eœ. Twoje próby: " << yourAttempts << "\n";
			std::cout << "Numer do odgadniêcia: " << randomNumber << "\n";
			std::cout << "------------------------------------------\n";
			break;
		}

		std::cout << "Podaj liczbe: \n";
		std::cin >> numberFromUser;

		if (numberFromUser > UPPER_RANGE || numberFromUser < LOWER_RANGE)
			break;

		std::cin.ignore(255, '\n');
		yourAttempts++;

		if (numberFromUser < randomNumber)
		{
			moreOrLess = "W";
		}
		if (numberFromUser > randomNumber)
		{
			moreOrLess = "M";
		}

		system("cls");

		std::cout << "Wpisane liczby: \n";

		for (int i = 1; i < maxLives + 1; i++)
		{
			std::cout << numbersUsed[i] << whatValue[i] << ", ";

			numbersUsed[currentLives] = numberFromUser;
			whatValue[currentLives] = moreOrLess;
		}

		std::cout << "\n------------------------------------------\n";

		if (numberFromUser > randomNumber)
		{
			currentLives--;
			std::cout << "\nTwoje ¯ycia: " << currentLives << "\n";
			std::cout << "Mniej.\n";
			continue;
		}
		else
		{
			currentLives--;
			std::cout << "Twoje ¯ycia: " << currentLives << "\n";
			std::cout << "Wiecej.\n";
			continue;
		}

		std::cout << "------------------------------------------\n";

	} while (numberFromUser != randomNumber);

	system("cls");

	if (currentLives < 1)
	{
		std::cout << "------------------------------------------\n";
		std::cout << "Przegra³eœ!!! IdŸ sie powieœ bez drzewa >:(\n";
		std::cout << "Numer do odgadniêcia: " << randomNumber << "\n";
		std::cout << "------------------------------------------\n";
	}
	else
	{
		if (numberFromUser > UPPER_RANGE || numberFromUser < LOWER_RANGE)
		{
			std::cout << "------------------------------------------\n";
			std::cout << "Podales/as liczbê z poza zakresu trudnoœci!\n";
			std::cout << "Zrzuæ siê ze schodów, Pozdrawiam <3\n";
			std::cout << "------------------------------------------\n";
		}
		else
		{
			std::cout << "------------------------------------------\n";
			std::cout << "Wygra³eœ!!! Twoje ¯ycia: " << currentLives << "\n";
			std::cout << "Numer do odgadniêcia: " << randomNumber << "\n";
			std::cout << "------------------------------------------\n";
		}
	}
}
