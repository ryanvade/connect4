// Connect4_DFS.cpp : Defines the entry point for the console application.
//
//need .exe to be in bin with .cs file
#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int nodecount = 0;
const int maxturn = 1;
const int minturn = -1;
const int maxsucc = 17;
const int VS = -1000000;
const int VL = 1000000;

struct node
{
	char boardState[maxsucc][maxsucc];
	char color;
};

typedef int stateType;


enum cell { black = 'B', red = 'R', blank = '0' };

stateType best = NULL;

int alphabeta(stateType state, stateType h, int maxDepth, int curDepth, int alpha, int beta, char playerColor, char opponentColor, char boardState[][maxsucc]);
bool isterminal(char playerColor, char boardState[][maxsucc]);
void swap(int &a, int &b);
int potentialMoves(char boardState[][maxsucc]);
void expand(stateType state, stateType successor[], stateType hValues[], node nextState[], int &sn, int turn, char color, char boardState[][maxsucc]);
int max(int a, int b);
int min(int a, int b);
int eval(stateType s);
int checkHorizontal(char color, char boardState[][maxsucc], int row, int col);
int checkVertical(char color, char boardState[][maxsucc], int row, int col);
int checkDiagonal(char color, char boardState[][maxsucc], int row, int col);

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

	char gameGrid[maxsucc][maxsucc];
	char playerColor;

	getline(fin, temp);
	playerColor = temp.at(0);
	//cout << temp << endl;

	//Read gameGrid and player color from input file
	for (int i = 0; i < maxsucc; i++) {

		for (int j = 0; j < maxsucc; j++) {
			int n;
			n = ((i)*maxsucc) + (j + 1);
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

	//cout << "The node list:\n";
	int value = alphabeta(1, 0, 3, 0, VS, VL, playerColor, opponentColor, gameGrid);
	//cout << "\n\nThe value for the node 1 is " << value << endl;
	//cout << "The best succesor is " << best << endl;
	//cout << nodecount << " nodes visited\n\n\n" << endl;
	//cin.get();
	return 0;
}

// add 2 vars to minimax search --> alpha-beta search
int alphabeta(stateType state, stateType h, int maxDepth, int curDepth, int alpha, int beta, char playerColor, char opponentColor, char boardState[][maxsucc])
{
	nodecount++;
	//cout << "entetring " << state << endl; //need to add code for state back and add h as a parameter
	if (curDepth == maxDepth || isterminal(playerColor, boardState)) // CUTOFF test
	{
		int UtilV = eval(h);
		//cout << state << " [" << UtilV << "]\n";
		return UtilV;  // eval returns the heuristic value of state
	}
	stateType successor[maxsucc];
	stateType heuristic[maxsucc];
	node nextStates[maxsucc]; //need boardState array for next move


	int succnum, turn;
	succnum = potentialMoves(boardState);

	if (curDepth % 2 == 0) {
		// This is a MAX node 
		// since MAX has depth of: 0, 2, 4, 6, ...
		turn = maxturn;
		expand(state, successor, heuristic, nextStates, succnum, turn, playerColor, boardState); // find all successors of state for self
	}
	else {
		turn = minturn;
		expand(state, successor, heuristic, nextStates, succnum, turn, opponentColor, boardState); // find all successors of state for opponent
	}

	//Print boardState at current node
	/*
	for (int i = 0; i < maxsucc; i++) {
	for (int j = 0; j < maxsucc; j++) {
	cout << boardState[i][j] << " ";
	}
	cout << endl;
	}*/

	if (turn == maxturn) // This is a MAX node 
						 // since MAX has depth of: 0, 2, 4, 6, ...
	{
		alpha = VS; // initialize to some very small value 
		for (int k = 0; k<succnum; k++)
		{
			// recursively find the value of each successor
			int curvalue = alphabeta(successor[k], heuristic[k], maxDepth, curDepth + 1, alpha, beta, playerColor, opponentColor, nextStates[k].boardState);
			alpha = max(alpha, curvalue); // update alpha
			if (curvalue>alpha || curvalue == alpha)//&& time(0)%2==0)
			{
				alpha = curvalue;
				if (curDepth == 0) {
					best = successor[k];
					//cout << "Best is now: " << best << endl;
					//Print to output file
					ofstream fout;
					string file = "result.txt";
					fout.open(file, ios::trunc);
					string temp;
					for (int i = 0; i < maxsucc; i++) {
						for (int j = 0; j < maxsucc; j++) {
							//cout << nextStates[k].boardState[i][j] << " ";
							temp += nextStates[k].boardState[i][j];
						}
						fout << temp;
						temp = "";
						//cout << endl;
					}
					fout.close();
				}
			}
			if (alpha >= beta) return alpha; // best = successor[k];
		}
		//cout << state << " [" << alpha << "]\n";
		return alpha;
	}
	else // A MIN node
	{
		beta = VL;  // initialize to some very large value
		for (int k = 0; k<succnum; k++)
		{
			// recursively find the value of each successor
			int curvalue = alphabeta(successor[k], heuristic[k], maxDepth, curDepth + 1, alpha, beta, playerColor, opponentColor, nextStates[k].boardState);
			beta = min(beta, curvalue); // update beta
			if (alpha >= beta) return beta;
		}
		//cout << state << " [" << beta << "]\n";
		return beta;
	}
}

bool isterminal(char playerColor, char boardState[][maxsucc])
{
	bool terminate = false;
	int full = 0;
	//check if the board is full
	for (int i = 0; i < maxsucc; i++) {
		if (boardState[0][i] != blank)
			full++;
	}

	if (full == maxsucc)
		terminate = true;

	//Check for connect 5
	for (int i = 0; i < maxsucc - 4; i++) {
		for (int j = 0; j < maxsucc; j++) {
			//Look for vertical solutions
			if (boardState[i][j] == boardState[i + 1][j] == boardState[i + 2][j] == boardState[i + 3][j] == boardState[i + 4][j]) {
				terminate = true;
				j = maxsucc;
				i = maxsucc;
			}

			//Look for horizontal solutions
			if (boardState[j][i] == boardState[j][i + 1] == boardState[j][i + 2] == boardState[j][i + 3] == boardState[j][i + 4]) {
				terminate = true;
				j = maxsucc;
				i = maxsucc;
			}

			//look for diagonol solutions
			/*
			000br	rb000
			00brw	wrb00
			0brw0	0wrb0
			brw00	00wrb
			rw00r	000wr
			*/
			if (j < maxsucc / 2) {
				if (j + 4 < maxsucc && i + 4 < maxsucc) {
					if (boardState[i][j] == boardState[i + 1][j + 1] == boardState[i + 2][j + 2] == boardState[i + 3][j + 3] == boardState[i + 4][j + 4]) {
						terminate = true;
						j = maxsucc;
						i = maxsucc;
					}
				}
			}
			if (j > maxsucc / 2) {
				if (j - 4 > -1 && i - 4 > -1) {
					if (boardState[i - 4][j - 4] == boardState[i - 3][j - 3] == boardState[i - 2][j - 2] == boardState[i - 1][j - 1] == boardState[i][j]) {
						terminate = true;
						j = maxsucc;
						i = maxsucc;
					}
				}
			}
		}
	}

	return terminate;
}

void swap(int &a, int &b)
{
	int tmp = a;
	a = b;
	b = tmp;
}

int potentialMoves(char boardState[][maxsucc])
{
	int moves = 0;

	for (int i = 0; i < maxsucc; i++) {
		int row = 0;
		while (row < maxsucc) {
			if (boardState[row][i] == blank) {
				moves++;
				row = maxsucc;
			}

			row++;
		}
	}

	return moves;
}

void expand(stateType state, stateType successor[], stateType hValues[], node nextState[], int &sn, int turn, char color, char boardState[][maxsucc])
{
	int h = 0;
	int succIndex = 0;
	for (int i = 0; i < maxsucc; i++) {
		int row = maxsucc - 1;

		if (succIndex < sn) {
			//get heuristic for each column of the game board
			while (row > -1) {
				if (boardState[row][i] == blank) {
					h += checkHorizontal(color, boardState, row, i);
					h += checkDiagonal(color, boardState, row, i);
					h += checkVertical(color, boardState, row, i);

					hValues[succIndex] = h;
					successor[succIndex] = maxsucc * state - 1 + succIndex;

					node state;
					//cout << "Temp matrix" << endl; //Print potential next move
					for (int m = 0; m < maxsucc; m++) {
						for (int n = 0; n < maxsucc; n++) {
							//cout << temp[m][n] << " ";
							state.boardState[m][n] = boardState[m][n];
							if (m == row && n == i)
								state.boardState[m][n] = color;
						}
						//cout << endl;
					}

					state.color = color;
					nextState[succIndex] = state;

					succIndex++;
					h = 0;
					row = -1; //break while loop for column i
				}

				row--;
			}
		}
	}

	//question everything...
	if (turn == maxturn) {

		for (int i = 0; i < sn; i++) {
			for (int j = i; j < sn; j++) {
				if (successor[i] >= successor[j]) {
					swap(successor[i], successor[j]);
					swap(hValues[i], hValues[j]);
					swap(nextState[i], nextState[j]);
				}
			}
		}
		//largest heuristic value
		swap(successor[0], successor[sn - 1]);
		swap(hValues[0], hValues[sn - 1]);
		swap(nextState[0], nextState[sn - 1]);
	}


}

int max(int a, int b)
{
	return a>b ? a : b;
}

int min(int a, int b)
{
	return a>b ? b : a;
}

int eval(stateType s)
{
	return s;
}

int checkHorizontal(char color, char boardState[][maxsucc], int row, int col) {
	//check for same colored game pieces to the left and right of the blank
	int h = 0;
	int i = col + 1;
	while (i < maxsucc && boardState[row][i] == color) {
		h++;
		i++;
	}

	i = col - 1;
	while (i > -1 && boardState[row][i] == color) {
		h++;
		i--;
	}

	return h;
}

int checkVertical(char color, char boardState[][maxsucc], int row, int col) {
	//check for same colored game pieces below the blank
	int h = 0;
	int i = row + 1;
	while (i < maxsucc && boardState[i][col] == color) {
		h++;
		i++;
	}

	return h;
}

int checkDiagonal(char color, char boardState[][maxsucc], int row, int col) {
	//check for same colored game pieces diagonal of the blank

	int h = 0;
	//Down-right diagonal
	int i = row + 1;
	int j = col + 1;

	while (i < maxsucc && j < maxsucc && boardState[i][j] == color) {
		h++;
		i++;
		j++;
	}

	//Up-right diagonal
	i = row - 1;
	j = col + 1;

	while (i > -1 && j < maxsucc && boardState[i][j] == color) {
		h++;
		i--;
		j++;
	}

	//Down-left diagonal
	i = row + 1;
	j = col - 1;

	while (i < maxsucc && j > -1 && boardState[i][j] == color) {
		h++;
		i++;
		j--;
	}

	//Up-left diagonal
	i = row - 1;
	j = col - 1;

	while (i > -1 && j > -1 && boardState[i][j] == color) {
		h++;
		i--;
		j--;
	}

	return h;
}
