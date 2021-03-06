// Blocking.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

const int gridSize = 11;
enum cell { black = 'B', red = 'R', blank = '0' };

void block(char gameGrid[][gridSize], char opponentColor, char playerColor);

int main(int argc, char* args[])
{
	ifstream fin;
	string file = "output.txt";
	//cout << "Enter an input file." << endl;
	//cin >> file;
	string temp;

	fin.open(file);
	if (fin.fail()) {
		cerr << "Could not open file.";
		exit(1);
	}

	char gameGrid[gridSize][gridSize];
	char playerColor;

	getline(fin, temp);
	playerColor = temp.at(0);
	//cout << temp << endl;

	//Read gameGrid and player color from input file
	for (int i = 0; i < gridSize; i++) {

		for (int j = 0; j < gridSize; j++) {
			int n;
			n = ((i)*gridSize) + (j + 1);
			gameGrid[i][j] = temp.at(n);
			//cout << gameGrid[i][j] << " ";
		}
		//cout << endl;
	}

	fin.close();

	char opponentColor;
	if (playerColor == black)
		opponentColor = red;
	else
		opponentColor = black;

	block(gameGrid, opponentColor, playerColor);

	//cin.get();
	return 0;
}

void block(char gameGrid[][gridSize], char opponentColor, char playerColor) {
	//find the longest horizontal row of chips the opponent has.
	int longestHoriz = 0;
	int horizRow = 0;
	int horizCol = 0;

	//find the longest vertical column of chips the opponent has.
	int longestVert = 0;
	int vertRow = 0;
	int vertCol = 0;
	//find the longest diagonal of chips the opponent has.
	int longestUpperDiag = 0;
	int upperDiagRow = 0;
	int upperDiagCol = 0;

	int longestLowerDiag = 0;
	int lowerDiagRow = 0;
	int lowerDiagCol = 0;


	for (int i = 0; i < gridSize; i++) {
		for (int j = 0; j < gridSize; j++) {
			if (gameGrid[i][j] == blank) {
				int k = j + 1;
				int h = 0;
				//Check horizontal right
				while (k < gridSize && gameGrid[i][k] == opponentColor) {
					h++;
					k++;
				}

				k = j - 1;
				//Check horizontal left
				while (k > -1 && gameGrid[i][k] == opponentColor) {
					h++;
					k--;
				}

				if (h > longestHoriz) {
					longestHoriz = h;
					horizRow = i;
					horizCol = j;
				}

				h = 0;
				k = i + 1;
				//Check vertical down
				while (k < gridSize && gameGrid[k][j] == opponentColor) {
					h++;
					k++;
				}

				k = i - 1;
				//Check vertical up
				while (k > -1 && gameGrid[k][j] == opponentColor) {
					h++;
					k--;
				}

				if (h > longestVert) {
					longestVert = h;
					vertRow = i;
					vertCol = j;
				}

				h = 0;
				k = i + 1;
				int l = j + 1;
				//Check down-right diagonal
				while (k < gridSize && l < gridSize && gameGrid[k][l] == opponentColor) {
					h++;
					k++;
					l++;
				}

				k = i - 1;
				l = j + 1;
				//Check up-right diagonal
				while (k > -1 && l < gridSize && gameGrid[k][l] == opponentColor) {
					h++;
					k--;
					l++;
				}

				if (h > longestUpperDiag) {
					longestUpperDiag = h;
					upperDiagRow = i;
					upperDiagCol = j;
				}

				h = 0;
				k = i + 1;
				l = j - 1;
				//Check down-left diagonal
				while (k < gridSize && l > -1 && gameGrid[k][l] == opponentColor) {
					h++;
					k++;
					l--;
				}

				k = i - 1;
				l = j - 1;
				//Check up-left diagonal
				while (k > -1 && l > -1 && gameGrid[k][l] == opponentColor) {
					h++;
					k--;
					l--;
				}

				if (h > longestLowerDiag) {
					longestLowerDiag = h;
					lowerDiagRow = i;
					lowerDiagCol = j;
				}
			}
		}
	}

	int row, column;

	if (longestHoriz > longestVert && longestHoriz > longestUpperDiag && longestHoriz > longestLowerDiag) {
		row = horizRow;
		column = horizCol;
	}
	else if (longestVert > longestHoriz && longestVert > longestUpperDiag && longestVert > longestLowerDiag) {
		row = vertRow;
		column = vertCol;
	}else if (longestUpperDiag > longestHoriz && longestUpperDiag > longestVert && longestUpperDiag > longestLowerDiag) {
		row = upperDiagRow;
		column = upperDiagCol;
	}
	else {
		row = lowerDiagRow;
		column = lowerDiagCol;
	}

	gameGrid[row][column] = playerColor;

	//Print to output file
	ofstream fout;
	string file = "result.txt";
	fout.open(file, ios::trunc);
	string temp;
	for (int i = 0; i < gridSize; i++) {
		for (int j = 0; j < gridSize; j++) {
			//cout << gameGrid[i][j] << " ";
			temp += gameGrid[i][j];
		}
		fout << temp;
		temp = "";
		//cout << endl;
	}
	fout.close();
}