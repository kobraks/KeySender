#include "stdafx.h"
#include "Parser.h"

using namespace Core::Parser;

using namespace System::Collections::Generic;

Parser::Parser()
{
}

array<Core::Text::Text^>^ Parser::Parse(array<Token^>^ tokens)
{
	List<Core::Text::Text^>^ message = gcnew List<Core::Text::Text^>();
	bool command = false;

	for each (auto t in tokens)
	{
		if (t->Key == ' ' && !command)
		{
			message->Add(gcnew Core::Text::Text(t->Value));
		}
		else if (t->Key == '{' && !command)
		{
			command = true;
		}
		else if (t->Key == '}' && command)
		{
			command = false;
		}
		else if (command && t->Key == ' ')
		{
			message->Add(gcnew Core::Text::Text(Decode(t->Value), true));
		}
	}

	return message->ToArray();
}

String^ Parser::Decode(String^ code)
{
	if (String::Equals(code, "Enter", StringComparison::CurrentCultureIgnoreCase))
	{
		return "{ENTER}";
	}

	return "";
}
