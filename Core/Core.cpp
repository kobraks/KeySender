// This is the main DLL file.

#include "stdafx.h"

#include "Core.h"
#include "Converter.h"

using namespace Core;

Shortcuts::Shortcuts()
{
	shortcuts = gcnew List<Shortcut^>();
}

Shortcuts::~Shortcuts()
{
	for each(auto element in shortcuts)
	{
		delete element;
	}

	shortcuts->Clear();
}

Shortcut^ Shortcuts::Get(String^ name)
{
	for each(auto element in shortcuts)
	{
		if (element->Name == name) return element;
	}

	return nullptr;
}

Shortcut^ Shortcuts::Get(int number)
{
	if (number < 0 || number > shortcuts->Count) return nullptr;
	else return shortcuts[number];
}

bool Shortcuts::Load(String^ path)
{
	return false;
}

bool Shortcuts::Save(String^ path)
{
	return false;
}

void Shortcuts::Add(Shortcut^ shortcut)
{
	shortcuts->Add(shortcut);
}

void Shortcuts::Remove(int index)
{
	if (shortcuts->Count == 0) return;

	if (index >= 0 && index < shortcuts->Count)
	{
		delete shortcuts[index];
		shortcuts->RemoveAt(index);
	}
}

void Shortcuts::Change(int index, Shortcut^ shortcut)
{
	if (shortcuts->Count == 0) return;

	if (index >= 0 && index < shortcuts->Count)
	{
		delete shortcuts[index];
		shortcuts[index] = shortcut;
	}
}
