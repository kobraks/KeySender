#include "stdafx.h"
#include "Tokenizer.h"

using namespace Core::Parser;
using namespace System::Collections::Generic;

Tokenizer::Tokenizer()
{
}

array<Token^>^ Tokenizer::Tokenize(String^ message)
{
	auto split = Split(message);

	List<Token^>^ tokens = gcnew List<Token^>();

	for each(auto element in split)
	{
		if (element == "{!")
			tokens->Add(gcnew Token("", '{'));
		else if (element == "!}")
			tokens->Add(gcnew Token("", '}'));
		else
			tokens->Add(gcnew Token(element));
	}

	return tokens->ToArray();
}

array<String^>^ Tokenizer::Split(String^ s)
{
	s = s->Replace("{!", " {! ");
	s = s->Replace("!}", " !} ");
	s = s->Trim();

	while (s->Contains("  "))
		s = s->Replace("  ", " ");

	return s->Split();
}
