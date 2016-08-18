#include "stdafx.h"
#include "Shortcut.h"
#include "Parser.h"
#include "Tokenizer.h"

using namespace Core::Parser;
using namespace Core;

using namespace System::Windows::Forms;
using namespace System::Diagnostics;

Core::Shortcut::Shortcut()
{
	shortcut = new Core::cpp::Shortcutcpp();
}

Core::Shortcut::Shortcut(Core::cpp::Shortcutcpp* shortcutcpp)
{
	shortcut = shortcutcpp;
}

Core::Shortcut::~Shortcut()
{
}

void Core::Shortcut::Send()
{
	Parser::Parser^ parser = gcnew Parser::Parser();
	Tokenizer^ tokenizer = gcnew Tokenizer();

	auto tokens = tokenizer->Tokenize(Message);
	auto toSend = parser->Parse(tokens);

	for (int i = 0; i < toSend->Length; i++)
	{
		Debug::WriteLine(Message);
		if (toSend[i]->Message != String::Empty)
		{
			toSend[i]->Send(Interval);

			if (i != toSend->Length - 1 && !toSend[i]->IsSpecialValue) SendKeys::Send(" ");
		}
	}
}

Core::cpp::Shortcutcpp* Core::Shortcut::GetShortcutcpp()
{
	return this->shortcut;
}
