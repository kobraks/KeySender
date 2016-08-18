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
	return gcnew Shortcut(shortcut->Get(Core::Converter::ConvertManagmentStoS(name)));
}

Shortcut^ Shortcuts::Get(int number)
{
	return gcnew Shortcut(shortcut->Get(number));
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

void Shortcuts::Change(int index, Shortcut^ shortcut)
{
	this->shortcut->Change(index, shortcut->GetShortcutcpp());
}

void Shortcuts::Clear()
{
	this->shortcut->Clear();
}
