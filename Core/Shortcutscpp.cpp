#include "stdafx.h"
#include "Shortcutscpp.h"

#include <fstream>

using namespace Core::cpp;
using namespace std;

Shortcutscpp::Shortcutscpp()
{
}


Shortcutscpp::~Shortcutscpp()
{
	Clear();
}

void Shortcutscpp::Clear()
{
	for (auto element : shortcuts)
	{
		delete element;
	}

	shortcuts.clear();
}

Shortcutcpp* Shortcutscpp::Get(string name)
{
	for (auto element : this->shortcuts)
	{
		if (element->GetName() == name)
		{
			return element;
		}
	}

	return nullptr;
}

Shortcutcpp* Shortcutscpp::Get(int index)
{
	if (index < 0 && index > shortcuts.size()) return nullptr;
	else return shortcuts[index];
}

void Shortcutscpp::Add(Shortcutcpp* value)
{
	this->shortcuts.push_back(new Shortcutcpp(*value));
}

void Shortcutscpp::Remove(int index)
{
	if (index < 0 && index > shortcuts.size()) return;

	delete this->shortcuts[index];
	this->shortcuts.erase(shortcuts.begin() + index);
}

void Shortcutscpp::Change(int index, Shortcutcpp* value)
{
	if (index < 0 && index > shortcuts.size()) return;
	else
	{
	}
}

int Shortcutscpp::Size()
{
	return shortcuts.size();
}

bool Shortcutscpp::Load(string path)
{
	fstream file(path, ios::in | ios::binary);

	if (!file.good()) return false;

	file >> *this;

	file.close();
	return true;
}

bool Shortcutscpp::Save(string path)
{
	fstream file(path, ios::out | ios::binary | ios::trunc);


	file << *this;

	file.close();
	return true;
}
