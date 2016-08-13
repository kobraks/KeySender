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
	_name = "new";
	_message = "write your message";
	_shortcutKey = "";
	_interval = 100;
	_ctr = false;
	_alt = false;
	_shift = false;
	_isReady = false;
}

Core::Shortcut::~Shortcut()
{
	delete _name;
	delete _message;
	delete _shortcutKey;
}

void Core::Shortcut::Send()
{
	Parser::Parser^ parser = gcnew Parser::Parser();
	Tokenizer^ tokenizer = gcnew Tokenizer();

	auto tokens = tokenizer->Tokenize(_message);
	auto toSend = parser->Parse(tokens);

	for (int i = 0; i < toSend->Length; i++)
	{
		Debug::WriteLine(_message);
		if (toSend[i] != String::Empty)
		{
			SendKeys::Send(toSend[i]);
			Debug::WriteLine(toSend[i]);

			if (i != toSend->Length && toSend[i] != "{ENTER}") SendKeys::Send(" ");
		}
	}
}
