#include "stdafx.h"
#include "Parser.h"

using namespace Core::Parser;

using namespace System::Collections::Generic;

Parser::Parser()
{
}

array<String^>^ Parser::Parse(array<Token^>^ tokens)
{
	List<String^>^ message = gcnew List<String^>();
	bool command = false;

	for each (auto t in tokens)
	{
		if (t->Key == ' ' && !command)
		{
			message->Add(t->Value);
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
			message->Add(Decode(t->Value));
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
