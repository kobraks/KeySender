// This is the main DLL file.

#include "stdafx.h"

#include "Core.h"
#include "Converter.h"

using namespace Core;

Shortcuts::Shortcuts()
{
	shortcut = new Core::cpp::Shortcutscpp();
}

Shortcuts::~Shortcuts()
{
	delete shortcut;
}

Shortcut^ Shortcuts::Get(String^ name)
{
	auto var = shortcut->Get(Core::Converter::ConvertManagmentStoS(name));

	if (var == nullptr)
		return nullptr;
	else
		return gcnew Shortcut(var);
}

Shortcut^ Shortcuts::Get(int number)
{
	if (number < Count && number >= 0)
		return gcnew Shortcut(shortcut->Get(number));
	else return nullptr;
}

bool Shortcuts::Load(String^ path)
{
	return shortcut->Load(Core::Converter::ConvertManagmentStoS(path));
}

bool Shortcuts::Save(String^ path)
{
	return shortcut->Save(Core::Converter::ConvertManagmentStoS(path));
}

void Shortcuts::Add(Shortcut^ shortcut)
{
	this->shortcut->Add(shortcut->GetShortcutcpp());
}

void Shortcuts::Remove(int index)
{
	shortcut->Remove(index);
}

void Shortcuts::Remove(String^ name)
{
	shortcut->Remove(Converter::ConvertManagmentStoS(name));
}

void Shortcuts::Change(int index, Shortcut^ shortcut)
{
	this->shortcut->Change(index, shortcut->GetShortcutcpp());
}

void Shortcuts::Clear()
{
	this->shortcut->Clear();
}
